using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class PickupMaster : BusinessBaseObject
    {
        #region Properties
        public int PickupID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CenterName { get; set; }
        public string CenterCode { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public string ContactNo { get; set; }
        public string Alternate1 { get; set; }
        public string Alternate2 { get; set; }
        public string GstinNo { get; set; }
        public DateTime Regdate { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            PickupID = GetInt(row, "PickupID");
            FirstName = GetString(row, "FirstName");
            LastName = GetString(row, "LastName");
            UserName = GetString(row, "UserName");
            Password = GetString(row, "Password");
            CenterName = GetString(row, "CenterName");
            CenterCode = GetString(row, "CenterCode");
            Address = GetString(row, "Address");
            Pincode = GetString(row, "Pincode");
            City = GetInt(row, "City");
            State = GetInt(row, "State");
            ContactNo = GetString(row, "ContactNo");
            Alternate1 = GetString(row, "Alternate1");
            Alternate2 = GetString(row, "Alternate2");
            GstinNo = GetString(row, "GstinNo");
            Regdate = GetDateTime(row, "Regdate");
            Status = GetString(row, "Status");
            Action = GetString(row, "Action");
            return base.MapData(row);
        }
        public static PickupMaster GetByPickupID(int PickupID)
        {
            PickupMaster obj = new PickupMaster();
            obj.MapData(new PickUpMasterDataSevice().PickUpMasterGetByPickupID(PickupID));
            return obj;
        }
        public static PickupMaster GetByCenterCode(string CenterCode)
        {
            PickupMaster obj = new PickupMaster();
            obj.MapData(new PickUpMasterDataSevice().PickUpMasterGetByCenterCode(CenterCode));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new PickUpMasterDataSevice().PickUpMasterSave(PickupID, FirstName, LastName, UserName, Password, CenterName, CenterCode, Address, Pincode, City, State, ContactNo, Alternate1, Alternate2, GstinNo, Regdate, Status, Action);
        }
        public static PickupMaster GetByPASSWORD(string Password)
        {
            PickupMaster obj = new PickupMaster();
            obj.MapData(new PickUpMasterDataSevice().PickUpMasterGetByPASSWORD(Password));
            return obj;
        }
        public void Update_PASSWORD(int PickupID, string Password)
        {
            new PickUpMasterDataSevice().GetByUpdate_PASSWORD(PickupID, Password);
        }
        public static PickupMaster GetByStatus(string Status)
        {
            PickupMaster obj = new PickupMaster();
            obj.MapData(new PickUpMasterDataSevice().PickUpMasterGetByStatus(Status));
            return obj;
        }
        public void Update_Status(int PickupID, string Status)
        {
            new PickUpMasterDataSevice().GetByUpdate_Status(PickupID, Status);
        }
        public static PickupMaster GetByAction(string Action)
        {
            PickupMaster obj = new PickupMaster();
            obj.MapData(new PickUpMasterDataSevice().PickUpMasterGetByAction(Action));
            return obj;
        }
        public void Update_Action(int PickupID, string Action)
        {
            new PickUpMasterDataSevice().GetByUpdate_Action(PickupID, Action);
        }
        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new PickUpMasterDataSevice().PickUpMasterGetByDelete(PickupID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new PickUpMasterDataSevice().PickUpMasterGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
