using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class ProductBill_MasterDataService : DataServiceBase
    {
        #region Consturctor
        public ProductBill_MasterDataService() : base() { }
        public ProductBill_MasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void ProductBill_MasterSave(int BILL_ID, string BILLNO, decimal TOTAL, string STATUS, DateTime BILLDATE,  int RECEIVER_ID, string REMARKS, int LOGIN_ID, string Bil_Stutas, decimal Extra_Payment, string NO_OF_BOXES)
        {
            SqlCommand cmd;
            DataSet ds = ProductBill_MasterGetByBILL_ID(BILL_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE ProductBillMaster set BILLNO=@BILLNO,TOTAL=@TOTAL, STATUS=@STATUS,BILLDATE=@BILLDATE,RECEIVER_ID=@RECEIVER_ID,REMARKS=@REMARKS,LOGIN_ID=@LOGIN_ID,Bil_Stutas=@Bil_Stutas,Extra_Payment=@Extra_Payment,NO_OF_BOXES=@NO_OF_BOXES where BILL_ID=@BILL_ID",
                                CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
                                CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                                CreateParameter("@BILLDATE", SqlDbType.Date, BILLDATE),
                                CreateParameter("@RECEIVER_ID", SqlDbType.Int, RECEIVER_ID),
                                CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                                CreateParameter("@LOGIN_ID", SqlDbType.Int, LOGIN_ID),
                                CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                                CreateParameter("@Extra_Payment", SqlDbType.Decimal, Extra_Payment),
                                 CreateParameter("@NO_OF_BOXES", SqlDbType.VarChar, NO_OF_BOXES),
                                CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO ProductBillMaster VALUES (@BILL_ID,@BILLNO,@TOTAL,@STATUS,@BILLDATE,@RECEIVER_ID,@REMARKS,@LOGIN_ID,@Bil_Stutas,@Extra_Payment,@NO_OF_BOXES)",
                                CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
                                 CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
                                CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                                CreateParameter("@BILLDATE", SqlDbType.Date, BILLDATE),
                                CreateParameter("@RECEIVER_ID", SqlDbType.Int, RECEIVER_ID),
                                CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                                CreateParameter("@LOGIN_ID", SqlDbType.Int, LOGIN_ID),
                                CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                                CreateParameter("@Extra_Payment", SqlDbType.Decimal, Extra_Payment),
                                CreateParameter("@NO_OF_BOXES", SqlDbType.VarChar, NO_OF_BOXES));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet ProductBill_MasterGetAll()
        {
            return ExecuteDataSet("select * from ProductBillMaster ", null, null);
        }
        public DataSet ProductBill_MasterGetByBILL_ID(int BILL_ID)
        {
            return ExecuteDataSet("select * from ProductBillMaster where BILL_ID=@BILL_ID", null,
            CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
        }
             public DataSet ProductBill_MasterGetByBILLNO(string BILLNO)
        {
            return ExecuteDataSet("select * from ProductBillMaster where BILLNO=@BILLNO", null,
            CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO));
        }

        public DataSet ProductBill_MasterUpdateBILLNO(string BILLNO, string Bil_Stutas)
        {
            return ExecuteDataSet("UPDATE ProductBillMaster set Bil_Stutas=@Bil_Stutas where BILLNO=@BILLNO", null,
            CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
             CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet ProductBill_MasterGetByFrom_BILLNO_TO_BILLNO(int From_BILLNO, int To_BILLNO)
        {
            return ExecuteDataSet("select * from ProductBillMaster where BILLNO between @From_BILLNO and @To_BILLNO", null,
            CreateParameter("@From_BILLNO", SqlDbType.Int, From_BILLNO),
            CreateParameter("@To_BILLNO", SqlDbType.Int, To_BILLNO));
        }
        public DataSet ProductBill_MasterGetByFrom_BILLNO_TO_BILLNOAndStatus(int From_BILLNO, int To_BILLNO, string Bil_Stutas)
        {
            return ExecuteDataSet("select * from ProductBillMaster where BILLNO between @From_BILLNO and @To_BILLNO and Bil_Stutas=@Bil_Stutas", null,
            CreateParameter("@From_BILLNO", SqlDbType.Int, From_BILLNO),
            CreateParameter("@To_BILLNO", SqlDbType.Int, To_BILLNO),
            CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet ProductBill_MasterDelete(int BILL_ID)
        {
            return ExecuteDataSet("Delete from ProductBillMaster where BILL_ID=@BILL_ID", null,
            CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
        }

        public DataSet ProductBill_MasterDate(DateTime DATE)
        {
            return ExecuteDataSet("Delete from ProductBillMaster where BILLDATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.Date, DATE));
        }
        public DataSet ProductBill_MasterFromDate_ToDateAndStatus(DateTime FromDATE, DateTime ToDate, string Bil_Stutas)
        {
            return ExecuteDataSet("Select * from ProductBillMaster where BILLDATE>=@FromDATE and BILLDATE<=@ToDate and Bil_Stutas=@Bil_Stutas", null,
            CreateParameter("@FromDATE", SqlDbType.Date, FromDATE),
            CreateParameter("@ToDate", SqlDbType.Date, ToDate),
            CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet ProductBill_MasterFromDate_ToDate(DateTime FromDATE, DateTime ToDate)
        {
            return ExecuteDataSet("Select * from ProductBillMaster where BILLDATE>=@FromDATE and BILLDATE<=@ToDate", null,
            CreateParameter("@FromDATE", SqlDbType.Date, FromDATE),
            CreateParameter("@ToDate", SqlDbType.Date, ToDate));
        }
        public DataSet ProductBill_MasterGetMaxbillNo()
        {
            return ExecuteDataSet("select BILLNO from ProductBillMaster where BILL_ID=(select MAX(bill_id) from ProductBillMaster)", null);

        }
        public DataSet ProductBill_MasterGetMAXId()
        {
            return ExecuteDataSet("select max(BILL_ID)  from ProductBillMaster", null, null);
        }
        #endregion
    }
}
