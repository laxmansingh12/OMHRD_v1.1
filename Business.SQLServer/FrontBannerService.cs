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
    public class FrontBannerService : DataServiceBase
    {

        #region Constructors

        public FrontBannerService() : base() { }
        public FrontBannerService(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void FrontBannerSave(int FILE_ID, string HEADING1, string HEADING2, string HEADING3, string HEADING4, string HEADING5, string FILE_NAME1, string FILE_NAME2, string FILE_NAME3, string FILE_NAME4, string FILE_NAME5)
        {
            SqlCommand cmd;
            DataSet ds = FrontBannerGetByFILE_ID(FILE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update FrontBannerMaster set [HEADING1]=@HEADING1,[HEADING2]=@HEADING2,[HEADING3]=@HEADING3,[HEADING4]=@HEADING4,[HEADING5]=@HEADING5,[FILE_NAME1]=@FILE_NAME1 ,[FILE_NAME2]=@FILE_NAME2,[FILE_NAME3]=@FILE_NAME3 ,[FILE_NAME4]=@FILE_NAME4,FILE_NAME5=@FILE_NAME5 WHERE FILE_ID=@FILE_ID",
                                 CreateParameter("@HEADING1", SqlDbType.VarChar, HEADING1),
                                 CreateParameter("@HEADING2", SqlDbType.VarChar, HEADING2),
                                 CreateParameter("@HEADING3", SqlDbType.VarChar, HEADING3),
                                  CreateParameter("@HEADING4", SqlDbType.VarChar, HEADING4),
                                 CreateParameter("@HEADING5", SqlDbType.VarChar, HEADING5),
                                 CreateParameter("@FILE_NAME1", SqlDbType.VarChar, FILE_NAME1),
                                 CreateParameter("@FILE_NAME2", SqlDbType.VarChar, FILE_NAME2),
                                 CreateParameter("@FILE_NAME3", SqlDbType.VarChar, FILE_NAME3),
                                 CreateParameter("@FILE_NAME4", SqlDbType.VarChar, FILE_NAME4),
                                   CreateParameter("@FILE_NAME5", SqlDbType.VarChar, FILE_NAME5),
                                 CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into FrontBannerMaster values(@FILE_ID, @HEADING1,@HEADING2,@HEADING3,@HEADING4,@HEADING5, @FILE_NAME1,@FILE_NAME2, @FILE_NAME3,@FILE_NAME4,@FILE_NAME5)",
                               CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID),
                               CreateParameter("@HEADING1", SqlDbType.VarChar, HEADING1),
                               CreateParameter("@HEADING2", SqlDbType.VarChar, HEADING2),
                               CreateParameter("@HEADING3", SqlDbType.VarChar, HEADING3),
                                 CreateParameter("@HEADING4", SqlDbType.VarChar, HEADING4),
                                 CreateParameter("@HEADING5", SqlDbType.VarChar, HEADING5),
                               CreateParameter("@FILE_NAME1", SqlDbType.VarChar, FILE_NAME1),
                                 CreateParameter("@FILE_NAME2", SqlDbType.VarChar, FILE_NAME2),
                                 CreateParameter("@FILE_NAME3", SqlDbType.VarChar, FILE_NAME3),
                                 CreateParameter("@FILE_NAME4", SqlDbType.VarChar, FILE_NAME4),
                                   CreateParameter("@FILE_NAME5", SqlDbType.VarChar, FILE_NAME5));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet FrontBannerGetAll()
        {
            return ExecuteDataSet("Select * from FrontBannerMaster ", null, null);
        }

        public DataSet FrontBannerGetByFILE_ID(int FILE_ID)
        {
            return ExecuteDataSet("select * from FrontBannerMaster where FILE_ID=@FILE_ID", null,
                CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
        }

        public DataSet FrontBannerGetMaxID()
        {
            return ExecuteDataSet("select MAX(FILE_ID)from FrontBannerMaster", null, null);
        }

        public DataSet FrontBannerGetByDelete(int FILE_ID)
        {
            return ExecuteDataSet("Delete from FrontBannerMaster where FILE_ID=@FILE_ID", null,
                CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
        }
        #endregion
    }
}
