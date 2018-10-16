using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class CityMaster : BusinessBaseObject
    {
        #region

        public int CITY_ID { get; set; }

        public string CITY_NAME { get; set; }
        public int STATE_ID { get; set; }
        public string REMARKS { get; set; }
        #endregion

        #region Methods
        public static CityMaster GetByCITY_ID(int CITY_ID)
        {
            CityMaster obj = new CityMaster();
            obj.MapData(new CityMasterDataService().CityMaster_GetByCITY_ID(CITY_ID));
            return obj;
        }

        public override bool MapData(DataRow row)
        {

            CITY_ID = GetInt(row, "CITY_ID");

            CITY_NAME = GetString(row, "CITY_NAME");
            STATE_ID = GetInt(row, "STATE_ID");
            REMARKS = GetString(row, "REMARKS");

            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public static CityMaster GetBySTATE_NAME(string CITY_NAME)
        {
            CityMaster obj = new CityMaster();
            obj.MapData(new CityMasterDataService().CityMaster_GetByCITY_NAME(CITY_NAME));
            return obj;
        }

        public void Save(IDbTransaction txn)
        {
            new CityMasterDataService().CityMaster_Save(CITY_ID, CITY_NAME, STATE_ID, REMARKS);
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new CityMasterDataService().CityMaster_GetByDelete(CITY_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new CityMasterDataService().CityMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
