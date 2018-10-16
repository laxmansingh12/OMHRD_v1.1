using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class SALE_MASTER : BusinessBaseObject
    {
        #region

      public int SUPLIE_ID { get; set; }
      public string HOTEL_NAME { get; set; }
      public string CROP_NMAE { get; set; }
      public float QUANTITY { get; set; }
      public float PRICE { get; set; }
      public DateTime DATE { get; set; }
      public string STATUS { get; set; }
      public int BILL_NO { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            SUPLIE_ID = GetInt(row, "SUPLIE_ID");
           HOTEL_NAME = GetString(row, "HOTEL_NAME");
           CROP_NMAE = GetString(row, "CROP_NMAE");
           QUANTITY =GetFloat(row, "QUANTITY");
           PRICE = GetFloat(row, "PRICE");
            DATE = GetDateTime(row, "DATE");
            STATUS = GetString(row, "STATUS");
            BILL_NO = GetInt(row, "BILL_NO");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new SALE_MASTERDataService().SALE_MASTER_Save(SUPLIE_ID, HOTEL_NAME, CROP_NMAE, QUANTITY, PRICE, DATE, STATUS, BILL_NO);
        }
        public static SALE_MASTER GetById(int SUPLIE_ID)
        {
            SALE_MASTER obj = new SALE_MASTER();
            obj.MapData(new SALE_MASTERDataService().SALE_MASTER_GetById(SUPLIE_ID));
            return obj;
        }


        public static SALE_MASTER GetByName(string  HOTEL_NAME)
        {
            SALE_MASTER obj = new SALE_MASTER();
            obj.MapData(new SALE_MASTERDataService().SALE_MASTER_GetByName(HOTEL_NAME));
            return obj;
        }

        public static SALE_MASTER GetByDate(DateTime DATE)
        {
            SALE_MASTER obj = new SALE_MASTER();
            obj.MapData(new SALE_MASTERDataService().SALE_MASTER_GetByDATE(DATE));
            return obj;
        }
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new SALE_MASTERDataService().SALE_MASTER_Delete(SUPLIE_ID);
        }
        public static int MaxIdbyhotel(string HOTEL_NAME)
        {
            int result = 0;
            DataSet ds = new SALE_MASTERDataService().SALE_MASTER_GetMAXIdbyhotel(HOTEL_NAME);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new SALE_MASTERDataService().SALE_MASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
