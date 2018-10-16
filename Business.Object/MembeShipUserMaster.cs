using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class MembeShipUserMaster : BusinessBaseObject
    {
        #region

        public int MembeShip_ID { get; set; }
        public string MembeShip { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Member_Id { get; set; }
        public string Remark { get; set; }
        public DateTime RegDate { get; set; }
        public string ContactNo { get; set; }

        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            MembeShip_ID = GetInt(row, "MembeShip_ID");
            MembeShip = GetString(row, "MembeShip");
            Email = GetString(row, "Email");
            Password = GetString(row, "Password");
            Member_Id = GetInt(row, "Member_Id");
            Remark = GetString(row, "Remark");
            RegDate = GetDateTime(row, "RegDate");
            ContactNo = GetString(row, "ContactNo");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static MembeShipUserMaster GetByMembeShip_ID(int MembeShip_ID)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().MembeShipUser_GetByMembeShip_ID(MembeShip_ID));
            return obj;
        }
        public static MembeShipUserMaster GetByPASSWORD(string Password)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().UserMasterGetByPASSWORD(Password));
            return obj;
        }
        //public static MembeShipUserMaster LoginMaster_GetByquestionand_answer(string MembeShip, string QUESTION, string ANSWER)
        //{
        //    MembeShipUserMaster obj = new MembeShipUserMaster();
        //    obj.MapData(new MembeShipUserDataService().LoginMaster_GetByquestionand_answer(MembeShip, QUESTION, ANSWER));
        //    return obj;
        //}
        public static MembeShipUserMaster GetByLoginNameandPassword(string MembeShip, string Password)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().MembeShip_And_Password(MembeShip, Password));
            return obj;
        }
        public void Update_PASSWORD(string MembeShip, string Password)
        {
            new MembeShipUserDataService().GetByUpdate_PASSWORD(MembeShip, Password);
        }
        public static MembeShipUserMaster GetByMembeShipandPasswordROLE(string MembeShip, string Password)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().MembeShip_And_Password(MembeShip, Password));
            return obj;
        }
        public static MembeShipUserMaster LoginMaster_GetByquestionand_answer(string LOGIN_NAME, string QUESTION, string ANSWER)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().User_GetByquestionand_answer(LOGIN_NAME, QUESTION, ANSWER));
            return obj;
        }
        public static MembeShipUserMaster GetByMembeShip(string MembeShip)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().MembeShipUser_GetByMembeShip(MembeShip));
            return obj;
        }
        public static MembeShipUserMaster MembeShip_And_Password(string MembeShip, string Password)
        {
            MembeShipUserMaster obj = new MembeShipUserMaster();
            obj.MapData(new MembeShipUserDataService().MembeShip_And_Password(MembeShip, Password));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new MembeShipUserDataService().MembeShipUser_Save(MembeShip_ID, MembeShip, Email, Password, Member_Id, Remark, RegDate, ContactNo);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new MembeShipUserDataService().MembeShipUser_Delete(MembeShip_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new MembeShipUserDataService().MembeShipUser_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
