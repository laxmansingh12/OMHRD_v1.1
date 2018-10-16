using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class FarmerMaster : BusinessBaseObject
    {
        #region

      public int HOTEL_ID { get; set; }
      public string HOTEL_NAME { get; set; }
      public string ADDRESS { get; set; }
      public string CONTACT { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            HOTEL_ID = GetInt(row, "HOTEL_ID");
            HOTEL_NAME = GetString(row, "HOTEL_NAME");
            ADDRESS = GetString(row, "ADDRESS");
            CONTACT = GetString(row, "CONTACT");
              return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new FarmerMasterDataService().FarmerMaster_Save(HOTEL_ID, HOTEL_NAME, ADDRESS, CONTACT);
        }
        public static FarmerMaster GetById(int HOTEL_ID)
        {
            FarmerMaster obj = new FarmerMaster();
            obj.MapData(new FarmerMasterDataService().FarmerMaster_GetById(HOTEL_ID));
            return obj;
        }

        public static FarmerMaster GetByName(string HOTEL_NAME)
        {
            FarmerMaster obj = new FarmerMaster();
            obj.MapData(new FarmerMasterDataService().FarmerMaster_GetByName(HOTEL_NAME));
            return obj;
        }
       
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new FarmerMasterDataService().FarmerMaster_Delete(HOTEL_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new FarmerMasterDataService().FarmerMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
