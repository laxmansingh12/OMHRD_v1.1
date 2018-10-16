using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class PURCHASE_MASTERDataService: DataServiceBase 
    {
        #region Consturctor

       public PURCHASE_MASTERDataService() : base() { }
       public PURCHASE_MASTERDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

       public void PURCHASE_MASTER_Save(int PURCHASE_ID, string HOTEL_NAME, string CROP_NAME, float QUANTITY, float PURCHASE_RATE, DateTime PURCHASE_DATE, string STATUS)
        {
            SqlCommand cmd;
            DataSet ds = PURCHASE_MASTER_GetById(PURCHASE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE PURCHASE_MASTER set HOTEL_NAME=@HOTEL_NAME, CROP_NAME=@CROP_NAME,QUANTITY=@QUANTITY ,PURCHASE_RATE=@PURCHASE_RATE,PURCHASE_DATE=@PURCHASE_DATE, STATUS=@STATUS where PURCHASE_ID=@PURCHASE_ID",
                          CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                             CreateParameter("@CROP_NAME", SqlDbType.VarChar, CROP_NAME),
                           CreateParameter("@QUANTITY", SqlDbType.Float, QUANTITY),
                          CreateParameter("@PURCHASE_RATE", SqlDbType.Float, PURCHASE_RATE),
                          CreateParameter("@PURCHASE_DATE", SqlDbType.Date, PURCHASE_DATE),
                          CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                          CreateParameter("@PURCHASE_ID", SqlDbType.Int, PURCHASE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO PURCHASE_MASTER(PURCHASE_ID,HOTEL_NAME,CROP_NAME,QUANTITY,PURCHASE_RATE,PURCHASE_DATE,STATUS)VALUES(@PURCHASE_ID,@HOTEL_NAME,@CROP_NAME,@QUANTITY,@PURCHASE_RATE,@PURCHASE_DATE,@STATUS)",
                         CreateParameter("@PURCHASE_ID", SqlDbType.Int, PURCHASE_ID),
                         CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                         CreateParameter("@CROP_NAME", SqlDbType.VarChar, CROP_NAME),
                           CreateParameter("@QUANTITY", SqlDbType.Float, QUANTITY),
                         CreateParameter("@PURCHASE_RATE", SqlDbType.Float, PURCHASE_RATE),
                         CreateParameter("@PURCHASE_DATE", SqlDbType.Date, PURCHASE_DATE),
                         CreateParameter("@STATUS", SqlDbType.VarChar, STATUS));
                        
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
       public DataSet PURCHASE_MASTER_GetAll()
        {
            return ExecuteDataSet("select * from PURCHASE_MASTER ", null, null);
        }

       public DataSet PURCHASE_MASTER_GetById(int PURCHASE_ID)
        {
            return ExecuteDataSet("select * from PURCHASE_MASTER where PURCHASE_ID=@PURCHASE_ID", null,
            CreateParameter("@PURCHASE_ID", SqlDbType.Int, PURCHASE_ID));
        }

       public DataSet PURCHASE_MASTER_GetByDATE(DateTime PURCHASE_RATE)
        {
            return ExecuteDataSet("select * from PURCHASE_MASTER where PURCHASE_RATE=@PURCHASE_RATE", null,
            CreateParameter("@PURCHASE_RATE", SqlDbType.DateTime, PURCHASE_RATE));
        }

       public DataSet PURCHASE_MASTER_Delete(int PURCHASE_ID)
        {
            return ExecuteDataSet("Delete from PURCHASE_MASTER where PURCHASE_ID=@PURCHASE_ID", null,
            CreateParameter("@PURCHASE_ID", SqlDbType.Int, PURCHASE_ID));
        }

       public DataSet PURCHASE_MASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(PURCHASE_ID)  from PURCHASE_MASTER", null, null);
        }

        #endregion
            
    }
}
