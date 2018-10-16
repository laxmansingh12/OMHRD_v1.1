using System;
using System.Data;
using Business.Common;
using Business.SQLServer;


namespace Business.Object
{
    public class CategoryMaster : BusinessBaseObject
    {
        #region
        public int CATEGORY_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string REMARK { get; set; }
        public string DEALS_IN { get; set; }
        #endregion

        #region Methods
        public static CategoryMaster GetByCATEGORY_ID(int CATEGORY_ID)
        {
            CategoryMaster obj = new CategoryMaster();
            obj.MapData(new CategoryMasterDataService().CategoryMaster_GetByCATEGORY_ID(CATEGORY_ID));
            return obj;
        }

        public static CategoryMaster GetByCATEGORY_NAME(string CATEGORY_NAME)
        {
            CategoryMaster obj = new CategoryMaster();
            obj.MapData(new CategoryMasterDataService().CategoryMaster_GetByCATEGORY_NAME(CATEGORY_NAME));
            return obj;
        }

        public override bool MapData(DataRow row)
        {
            CATEGORY_ID = GetInt(row, "CATEGORY_ID");
            CATEGORY_NAME = GetString(row, "CATEGORY_NAME");
            REMARK = GetString(row, "REMARK");
            DEALS_IN = GetString(row, "DEALS_IN");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new CategoryMasterDataService().CategoryMaster_Save(CATEGORY_ID, CATEGORY_NAME, REMARK, DEALS_IN);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new CategoryMasterDataService().CategoryMaster_Delete(CATEGORY_ID);
        }
        public static int MaxID()
        {
            int result = 0;
            DataSet ds = new CategoryMasterDataService().CategoryMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
