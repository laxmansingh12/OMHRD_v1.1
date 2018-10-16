using System;
using System.Data;
using Business.Common;
using Business.SQLServer;


namespace Business.Object
{
    public class ColorDataMaster : BusinessBaseObject
    {
        #region
        public int Color_ID { get; set; }
        public string Color_NAME { get; set; }
        public string Color_Code { get; set; }
        public string REMARK { get; set; }

        #endregion

        #region Methods
        public static ColorDataMaster GetByColor_ID(int Color_ID)
        {
            ColorDataMaster obj = new ColorDataMaster();
            obj.MapData(new ColorMasterDataService().ColorMaster_GetByColor_ID(Color_ID));
            return obj;
        }

        public static ColorDataMaster GetByColor_NAME(string Color_NAME)
        {
            ColorDataMaster obj = new ColorDataMaster();
            obj.MapData(new ColorMasterDataService().ColorMaster_GetByColor_NAME(Color_NAME));
            return obj;
        }

        public override bool MapData(DataRow row)
        {
            Color_ID = GetInt(row, "Color_ID");
            Color_NAME = GetString(row, "Color_NAME");
            Color_Code = GetString(row, "Color_Code");
            REMARK = GetString(row, "REMARK");
            //  
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new ColorMasterDataService().ColorMaster_Save(Color_ID, Color_NAME, Color_Code, REMARK);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new ColorMasterDataService().ColorMaster_Delete(Color_ID);
        }
        public static int MaxID()
        {
            int result = 0;
            DataSet ds = new ColorMasterDataService().ColorMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
