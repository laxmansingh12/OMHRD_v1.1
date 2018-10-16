using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class CropTypeMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public CropTypeMasterDataService() : base() { }
        public CropTypeMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void CropTypeMaster_Save(int CROPS_TYPE_ID, string CROPS_TYPE,string REMARKS)
        {
            SqlCommand cmd;
            DataSet ds = CropTypeMaster_GetById(CROPS_TYPE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE CROP_TYPE_MASTER set CROPS_TYPE=@CROPS_TYPE,REMARKS=@REMARKS where CROPS_TYPE_ID=@CROPS_TYPE_ID",
                         CreateParameter("@CROPS_TYPE", SqlDbType.VarChar, CROPS_TYPE),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@CROPS_TYPE_ID", SqlDbType.Int, CROPS_TYPE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO CROP_TYPE_MASTER VALUES(@CROPS_TYPE_ID,@CROPS_TYPE,@REMARKS)",
                         CreateParameter("@CROPS_TYPE_ID", SqlDbType.Int, CROPS_TYPE_ID),
                         CreateParameter("@CROPS_TYPE", SqlDbType.VarChar, CROPS_TYPE),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet CropTypeMaster_GetAll()
        {
            return ExecuteDataSet("select * from CROP_TYPE_MASTER ", null, null);
        }

        public DataSet CropTypeMaster_GetById(int CROPS_TYPE_ID)
        {
            return ExecuteDataSet("select * from CROP_TYPE_MASTER where CROPS_TYPE_ID=@CROPS_TYPE_ID", null,
            CreateParameter("@CROPS_TYPE_ID", SqlDbType.Int, CROPS_TYPE_ID));
        }

        public DataSet CropTypeMaster_GetByName(string CROPS_TYPE)
        {
            return ExecuteDataSet("select * from CROP_TYPE_MASTER where CROPS_TYPE=@CROPS_TYPE", null,
            CreateParameter("@CROPS_TYPE", SqlDbType.VarChar, CROPS_TYPE));
        }

        public DataSet CropTypeMaster_Delete(int CROPS_TYPE_ID)
        {
            return ExecuteDataSet("Delete from CROP_TYPE_MASTER where CROPS_TYPE_ID=@CROPS_TYPE_ID", null,
            CreateParameter("@CROPS_TYPE_ID", SqlDbType.Int, CROPS_TYPE_ID));
        }

        public DataSet CropTypeMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(CROPS_TYPE_ID)  from CROP_TYPE_MASTER", null, null);
        }

        #endregion

        //public void FarmerMaster_Save(int FARMER_ID, string DAYAL_ID, string NAME, string ADDRESS, string PINCODE, string CONTACT, string REMARKS)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
