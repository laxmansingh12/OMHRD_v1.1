using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class SALE_MASTERDataService: DataServiceBase 
    {
        #region Consturctor

        public SALE_MASTERDataService() : base() { }
        public SALE_MASTERDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void SALE_MASTER_Save(int SUPLIE_ID, string HOTEL_NAME, string CROP_NMAE, float QUANTITY, float PRICE, DateTime DATE, string STATUS, int BILL_NO)
        {
            SqlCommand cmd;
            DataSet ds = SALE_MASTER_GetById(SUPLIE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE SALE_MASTER set  HOTEL_NAME = @HOTEL_NAME, CROP_NMAE=@CROP_NMAE, QUANTITY=@QUANTITY,PRICE =@PRICE, DATE=@DATE, STATUS=@STATUS,BILL_NO=@BILL_NO where SUPLIE_ID=@SUPLIE_ID",
                         CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                         CreateParameter("@CROP_NMAE", SqlDbType.VarChar, CROP_NMAE),
                         CreateParameter("@QUANTITY", SqlDbType.Float, QUANTITY),
                       //  CreateParameter("@SELLING_PRICE", SqlDbType.VarChar, SELLING_PRICE),
                         CreateParameter("@PRICE", SqlDbType.Float,PRICE),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE),
                          CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                           CreateParameter("@BILL_NO", SqlDbType.Int, BILL_NO),
                         CreateParameter("@SUPLIE_ID", SqlDbType.Int, SUPLIE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO SALE_MASTER(SUPLIE_ID,HOTEL_NAME,CROP_NMAE,QUANTITY,PRICE, DATE,STATUS,BILL_NO)VALUES(@SUPLIE_ID,@HOTEL_NAME,@CROP_NMAE,@QUANTITY, @PRICE,@DATE,@STATUS,@BILL_NO)",
                         CreateParameter("@SUPLIE_ID", SqlDbType.Int, SUPLIE_ID),
                         CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME),
                         CreateParameter("@CROP_NMAE", SqlDbType.VarChar, CROP_NMAE),
                         CreateParameter("@QUANTITY", SqlDbType.Float, QUANTITY),
                        // CreateParameter("@SELLING_PRICE", SqlDbType.VarChar, SELLING_PRICE),
                         CreateParameter("@PRICE", SqlDbType.Float, PRICE),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE),
                           CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                            CreateParameter("@BILL_NO", SqlDbType.Int, BILL_NO));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet SALE_MASTER_GetAll()
        {
            return ExecuteDataSet("select * from SALE_MASTER ", null, null);
        }
        public DataSet SALE_MASTER_GetById(int SUPLIE_ID)
        {
            return ExecuteDataSet("select * from SALE_MASTER where SUPLIE_ID=@SUPLIE_ID", null,
            CreateParameter("@SUPLIE_ID", SqlDbType.Int, SUPLIE_ID));
        }
        public DataSet SALE_MASTER_GetByName(string HOTEL_NAME)
        {
            return ExecuteDataSet("select * from SALE_MASTER where HOTEL_NAME=@HOTEL_NAME", null,
            CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME));
        }

        public DataSet SALE_MASTER_GetByDATE(DateTime DATE)
        {
            return ExecuteDataSet("select * from SALE_MASTER where DATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        }
        //public DataSet SALE_MASTER_GetBybillno_bydate(string HOTEL_NAME, DateTime DATE, int BILL_NO)
        //{
        //    return ExecuteDataSet("select * from SALE_MASTER where DATE=@DATE", null,
        //    CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME), 
        //    CreateParameter("@DATE", SqlDbType.DateTime, DATE),
        //     CreateParameter("@BILL_NO", SqlDbType.Int, BILL_NO));
           
        //}

        public DataSet SALE_MASTER_Delete(int SUPLIE_ID)
        {
            return ExecuteDataSet("Delete from SALE_MASTER where SUPLIE_ID=@SUPLIE_ID", null,
            CreateParameter("@SUPLIE_ID", SqlDbType.Int, SUPLIE_ID));
        }
        public DataSet SALE_MASTER_GetMAXIdbyhotel(string HOTEL_NAME)
        {
            return ExecuteDataSet("select max(SUPLIE_ID)  from SALE_MASTER where HOTEL_NAME=@HOTEL_NAME", null,
                 CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME));
        }
        public DataSet SALE_MASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(SUPLIE_ID)  from SALE_MASTER", null, null);
        }

        #endregion

       
    }
}
