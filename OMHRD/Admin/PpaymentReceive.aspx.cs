using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
namespace OMHRD.AdminPanel
{
    public partial class PpaymentReceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid(); fillUser();
            }
        }

        public void grid()
        {
            gdvNotice.DataSource = PaymentMasterCollection.GetAll();
            gdvNotice.DataBind();

        }
        public void fillUser()
        {
            try
            {
                List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetAll().FindAll(X => X.Status == "Active");
                USERPROFILEMASTER sm = new USERPROFILEMASTER();
                sm.Registration_ID = 0;
                sm.User_Name = "-select Users-";
                _state.Insert(0, sm);
                ddlUserName.DataSource = _state;
                ddlUserName.DataTextField = "User_Name";
                ddlUserName.DataValueField = "Registration_ID";
                ddlUserName.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
                btnPayment.Text = "Submit";
            }
        }
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentMaster um = new PaymentMaster();
                if (btnPayment.Text == "Submit")
                {
                    um.Paymemt_ID = PaymentMaster.GetMaxID() + 1;
                    um.User_Name = ddlUserName.SelectedItem.Text;
                    um.User_ID = USERPROFILEMASTER.GetByUser_Name(um.User_Name).User_Name;// lblUSerId.Text.Trim();
                    um.Amount = decimal.Parse(txtamount.Text);
                    um.Remark = txtremark.Text.Trim();
                    um.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnPayment.Text == "Update")
                {
                    um = PaymentMaster.GetByPaymemt_ID(int.Parse(ViewState["id"].ToString()));
                    um.Paymemt_ID = int.Parse(ViewState["id"].ToString());
                    um.User_Name = ddlUserName.SelectedItem.Text;
                    um.User_ID = USERPROFILEMASTER.GetByUser_Name(um.User_Name).User_Name;// lblUSerId.Text.Trim();
                    um.Amount = decimal.Parse(txtamount.Text);
                    um.Remark = txtremark.Text.Trim();
                    um.Save();
                    btnPayment.Text = "Submit";
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully..');</Script>", false);
                }
                ClearInputs(Page.Controls);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            PaymentMaster dm = PaymentMaster.GetByPaymemt_ID(int.Parse(nid));
            ddlUserName.SelectedItem.Text = dm.User_Name;
            txtamount.Text = dm.Amount.ToString();
            txtremark.Text = dm.Remark;
            btnPayment.Text = "Update";
        }


        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                PaymentMaster dm = new PaymentMaster();
                dm.Paymemt_ID = int.Parse(did);
                dm.GetByDelete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("PpaymentReceive.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }

        }
    }
}