using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class PURCHASE_MASTER : BusinessBaseObject
    {
        #region

        public int PURCHASE_ID { get; set; }
        public string HOTEL_NAME { get; set; }
        public string CROP_NAME { get; set; }
        public float QUANTITY { get; set; }
        public float PURCHASE_RATE { get; set; }
       public DateTime PURCHASE_DATE { get; set; }
       public string STATUS { get; set; }

        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            PURCHASE_ID = GetInt(row, "PURCHASE_ID");
            HOTEL_NAME = GetString(row, "HOTEL_NAME");
            CROP_NAME = GetString(row, "CROP_NAME");
            QUANTITY = GetFloat(row, "QUANTITY");
            PURCHASE_RATE = GetFloat(row, "PURCHASE_RATE");
            PURCHASE_DATE = GetDateTime(row, "PURCHASE_DATE");
            STATUS = GetString(row, "STATUS");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new PURCHASE_MASTERDataService().PURCHASE_MASTER_Save(PURCHASE_ID, HOTEL_NAME, CROP_NAME, QUANTITY, PURCHASE_RATE, PURCHASE_DATE, STATUS);
        }
        public static PURCHASE_MASTER GetById(int PURCHASE_ID)
        {
            PURCHASE_MASTER obj = new PURCHASE_MASTER();
            obj.MapData(new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetById(PURCHASE_ID));
            return obj;
        }

        public static PURCHASE_MASTER GetByDATE(DateTime PURCHASE_DATE)
        {
            PURCHASE_MASTER obj = new PURCHASE_MASTER();
            obj.MapData(new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetByDATE(PURCHASE_DATE));
            return obj;
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new PURCHASE_MASTERDataService().PURCHASE_MASTER_Delete(PURCHASE_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
