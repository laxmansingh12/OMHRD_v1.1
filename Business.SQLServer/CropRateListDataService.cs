using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
    public class CropRateListDataService : DataServiceBase
    {
        #region Consturctor

        public CropRateListDataService() : base() { }
        public CropRateListDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void CropRateList_Save(int CROPRate_ID, int HOtel_ID, string CROP_NAME, float RATE, string MONTH, string REMARKS)
        {
            SqlCommand cmd;
            DataSet ds = CropRateList_GetById(CROPRate_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE CROPRATELIST_MASTER set HOtel_ID=@HOtel_ID, CROP_NAME=@CROP_NAME, RATE=@RATE,MONTH=@MONTH, REMARKS=@REMARKS where CROPRate_ID=@CROPRate_ID",
                         CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
                         CreateParameter("@CROP_NAME", SqlDbType.VarChar, CROP_NAME),
                         CreateParameter("@RATE", SqlDbType.Float, RATE),
                         CreateParameter("@MONTH", SqlDbType.VarChar, MONTH),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@CROPRate_ID", SqlDbType.Int, CROPRate_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO CROPRATELIST_MASTER VALUES(@CROPRate_ID,@HOtel_ID,@CROP_NAME,@RATE,@MONTH,@REMARKS)",
                         CreateParameter("@CROPRate_ID", SqlDbType.Int, CROPRate_ID),
                          CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
                           CreateParameter("@CROP_NAME", SqlDbType.VarChar, CROP_NAME),
                         CreateParameter("@RATE", SqlDbType.Float, RATE),
                         CreateParameter("@MONTH", SqlDbType.VarChar, MONTH),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet CropRateList_GetAll()
        {
            return ExecuteDataSet("select * from CROPRATELIST_MASTER ", null, null);
        }
        public DataSet CropRateList_GetById(int CROPRate_ID)
        {
            return ExecuteDataSet("select * from CROPRATELIST_MASTER where CROPRate_ID=@CROPRate_ID ", null,
            CreateParameter("@CROPRate_ID", SqlDbType.Int, CROPRate_ID));
        }
        public DataSet CropRateList_GetByrate(string CROP_NAME, int HOtel_ID, string MONTH)
        {
            return ExecuteDataSet("select * from CROPRATELIST_MASTER where CROP_NAME=@CROP_NAME and HOtel_ID=@HOtel_ID and MONTH=@MONTH", null,
             CreateParameter("@CROP_NAME", SqlDbType.VarChar, CROP_NAME),
             CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
             CreateParameter("@MONTH", SqlDbType.VarChar, MONTH));
        }

        public DataSet CropRateList_GetByMonthName(string MONTH)
        {
            return ExecuteDataSet("select * from CROPRATELIST_MASTER where MONTH=@MONTH", null,
            CreateParameter("@MONTH", SqlDbType.VarChar, MONTH));
        }

        public DataSet CropRateList_Delete(int CROPRate_ID)
        {
            return ExecuteDataSet("Delete from CROPRATELIST_MASTER where CROPRate_ID=@CROPRate_ID", null,
            CreateParameter("@CROPRate_ID", SqlDbType.Int, CROPRate_ID));
        }

        public DataSet CropRateList_GetMAXId()
        {
            return ExecuteDataSet("select max(CROPRate_ID)  from CROPRATELIST_MASTER", null, null);
        }

        #endregion
    }
}
