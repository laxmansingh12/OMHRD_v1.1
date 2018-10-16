using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class SourceMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public SourceMasterDataService() : base() { }
        public SourceMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void SourceMaster_Save(int SOURCE_ID, string SOURCE_NAME, float PAYMENT, DateTime DATE, string REMAEK)
        {
            SqlCommand cmd;
            DataSet ds = SourceMaster_GetById(SOURCE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE SOURCE_MASTER set  SOURCE_NAME=@SOURCE_NAME,PAYMENT=@PAYMENT,DATE=@DATE, REMAEK=@REMAEK where SOURCE_ID=@SOURCE_ID",
                         CreateParameter("@SOURCE_NAME", SqlDbType.VarChar, SOURCE_NAME),
                         CreateParameter("@PAYMENT", SqlDbType.Float, PAYMENT),
                         CreateParameter("@DATE", SqlDbType.Date, DATE),
                         CreateParameter("@REMAEK", SqlDbType.VarChar, REMAEK),
                         CreateParameter("@SOURCE_ID", SqlDbType.Int, SOURCE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO SOURCE_MASTER VALUES(@SOURCE_ID,@SOURCE_NAME,@PAYMENT,@DATE,@REMAEK)",
                         CreateParameter("@SOURCE_ID", SqlDbType.Int, SOURCE_ID),
                         CreateParameter("@SOURCE_NAME", SqlDbType.VarChar, SOURCE_NAME),
                         CreateParameter("@PAYMENT", SqlDbType.Float, PAYMENT),
                         CreateParameter("@DATE", SqlDbType.Date, DATE),
                         CreateParameter("@REMAEK", SqlDbType.VarChar, REMAEK));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet SourceMaster_GetAll()
        {
            return ExecuteDataSet("select * from SOURCE_MASTER ", null, null);
        }

        public DataSet SourceMaster_GetById(int SOURCE_ID)
        {
            return ExecuteDataSet("select * from SOURCE_MASTER where SOURCE_ID=@SOURCE_ID", null,
            CreateParameter("@SOURCE_ID", SqlDbType.Int, SOURCE_ID));
        }

        public DataSet SourceMaster_GetByDATE(DateTime DATE)
        {
            return ExecuteDataSet("select * from SOURCE_MASTER where DATE=@DATE ", null,
            CreateParameter("@DATE", SqlDbType.Date, DATE));
           
        }


        public DataSet SourceMaster_Delete(int SOURCE_ID)
        {
            return ExecuteDataSet("Delete from SOURCE_MASTER where SOURCE_ID=@SOURCE_ID", null,
            CreateParameter("@SOURCE_ID", SqlDbType.Int, SOURCE_ID));
        }

        public DataSet SourceMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(SOURCE_ID)  from SOURCE_MASTER", null, null);
        }

        #endregion

       
    }
}
