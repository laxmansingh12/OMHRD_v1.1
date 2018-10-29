using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductAddtoCartMaster : BusinessBaseObject
    {
        #region
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public string ITEMNAME
        {
            get
            {
                PickUpItemMaster sm = PickUpItemMaster.GetByOrderId(Product_id);// PickUpItemMaster.GetByOrderId(ItemId).RATE_PER.ToString();
                return sm.ITEMNAME;
            }
        }
        public decimal Price
        {
            get
            {
                PickUpItemMaster sm = PickUpItemMaster.GetByOrderId(Product_id);// PickUpItemMaster.GetByOrderId(ItemId).RATE_PER.ToString();
                return sm.RATE_PER;
            }
        }
        public decimal Quantity { get; set; }

        public decimal Total { get { return Price * Quantity; } }

        public string UnitCode { get; set; }
        public string Color_Code { get; set; }

        #endregion

        #region Methods
        public static ProductAddtoCartMaster GetByCart_id(int Cart_id)
        {
            ProductAddtoCartMaster obj = new ProductAddtoCartMaster();
            obj.MapData(new ProductAddtoCartDataService().AddtoCartMaster_GetByCart_id(Cart_id));
            return obj;
        }
        public static ProductAddtoCartMaster GetByUser_id(int User_id)
        {
            ProductAddtoCartMaster obj = new ProductAddtoCartMaster();
            obj.MapData(new ProductAddtoCartDataService().AddtoCartMaster_GetByUser_id(User_id));
            return obj;
        }
        public static ProductAddtoCartMaster GetByUser_idProductID(int User_id, int Product_id)
        {
            ProductAddtoCartMaster obj = new ProductAddtoCartMaster();
            obj.MapData(new ProductAddtoCartDataService().AddtoCartMaster_GetByUser_idProductID(User_id, Product_id));
            return obj;
        }
        public override bool MapData(DataRow row)
        {
            Cart_id = GetInt(row, "Cart_id");
            User_id = GetInt(row, "User_id");
            Product_id = GetInt(row, "Product_id");
            Quantity = GetDecimal(row, "Quantity");
            UnitCode = GetString(row, "UnitCode");
            Color_Code = GetString(row, "Color_Code");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new ProductAddtoCartDataService().AddtoCartMasterSave(Cart_id, User_id, Product_id, Quantity, UnitCode, Color_Code);
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new ProductAddtoCartDataService().AddtoCartMaster_GetByDelete(Cart_id);
        }
        public void UserDelete(int User_id)
        {
            new ProductAddtoCartDataService().AddtoCartMaster_GetByDeleteUserId(User_id);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new ProductAddtoCartDataService().AddtoCartMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
