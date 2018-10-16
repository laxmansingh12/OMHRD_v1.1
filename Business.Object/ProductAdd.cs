using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductAdd : BusinessBaseObject
    {
        #region Properties
        public int PRO_ID { get; set; }
        public string PRO_CATE { get; set; }
        public string PRO_NAME { get; set; }
        public string PRO_CODE { get; set; }
        public string Description { get; set; }
        public string ATTETMENT { get; set; }
        public string FILE_NAME { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            PRO_ID = GetInt(row, "PRO_ID");
            PRO_CATE = GetString(row, "PRO_CATE");
            PRO_NAME = GetString(row, "PRO_NAME");
            PRO_CODE = GetString(row, "PRO_CODE");
            Description = GetString(row, "Description");
            ATTETMENT = GetString(row, "ATTETMENT");
            FILE_NAME = GetString(row, "FILE_NAME");
            return base.MapData(row);
        }
        public static ProductAdd GetByPRO_ID(int PRO_ID)
        {
            ProductAdd obj = new ProductAdd();
            obj.MapData(new ProductAddService().ProductAddGetByPRO_ID(PRO_ID));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new ProductAddService().ProductAddSave(PRO_ID, PRO_CATE, PRO_NAME, PRO_CODE, Description, ATTETMENT, FILE_NAME);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new ProductAddService().ProductAddGetByDelete(PRO_ID);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new ProductAddService().ProductAddGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
