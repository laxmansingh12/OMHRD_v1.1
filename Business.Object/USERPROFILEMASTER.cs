using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class USERPROFILEMASTER : BusinessBaseObject
    {
        #region
        public int Registration_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string User_Name { get; set; }
        public string User_ID { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNumber { get; set; }
        public string NomineeName { get; set; }
        public string NomineeId { get; set; }
        public string NomineeRelation { get; set; }
        public string Reference_Id { get; set; }
        public DateTime RegDate { get; set; }
        public string COUNTRY { get; set; }
        public string Individual_Company { get; set; }
        public string IdentificationType { get; set; }
        public string TaxExempt { get; set; }
        public string Commission { get; set; }
        public string WFile { get; set; }
        public DateTime AnniversaryDate { get; set; }
        public DateTime SmartDeliveryDate { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public int State { get; set; }
        public string StateName
        {
            get
            {
                StateMaster sm = StateMaster.GetBySTATE_ID(State);
                return sm.STATE_NAME.ToString();
            }
        }
        public int City { get; set; }
        public string CityName
        {
            get
            {
                CityMaster sm = CityMaster.GetByCITY_ID(City);
                return sm.CITY_NAME.ToString();
            }
        }

        public string StateOther { get; set; }
        public string ZipCode { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddressLine2 { get; set; }
        public int ShippingState { get; set; }
        public string ShippStateName
        {
            get
            {
                StateMaster sm = StateMaster.GetBySTATE_ID(ShippingState);
                return sm.STATE_NAME.ToString();
            }
        }
        public int ShippingCity { get; set; }
        public string ShipCityName
        {
            get
            {
                CityMaster sm = CityMaster.GetByCITY_ID(ShippingCity);
                return sm.CITY_NAME.ToString();
            }
        }
        public string ShippingZip { get; set; }
        public string ShippingStateOther { get; set; }
        public string AlternativeNumber { get; set; }
        public string Fax { get; set; }
        public string Co_Applicant { get; set; }
        public string Language { get; set; }
        public string Skype { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string AadharVerified { get; set; }
        public string AadharImage { get; set; }
        public string PanVerified { get; set; }
        public string PanImage { get; set; }
        public string ChequeVerified { get; set; }
        public string ChequeImage { get; set; }
        public string GstinVerified { get; set; }
        public string AddressVerified { get; set; }
        public string AddressImage { get; set; }
        public string Image_Name { get; set; }
        public string Status { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string Branch { get; set; }
        public decimal UserWallet { get; set; }
        public int? UserParentId { get; set; }
        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            Registration_ID = GetInt(row, "Registration_ID");
            First_Name = GetString(row, "First_Name");
            Last_Name = GetString(row, "Last_Name");
            Email = GetString(row, "Email");
            User_Name = GetString(row, "User_Name"); User_ID = GetString(row, "User_ID");
            Password = GetString(row, "Password");
            DOB = GetDateTime(row, "DOB");
            ContactNumber = GetString(row, "ContactNumber");
            NomineeName = GetString(row, "NomineeName");
            NomineeId = GetString(row, "NomineeId");
            NomineeRelation = GetString(row, "NomineeRelation");
            Reference_Id = GetString(row, "Reference_Id");
            RegDate = GetDateTime(row, "RegDate");
            COUNTRY = GetString(row, "COUNTRY"); Individual_Company = GetString(row, "Individual_Company");
            IdentificationType = GetString(row, "IdentificationType"); TaxExempt = GetString(row, "TaxExempt"); Commission = GetString(row, "Commission");
            WFile = GetString(row, "WFile"); AnniversaryDate = GetDateTime(row, "AnniversaryDate"); SmartDeliveryDate = GetDateTime(row, "SmartDeliveryDate");
            Website = GetString(row, "Website"); Address = GetString(row, "Address");
            AddressLine2 = GetString(row, "AddressLine2"); City = GetInt(row, "City"); State = GetInt(row, "State"); StateOther = GetString(row, "StateOther");
            ZipCode = GetString(row, "ZipCode"); ShippingFirstName = GetString(row, "ShippingFirstName"); ShippingLastName = GetString(row, "ShippingLastName");
            ShippingAddress = GetString(row, "ShippingAddress"); ShippingAddressLine2 = GetString(row, "ShippingAddressLine2"); ShippingCity = GetInt(row, "ShippingCity");
            ShippingState = GetInt(row, "ShippingState"); ShippingZip = GetString(row, "ShippingZip"); ShippingStateOther = GetString(row, "ShippingStateOther");
            AlternativeNumber = GetString(row, "AlternativeNumber"); Fax = GetString(row, "Fax"); Co_Applicant = GetString(row, "Co_Applicant"); Language = GetString(row, "Language");
            Skype = GetString(row, "Skype"); Twitter = GetString(row, "Twitter"); Facebook = GetString(row, "Facebook"); AadharVerified = GetString(row, "AadharVerified"); AadharImage = GetString(row, "AadharImage");
            PanVerified = GetString(row, "PanVerified"); PanImage = GetString(row, "PanImage"); ChequeVerified = GetString(row, "ChequeVerified"); ChequeImage = GetString(row, "ChequeImage");
            GstinVerified = GetString(row, "GstinVerified"); AddressVerified = GetString(row, "AddressVerified"); AddressImage = GetString(row, "AddressImage"); Image_Name = GetString(row, "Image_Name");
            Status = GetString(row, "Status");
            BankName = GetString(row, "BankName");
            AccountNo = GetString(row, "AccountNo");
            IFSCCode = GetString(row, "IFSCCode"); Branch = GetString(row, "Branch");
            UserWallet = GetDecimal(row, "UserWallet");
            UserParentId = GetInt(row, "UserParentId");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }


        public static USERPROFILEMASTER GetByRegistration_ID(int Registration_ID)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().USERPROFILEMASTER_GetByRegistration_ID(Registration_ID));
            return obj;
        }
        public static USERPROFILEMASTER GetByPASSWORD(string Password)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().UserMasterGetByPASSWORD(Password));
            return obj;
        }
        public static USERPROFILEMASTER GetByLoginNameandPassword(string User_Name, string Password)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Update_PASSWORD(int Registration_ID, string Password)
        {
            new USERPROFILEMASTERDataService().GetByUpdate_PASSWORD(Registration_ID, Password);
        }
        public void WalletRecharge(int Registration_ID, decimal UserWallet)
        {
            new USERPROFILEMASTERDataService().GetByWalletRecharge(Registration_ID, UserWallet);
        }
        public static USERPROFILEMASTER GetByUser_NameandPasswordROLE(string User_Name, string Password)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public static USERPROFILEMASTER LoginMaster_GetByquestionand_answer(string LOGIN_NAME, string QUESTION, string ANSWER)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().User_GetByquestionand_answer(LOGIN_NAME, QUESTION, ANSWER));
            return obj;
        }
        public static USERPROFILEMASTER GetByEmail(string Email)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().USERPROFILEMASTERGetByEmail(Email));
            return obj;
        }
        public static USERPROFILEMASTER GetByUser_Name(string User_Name)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().USERPROFILEMASTERGetByUser_Name(User_Name));
            return obj;
        }
        public static USERPROFILEMASTER User_Name_And_Password(string User_Name, string Password)
        {
            USERPROFILEMASTER obj = new USERPROFILEMASTER();
            obj.MapData(new USERPROFILEMASTERDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new USERPROFILEMASTERDataService().USERPROFILEMASTER_Save(Registration_ID, First_Name, Last_Name, Email, User_Name, User_ID, Password, DOB, ContactNumber, NomineeName, NomineeId, NomineeRelation, Reference_Id, RegDate, COUNTRY,
                                            Individual_Company, IdentificationType, TaxExempt, Commission, WFile, AnniversaryDate, SmartDeliveryDate,
                                            Website, Address, AddressLine2, City, State, StateOther, ZipCode, ShippingFirstName,
                                            ShippingLastName, ShippingAddress, ShippingAddressLine2, ShippingCity, ShippingState, ShippingZip, ShippingStateOther, AlternativeNumber, Fax,
                                            Co_Applicant, Language, Skype, Twitter, Facebook, AadharVerified, AadharImage, PanVerified, PanImage, ChequeVerified, ChequeImage, GstinVerified,
                                            AddressVerified, AddressImage, Image_Name, Status, BankName, AccountNo, IFSCCode, Branch, UserParentId, UserWallet);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new USERPROFILEMASTERDataService().USERPROFILEMASTER_Delete(Registration_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new USERPROFILEMASTERDataService().USERPROFILEMASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
