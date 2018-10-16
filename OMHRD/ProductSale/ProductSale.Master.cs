using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.ProductSale
{
    public partial class ProductSale : System.Web.UI.MasterPage
    {
        public static string Password;
        List<SubCategoryMaster> _subCategorys = new List<SubCategoryMaster>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginid"] != null && !string.IsNullOrEmpty(Session["loginid"].ToString()))
                {
                    myAccount.Visible = true;
                }
                else
                {
                    myAccount.Visible = false;
                }
                loggedinUserId.Value = Session["loginid"] == null ? string.Empty : Session["loginid"].ToString();
                FIllAllProduct();
                lblProfileName.Text = " Hello," + USERPROFILEMASTER.GetByUser_Name(Session["UserName"] == null ? string.Empty : Session["UserName"].ToString()).User_Name;
            }
        }
        public void FIllAllProduct()
        {
            _subCategorys = SubCategoryMasterCollection.GetAll();
            List<CategoryMaster> fp = CategoryMasterCollection.GetAll();
            if (fp.Count > 0)
            {
                rpProduct.DataSource = fp;
                rpProduct.DataBind();
            }
        }
        protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpSubProduct = e.Item.FindControl("rpSubProduct") as Repeater;

            if (rpSubProduct != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    CategoryMaster cat = e.Item.DataItem as CategoryMaster;
                    if (cat != null)
                    {
                        var subCatList = _subCategorys.Where(x => x.Category_ID == cat.CATEGORY_ID).ToList();
                        if (subCatList == null || subCatList.Count == 0)
                        {
                            rpSubProduct.HeaderTemplate = null;
                            rpSubProduct.FooterTemplate = null;
                        }
                        else
                        {
                            rpSubProduct.DataSource = subCatList;
                            rpSubProduct.DataBind();
                        }
                    }
                }
            }
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
                if (um.Registration_ID > 0 && um.Status == "Admin")
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = um.Registration_ID;
                    if (string.IsNullOrWhiteSpace(hdnreturnUrl.Value))
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Redirect(hdnreturnUrl.Value);
                    }
                    ClearControls(this);
                }
                else
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = um.Registration_ID;
                    Response.Redirect("Default.aspx");
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
        public void SendMail()
        {
            USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.Email == txtForgotEmail.Text.Trim() && x.User_Name == txtForUserEmail.Text.Trim());
            if (um == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Invalid Email Id..!!!!');</Script>", false);
                txtForgotEmail.Text = "";
                return;
            }
            else
            {
                Password = um.Password;
            }
            MailMessage mail = new MailMessage();
            // SmtpClient SmtpServer = new SmtpClient("webmail.omhrd.com");
            mail.From = new MailAddress("omhrd84@gmail.com");
            mail.To.Add(txtForgotEmail.Text.Trim());
            mail.Subject = "Forgot password";
            mail.Body = "Your Password is " + " " + Password;
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("omhrd84@gmail.com", "Ashok@123");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Kindly check your mailbox to get Omhrd Password ');</Script>", false);
            ClearControls(this);
        }
        public string Sendmsg(string msg, string mobno)
        {
            string UserName = "socialhub";
            string Password = "well03come";
            string senderid = "OMHRDA";
            string http = "https://www.auruminfo.com/Rest/AIwebservice/Bulk?";
            string parameters = "user=" + UserName + "&password=" + Password + "&mobilenumber=" + mobno + "&message=" + msg + "&sid=" + senderid + "&mtype=n";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http + parameters);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(response.GetResponseStream());
            respStreamReader.Close();
            return respStreamReader.ToString();
        }

        protected void btnforContact_Click(object sender, EventArgs e)
        {
            USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.ContactNumber == txtForgotContact.Text.Trim() && x.User_Name == txtForUserContact.Text.Trim());
            if (um == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Invalid Details !!!!');</Script>", false);
                txtForgotEmail.Text = "";
                return;
            }
            else
            {
                Password = um.Password;
                Sendmsg("Your Password is " + " " + Password, txtForgotContact.Text.Trim());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Password has been sent to your registered mobile number..!!');</Script>", false);
            }
            ClearControls(this);
        }
        protected void btnForgot_Click1(object sender, EventArgs e)
        {
            SendMail();
        }


        protected void lnkHistory_Click(object sender, EventArgs e)
        {
            if (Session["loginid"] != null && !string.IsNullOrEmpty(Session["loginid"].ToString()))
            {
                USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
                if (um.Registration_ID > 0 && um.Status == "Admin")
                {
                    Response.Redirect("../Admin/ShoppingHistory.aspx");
                }
                else
                { Response.Redirect("../User/ShoppingHistory.aspx"); }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('User not login');</Script>", false);
                return;
            }
        }
        protected void lnkMyAccount_Click(object sender, EventArgs e)
        {
            if (Session["loginid"] != null && !string.IsNullOrEmpty(Session["loginid"].ToString()))
            {
                USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
                if (um.Registration_ID > 0 && um.Status == "Admin")
                {
                    Response.Redirect("../Admin/AdminProfileShow.aspx");
                }
                else
                { Response.Redirect("../User/frmMyProfile.aspx"); }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('User not login');</Script>", false);
                return;
            }
        }
        protected void linklogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx");

        }



    }
}