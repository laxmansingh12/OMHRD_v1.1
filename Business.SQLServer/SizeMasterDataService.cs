using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class SizeMasterDataService : DataServiceBase
    {
        #region Constructors

        public SizeMasterDataService() : base() { }
        public SizeMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void SizeMaster_Save(int Size_ID, string Size_NAME, string REMARK)
        {

            SqlCommand cmd;
            DataSet ds = SizeMaster_GetBySize_ID(Size_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE Size_MASTER SET Size_NAME=@Size_NAME,REMARK=@REMARK WHERE Size_ID=@Size_ID ",
                           CreateParameter("@Size_NAME", SqlDbType.VarChar, Size_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK),
                           CreateParameter("@Size_ID", SqlDbType.Int, Size_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO Size_MASTER VALUES(@Size_ID,@Size_NAME,@REMARK)",
                           CreateParameter("@Size_ID", SqlDbType.Int, Size_ID),
                           CreateParameter("@Size_NAME", SqlDbType.VarChar, Size_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK));
              }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet SizeMaster_GetBySize_ID(int Size_ID)
        {
            return ExecuteDataSet("select * from Size_MASTER where Size_ID=@Size_ID", null,
                CreateParameter("@Size_ID", SqlDbType.Int, Size_ID));
        }

        public DataSet SizeMaster_GetBySize_NAME(string Size_NAME)
        {
            return ExecuteDataSet("select * from Size_MASTER where Size_NAME=@Size_NAME", null,
                CreateParameter("@Size_NAME", SqlDbType.VarChar, Size_NAME));
        }

        public DataSet SizeMaster_GetAll()
        {
            return ExecuteDataSet("select * from Size_MASTER  ", null, null);
        }

        public DataSet SizeMaster_Delete(int Size_ID)
        {
            return ExecuteDataSet("Delete from Size_MASTER where Size_ID=@Size_ID", null,
            CreateParameter("@Size_ID", SqlDbType.Int, Size_ID));
        }
        public DataSet SizeMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(Size_ID) as Size_ID from Size_MASTER", null, null);

        }
        #endregion
    }
}
