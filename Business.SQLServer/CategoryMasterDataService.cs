using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class CategoryMasterDataService : DataServiceBase
    {
        #region Constructors

        public CategoryMasterDataService() : base() { }
        public CategoryMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void CategoryMaster_Save(int CATEGORY_ID, string CATEGORY_NAME, string REMARK, string DEALS_IN)
        {

            SqlCommand cmd;
            DataSet ds = CategoryMaster_GetByCATEGORY_ID(CATEGORY_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE CATEGORY_MASTER SET CATEGORY_NAME=@CATEGORY_NAME,REMARK=@REMARK,DEALS_IN=@DEALS_IN WHERE CATEGORY_ID=@CATEGORY_ID ",
                           CreateParameter("@CATEGORY_NAME", SqlDbType.VarChar, CATEGORY_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK),
                             CreateParameter("@DEALS_IN", SqlDbType.VarChar, DEALS_IN),
                            CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO CATEGORY_MASTER VALUES(@CATEGORY_ID,@CATEGORY_NAME,@REMARK,@DEALS_IN)",
                           CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                           CreateParameter("@CATEGORY_NAME", SqlDbType.VarChar, CATEGORY_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK),
                              CreateParameter("@DEALS_IN", SqlDbType.VarChar, DEALS_IN));


            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet CategoryMaster_GetByCATEGORY_ID(int CATEGORY_ID)
        {
            return ExecuteDataSet("select * from CATEGORY_MASTER where CATEGORY_ID=@CATEGORY_ID", null,
                CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID));
        }

        public DataSet CategoryMaster_GetByCATEGORY_NAME(string CATEGORY_NAME)
        {
            return ExecuteDataSet("select * from CATEGORY_MASTER where CATEGORY_NAME=@CATEGORY_NAME", null,
                CreateParameter("@CATEGORY_NAME", SqlDbType.VarChar, CATEGORY_NAME));
        }

        public DataSet CategoryMaster_GetAll()
        {
            return ExecuteDataSet("select * from CATEGORY_MASTER  ", null, null);
        }

        public DataSet CategoryMaster_Delete(int CATEGORY_ID)
        {
            return ExecuteDataSet("Delete from CATEGORY_MASTER where CATEGORY_ID=@CATEGORY_ID", null,
            CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID));
        }
        public DataSet CategoryMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(CATEGORY_ID) as CATEGORY_ID from CATEGORY_MASTER", null, null);

        }
        #endregion
    }
}
