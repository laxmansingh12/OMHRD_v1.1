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
    public class BannerService : DataServiceBase
    {

        #region Constructors

        public BannerService() : base() { }
        public BannerService(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void BannerSave(int FILE_ID, string HEADING1, string HEADING2, string HEADING3, string ATTETMENT, string FILE_NAME, string ATTETMENT1, string FILE_NAME1, string FooterHeading)
        {
            SqlCommand cmd;
            DataSet ds = BannerGetByFILE_ID(FILE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update Banner_Master set [HEADING1]=@HEADING1,[HEADING2]=@HEADING2,[HEADING3]=@HEADING3,[ATTETMENT]=@ATTETMENT ,[FILE_NAME]=@FILE_NAME,[ATTETMENT1]=@ATTETMENT1 ,[FILE_NAME1]=@FILE_NAME1,FooterHeading=@FooterHeading WHERE FILE_ID=@FILE_ID",
                                 CreateParameter("@HEADING1", SqlDbType.VarChar, HEADING1),
                                 CreateParameter("@HEADING2", SqlDbType.VarChar, HEADING2),
                                 CreateParameter("@HEADING3", SqlDbType.VarChar, HEADING3),
                                 CreateParameter("@ATTETMENT", SqlDbType.VarChar, ATTETMENT),
                                 CreateParameter("@FILE_NAME", SqlDbType.VarChar, FILE_NAME),
                                 CreateParameter("@ATTETMENT1", SqlDbType.VarChar, ATTETMENT1),
                                 CreateParameter("@FILE_NAME1", SqlDbType.VarChar, FILE_NAME1),
                                   CreateParameter("@FooterHeading", SqlDbType.VarChar, FooterHeading),
                                 CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into Banner_Master values(@FILE_ID, @HEADING1,@HEADING2,@HEADING3, @ATTETMENT,@FILE_NAME, @ATTETMENT1,@FILE_NAME1,@FooterHeading)",
                               CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID),
                               CreateParameter("@HEADING1", SqlDbType.VarChar, HEADING1),
                               CreateParameter("@HEADING2", SqlDbType.VarChar, HEADING2),
                               CreateParameter("@HEADING3", SqlDbType.VarChar, HEADING3),
                               CreateParameter("@ATTETMENT", SqlDbType.VarChar, ATTETMENT),
                               CreateParameter("@FILE_NAME", SqlDbType.VarChar, FILE_NAME),
                                CreateParameter("@ATTETMENT1", SqlDbType.VarChar, ATTETMENT1),
                                 CreateParameter("@FILE_NAME1", SqlDbType.VarChar, FILE_NAME1),
                                  CreateParameter("@FooterHeading", SqlDbType.VarChar, FooterHeading));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet BannerGetAll()
        {
            return ExecuteDataSet("Select * from Banner_Master ", null, null);
        }

        public DataSet BannerGetByFILE_ID(int FILE_ID)
        {
            return ExecuteDataSet("select * from Banner_Master where FILE_ID=@FILE_ID", null,
                CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
        }

        public DataSet BannerGetMaxID()
        {
            return ExecuteDataSet("select MAX(FILE_ID)from Banner_Master", null, null);
        }

        public DataSet BannerGetByDelete(int FILE_ID)
        {
            return ExecuteDataSet("Delete from Banner_Master where FILE_ID=@FILE_ID", null,
                CreateParameter("@FILE_ID", SqlDbType.Int, FILE_ID));
        }
        #endregion
    }
}
