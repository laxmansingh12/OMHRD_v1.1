using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class CropRateListMaster : BusinessBaseObject
    {
        #region
      public int CROPRate_ID { get; set; }
      public int HOtel_ID { get; set; }
      public string CROP_NAME  { get; set; }
      public float RATE { get; set; }
      public string MONTH { get; set; }
      public string REMARKS { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            CROPRate_ID = GetInt(row, "CROPRate_ID");
            HOtel_ID = GetInt(row, "HOtel_ID");
            CROP_NAME = GetString(row, "CROP_NAME");
            RATE = GetFloat(row, "RATE");
            MONTH = GetString(row, "MONTH");
            REMARKS = GetString(row, "REMARKS");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new CropRateListDataService().CropRateList_Save(CROPRate_ID, HOtel_ID, CROP_NAME, RATE, MONTH, REMARKS);
        }
        public static CropRateListMaster GetById(int CROPRate_ID)
        {
            CropRateListMaster obj = new CropRateListMaster();
            obj.MapData(new CropRateListDataService().CropRateList_GetById(CROPRate_ID));
            return obj;
        }
        public static CropRateListMaster GetByRate(string CROP_NAME, int HOtel_ID, string MONTH)
        {
            CropRateListMaster obj = new CropRateListMaster();
            obj.MapData(new CropRateListDataService().CropRateList_GetByrate(CROP_NAME, HOtel_ID, MONTH));
            return obj;
        }

        public static CropRateListMaster GetByMonthName(string MONTH)
        {
            CropRateListMaster obj = new CropRateListMaster();
            obj.MapData(new CropRateListDataService().CropRateList_GetByMonthName(MONTH));
            return obj;
        }
       
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new CropRateListDataService().CropRateList_Delete(CROPRate_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new CropRateListDataService().CropRateList_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
