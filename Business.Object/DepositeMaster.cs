using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class DepositeMaster : BusinessBaseObject
    {
        #region

      public int DEPOSITE_ID { get; set; }
      public string ACCOUNT_NO { get; set; }
      public string MONEY { get; set; }
      public DateTime DATE { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            DEPOSITE_ID = GetInt(row, "DEPOSITE_ID");
            ACCOUNT_NO = GetString(row, "ACCOUNT_NO");
            MONEY = GetString(row, "MONEY");
            DATE = GetDateTime(row, "DATE");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new DepositeMasterDataService().DepositeMaster_Save(DEPOSITE_ID, ACCOUNT_NO,MONEY, DATE);
        }
        public static DepositeMaster GetById(int DEPOSITE_ID)
        {
            DepositeMaster obj = new DepositeMaster();
            obj.MapData(new DepositeMasterDataService().DepositeMaster_GetById(DEPOSITE_ID));
            return obj;
        }
        public static DepositeMaster GetByDateCrop(DateTime DATE)
        {
            DepositeMaster obj = new DepositeMaster();
            obj.MapData(new DepositeMasterDataService().DepositeMaster_GetByDATE(DATE));
            return obj;
        }


        //public static PurchasingMaster GetByName(string NAME)
        //{
        //    PurchasingMaster obj = new PurchasingMaster();
        //    obj.MapData(new PurchasingMasterDataService().PurchasingMaster_GetByName(NAME));
        //    return obj;
        //}
       
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new DepositeMasterDataService().DepositeMaster_Delete(DEPOSITE_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new DepositeMasterDataService().DepositeMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
