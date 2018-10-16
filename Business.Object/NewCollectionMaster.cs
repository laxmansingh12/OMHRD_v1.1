using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class NewCollectionMaster : BusinessBaseObject
    {
        #region

        public int NewCollection_ID { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEMNAME { get; set; }
        public int CATEGORY_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }


        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            NewCollection_ID = GetInt(row, "NewCollection_ID");
            ITEM_ID = GetInt(row, "ITEM_ID");
            ITEMNAME = GetString(row, "ITEMNAME");
            CATEGORY_ID = GetInt(row, "CATEGORY_ID");
            SubCategory_ID = GetInt(row, "SubCategory_ID");
            Description = GetString(row, "Description");
            DiscountPrice = GetDecimal(row, "DiscountPrice");
            Price = GetDecimal(row, "Price");
            Image = GetString(row, "Image");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }

        public static NewCollectionMaster GetByNewCollection_ID(int NewCollection_ID)
        {
            NewCollectionMaster obj = new NewCollectionMaster();
            obj.MapData(new NewCollectionDataService().NewCollection_GetByNewCollection_ID(NewCollection_ID));
            return obj;
        }
        public static NewCollectionMaster GetByITEMNAME(string ITEMNAME)
        {
            NewCollectionMaster obj = new NewCollectionMaster();
            obj.MapData(new NewCollectionDataService().NewCollection_GetByITEMNAME(ITEMNAME));
            return obj;
        }

        public void Save(IDbTransaction txn)
        {
            new NewCollectionDataService().NewCollection_Save(NewCollection_ID, ITEM_ID, ITEMNAME, CATEGORY_ID, SubCategory_ID, Description, DiscountPrice, Price, Image);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new NewCollectionDataService().NewCollection_Delete(NewCollection_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new NewCollectionDataService().NewCollection_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}
