using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class OrderBillMasterDataService : DataServiceBase
    {
        #region Consturctor
        public OrderBillMasterDataService() : base() { }
        public OrderBillMasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void OrderBillMasterSave(int OrderBILL_ID, string BILLNO, decimal TOTAL, string STATUS, DateTime BILLDATE, string REMARKS, int LOGIN_ID, string Bil_Stutas, decimal Extra_Payment, string NO_OF_Items)
        {
            SqlCommand cmd;
            DataSet ds = OrderBillMasterGetByOrderBILL_ID(OrderBILL_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE OrderBillMaster set BILLNO=@BILLNO,TOTAL=@TOTAL,STATUS=@STATUS,BILLDATE=@BILLDATE,REMARKS=@REMARKS,LOGIN_ID=@LOGIN_ID,Bil_Stutas=@Bil_Stutas,Extra_Payment=@Extra_Payment,NO_OF_Items=@NO_OF_Items where OrderBILL_ID=@OrderBILL_ID",
                                CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
                                CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                                CreateParameter("@BILLDATE", SqlDbType.Date, BILLDATE),
                                CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                                CreateParameter("@LOGIN_ID", SqlDbType.Int, LOGIN_ID),
                                CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                                CreateParameter("@Extra_Payment", SqlDbType.Decimal, Extra_Payment),
                                CreateParameter("@NO_OF_Items", SqlDbType.VarChar, NO_OF_Items),
                                CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO OrderBillMaster VALUES (@OrderBILL_ID,@BILLNO,@TOTAL,@STATUS,@BILLDATE,@REMARKS,@LOGIN_ID,@Bil_Stutas,@Extra_Payment,@NO_OF_Items)",
                                CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID),
                                CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
                                CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                CreateParameter("@STATUS", SqlDbType.VarChar, STATUS),
                                CreateParameter("@BILLDATE", SqlDbType.Date, BILLDATE),
                                CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                                CreateParameter("@LOGIN_ID", SqlDbType.Int, LOGIN_ID),
                                CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                                CreateParameter("@Extra_Payment", SqlDbType.Decimal, Extra_Payment),
                                CreateParameter("@NO_OF_Items", SqlDbType.VarChar, NO_OF_Items));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet OrderBillMasterGetAll()
        {
            return ExecuteDataSet("select * from OrderBillMaster ", null, null);
        }
        public DataSet OrderBillMasterGetByOrderBILL_ID(int OrderBILL_ID)
        {
            return ExecuteDataSet("select * from OrderBillMaster where OrderBILL_ID=@OrderBILL_ID", null,
            CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID));
        }

        public DataSet OrderBillMasterGetByBILLNO(string BILLNO)
        {
            return ExecuteDataSet("select * from OrderBillMaster where BILLNO=@BILLNO", null,
            CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO));
        }

        public DataSet OrderBillMasterUpdateBILLNO(string BILLNO, string Bil_Stutas)
        {
            return ExecuteDataSet("UPDATE OrderBillMaster set Bil_Stutas=@Bil_Stutas where BILLNO=@BILLNO", null,
            CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
             CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet OrderBillMasterGetByFrom_BILLNO_TO_BILLNO(int From_BILLNO, int To_BILLNO)
        {
            return ExecuteDataSet("select * from OrderBillMaster where BILLNO between @From_BILLNO and @To_BILLNO", null,
            CreateParameter("@From_BILLNO", SqlDbType.Int, From_BILLNO),
            CreateParameter("@To_BILLNO", SqlDbType.Int, To_BILLNO));
        }
        public DataSet OrderBillMasterGetByFrom_BILLNO_TO_BILLNOAndStatus(int From_BILLNO, int To_BILLNO, string Bil_Stutas)
        {
            return ExecuteDataSet("select * from OrderBillMaster where BILLNO between @From_BILLNO and @To_BILLNO and Bil_Stutas=@Bil_Stutas", null,
            CreateParameter("@From_BILLNO", SqlDbType.Int, From_BILLNO),
            CreateParameter("@To_BILLNO", SqlDbType.Int, To_BILLNO),
            CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet OrderBillMasterDelete(int OrderBILL_ID)
        {
            return ExecuteDataSet("Delete from OrderBillMaster where OrderBILL_ID=@OrderBILL_ID", null,
            CreateParameter("@OrderBILL_ID", SqlDbType.Int, OrderBILL_ID));
        }

        public DataSet OrderBillMasterDate(DateTime DATE)
        {
            return ExecuteDataSet("Delete from OrderBillMaster where BILLDATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.Date, DATE));
        }
        public DataSet OrderBillMasterFromDate_ToDateAndStatus(DateTime FromDATE, DateTime ToDate, string Bil_Stutas)
        {
            return ExecuteDataSet("Select * from OrderBillMaster where BILLDATE>=@FromDATE and BILLDATE<=@ToDate and Bil_Stutas=@Bil_Stutas", null,
            CreateParameter("@FromDATE", SqlDbType.Date, FromDATE),
            CreateParameter("@ToDate", SqlDbType.Date, ToDate),
            CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet OrderBillMasterFromDate_ToDate(DateTime FromDATE, DateTime ToDate)
        {
            return ExecuteDataSet("Select * from OrderBillMaster where BILLDATE>=@FromDATE and BILLDATE<=@ToDate", null,
            CreateParameter("@FromDATE", SqlDbType.Date, FromDATE),
            CreateParameter("@ToDate", SqlDbType.Date, ToDate));
        }
        public DataSet OrderBillMasterGetMaxbillNo()
        {
            return ExecuteDataSet("select BILLNO from OrderBillMaster where OrderBILL_ID=(select MAX(OrderBILL_ID) from BILLMASTER)", null);

        }
        public DataSet OrderBillMasterGetMAXId()
        {
            return ExecuteDataSet("select max(OrderBILL_ID)  from OrderBillMaster", null, null);
        }
        #endregion
    }
}
