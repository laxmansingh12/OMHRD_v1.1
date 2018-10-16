using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class PaymentMaster : BusinessBaseObject
    {
        #region Properties
        public int Paymemt_ID { get; set; }
        public string User_Name { get; set; }
        public string User_ID { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            Paymemt_ID = GetInt(row, "Paymemt_ID");
            User_Name = GetString(row, "User_Name");
            User_ID = GetString(row, "User_ID");
            Amount = GetDecimal(row, "Amount");
            Remark = GetString(row, "Remark");
            return base.MapData(row);
        }
        public static PaymentMaster GetByPaymemt_ID(int Paymemt_ID)
        {
            PaymentMaster obj = new PaymentMaster();
            obj.MapData(new PaymentMasterDataSevice().PaymentMasterGetByPaymemt_ID(Paymemt_ID));
            return obj;
        }
        public static PaymentMaster GetByUser_Name(string User_Name)
        {
            PaymentMaster obj = new PaymentMaster();
            obj.MapData(new PaymentMasterDataSevice().PaymentMasterGetByUser_Name(User_Name));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new PaymentMasterDataSevice().PaymentMasterSave(Paymemt_ID, User_Name, User_ID, Amount, Remark);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new PaymentMasterDataSevice().PaymentMasterGetByDelete(Paymemt_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new PaymentMasterDataSevice().PaymentMasterGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
