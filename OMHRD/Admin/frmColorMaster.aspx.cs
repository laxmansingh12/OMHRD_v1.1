using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.AdminPanel
{
    public partial class frmColorMaster : System.Web.UI.Page
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
            gdvNotice.DataSource = ColorDataMasterCollection.GetAll();
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
                ColorDataMaster cm = new ColorDataMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.Color_ID = ColorDataMaster.MaxID() + 1;
                    cm.Color_NAME = txtcolor.Text;
                    cm.Color_Code = txtcolorCode.Text;
                    cm.REMARK = txtremark.Text;
                    cm.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = ColorDataMaster.GetByColor_ID(int.Parse(ViewState["id"].ToString()));
                    cm.Color_ID = int.Parse(ViewState["id"].ToString());
                    cm.Color_NAME = txtcolor.Text;
                    cm.Color_Code = txtcolorCode.Text;
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

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            ColorDataMaster dm = ColorDataMaster.GetByColor_ID(int.Parse(nid));
            txtcolor.Text = dm.Color_NAME;
            txtcolorCode.Text = dm.Color_Code;
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
                ColorDataMaster dm = new ColorDataMaster();
                dm.Color_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmColorMaster.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();

        }
    }
}