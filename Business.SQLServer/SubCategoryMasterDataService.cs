using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class SubCategoryMasterDataService : DataServiceBase
    {
        #region Constructors

        public SubCategoryMasterDataService() : base() { }
        public SubCategoryMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void SubCategoryMaster_Save(int SubCategory_ID,int CATEGORY_ID, string SubCategory_NAME, string REMARK)
        {

            SqlCommand cmd;
            DataSet ds = SubCategoryMaster_GetBySubCategory_ID(SubCategory_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE SubCategory_MASTER SET CATEGORY_ID=@CATEGORY_ID, SubCategory_NAME=@SubCategory_NAME,REMARK=@REMARK WHERE SubCategory_ID=@SubCategory_ID ",
                           CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                           CreateParameter("@SubCategory_NAME", SqlDbType.VarChar, SubCategory_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK),
                           CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO SubCategory_MASTER VALUES(@SubCategory_ID,@CATEGORY_ID,@SubCategory_NAME,@REMARK)",
                           CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID),
                           CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                           CreateParameter("@SubCategory_NAME", SqlDbType.VarChar, SubCategory_NAME),
                           CreateParameter("@REMARK", SqlDbType.VarChar, REMARK));


            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet SubCategoryMaster_GetBySubCategory_ID(int SubCategory_ID)
        {
            return ExecuteDataSet("select * from SubCategory_MASTER where SubCategory_ID=@SubCategory_ID", null,
                CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID));
        }
        public DataSet SubCategoryMaster_GetByCategory_ID(int SubCategory_ID)
        {
            return ExecuteDataSet("select * from SubCategory_MASTER where SubCategory_ID=@SubCategory_ID", null,
                CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID));
        }
        public DataSet SubCategoryMaster_GetBySubCategory_NAME(string SubCategory_NAME)
        {
            return ExecuteDataSet("select * from SubCategory_MASTER where SubCategory_NAME=@SubCategory_NAME", null,
                CreateParameter("@SubCategory_NAME", SqlDbType.VarChar, SubCategory_NAME));
        }

        public DataSet SubCategoryMaster_GetAll()
        {
            return ExecuteDataSet("select * from SubCategory_MASTER  ", null, null);
        }

        public DataSet SubCategoryMaster_Delete(int SubCategory_ID)
        {
            return ExecuteDataSet("Delete from SubCategory_MASTER where SubCategory_ID=@SubCategory_ID", null,
            CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID));
        }
        public DataSet SubCategoryMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(SubCategory_ID) as SubCategory_ID from SubCategory_MASTER", null, null);

        }
        #endregion
    }
}
