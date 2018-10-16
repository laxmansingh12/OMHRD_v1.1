using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class AdminProfileShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkAddress.Attributes.Add("onClick", "CopyText()");
            if (!IsPostBack)
            {
                fillstate();
                fillMyRefName();
                fillNEWUSER();
                BinddropParentUser();
                Member_detail(int.Parse(Session["loginid"].ToString()));
                decimal Am = PaymentMaster.GetByUser_Name(Session["UserName"].ToString()).Amount;
                lblWallet.Text = Am.ToString();
            }
        }
        public void fillMyRefName()
        {
            try
            {
                string UserName = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).User_Name;
                List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetByReference_Id(UserName);
                USERPROFILEMASTER sm = new USERPROFILEMASTER();
                sm.Registration_ID = 0;
                sm.User_Name = "- Our Reference Person-";
                _state.Insert(0, sm);
                dropMyRef.DataSource = _state;
                dropMyRef.DataTextField = "User_Name";
                dropMyRef.DataValueField = "Registration_ID";
                dropMyRef.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public DataTable OurRefence()
        {
            string RefenceName = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).User_Name;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetNotLinkReferenceUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Reference_Id", RefenceName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return ds.Tables[0];
        }
        public void fillNEWUSER()
        {
            var dt = OurRefence();
            dropNewUser.DataTextField = "User_Name";
            dropNewUser.DataValueField = "Registration_ID";
            dropNewUser.DataSource = dt;
            dropNewUser.DataBind();
            dropNewUser.Items.Insert(0, new ListItem("- Our Reference Person-", "0"));
        }
        //public void fillNEWUSER()
        //{
        //    //try
        //    //{
        //    //    string UserName = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).User_Name;
        //    //    List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetByReference_Id(UserName).Where(x => x.UserParentId.HasValue == false || x.UserParentId.Value <= 0).ToList();
        //    //    USERPROFILEMASTER sm = new USERPROFILEMASTER();
        //    //    sm.Registration_ID = 0;
        //    //    sm.User_Name = "- Our Reference Person-";
        //    //    _state.Insert(0, sm);
        //    //    dropNewUser.DataSource = _state;
        //    //    dropNewUser.DataTextField = "User_Name";
        //    //    dropNewUser.DataValueField = "Registration_ID";
        //    //    dropNewUser.DataBind();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string script = "<script>alert('" + ex.Message + "');</script>";
        //    //}
        //    string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select * from PayoutLevelSetting"))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            dropNewUser.DataSource = cmd.ExecuteReader();
        //            dropNewUser.DataTextField = "Code";
        //            dropNewUser.DataValueField = "Id";
        //            dropNewUser.DataBind();
        //            con.Close();
        //        }
        //    }
        //    dropNewUser.Items.Insert(0, new ListItem("- Our Reference Person-", "0"));
        //}
        public DataTable GetItems()
        {
            string userId = Session["loginid"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetChildren", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                //write error message
            }

            return ds.Tables[0];
        }
        public void BinddropParentUser()
        {
            var dt = GetItems();
            dropParentUser.DataTextField = "Label";
            dropParentUser.DataValueField = "Registration_ID";
            dropParentUser.DataSource = dt;
            dropParentUser.DataBind();
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
                DropState.DataSource = _state;
                DropState.DataTextField = "STATE_NAME";
                DropState.DataValueField = "STATE_ID";
                DropState.DataBind();



                dropShipstate.DataSource = _state;
                dropShipstate.DataTextField = "STATE_NAME";
                dropShipstate.DataValueField = "STATE_ID";
                dropShipstate.DataBind();

            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillcity()
        {
            List<CityMaster> _city = CityMasterCollection.GetAll().Where(x => x.STATE_ID == int.Parse(DropState.SelectedValue.ToString())).OrderBy(x => x.CITY_NAME).ToList();
            CityMaster cm = new CityMaster();
            cm.CITY_ID = 0;
            cm.CITY_NAME = "-Select City-";
            _city.Insert(0, cm);
            DropCity.DataSource = _city;
            DropCity.DataTextField = "CITY_NAME";
            DropCity.DataValueField = ("CITY_ID");
            DropCity.DataBind();

        }
        public void fillShippingCity()
        {
            List<CityMaster> _city = CityMasterCollection.GetAll().Where(x => x.STATE_ID == int.Parse(dropShipstate.SelectedValue.ToString())).OrderBy(x => x.CITY_NAME).ToList();
            CityMaster cm = new CityMaster();
            cm.CITY_ID = 0;
            cm.CITY_NAME = "-Select City-";
            _city.Insert(0, cm);
            dropShipCity.DataSource = _city;
            dropShipCity.DataTextField = "CITY_NAME";
            dropShipCity.DataValueField = ("CITY_ID");
            dropShipCity.DataBind();

        }
        public void Member_detail(int MID)
        {
            try
            {
                USERPROFILEMASTER drms = USERPROFILEMASTER.GetByRegistration_ID((int.Parse(Session["loginid"].ToString())));
                if (drms.Registration_ID > 0)
                {
                    #region
                    txtFname.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).First_Name;
                    txtLName.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).Last_Name;
                    txtEmail.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).Email;
                    lblUsername.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).User_Name;
                    lblUSerId.Text = drms.User_ID;
                    // txtoldpass.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).Password;
                    txtDOB.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).DOB.ToShortDateString();
                    txtHomePhone.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).ContactNumber;
                    lblSponsorUserName.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).Reference_Id;
                    lblSignupDate.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).RegDate.ToShortDateString();
                    lblCountry.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).COUNTRY;
                    txtIndividual.Text = drms.Individual_Company;
                    lblIdentiType.Text = drms.IdentificationType;
                    lblTaxExempt.Text = drms.TaxExempt;
                    lblCommHoldExempt.Text = drms.Commission;
                    lblW9File.Text = drms.WFile;
                    txtAnniversaryDate.Text = drms.AnniversaryDate.ToShortDateString();
                    lblSmartDeliveryDate.Text = drms.SmartDeliveryDate.ToShortDateString();
                    txtwebsite.Text = drms.Website;
                    txtAddress.Text = drms.Address;
                    txtAddressline2.Text = drms.AddressLine2;
                    DropCity.SelectedIndex = drms.City;
                    DropState.SelectedIndex = drms.State;
                    txtStateOther.Text = drms.StateOther;
                    txtZipCode.Text = drms.ZipCode;
                    txtShipFname.Text = drms.ShippingFirstName;
                    txtShipLname.Text = drms.ShippingLastName;
                    txtShipAdd.Text = drms.ShippingAddress;
                    txtShipAdd2.Text = drms.ShippingAddressLine2;
                    dropShipCity.SelectedIndex = drms.ShippingCity;
                    dropShipstate.SelectedIndex = drms.ShippingState;
                    txtShipZipCode.Text = drms.ShippingZip;
                    txtShipStateOther.Text = drms.ShippingStateOther;
                    lblShipCountry.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).COUNTRY;
                    txtAlternetContact.Text = drms.AlternativeNumber;
                    txtFaxNumber.Text = drms.Fax;
                    lblCoApplicantName.Text = drms.Co_Applicant;
                    dropLanguage.Text = drms.Language;
                    txtSkype.Text = drms.Skype;
                    txtTwitter.Text = drms.Twitter;
                    txtFacebook.Text = drms.Facebook;
                    txtadhar.Text = drms.AadharVerified;
                    if (drms.AadharImage == "" || drms.AadharImage == null)
                    {
                        Image1.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = "~/images/ProfileImages/" + drms.AadharImage;
                    }
                    txtPancard.Text = drms.PanVerified;
                    if (drms.PanImage == "" || drms.PanImage == null)
                    {
                        Image2.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image2.ImageUrl = "~/images/ProfileImages/" + drms.PanImage;
                    }
                    txtCheque.Text = drms.ChequeVerified;
                    if (drms.ChequeImage == "" || drms.ChequeImage == null)
                    {
                        Image3.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image3.ImageUrl = "~/images/ProfileImages/" + drms.ChequeImage;
                    }
                    txtgst.Text = drms.GstinVerified;
                    txtaddProof.Text = drms.AddressVerified;
                    if (drms.AddressImage == "" || drms.AddressImage == null)
                    {
                        Image4.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image4.ImageUrl = "~/images/ProfileImages/" + drms.AddressImage;
                    }
                    if (drms.Image_Name == "" || drms.Image_Name == null)
                    {
                        ImagePhoto.ImageUrl = "~/images/b2.jpg";
                    }
                    else
                    {
                        ImagePhoto.ImageUrl = "~/images/ProfileImages/" + drms.Image_Name;
                    }
                    lblStatus.Text = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).Status;
                    txtBankName.Text = drms.BankName;
                    txtaccount.Text = drms.AccountNo;
                    txtifsc.Text = drms.IFSCCode;
                    txtbranch.Text = drms.Branch;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        private bool SaveNewUserAssociation()
        {
            int newUserId = 0;
            int parentUserId = 0;

            int.TryParse(dropNewUser.SelectedValue, out newUserId);
            int.TryParse(dropParentUser.SelectedValue, out parentUserId);

            if (parentUserId > 0 && newUserId > 0)
            {
                string UserName = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).User_Name;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

                string query = "UPDATE USERPROFILEMASTER SET UserParentId = " + dropParentUser.SelectedValue + " WHERE Registration_ID = " + dropNewUser.SelectedValue;
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@UserName", UserName);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //write error message
                }
                return true;
            }
            return false;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            if (btnUpdate.Text == "Submit Changes")
            {
                USERPROFILEMASTER um = new USERPROFILEMASTER();
                um.Registration_ID = int.Parse(Session["loginid"].ToString());
                um.First_Name = txtFname.Text.Trim();
                um.Last_Name = txtLName.Text.Trim();
                um.Email = txtEmail.Text.Trim();
                um.User_Name = lblUsername.Text.Trim();
                um.User_ID = lblUSerId.Text;
                um.Password = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Password;
                um.DOB = DateTime.Parse(txtDOB.Text);
                um.ContactNumber = txtHomePhone.Text.Trim();
                um.NomineeName = um.NomineeName;
                um.NomineeId = um.NomineeId;
                um.NomineeRelation = um.NomineeRelation;
                um.Reference_Id = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Reference_Id;
                um.RegDate = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).RegDate;
                um.COUNTRY = "India";
                um.Individual_Company = txtIndividual.Text;
                um.IdentificationType = lblIdentiType.Text;
                um.TaxExempt = lblTaxExempt.Text;
                um.Commission = lblCommHoldExempt.Text;
                um.WFile = lblW9File.Text;
                um.AnniversaryDate = DateTime.Parse(txtAnniversaryDate.Text);
                um.SmartDeliveryDate = DateTime.Parse(lblSmartDeliveryDate.Text);
                um.Website = txtwebsite.Text;
                um.Address = txtAddress.Text;
                um.AddressLine2 = txtAddressline2.Text;
                um.State = int.Parse(DropState.SelectedValue);
                fillcity();
                um.City = int.Parse(DropCity.SelectedValue);

                um.StateOther = txtStateOther.Text;
                um.ZipCode = txtZipCode.Text;
                um.ShippingFirstName = txtShipFname.Text;
                um.ShippingLastName = txtShipLname.Text;
                um.ShippingAddress = txtShipAdd.Text;
                um.ShippingAddressLine2 = txtShipAdd2.Text;
                um.ShippingState = int.Parse(dropShipstate.SelectedValue);
                fillShippingCity();
                um.ShippingCity = int.Parse(dropShipCity.SelectedValue);

                um.ShippingZip = txtShipZipCode.Text;
                um.ShippingStateOther = txtShipStateOther.Text;
                um.AlternativeNumber = txtAlternetContact.Text;
                um.Fax = txtFaxNumber.Text;
                um.Co_Applicant = lblCoApplicantName.Text;
                um.Language = dropLanguage.Text;
                um.Skype = txtSkype.Text;
                um.Twitter = txtTwitter.Text;
                um.Facebook = txtFacebook.Text;
                #region AadharVerified
                um.AadharVerified = txtadhar.Text;
                string exten1 = System.IO.Path.GetExtension(fileAdhar.FileName);
                if (fileAdhar.HasFile == true)
                {
                    fileAdhar.SaveAs(Server.MapPath("~/images/UsreVerifiedImages/" + um.User_Name + "AadharVerified" + exten1));
                    um.AadharImage = um.User_Name + "AadharVerified" + exten1;
                }
                else
                {
                    um.AadharImage = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AadharImage;
                }
                #endregion
                #region PanVerified
                um.PanVerified = txtPancard.Text;
                string exten2 = System.IO.Path.GetExtension(filePan.FileName);
                if (filePan.HasFile == true)
                {
                    filePan.SaveAs(Server.MapPath("~/images/UsreVerifiedImages/" + um.User_Name + "PanVerified" + exten2));
                    um.PanImage = um.User_Name + "PanVerified" + exten2;
                }
                else
                {
                    um.PanImage = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).PanImage;
                }
                #endregion
                #region ChequeVerified
                um.ChequeVerified = txtCheque.Text;
                string exten3 = System.IO.Path.GetExtension(fileCheque.FileName);
                if (fileCheque.HasFile == true)
                {
                    fileCheque.SaveAs(Server.MapPath("~/images/UsreVerifiedImages/" + um.User_Name + "ChequeVerified" + exten3));
                    um.ChequeImage = um.User_Name + "ChequeVerified" + exten3;
                }
                else
                {
                    um.ChequeImage = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).ChequeImage;
                }
                #endregion
                um.GstinVerified = txtgst.Text;
                #region AddressVerified
                um.AddressVerified = txtaddProof.Text;
                string exten4 = System.IO.Path.GetExtension(fileAdd.FileName);
                if (fileAdd.HasFile == true)
                {
                    fileAdd.SaveAs(Server.MapPath("~/images/UsreVerifiedImages/" + um.User_Name + "AddressVerified" + exten4));
                    um.AddressImage = um.User_Name + "AddressVerified" + exten4;
                }
                else
                {
                    um.AddressImage = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).AddressImage;
                }
                #endregion
                #region ProfileImage
                string exten = System.IO.Path.GetExtension(fileImage.FileName);
                if (fileImage.HasFile == true)
                {
                    fileImage.SaveAs(Server.MapPath("~/images/ProfileImages/" + um.User_Name + exten));
                    um.Image_Name = um.User_Name + exten;
                }
                else
                {
                    um.Image_Name = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).Image_Name;
                }
                #endregion
                um.Status = lblStatus.Text;
                um.BankName = txtBankName.Text.Trim();
                um.AccountNo = txtaccount.Text.Trim();
                um.IFSCCode = txtifsc.Text.Trim();
                um.Branch = txtbranch.Text.Trim();
                um.UserParentId = USERPROFILEMASTER.GetByRegistration_ID(um.Registration_ID).UserParentId;
                um.Save();
                SaveNewUserAssociation();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Save Sucessfull...!!');</script>", false);
                Response.Redirect("AdminProfileShow.aspx");
            }
            #endregion
        }


        protected void DropState_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcity();
        }

        protected void dropShipstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillShippingCity();
        }
    }
}