using System;
using System.Data;
using Business.Common;

using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class AddtoCartDataService : DataServiceBase
    {
        #region Constructors

        public AddtoCartDataService() : base() { }
        public AddtoCartDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void AddtoCartMasterSave(int Cart_id, int User_id, int Product_id, decimal Quantity)
        {

            SqlCommand cmd;
            DataSet ds = AddtoCartMaster_GetByCart_id(Cart_id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE AddtoCart SET User_id=@User_id,Product_id=@Product_id,Quantity=@Quantity WHERE Cart_id=@Cart_id",
                    CreateParameter("@User_id", SqlDbType.Int, User_id),
                    CreateParameter("@Product_id", SqlDbType.Int, Product_id),
                    CreateParameter("@Quantity", SqlDbType.Decimal, Quantity),
                    CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));

            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO AddtoCart VALUES(@Cart_id,@User_id,@Product_id,@Quantity)",
                    CreateParameter("@Cart_id", SqlDbType.Int, Cart_id),
                    CreateParameter("@User_id", SqlDbType.Int, User_id),
                    CreateParameter("@Product_id", SqlDbType.Int, Product_id),
                    CreateParameter("@Quantity", SqlDbType.Decimal, Quantity));

            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet AddtoCartMaster_GetByCart_id(int Cart_id)
        {
            return ExecuteDataSet("select * from AddtoCart where Cart_id=@Cart_id", null,
                CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));
        }

        public DataSet AddtoCartMaster_GetByUser_id(int User_id)
        {
            return ExecuteDataSet("select * from AddtoCart where User_id=@User_id", null,
                CreateParameter("@User_id", SqlDbType.Int, User_id));
        }
        public DataSet AddtoCartMaster_GetByUser_idProductID(int User_id, int Product_id)
        {
            return ExecuteDataSet("select * from AddtoCart where User_id=@User_id and Product_id=@Product_id", null,
                CreateParameter("@User_id", SqlDbType.Int, User_id),
                 CreateParameter("@Product_id", SqlDbType.Int, Product_id));
        }

        public DataSet AddtoCartMaster_GetAll()
        {
            return ExecuteDataSet("select * from AddtoCart", null, null);
        }


        public DataSet AddtoCartMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(Cart_id)from AddtoCart", null, null);

        }
        public DataSet AddtoCartMaster_GetByDelete(int Cart_id)
        {
            return ExecuteDataSet("Delete from AddtoCart where Cart_id=@Cart_id", null,
                CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));
        }

        #endregion

    }
}
