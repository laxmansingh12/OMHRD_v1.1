using System;
using System.Data;
using Business.Common;
using Business.SQLServer;


namespace Business.Object
{
    public class SizeDataMaster : BusinessBaseObject
    {
        #region
        public int Size_ID { get; set; }
        public string Size_NAME { get; set; }
        public string REMARK { get; set; }
     
        #endregion

        #region Methods
        public static SizeDataMaster GetBySize_ID(int Size_ID)
        {
            SizeDataMaster obj = new SizeDataMaster();
            obj.MapData(new SizeMasterDataService().SizeMaster_GetBySize_ID(Size_ID));
            return obj;
        }

        public static SizeDataMaster GetBySize_NAME(string Size_NAME)
        {
            SizeDataMaster obj = new SizeDataMaster();
            obj.MapData(new SizeMasterDataService().SizeMaster_GetBySize_NAME(Size_NAME));
            return obj;
        }

        public override bool MapData(DataRow row)
        {
            Size_ID = GetInt(row, "Size_ID");
            Size_NAME = GetString(row, "Size_NAME");
            REMARK = GetString(row, "REMARK");
         //   DEALS_IN = GetString(row, "DEALS_IN");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new SizeMasterDataService().SizeMaster_Save(Size_ID, Size_NAME, REMARK);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new SizeMasterDataService().SizeMaster_Delete(Size_ID);
        }
        public static int MaxID()
        {
            int result = 0;
            DataSet ds = new SizeMasterDataService().SizeMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
