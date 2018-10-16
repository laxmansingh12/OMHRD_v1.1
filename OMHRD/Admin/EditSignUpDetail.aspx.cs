using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class EditSignUpDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["st"].ToString() == null || Request.QueryString["st"].ToString() == "")
                {
                    Response.Redirect("USerList.aspx");
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
                USERPROFILEMASTER drms = USERPROFILEMASTER.GetByRegistration_ID(MID);
                if (drms.Registration_ID > 0)
                {
                    #region
                    ViewState["MID"] = MID;
                    txtuseraname.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).User_Name;
                    txtFirstname.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).First_Name;
                    txtLastName.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).Last_Name;
                    txtemail.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).Email;
                    txtcontact.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).ContactNumber;
                    txtReferenceId.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(MID.ToString())).Reference_Id;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (btnSignUp.Text == "Submit Changes")
            {
                USERPROFILEMASTER um = new USERPROFILEMASTER();
                um.Registration_ID = int.Parse(ViewState["MID"].ToString());
                um.First_Name = txtFirstname.Text.Trim();
                um.Last_Name = txtLastName.Text.Trim();
                um.User_Name = txtuseraname.Text.Trim();
                um.Email = txtemail.Text.Trim();
                um.ContactNumber = txtcontact.Text;
                um.Reference_Id = txtReferenceId.Text.Trim();
                um.User_ID = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).User_ID;
                um.Password = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Password;
                um.DOB = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).DOB;
                um.AlternativeNumber = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AlternativeNumber;
                um.NomineeName = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).NomineeName;
                um.NomineeId = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).NomineeId;
                um.NomineeRelation = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).NomineeRelation;
                um.RegDate = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).RegDate;
                um.COUNTRY = "India";
                um.Individual_Company = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Individual_Company;
                um.IdentificationType = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).IdentificationType;
                um.TaxExempt = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).TaxExempt;
                um.Commission = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Commission;
                um.WFile = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).WFile;
                um.AnniversaryDate = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AnniversaryDate;
                um.SmartDeliveryDate = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).SmartDeliveryDate;
                um.Website = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Website;
                um.Address = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Address;
                um.AddressLine2 = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AddressLine2;
                um.City = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).City;
                um.State = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).State;
                um.StateOther = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).StateOther;
                um.ZipCode = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ZipCode;
                um.ShippingFirstName = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingFirstName;
                um.ShippingLastName = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingLastName;
                um.ShippingAddress = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingAddress;
                um.ShippingAddressLine2 = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingAddressLine2;
                um.ShippingCity = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingCity;
                um.ShippingState = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingState;
                um.ShippingStateOther = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingStateOther;
                um.ShippingZip = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ShippingZip;
                um.Fax = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Fax;
                um.Co_Applicant = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Co_Applicant;
                um.Language = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Language;
                um.Skype = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Skype;
                um.Twitter = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Twitter;
                um.Facebook = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Facebook;
                um.AadharVerified = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AadharVerified;
                um.PanVerified = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).PanVerified;
                um.ChequeVerified = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ChequeVerified;
                um.GstinVerified = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).GstinVerified;
                um.AddressVerified = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AddressVerified;
                um.Image_Name = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Image_Name;
                um.Status = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Status;
                um.UserParentId = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).UserParentId;
                um.Save();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Change Sucessfull...!!');</script>", false);
                // Response.Redirect("Default.aspx");
            }
        }
    }
}