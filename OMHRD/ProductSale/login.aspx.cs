using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.ProductSale
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void ClearControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = "";
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is DropDownList)
                    ((DropDownList)c).SelectedIndex = 0;
                else if (c is Image)
                    ((Image)c).ImageUrl = null;
                ClearControls(c);
            }
        }
        protected void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.User_Name == txtluser.Text.Trim() && x.Password == txtLpassword.Text.Trim());
                if (um.Registration_ID > 0 && um.Status == "Active")
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = um.Registration_ID;
                    Response.Redirect("UserPanel/frmMyProfile.aspx");
                    ClearControls(this);
                }
                else
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = um.Registration_ID;
                    Response.Redirect("~/AdminPanel/AdminProfileShow.aspx");
                    ClearControls(this);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Invalid Login Password!!!!');</Script>", false);
                ClearControls(this);
                txtluser.Focus();
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }
    }
}