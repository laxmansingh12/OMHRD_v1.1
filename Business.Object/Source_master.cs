using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class Source_master : BusinessBaseObject
    {
        #region

      public int SOURCE_ID { get; set; }
      public string SOURCE_NAME { get; set; }
      public float PAYMENT { get; set; }
      public DateTime DATE { get; set; }
      public string REMAEK { get; set; }
       #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            SOURCE_ID = GetInt(row, "SOURCE_ID");
            SOURCE_NAME = GetString(row, "SOURCE_NAME");
            PAYMENT = GetFloat(row, "PAYMENT");
            DATE = GetDateTime(row, "DATE");
            REMAEK = GetString(row, "REMAEK");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new SourceMasterDataService().SourceMaster_Save(SOURCE_ID, SOURCE_NAME, PAYMENT, DATE, REMAEK);
        }
        public static Source_master GetById(int SOURCE_ID)
        {
            Source_master obj = new Source_master();
            obj.MapData(new SourceMasterDataService().SourceMaster_GetById(SOURCE_ID));
            return obj;
        }
      
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new SourceMasterDataService().SourceMaster_Delete(SOURCE_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new SourceMasterDataService().SourceMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
