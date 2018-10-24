using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        public static int loginid; public static string Password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) fillstate(); fillcity();
            { }
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

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            SendMail();
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
        protected void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.User_Name == txtluser.Text.Trim() && x.Password == txtLpassword.Text.Trim());
                if (um.Registration_ID > 0 && um.Status == "Active")
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = loginid = um.Registration_ID;
                    Response.Redirect("User/frmMyProfile.aspx");
                    ClearControls(this);
                }
                else
                {
                    Session["UserName"] = this.txtluser.Text.Trim();
                    Session["loginid"] = loginid = um.Registration_ID;
                    Response.Redirect("Admin/AdminProfileShow.aspx");
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

        protected void btnPicklog_Click(object sender, EventArgs e)
        {
            try
            {
                PickupMaster um = PickupMasterrCollection.GetAll().Find(x => x.UserName == txtPickuser.Text.Trim() && x.Password == txtPickPassword.Text.Trim());
                if (um.PickupID > 0 && um.Action == "Active")
                {
                    Session["Pickuser"] = this.txtPickuser.Text.Trim();
                    Session["PickupID"] = um.PickupID;
                    Response.Redirect("PickUp/SaleProduct.aspx");
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

        public void fillstate()
        {
            try
            {
                List<StateMaster> _state = StateMasterCollection.GetAll();
                StateMaster sm = new StateMaster();
                sm.STATE_ID = 0;
                sm.STATE_NAME = "-select state-";
                _state.Insert(0, sm);
                ddlState.DataSource = _state;
                ddlState.DataTextField = "STATE_NAME";
                ddlState.DataValueField = "STATE_ID";
                ddlState.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillcity()
        {
            List<CityMaster> _city = CityMasterCollection.GetAll();//.Where(x => x.STATE_ID == int.Parse(ddlState.SelectedValue.ToString())).OrderBy(x => x.CITY_NAME).ToList();
            CityMaster cm = new CityMaster();
            cm.CITY_ID = 0;
            cm.CITY_NAME = "-Select City-";
            _city.Insert(0, cm);
            ddlcity.DataSource = _city;
            ddlcity.DataTextField = "CITY_NAME";
            ddlcity.DataValueField = ("CITY_ID");
            ddlcity.DataBind();

        }
    }
}