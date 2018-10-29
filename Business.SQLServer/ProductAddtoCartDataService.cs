using System;
using System.Data;
using Business.Common;

using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class ProductAddtoCartDataService : DataServiceBase
    {
        #region Constructors

        public ProductAddtoCartDataService() : base() { }
        public ProductAddtoCartDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void AddtoCartMasterSave(int Cart_id, int User_id, int Product_id, decimal Quantity, string UnitCode, string Color_Code)
        {

            SqlCommand cmd;
            DataSet ds = AddtoCartMaster_GetByCart_id(Cart_id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE ProductAddtoCart SET User_id=@User_id,Product_id=@Product_id,Quantity=@Quantity,UnitCode=@UnitCode,Color_Code=@Color_Code WHERE Cart_id=@Cart_id",
                    CreateParameter("@User_id", SqlDbType.Int, User_id),
                    CreateParameter("@Product_id", SqlDbType.Int, Product_id),
                    CreateParameter("@Quantity", SqlDbType.Decimal, Quantity),
                    CreateParameter("@UnitCode", SqlDbType.VarChar, UnitCode),
                    CreateParameter("@Color_Code", SqlDbType.VarChar, Color_Code),
                    CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));

            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO ProductAddtoCart VALUES(@Cart_id,@User_id,@Product_id,@Quantity,@UnitCode,@Color_Code)",
                    CreateParameter("@Cart_id", SqlDbType.Int, Cart_id),
                    CreateParameter("@User_id", SqlDbType.Int, User_id),
                    CreateParameter("@Product_id", SqlDbType.Int, Product_id),
                    CreateParameter("@Quantity", SqlDbType.Decimal, Quantity),
                    CreateParameter("@UnitCode", SqlDbType.VarChar, UnitCode),
                    CreateParameter("@Color_Code", SqlDbType.VarChar, Color_Code));

            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet AddtoCartMaster_GetByCart_id(int Cart_id)
        {
            return ExecuteDataSet("select * from ProductAddtoCart where Cart_id=@Cart_id", null,
                CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));
        }

        public DataSet AddtoCartMaster_GetByUser_id(int User_id)
        {
            return ExecuteDataSet("select * from ProductAddtoCart where User_id=@User_id", null,
                CreateParameter("@User_id", SqlDbType.Int, User_id));
        }
        public DataSet AddtoCartMaster_GetByUser_idProductID(int User_id, int Product_id)
        {
            return ExecuteDataSet("select * from ProductAddtoCart where User_id=@User_id and Product_id=@Product_id", null,
                CreateParameter("@User_id", SqlDbType.Int, User_id),
                 CreateParameter("@Product_id", SqlDbType.Int, Product_id));
        }

        public DataSet AddtoCartMaster_GetAll()
        {
            return ExecuteDataSet("select * from ProductAddtoCart", null, null);
        }


        public DataSet AddtoCartMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(Cart_id)from ProductAddtoCart", null, null);

        }
        public DataSet AddtoCartMaster_GetByDelete(int Cart_id)
        {
            return ExecuteDataSet("Delete from ProductAddtoCart where Cart_id=@Cart_id", null,
                CreateParameter("@Cart_id", SqlDbType.Int, Cart_id));
        }

        #endregion

    }
}
