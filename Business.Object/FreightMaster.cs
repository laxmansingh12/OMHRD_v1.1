using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class FreightMaster : BusinessBaseObject
    {
        #region
      public int FREIGHT_ID { get; set; }
      public string STOCK { get; set; }
      public string FREIGHT { get; set; }
      public DateTime DATE { get; set; }
      public int BILL_NO { get; set; }
      public string REMARKS { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            FREIGHT_ID = GetInt(row, "FREIGHT_ID");
            STOCK=GetString(row,"STOCK");
            FREIGHT = GetString(row, "FREIGHT");
            DATE = GetDateTime(row, "DATE");
            BILL_NO = GetInt(row, "BILL_NO");
            REMARKS = GetString(row, "REMARKS");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new FreightMasterDataService().FreightMaster_Save(FREIGHT_ID, STOCK, FREIGHT, DATE,BILL_NO, REMARKS);
        }
        public static FreightMaster GetById(int FREIGHT_ID)
        {
            FreightMaster obj = new FreightMaster();
            obj.MapData(new FreightMasterDataService().FreightMaster_GetById(FREIGHT_ID));
            return obj;
        }

        public static FreightMaster GetByName(string FREIGHT)
        {
            FreightMaster obj = new FreightMaster();
            obj.MapData(new FreightMasterDataService().FreightMaster_GetByFreight(FREIGHT));
            return obj;
        }
       
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new FreightMasterDataService().FreightMaster_Delete(FREIGHT_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new FreightMasterDataService().FreightMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
