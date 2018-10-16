using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class ColorMasterDataService : DataServiceBase
    {
        #region Constructors

        public ColorMasterDataService() : base() { }
        public ColorMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void ColorMaster_Save(int Color_ID, string Color_NAME,string Color_Code, string REMARK)
        {

            SqlCommand cmd;
            DataSet ds = ColorMaster_GetByColor_ID(Color_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE Color_MASTER SET Color_NAME=@Color_NAME,Color_Code=@Color_Code,REMARK=@REMARK WHERE Color_ID=@Color_ID ",
                           CreateParameter("@Color_NAME", SqlDbType.VarChar, Color_NAME),
                           CreateParameter("@Color_Code", SqlDbType.VarChar, Color_Code),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK),
                           CreateParameter("@Color_ID", SqlDbType.Int, Color_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO Color_MASTER VALUES(@Color_ID,@Color_NAME,@Color_Code,@REMARK)",
                           CreateParameter("@Color_ID", SqlDbType.Int, Color_ID),
                           CreateParameter("@Color_NAME", SqlDbType.VarChar, Color_NAME),
                           CreateParameter("@Color_Code", SqlDbType.VarChar, Color_Code),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK));
              }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet ColorMaster_GetByColor_ID(int Color_ID)
        {
            return ExecuteDataSet("select * from Color_MASTER where Color_ID=@Color_ID", null,
                CreateParameter("@Color_ID", SqlDbType.Int, Color_ID));
        }

        public DataSet ColorMaster_GetByColor_NAME(string Color_NAME)
        {
            return ExecuteDataSet("select * from Color_MASTER where Color_NAME=@Color_NAME", null,
                CreateParameter("@Color_NAME", SqlDbType.VarChar, Color_NAME));
        }

        public DataSet ColorMaster_GetAll()
        {
            return ExecuteDataSet("select * from Color_MASTER  ", null, null);
        }

        public DataSet ColorMaster_Delete(int Color_ID)
        {
            return ExecuteDataSet("Delete from Color_MASTER where Color_ID=@Color_ID", null,
            CreateParameter("@Color_ID", SqlDbType.Int, Color_ID));
        }
        public DataSet ColorMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(Color_ID) as Color_ID from Color_MASTER", null, null);

        }
        #endregion
    }
}
