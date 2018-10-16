using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class PickUpApproveList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { grid(); }
        }
        public void grid()
        {
            gdvNotice.DataSource = PickupMasterrCollection.GetAll().FindAll(x => x.Status == "Approve");
            gdvNotice.DataBind();
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            List<PickupMaster> _rg = PickupMasterrCollection.GetAll().FindAll(x => x.UserName == username);
            if (_rg.Count > 0)
            {
                gdvNotice.DataSource = _rg;
                gdvNotice.DataBind();
                txtUserName.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Not Record Found....');</Script>", false);
                txtUserName.Text = "";
                grid();
            }
        }

        protected void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string contact = txtPhone.Text.Trim();
            List<PickupMaster> _rg = PickupMasterrCollection.GetAll().FindAll(x => x.ContactNo == contact);
            if (_rg.Count > 0)
            {
                gdvNotice.DataSource = _rg;
                gdvNotice.DataBind();
                txtPhone.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Not Record Found....');</Script>", false);
                txtPhone.Text = "";
                grid();
            }
        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();
        }

        protected void linkbtnActive_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gdvNotice.Rows.Count; i++)
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                PickupMaster dm = new PickupMaster();
                dm.PickupID = int.Parse(did);
                GridViewRow gRow = gdvNotice.Rows[i];
                DropDownList txtbox1 = (DropDownList)gRow.FindControl("ddlactive");
                string Action = txtbox1.SelectedValue.Trim();
                if (dm.PickupID > 0)
                {
                    dm.Update_Action(dm.PickupID, Action);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Action Changed....');</Script>", false);
                    Response.Redirect("PickUpApproveList.aspx");
                }
            }
        }
    }
}
