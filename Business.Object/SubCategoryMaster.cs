using System;
using System.Data;
using Business.Common;
using Business.SQLServer;


namespace Business.Object
{
    public class SubCategoryMaster : BusinessBaseObject
    {
        #region
        public int SubCategory_ID { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name
        {
            get
            {
                CategoryMaster sm = CategoryMaster.GetByCATEGORY_ID(Category_ID);
                return sm.CATEGORY_NAME.ToString();
            }
        }
        public string SubCategory_NAME { get; set; }
        public string REMARK { get; set; }

        #endregion

        #region Methods
        public static SubCategoryMaster GetBySubCategory_ID(int SubCategory_ID)
        {
            SubCategoryMaster obj = new SubCategoryMaster();
            obj.MapData(new SubCategoryMasterDataService().SubCategoryMaster_GetBySubCategory_ID(SubCategory_ID));
            return obj;
        }
        public static SubCategoryMaster GetByCategory_ID(int SubCategory_ID)
        {
            SubCategoryMaster obj = new SubCategoryMaster();
            obj.MapData(new SubCategoryMasterDataService().SubCategoryMaster_GetByCategory_ID(SubCategory_ID));
            return obj;
        }
        public static SubCategoryMaster GetBySubCategory_NAME(string SubCategory_NAME)
        {
            SubCategoryMaster obj = new SubCategoryMaster();
            obj.MapData(new SubCategoryMasterDataService().SubCategoryMaster_GetBySubCategory_NAME(SubCategory_NAME));
            return obj;
        }

        public override bool MapData(DataRow row)
        {
            SubCategory_ID = GetInt(row, "SubCategory_ID");
            Category_ID = GetInt(row, "Category_ID");
            SubCategory_NAME = GetString(row, "SubCategory_NAME");
            REMARK = GetString(row, "REMARK");

            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new SubCategoryMasterDataService().SubCategoryMaster_Save(SubCategory_ID, Category_ID, SubCategory_NAME, REMARK);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new SubCategoryMasterDataService().SubCategoryMaster_Delete(SubCategory_ID);
        }
        public static int MaxID()
        {
            int result = 0;
            DataSet ds = new SubCategoryMasterDataService().SubCategoryMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
