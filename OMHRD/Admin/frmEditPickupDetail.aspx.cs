using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class frmEditPickupDetail : System.Web.UI.Page
    {
        static string CenterCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["st"].ToString() == null || Request.QueryString["st"].ToString() == "")
                {
                    Response.Redirect("frmEditPickupDetail.aspx");
                }
                else
                {
                    Member_detail(int.Parse(Request.QueryString["st"].ToString()));
                }

            }
        }
        public void Member_detail(int MID)
        {
            try
            {
                PickupMaster drms = PickupMaster.GetByPickupID(MID);
                if (drms.PickupID > 0)
                {
                    #region
                    ViewState["StateCode"] = drms.State;
                    ViewState["MID"] = MID;
                    lblFname.Text = PickupMaster.GetByPickupID(drms.PickupID).FirstName;
                    lblLName.Text = PickupMaster.GetByPickupID(drms.PickupID).LastName;
                    txtuser.Text = drms.UserName;
                    txtPassword.Text = drms.Password;
                    #region CenterCode
                    string Statecode = StateMaster.GetBySTATE_ID(int.Parse(ViewState["StateCode"].ToString())).STATECODE;
                    string Date = System.DateTime.Today.ToString("yyMMdd");
                    CenterCode = Statecode + Date + "00" + ViewState["MID"];
                    #endregion
                    lblCname.Text = "OMHRD" + CenterCode;
                    lblCCode.Text = CenterCode;
                    lblAdd.Text = drms.Address;
                    lblId.Text = drms.GstinNo;
                    lblContact.Text = PickupMaster.GetByPickupID(drms.PickupID).ContactNo;
                    lblRegdate.Text = PickupMaster.GetByPickupID(drms.PickupID).Regdate.ToString("dd-MM-yyyy");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<PickupMaster> _pic = PickupMasterrCollection.GetAll().FindAll(x => x.UserName == txtuser.Text.Trim());
            if (_pic.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('User Name Not Available...!!');</script>", false);
                txtuser.Focus();
                return;
            }
            PickupMaster rm = new PickupMaster();
            rm.PickupID = int.Parse(ViewState["MID"].ToString());
            rm.FirstName = lblFname.Text.Trim();
            rm.LastName = lblLName.Text.Trim();
            rm.UserName = txtuser.Text.Trim();
            rm.Password = txtPassword.Text;
            rm.CenterName = lblCname.Text.Trim();
            rm.CenterCode = lblCCode.Text.Trim();
            rm.Address = PickupMaster.GetByPickupID(rm.PickupID).Address;
            rm.Pincode = PickupMaster.GetByPickupID(rm.PickupID).Pincode;
            rm.City = PickupMaster.GetByPickupID(rm.PickupID).City;
            rm.State = PickupMaster.GetByPickupID(rm.PickupID).State;
            rm.ContactNo = lblContact.Text;
            rm.Alternate1 = PickupMaster.GetByPickupID(rm.PickupID).Alternate1;
            rm.Alternate2 = PickupMaster.GetByPickupID(rm.PickupID).Alternate2;
            rm.GstinNo = PickupMaster.GetByPickupID(rm.PickupID).GstinNo;
            rm.Regdate = PickupMaster.GetByPickupID(rm.PickupID).Regdate;
            rm.Status = "Approve";
            rm.Action = "Active";
            rm.PickUpWallet = 0;
            rm.Save();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Change Sucessfull...!!');</script>", false);
            Sendmsg("Your OMHRD PickUp User Name is " + " " + rm.UserName + " " + "And  Password is" + rm.Password, rm.ContactNo.Trim());
            Response.Redirect("PickUpWaitingList.aspx");
        }
    }
}