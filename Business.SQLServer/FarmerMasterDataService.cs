using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class FarmerMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public FarmerMasterDataService() : base() { }
        public FarmerMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void FarmerMaster_Save(int HOTEL_ID, string HOTEL_NAME, string ADDRESS, string CONTACT)
        {
            SqlCommand cmd;
            DataSet ds = FarmerMaster_GetById(HOTEL_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE HOTEL_MASTER set HOTEL_NAME=@HOTEL_NAME, ADDRESS = @ADDRESS, CONTACT=@CONTACT where HOTEL_ID=@HOTEL_ID",
                         CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                         CreateParameter("@ADDRESS", SqlDbType.VarChar, ADDRESS),
                         CreateParameter("@CONTACT", SqlDbType.VarChar, CONTACT),
                         CreateParameter("@HOTEL_ID", SqlDbType.Int, HOTEL_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO HOTEL_MASTER(HOTEL_ID,HOTEL_NAME,ADDRESS,CONTACT)VALUES(@HOTEL_ID,@HOTEL_NAME,@ADDRESS,@CONTACT)",
                        CreateParameter("@HOTEL_ID", SqlDbType.Int, HOTEL_ID),
                        CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                        CreateParameter("@ADDRESS", SqlDbType.VarChar, ADDRESS),
                        CreateParameter("@CONTACT", SqlDbType.VarChar, CONTACT));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet FarmerMaster_GetAll()
        {
            return ExecuteDataSet("select * from HOTEL_MASTER ", null, null);
        }

        public DataSet FarmerMaster_GetById(int HOTEL_ID)
        {
            return ExecuteDataSet("select * from HOTEL_MASTER where HOTEL_ID=@HOTEL_ID", null,
            CreateParameter("@HOTEL_ID", SqlDbType.Int, HOTEL_ID));
        }

        public DataSet FarmerMaster_GetByName(string HOTEL_NAME)
        {
            return ExecuteDataSet("select * from HOTEL_MASTER where HOTEL_NAME=@HOTEL_NAME", null,
            CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME));
        }

        public DataSet FarmerMaster_Delete(int HOTEL_ID)
        {
            return ExecuteDataSet("Delete from HOTEL_MASTER where HOTEL_ID=@HOTEL_ID", null,
            CreateParameter("@HOTEL_ID", SqlDbType.Int, HOTEL_ID));
        }

        public DataSet FarmerMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(HOTEL_ID)  from HOTEL_MASTER", null, null);
        }

        #endregion
            
    }
}
