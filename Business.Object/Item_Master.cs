using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class ITEM_MASTER : BusinessBaseObject
    {
        #region

        public int ITEM_ID { get; set; }
        public string ITEMNAME { get; set; }
        public int CATEGORY_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public string CODE { get; set; }
        public string HSNCODE { get; set; }
        public int UNIT_ID { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public decimal OPEN_STOCK { get; set; }
        public int Size_ID { get; set; }
        public int Color_ID { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }

        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            ITEM_ID = GetInt(row, "ITEM_ID");
            ITEMNAME = GetString(row, "ITEMNAME");
            // CATEGORY_ID = GetInt(row, "CATEGORY_ID");
            SubCategory_ID = GetInt(row, "SubCategory_ID");
            CODE = GetString(row, "CODE");
            HSNCODE = GetString(row, "HSNCODE");
            // UNIT_ID = GetInt(row, "UNIT_ID");
            CGST = GetDecimal(row, "CGST");
            SGST = GetDecimal(row, "SGST");
            IGST = GetDecimal(row, "IGST");
            Description = GetString(row, "Description");
            // Remarks = GetString(row, "Remarks");
            OPEN_STOCK = GetDecimal(row, "OPEN_STOCK");
            // Size_ID = GetInt(row, "Size_ID");
            // Color_ID = GetInt(row, "Color_ID");
            // DiscountPrice = GetDecimal(row, "DiscountPrice");
            Price = GetDecimal(row, "Price");
            Image = GetString(row, "Image");
            Image1 = GetString(row, "Image1");
            Image2 = GetString(row, "Image2");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }

        public static ITEM_MASTER GetByITEM_ID(int ITEM_ID)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEM_ID(ITEM_ID));
            return obj;
        }
        public static ITEM_MASTER GetByITEM_IDRATE(int ITEM_ID)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEM_IDRATE(ITEM_ID));
            return obj;
        }
        public static ITEM_MASTER GetByITEMColorAndUnit(string UnitCode, string Color_Code, int ITEM_ID)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEM_IDColorAndUnit(UnitCode, Color_Code, ITEM_ID));
            return obj;
        }
        public static ITEM_MASTER GetByITEMNAME(string ITEMNAME)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEMNAME(ITEMNAME));
            return obj;
        }
        public static ITEM_MASTER GetBySubCategory_ID(int SubCategory_ID)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetBySubCategory_ID(SubCategory_ID));
            return obj;
        }
        public void Save(IDbTransaction txn)
        {
            new ITEM_MASTERDataService().ITEM_MASTER_Save(ITEM_ID, ITEMNAME, SubCategory_ID, CODE, HSNCODE, CGST, SGST, IGST, Description, OPEN_STOCK, Image, Image1, Image2);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new ITEM_MASTERDataService().ITEM_MASTER_Delete(ITEM_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new ITEM_MASTERDataService().ITEM_MASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}
