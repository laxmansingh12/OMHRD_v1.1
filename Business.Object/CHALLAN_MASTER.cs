using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class CHALLAN_MASTER : BusinessBaseObject
    {
        #region

        public int CHALLAN_ID { get; set; }
        public int HOtel_ID { get; set; }
        public int CROP_ID { get; set; }
        public float QTY { get; set; }
        public DateTime DATE { get; set; }
        public string  CHALLAN_NO { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            CHALLAN_ID = GetInt(row, "CHALLAN_ID");
            HOtel_ID = GetInt(row, "HOtel_ID");
            CROP_ID = GetInt(row, "CROP_ID");
            QTY = GetFloat(row, "QTY");
            DATE = GetDateTime(row, "DATE");
            CHALLAN_NO =GetString(row, "CHALLAN_NO");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new Challan_MASTERDataService().Challan_MASTER_Save(CHALLAN_ID, HOtel_ID, CROP_ID, QTY, DATE, CHALLAN_NO);
        }
        public static CHALLAN_MASTER GetById(int CHALLAN_ID)
        {
            CHALLAN_MASTER obj = new CHALLAN_MASTER();
            obj.MapData(new Challan_MASTERDataService().Challan_MASTER_GetById(CHALLAN_ID));
            return obj;
        }


        public static CHALLAN_MASTER GetByName(int HOtel_ID)
        {
            CHALLAN_MASTER obj = new CHALLAN_MASTER();
            obj.MapData(new Challan_MASTERDataService().Challan_MASTER_GetByHName(HOtel_ID));
            return obj;
        }

        public static CHALLAN_MASTER GetByDATE(DateTime DATE)
        {
            CHALLAN_MASTER obj = new CHALLAN_MASTER();
            obj.MapData(new Challan_MASTERDataService().Challan_MASTER_GetByDATE(DATE));
            return obj;
        }
      
        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new Challan_MASTERDataService().Challan_MASTER_Delete(CHALLAN_ID);
        }
        public static int MaxIdbyhotel(int HOtel_ID, DateTime DATE)
        {
            int result = 0;
            DataSet ds = new Challan_MASTERDataService().Challan_MASTER_GetMAXIdbyhotel(HOtel_ID, DATE);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int Maxchallan(DateTime From_DATE, DateTime ToDate, int HOtel_ID)
        {
            int result = 0;
            DataSet ds = new Challan_MASTERDataService().Challan_MASTER_GetByMaxChallan(From_DATE, ToDate, HOtel_ID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int minchallan(DateTime From_DATE, DateTime ToDate, int HOtel_ID)
        {
            int result = 0;
            DataSet ds = new Challan_MASTERDataService().Challan_MASTER_GetByMinChallan(From_DATE,ToDate,HOtel_ID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int CHALLAN_NO_MaxId()
        {
            int result = 0;
            DataSet ds = new Challan_MASTERDataService().Challan_MASTER_GetCHALLAN_NO();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new Challan_MASTERDataService().Challan_MASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
