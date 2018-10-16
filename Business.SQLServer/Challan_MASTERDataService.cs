using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
    public class Challan_MASTERDataService : DataServiceBase
    {
        #region Consturctor

        public Challan_MASTERDataService() : base() { }
        public Challan_MASTERDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void Challan_MASTER_Save(int CHALLAN_ID, int HOtel_ID, int CROP_ID, float QTY, DateTime DATE, string CHALLAN_NO)
        {
            SqlCommand cmd;
            DataSet ds = Challan_MASTER_GetById(CHALLAN_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE CHALLAN_MASTER set  HOtel_ID = @HOtel_ID, CROP_ID=@CROP_ID, QTY=@QTY,DATE=@DATE,CHALLAN_NO=@CHALLAN_NO where CHALLAN_ID=@CHALLAN_ID",
                         CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
                         CreateParameter("@CROP_ID", SqlDbType.Int, CROP_ID),
                         CreateParameter("@QTY", SqlDbType.Float, QTY),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE),
                         CreateParameter("@CHALLAN_NO", SqlDbType.VarChar, CHALLAN_NO),
                         CreateParameter("@CHALLAN_ID", SqlDbType.Int, CHALLAN_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO CHALLAN_MASTER(CHALLAN_ID,HOtel_ID,CROP_ID,QTY,DATE,CHALLAN_NO)VALUES(@CHALLAN_ID,@HOtel_ID,@CROP_ID,@QTY,@DATE,@CHALLAN_NO)",
                         CreateParameter("@CHALLAN_ID", SqlDbType.Int, CHALLAN_ID),
                         CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
                         CreateParameter("@CROP_ID", SqlDbType.Int, CROP_ID),
                         CreateParameter("@QTY", SqlDbType.Float, QTY),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE),
                         CreateParameter("@CHALLAN_NO", SqlDbType.VarChar, CHALLAN_NO));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet Challan_MASTER_GetAll()
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER ", null, null);
        }
        public DataSet Challan_MASTER_GetById(int CHALLAN_ID)
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER where CHALLAN_ID=@CHALLAN_ID", null,
            CreateParameter("@CHALLAN_ID", SqlDbType.Int, CHALLAN_ID));
        }
        public DataSet Challan_MASTER_GetByHName(int HOtel_ID)
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER where HOtel_ID=@HOtel_ID", null,
            CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID));
        }

        public DataSet Challan_MASTER_GetByDATE(DateTime DATE)
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER where DATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        }
        public DataSet Challan_MASTER_GetByMinChallan(DateTime From_DATE, DateTime ToDate, int HOtel_ID)
        {
            return ExecuteDataSet("select min(CHALLAN_NO) from CHALLAN_MASTER where DATE between @From_DATE and @ToDate and HOtel_ID=@HOtel_ID", null,
            CreateParameter("@From_DATE", SqlDbType.DateTime, From_DATE),
            CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
            CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID));
        }
        public DataSet Challan_MASTER_GetByMaxChallan(DateTime From_DATE, DateTime ToDate, int HOtel_ID)
        {
            return ExecuteDataSet("select max(Convert(int,CHALLAN_NO)) from CHALLAN_MASTER where DATE between @From_DATE and @ToDate and HOtel_ID=@HOtel_ID", null,
            CreateParameter("@From_DATE", SqlDbType.DateTime, From_DATE),
            CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
            CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID));
        }
        public DataSet Bill_Master_GetByFrom_BILLNO_TO_BILLNO(string From_ChallanNO, string To_ChallanNO)
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER where CHALLAN_NO between @From_ChallanNO and @To_ChallanNO", null,
            CreateParameter("@From_ChallanNO", SqlDbType.VarChar, From_ChallanNO),
            CreateParameter("@To_ChallanNO", SqlDbType.VarChar, To_ChallanNO));
        }
        //public DataSet Challan_MASTER_MASTER_GetByMaxBill(string Hotel_ID, DateTime DATE)
        //{
        //    return ExecuteDataSet("select max(CONVERT (int, CHALLAN_NO)) from CHALLAN_MASTER where Hotel_ID=@Hotel_ID and DATE=@DATE", null,
        //    CreateParameter("@Hotel_ID", SqlDbType.VarChar, Hotel_ID),
        //    CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        //}
        public DataSet Challan_MASTER_GetByFromDate_ToDate(DateTime FromDATE, DateTime ToDATE)
        {
            return ExecuteDataSet("select * from CHALLAN_MASTER where DATE between @FromDATE and @ToDATE", null,
            CreateParameter("@FromDATE", SqlDbType.DateTime, FromDATE),
            CreateParameter("@ToDATE", SqlDbType.DateTime, ToDATE));
        }

        public DataSet Challan_MASTER_Delete(int CHALLAN_ID)
        {
            return ExecuteDataSet("Delete from CHALLAN_MASTER where CHALLAN_ID=@CHALLAN_ID", null,
            CreateParameter("@CHALLAN_ID", SqlDbType.Int, CHALLAN_ID));
        }
        public DataSet Challan_MASTER_GetMAXIdbyhotel(int HOtel_ID, DateTime DATE)
        {
            return ExecuteDataSet("select max(CHALLAN_ID)  from CHALLAN_MASTER where HOtel_ID=@HOtel_ID and DATE=@DATE", null,
                 CreateParameter("@HOtel_ID", SqlDbType.Int, HOtel_ID),
                 CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        }
        public DataSet Challan_MASTER_GetCHALLAN_NO()
        {
            return ExecuteDataSet("select max(CHALLAN_NO)  from CHALLAN_MASTER", null, null);
        }
        public DataSet Challan_MASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(CHALLAN_ID)  from CHALLAN_MASTER", null, null);
        }

        #endregion


    }
}
