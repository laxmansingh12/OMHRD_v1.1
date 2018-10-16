using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class OrderMaster : BusinessBaseObject
    {
        #region Properties
        public int OrderId { get; set; }
        public int ITEM_ID { get; set; }
        public string ItemName
        {
            get
            {
                ITEM_MASTER sm = ITEM_MASTER.GetByITEM_ID(ITEM_ID);
                return sm.ITEMNAME.ToString();
            }
        }
        public decimal QUANTITY { get; set; }
        public decimal RATE_PER { get; set; }
        public decimal TOTAL { get; set; }
        public int OrderBILL_ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int PickupID { get; set; }
        #endregion


        #region Methods
        public override bool MapData(DataRow row)
        {
            OrderId = GetInt(row, "OrderId");
            ITEM_ID = GetInt(row, "ITEM_ID");
            QUANTITY = GetDecimal(row, "QUANTITY");
            RATE_PER = GetDecimal(row, "RATE_PER");
            TOTAL = GetDecimal(row, "TOTAL");
            OrderBILL_ID = GetInt(row, "OrderBILL_ID");
            OrderDate = GetDateTime(row, "OrderDate");
            PickupID = GetInt(row, "PickupID");
            return base.MapData(row);
        }
        public static OrderMaster GetByOrderId(int OrderId)
        {
            OrderMaster obj = new OrderMaster();
            obj.MapData(new OrderService().OrderGetByOrderId(OrderId));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new OrderService().OrderSave(OrderId, ITEM_ID, QUANTITY, RATE_PER, TOTAL, OrderBILL_ID, OrderDate, PickupID);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new OrderService().OrderGetByDelete(OrderId);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new OrderService().OrderGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
