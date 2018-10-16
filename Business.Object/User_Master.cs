using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class User_Master : BusinessBaseObject
    {
          #region

        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Login_Access { get; set; }
        public string Roll { get; set; }
        public string QUESTION { get; set; }
        public string ANSWER { get; set; }
        public int Member_Id { get; set; }
        #endregion
        #region Methods
 
        public override bool MapData(DataRow row)
        {
            User_Id = GetInt(row, "User_Id");
            User_Name = GetString(row, "User_Name");
            Password = GetString(row, "Password");
            Login_Access = GetString(row, "Login_Access");
            Roll = GetString(row, "Roll");
            QUESTION = GetString(row, "QUESTION");
            ANSWER = GetString(row, "ANSWER");
            Member_Id = GetInt(row, "Member_Id");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static User_Master GetByUser_Id(int User_Id)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Master_GetByUser_Id(User_Id));
            return obj;
        }
        public static User_Master GetByPASSWORD(string Password)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().UserMasterGetByPASSWORD(Password));
            return obj;
        }
        //public static User_Master LoginMaster_GetByquestionand_answer(string User_Name, string QUESTION, string ANSWER)
        //{
        //    User_Master obj = new User_Master();
        //    obj.MapData(new User_MasterDataService().LoginMaster_GetByquestionand_answer(User_Name, QUESTION, ANSWER));
        //    return obj;
        //}
        public static User_Master GetByLoginNameandPassword(string User_Name, string Password)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Update_PASSWORD(string User_Name, string Password)
        {
            new User_MasterDataService().GetByUpdate_PASSWORD(User_Name, Password);
        }
        public static User_Master GetByUser_NameandPasswordROLE(string User_Name, string Password)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public static User_Master LoginMaster_GetByquestionand_answer(string LOGIN_NAME, string QUESTION, string ANSWER)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_GetByquestionand_answer(LOGIN_NAME, QUESTION, ANSWER));
            return obj;
        }
        public static User_Master GetByUser_Name(string User_Name)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Master_GetByUser_Name(User_Name));
            return obj;
        }
        public static User_Master User_Name_And_Password(string User_Name, string Password)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Name_And_Password(User_Name, Password));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new User_MasterDataService().User_Master_Save(User_Id, User_Name, Password, Login_Access, Roll, QUESTION, ANSWER, Member_Id);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new User_MasterDataService().User_Master_Delete(User_Id);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new User_MasterDataService().User_Master_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
                
            }
            return result;
        }
           #endregion
    }
    }
