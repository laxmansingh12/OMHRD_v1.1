using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { grid(); }
        }
        public void grid()
        {
            gdvNotice.DataSource = USERPROFILEMASTERCollection.GetAll();
            gdvNotice.DataBind();
        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            grid();
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            List<USERPROFILEMASTER> _rg = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.User_Name == username);
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
            List<USERPROFILEMASTER> _rg = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.ContactNumber == contact);
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
    }
}