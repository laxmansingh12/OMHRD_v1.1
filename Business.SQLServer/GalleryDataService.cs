using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class GalleryDataService : DataServiceBase
    {
        #region Constructors

        public GalleryDataService() : base() { }
        public GalleryDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void GallerySave(int Id, string FileName, string Heading)
        {

            SqlCommand cmd;
            DataSet ds = GalleryGetById(Id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE GalleryTbl SET FileName=@FileName,Heading=@Heading WHERE Id=@Id ",
                           CreateParameter("@FileName", SqlDbType.VarChar, FileName),
                           CreateParameter("@Heading", SqlDbType.VarChar, Heading),
                           CreateParameter("@Id", SqlDbType.Int, Id));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO GalleryTbl VALUES(@Id,@FileName,@Heading)",
                           CreateParameter("@Id", SqlDbType.Int, Id),
                           CreateParameter("@FileName", SqlDbType.VarChar, FileName),
                           CreateParameter("@Heading", SqlDbType.VarChar, Heading));
              }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet GalleryGetById(int Id)
        {
            return ExecuteDataSet("select * from GalleryTbl where Id=@Id", null,
                CreateParameter("@Id", SqlDbType.Int, Id));
        }

        public DataSet GalleryGetByFileName(string FileName)
        {
            return ExecuteDataSet("select * from GalleryTbl where FileName=@FileName", null,
                CreateParameter("@FileName", SqlDbType.VarChar, FileName));
        }

        public DataSet GalleryGetAll()
        {
            return ExecuteDataSet("select * from GalleryTbl  ", null, null);
        }

        public DataSet GalleryDelete(int Id)
        {
            return ExecuteDataSet("Delete from GalleryTbl where Id=@Id", null,
            CreateParameter("@Id", SqlDbType.Int, Id));
        }
        public DataSet GalleryGetMAXId()
        {
            return ExecuteDataSet("select max(Id) as Id from GalleryTbl", null, null);

        }
        #endregion
    }
}
