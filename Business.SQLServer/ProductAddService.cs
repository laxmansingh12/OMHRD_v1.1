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
    public class ProductAddService : DataServiceBase
    {

        #region Constructors

        public ProductAddService() : base() { }
        public ProductAddService(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void ProductAddSave(int PRO_ID,string PRO_CATE, string PRO_NAME, string PRO_CODE, string Description, string ATTETMENT, string FILE_NAME)
        {
            SqlCommand cmd;
            DataSet ds = ProductAddGetByPRO_ID(PRO_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update PRODUCT_MASTER set[PRO_CATE]=@PRO_CATE, [PRO_NAME]=@PRO_NAME,[PRO_CODE]=@PRO_CODE ,[Description]=@Description,[ATTETMENT]=@ATTETMENT,[FILE_NAME]=@FILE_NAME WHERE PRO_ID=@PRO_ID",
                               CreateParameter("@PRO_CATE", SqlDbType.VarChar, PRO_CATE),
                               CreateParameter("@PRO_NAME", SqlDbType.VarChar, PRO_NAME),
                               CreateParameter("@PRO_CODE", SqlDbType.VarChar, PRO_CODE),
                               CreateParameter("@Description", SqlDbType.VarChar, Description),
                               CreateParameter("@ATTETMENT", SqlDbType.VarChar, ATTETMENT),
                               CreateParameter("@FILE_NAME", SqlDbType.VarChar, FILE_NAME),
                               CreateParameter("@PRO_ID", SqlDbType.Int, PRO_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into PRODUCT_MASTER values(@PRO_ID,@PRO_CATE, @PRO_NAME,@PRO_CODE,@Description, @ATTETMENT,@FILE_NAME)",
                               CreateParameter("@PRO_ID", SqlDbType.Int, PRO_ID),
                               CreateParameter("@PRO_CATE", SqlDbType.VarChar, PRO_CATE),
                               CreateParameter("@PRO_NAME", SqlDbType.VarChar, PRO_NAME),
                               CreateParameter("@PRO_CODE", SqlDbType.VarChar, PRO_CODE),
                               CreateParameter("@Description", SqlDbType.VarChar, Description),
                               CreateParameter("@ATTETMENT", SqlDbType.VarChar, ATTETMENT),
                               CreateParameter("@FILE_NAME", SqlDbType.VarChar, FILE_NAME));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet ProductAddGetAll()
        {
            return ExecuteDataSet("Select * from PRODUCT_MASTER ", null, null);
        }

        public DataSet ProductAddGetByPRO_ID(int PRO_ID)
        {
            return ExecuteDataSet("select * from PRODUCT_MASTER where PRO_ID=@PRO_ID", null,
                CreateParameter("@PRO_ID", SqlDbType.Int, PRO_ID));
        }
        public DataSet ProductAddGetByPRO_CATE(string PRO_CATE)
        {
            return ExecuteDataSet("select * from PRODUCT_MASTER where PRO_CATE=@PRO_CATE", null,
                CreateParameter("@PRO_CATE", SqlDbType.VarChar, PRO_CATE));
        }
        public DataSet ProductAddGetMaxID()
        {
            return ExecuteDataSet("select MAX(PRO_ID)from PRODUCT_MASTER", null, null);
        }

        public DataSet ProductAddGetByDelete(int PRO_ID)
        {
            return ExecuteDataSet("Delete from PRODUCT_MASTER where PRO_ID=@PRO_ID", null,
                CreateParameter("@PRO_ID", SqlDbType.Int, PRO_ID));
        }
        #endregion
    }
}
