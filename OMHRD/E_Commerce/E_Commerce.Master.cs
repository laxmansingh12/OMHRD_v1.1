using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.E_Commerce
{
    public partial class E_Commerce : System.Web.UI.MasterPage
    {
        public static string Password;
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
                    Response.Redirect("../User/frmMyProfile.aspx");
                    ClearControls(this);
                }
                else
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = um.Registration_ID;
                    Response.Redirect("../Admin/AdminProfileShow.aspx");
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

        protected void linksignup_Click(object sender, EventArgs e)
        {
            try
            {
                List<USERPROFILEMASTER> um = USERPROFILEMASTERCollection.GetByUser_Name(txtReferenceId.Text);
                if (um.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Reference Name Not Valid.');</Script>", false);
                    //Response.Redirect("");
                    return;
                }
                USERPROFILEMASTER rm = new USERPROFILEMASTER();
                if (linksignup.Text == "Submit")
                {
                    rm.Registration_ID = USERPROFILEMASTER.MaxId() + 1;
                    rm.First_Name = txtFirstname.Text.Trim();
                    rm.Last_Name = txtLastName.Text.Trim();
                    rm.Email = txtemail.Text.Trim();
                    rm.User_Name = txtuserName.Text.Trim();
                    rm.User_ID = "OM000000" + rm.Registration_ID;
                    rm.Password = txtpassword.Text.Trim();
                    rm.DOB = DateTime.Today;
                    rm.ContactNumber = txtcontact.Text.Trim();
                    rm.NomineeName = "";
                    rm.NomineeId = "";
                    rm.NomineeRelation = "";
                    rm.Reference_Id = txtReferenceId.Text.Trim();
                    rm.RegDate = DateTime.Today.Date;
                    rm.COUNTRY = "India";
                    rm.Individual_Company = ""; rm.IdentificationType = ""; rm.TaxExempt = ""; rm.Commission = ""; rm.WFile = "";
                    rm.AnniversaryDate = DateTime.Today; rm.SmartDeliveryDate = DateTime.Today;
                    rm.Website = ""; rm.Address = ""; rm.AddressLine2 = ""; rm.City = 1; rm.State =1; rm.StateOther = "";
                    rm.ZipCode = ""; rm.ShippingFirstName = ""; rm.ShippingLastName = ""; rm.ShippingAddress = "";
                    rm.ShippingAddressLine2 = ""; rm.ShippingCity =1; rm.ShippingState =1; rm.ShippingZip = ""; rm.ShippingStateOther = "";
                    rm.AlternativeNumber = ""; rm.Fax = ""; rm.Co_Applicant = ""; rm.Language = ""; rm.Skype = ""; rm.Twitter = ""; rm.Facebook = ""; rm.AadharVerified = "";
                    rm.AadharImage = ""; rm.PanVerified = ""; rm.PanImage = ""; rm.ChequeVerified = ""; rm.ChequeImage = ""; rm.GstinVerified = "";
                    rm.AddressVerified = ""; rm.AddressImage = ""; rm.Image_Name = ""; rm.Status = "Active"; rm.BankName = ""; rm.AccountNo = "";
                    rm.IFSCCode = ""; rm.Branch = ""; rm.UserParentId = 0;
                    rm.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Sign Up Successfully...');</Script>", false);
                }
                ClearControls(this);
            }
            catch (Exception ex)
            {

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
        protected void btnForgotEmail_Click(object sender, EventArgs e)
        {
            SendMail();
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
        }

        protected void lnkForContact_Click(object sender, EventArgs e)
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
        }
    }
}