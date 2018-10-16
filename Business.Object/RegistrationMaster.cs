using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class RegistrationMaster : BusinessBaseObject
    {
        #region
        public int Registration_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string AdharCard { get; set; }
        public string PanCard { get; set; }
        public string ContactNumber { get; set; }
        public string NomineeName { get; set; }
        public string NomineeId { get; set; }
        public string NomineeRelation { get; set; }
        public string Reference_Id { get; set; }
        public DateTime RegDate { get; set; }
        public string COUNTRY { get; set; }

        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            Registration_ID = GetInt(row, "Registration_ID");
            First_Name = GetString(row, "First_Name");
            Last_Name = GetString(row, "Last_Name");
            Email = GetString(row, "Email");
            User_Name = GetString(row, "User_Name");
            Password = GetString(row, "Password");
            DOB = GetDateTime(row, "DOB");
            AdharCard = GetString(row, "AdharCard");
            PanCard = GetString(row, "PanCard");
            ContactNumber = GetString(row, "ContactNumber");
            NomineeName = GetString(row, "NomineeName");
            NomineeId = GetString(row, "NomineeId");
            NomineeRelation = GetString(row, "NomineeRelation");
            Reference_Id = GetString(row, "Reference_Id");
            RegDate = GetDateTime(row, "RegDate");
            COUNTRY = GetString(row, "COUNTRY");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static RegistrationMaster GetByRegistration_ID(int Registration_ID)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().RegistrationMaster_GetByRegistration_ID(Registration_ID));
            return obj;
        }
        public static RegistrationMaster GetByPASSWORD(string Password)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().UserMasterGetByPASSWORD(Password));
            return obj;
        }
        //public static RegistrationMaster LoginMaster_GetByquestionand_answer(string User_Name, string QUESTION, string ANSWER)
        //{
        //    RegistrationMaster obj = new RegistrationMaster();
        //    obj.MapData(new RegistrationMasterDataService().LoginMaster_GetByquestionand_answer(User_Name, QUESTION, ANSWER));
        //    return obj;
        //}
        public static RegistrationMaster GetByLoginNameandPassword(string User_Name, string Password)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Update_PASSWORD(string User_Name, string Password)
        {
            new RegistrationMasterDataService().GetByUpdate_PASSWORD(User_Name, Password);
        }
        public static RegistrationMaster GetByUser_NameandPasswordROLE(string User_Name, string Password)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public static RegistrationMaster LoginMaster_GetByquestionand_answer(string LOGIN_NAME, string QUESTION, string ANSWER)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().User_GetByquestionand_answer(LOGIN_NAME, QUESTION, ANSWER));
            return obj;
        }
        public static RegistrationMaster GetByUser_Name(string User_Name)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().RegistrationMaster_GetByUser_Name(User_Name));
            return obj;
        }
        public static RegistrationMaster User_Name_And_Password(string User_Name, string Password)
        {
            RegistrationMaster obj = new RegistrationMaster();
            obj.MapData(new RegistrationMasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new RegistrationMasterDataService().RegistrationMaster_Save(Registration_ID, First_Name, Last_Name, Email, User_Name, Password, DOB, AdharCard, PanCard, ContactNumber, NomineeName, NomineeId, NomineeRelation, Reference_Id, RegDate, COUNTRY);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new RegistrationMasterDataService().RegistrationMaster_Delete(Registration_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new RegistrationMasterDataService().RegistrationMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
