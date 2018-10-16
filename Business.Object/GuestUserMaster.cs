using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class GuestUserMaster : BusinessBaseObject
    {
        #region

        public int Guest_Id { get; set; }
        public string Guest_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Member_Id { get; set; }
        public string Remark { get; set; }

        public string ContactNo { get; set; }
        public string Address { get; set; }


        public DateTime RegDate { get; set; }
       
        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            Guest_Id = GetInt(row, "Guest_Id");
            Guest_Name = GetString(row, "Guest_Name");
            Email = GetString(row, "Email");
            Password = GetString(row, "Password");
            Member_Id = GetInt(row, "Member_Id");
            Remark = GetString(row, "Remark");

            ContactNo = GetString(row, "ContactNo");
            Address = GetString(row, "Address");

            RegDate = GetDateTime(row, "RegDate");

            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static GuestUserMaster GetByGuest_Id(int Guest_Id)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().GuestUser_GetByGuest_Id(Guest_Id));
            return obj;
        }
        public static GuestUserMaster GetByPASSWORD(string Password)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().UserMasterGetByPASSWORD(Password));
            return obj;
        }
        //public static GuestUserMaster LoginMaster_GetByquestionand_answer(string Guest_Name, string QUESTION, string ANSWER)
        //{
        //    GuestUserMaster obj = new GuestUserMaster();
        //    obj.MapData(new GuestUserDataService().LoginMaster_GetByquestionand_answer(Guest_Name, QUESTION, ANSWER));
        //    return obj;
        //}
        public static GuestUserMaster GetByLoginNameandPassword(string Guest_Name, string Password)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().Guest_Name_And_Password(Guest_Name, Password));
            return obj;
        }
        public void Update_PASSWORD(string Guest_Name, string Password)
        {
            new GuestUserDataService().GetByUpdate_PASSWORD(Guest_Name, Password);
        }
        public static GuestUserMaster GetByGuest_NameandPasswordROLE(string Guest_Name, string Password)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().Guest_Name_And_Password(Guest_Name, Password));
            return obj;
        }
        public static GuestUserMaster LoginMaster_GetByquestionand_answer(string LOGIN_NAME, string QUESTION, string ANSWER)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().User_GetByquestionand_answer(LOGIN_NAME, QUESTION, ANSWER));
            return obj;
        }
        public static GuestUserMaster GetByGuest_Name(string Guest_Name)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().GuestUser_GetByGuest_Name(Guest_Name));
            return obj;
        }
        public static GuestUserMaster Guest_Name_And_Password(string Guest_Name, string Password)
        {
            GuestUserMaster obj = new GuestUserMaster();
            obj.MapData(new GuestUserDataService().Guest_Name_And_Password(Guest_Name, Password));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new GuestUserDataService().GuestUser_Save(Guest_Id, Guest_Name, Email, Password, Member_Id, ContactNo, Address, Remark, RegDate);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new GuestUserDataService().GuestUser_Delete(Guest_Id);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new GuestUserDataService().GuestUser_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
