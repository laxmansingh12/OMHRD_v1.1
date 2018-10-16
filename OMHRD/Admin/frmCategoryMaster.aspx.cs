using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
namespace OMHRD.AdminPanel
{
    public partial class frmCategoryMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid();
            }
        }

        public void grid()
        {
            gdvNotice.DataSource = CategoryMasterCollection.GetAll();
            gdvNotice.DataBind();

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
                btnsubmit.Text = "Submit";
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryMaster cm = new CategoryMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.CATEGORY_ID = CategoryMaster.MaxID() + 1;
                    cm.CATEGORY_NAME = txtcategory.Text;
                    cm.REMARK = txtremark.Text;
                    cm.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = CategoryMaster.GetByCATEGORY_ID(int.Parse(ViewState["id"].ToString()));
                    cm.CATEGORY_ID = int.Parse(ViewState["id"].ToString());
                    cm.CATEGORY_NAME = txtcategory.Text;
                    cm.REMARK = txtremark.Text;
                    cm.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                ClearInputs(Page.Controls);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }

        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();

        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            CategoryMaster dm = CategoryMaster.GetByCATEGORY_ID(int.Parse(nid));
            txtcategory.Text = dm.CATEGORY_NAME;
            txtremark.Text = dm.REMARK;
            btnsubmit.Text = "Update";
        }



        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                CategoryMaster dm = new CategoryMaster();
                dm.CATEGORY_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmCategoryMaster.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}