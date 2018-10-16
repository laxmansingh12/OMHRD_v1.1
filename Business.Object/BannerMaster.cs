using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class BannerMaster : BusinessBaseObject
    {
        #region Properties
        public int FILE_ID { get; set; }
        public string HEADING1 { get; set; }
        public string HEADING2 { get; set; }
        public string HEADING3 { get; set; }
        public string ATTETMENT { get; set; }
        public string FILE_NAME { get; set; }
        public string ATTETMENT1 { get; set; }
        public string FILE_NAME1 { get; set; }
        public string FooterHeading { get; set; }
        public string SliderCSSClass { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            FILE_ID = GetInt(row, "FILE_ID");
            HEADING1 = GetString(row, "HEADING1"); HEADING2 = GetString(row, "HEADING2"); HEADING3 = GetString(row, "HEADING3");
            ATTETMENT = GetString(row, "ATTETMENT");
            FILE_NAME = GetString(row, "FILE_NAME");
            ATTETMENT1 = GetString(row, "ATTETMENT1");
            FILE_NAME1 = GetString(row, "FILE_NAME1"); FooterHeading = GetString(row, "FooterHeading");
            return base.MapData(row);
        }
        public static BannerMaster GetByFILE_ID(int FILE_ID)
        {
            BannerMaster obj = new BannerMaster();
            obj.MapData(new BannerService().BannerGetByFILE_ID(FILE_ID));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new BannerService().BannerSave(FILE_ID, HEADING1, HEADING2, HEADING3, ATTETMENT, FILE_NAME, ATTETMENT1, FILE_NAME1, FooterHeading);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new BannerService().BannerGetByDelete(FILE_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new BannerService().BannerGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
