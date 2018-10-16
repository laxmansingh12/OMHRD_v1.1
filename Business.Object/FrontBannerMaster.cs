using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class FrontBannerMaster : BusinessBaseObject
    {
        #region Properties
        public int FILE_ID { get; set; }
        public string HEADING1 { get; set; }
        public string HEADING2 { get; set; }
        public string HEADING3 { get; set; }
        public string HEADING4 { get; set; }
        public string HEADING5 { get; set; }
        public string FILE_NAME1 { get; set; }
        public string FILE_NAME2 { get; set; }
        public string FILE_NAME3 { get; set; }
        public string FILE_NAME4 { get; set; }
        public string FILE_NAME5 { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            FILE_ID = GetInt(row, "FILE_ID");
            HEADING1 = GetString(row, "HEADING1"); HEADING2 = GetString(row, "HEADING2");
            HEADING3 = GetString(row, "HEADING3"); HEADING4 = GetString(row, "HEADING4"); HEADING5 = GetString(row, "HEADING5");
            FILE_NAME1 = GetString(row, "FILE_NAME1");
            FILE_NAME2 = GetString(row, "FILE_NAME2");
            FILE_NAME3 = GetString(row, "FILE_NAME3");
            FILE_NAME4 = GetString(row, "FILE_NAME4"); FILE_NAME5 = GetString(row, "FILE_NAME5");
            return base.MapData(row);
        }
        public static FrontBannerMaster GetByFILE_ID(int FILE_ID)
        {
            FrontBannerMaster obj = new FrontBannerMaster();
            obj.MapData(new FrontBannerService().FrontBannerGetByFILE_ID(FILE_ID));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new FrontBannerService().FrontBannerSave(FILE_ID, HEADING1, HEADING2, HEADING3, HEADING4, HEADING5, FILE_NAME1, FILE_NAME2, FILE_NAME3, FILE_NAME4, FILE_NAME5);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new FrontBannerService().FrontBannerGetByDelete(FILE_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new FrontBannerService().FrontBannerGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
