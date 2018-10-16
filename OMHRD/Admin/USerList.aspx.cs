using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OMHRD.AdminPanel
{
    public partial class USerList : System.Web.UI.Page
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
        protected void linkbtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                int FileId = int.Parse(((Label)gv.FindControl("labelNOTICE_ID")).Text);
                USERPROFILEMASTER rg = USERPROFILEMASTER.GetByRegistration_ID(FileId);
                if (rg.Registration_ID > 0)
                {
                    Response.Redirect("EditSignUpDetail.aspx?st=" + rg.Registration_ID);
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
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
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string Email = txtEmail.Text.Trim();
            List<USERPROFILEMASTER> _rg = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.Email == Email);
            if (_rg.Count > 0)
            {
                gdvNotice.DataSource = _rg;
                gdvNotice.DataBind();
                txtEmail.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Not Record Found....');</Script>", false);
                txtEmail.Text = "";
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            grid();
        }
    }
}