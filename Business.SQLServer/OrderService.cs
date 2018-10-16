using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class OrderService : DataServiceBase
    {

        #region Constructors

        public OrderService() : base() { }
        public OrderService(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void OrderSave(int OrderId, int ITEM_ID, decimal QUANTITY, decimal RATE_PER, decimal TOTAL, int OrderBILL_ID, DateTime OrderDate, int PickupID)
        {
            SqlCommand cmd;
            DataSet ds = OrderGetByOrderId(OrderId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update Order_Master set [ITEM_ID]=@ITEM_ID,[QUANTITY]=@QUANTITY,[RATE_PER]=@RATE_PER,[TOTAL]=@TOTAL,[OrderBILL_ID]=@OrderBILL_ID,[OrderDate]=@OrderDate,[PickupID]=@PickupID WHERE OrderId=@OrderId",
                                 CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                                 CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                                 CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                                 CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                 CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID),
                                 CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate),
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID),
                                 CreateParameter("@OrderId", SqlDbType.Int, OrderId));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into Order_Master values(@OrderId, @ITEM_ID, @QUANTITY, @RATE_PER, @TOTAL, @OrderBILL_ID, @OrderDate, @PickupID)",
                                 CreateParameter("@OrderId", SqlDbType.Int, OrderId),
                                 CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                                 CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                                 CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                                 CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                 CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID),
                                 CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate),
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet OrderGetAll()
        {
            return ExecuteDataSet("Select * from Order_Master ", null, null);
        }

        public DataSet OrderGetByOrderId(int OrderId)
        {
            return ExecuteDataSet("select * from Order_Master where OrderId=@OrderId", null,
                CreateParameter("@OrderId", SqlDbType.Int, OrderId));
        }

        public DataSet OrderGetMaxID()
        {
            return ExecuteDataSet("select MAX(OrderId)from Order_Master", null, null);
        }

        public DataSet OrderGetByDelete(int OrderId)
        {
            return ExecuteDataSet("Delete from Order_Master where OrderId=@OrderId", null,
                CreateParameter("@OrderId", SqlDbType.Int, OrderId));
        }
        #endregion
    }
}
