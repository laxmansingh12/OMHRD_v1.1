using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class AddtoCartMaster : BusinessBaseObject
    {
        #region
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Product_Image { get; set; }
        #endregion

        #region Methods
        public static AddtoCartMaster GetByCart_id(int Cart_id)
        {
            AddtoCartMaster obj = new AddtoCartMaster();
            obj.MapData(new AddtoCartDataService().AddtoCartMaster_GetByCart_id(Cart_id));
            return obj;
        }
        public static AddtoCartMaster GetByUser_id(int User_id)
        {
            AddtoCartMaster obj = new AddtoCartMaster();
            obj.MapData(new AddtoCartDataService().AddtoCartMaster_GetByUser_id(User_id));
            return obj;
        }
        public static AddtoCartMaster GetByUser_idProductID(int User_id,int Product_id)
        {
            AddtoCartMaster obj = new AddtoCartMaster();
            obj.MapData(new AddtoCartDataService().AddtoCartMaster_GetByUser_idProductID(User_id, Product_id));
            return obj;
        }
        public override bool MapData(DataRow row)
        {
            Cart_id = GetInt(row, "Cart_id");
            User_id = GetInt(row, "User_id");
            Product_id = GetInt(row, "Product_id");
            Quantity = GetDecimal(row, "Quantity");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new AddtoCartDataService().AddtoCartMasterSave(Cart_id, User_id, Product_id, Quantity);
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new AddtoCartDataService().AddtoCartMaster_GetByDelete(Cart_id);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new AddtoCartDataService().AddtoCartMaster_GetMAXId();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;

        }
        #endregion
    }
}
