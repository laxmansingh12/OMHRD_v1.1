using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class StateMaster : BusinessBaseObject
    {
        #region
        public int STATE_ID { get; set; }
        public string STATE_NAME { get; set; }
        public int CountryId { get; set; }
        public string REMARKS { get; set; }
        public string STATECODE { get; set; }
        #endregion

        #region Methods
        public static StateMaster GetBySTATE_ID(int STATE_ID)
        {
            StateMaster obj = new StateMaster();
            obj.MapData(new StateMasterDataService().StateMaster_GetBySTATE_ID(STATE_ID));
            return obj;
        }

        public override bool MapData(DataRow row)
        {

            STATE_ID = GetInt(row, "STATE_ID");
            STATE_NAME = GetString(row, "STATE_NAME");
            CountryId = GetInt(row, "CountryId");
            REMARKS = GetString(row, "REMARKS");
            STATECODE = GetString(row, "STATECODE");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public static StateMaster GetBySTATE_NAME(string STATE_NAME)
        {
            StateMaster obj = new StateMaster();
            obj.MapData(new StateMasterDataService().StateMaster_GetBySTATE_NAME(STATE_NAME));
            return obj;
        }

        public void Save(IDbTransaction txn)
        {
            new StateMasterDataService().StateMaster_Save(STATE_ID, STATE_NAME, CountryId, REMARKS, STATECODE);
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new StateMasterDataService().StateMaster_GetByDelete(STATE_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new StateMasterDataService().StateMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
