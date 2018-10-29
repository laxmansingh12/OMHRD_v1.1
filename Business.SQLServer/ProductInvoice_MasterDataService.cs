using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class ProductInvoice_MasterDataService : DataServiceBase
    {
        #region Consturctor
        public ProductInvoice_MasterDataService() : base() { }
        public ProductInvoice_MasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void ProductInvoice_Master_Save(int INVOICE_ID, int ITEM_ID, string ITEMNAME, string HSNCODE, decimal QUANTITY, decimal RATE_PER, decimal TOTAL, decimal CGST_AMT, decimal SGST_AMT, decimal IGST_AMT, int BILL_ID, string REMARKS, decimal CGST_RATE, decimal SGST_RATE, decimal IGST_RATE, DateTime INVOICE_DATE, string Bil_Stutas,int RECEIVER_ID)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = ProductInvoice_Master_GetByINVOICE_ID(INVOICE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE ProductInvoice_Master set ITEM_ID=@ITEM_ID,ITEMNAME=@ITEMNAME,HSNCODE=@HSNCODE, QUANTITY=@QUANTITY,RATE_PER=@RATE_PER,TOTAL=@TOTAL,CGST_AMT=@CGST_AMT,SGST_AMT=@SGST_AMT,IGST_AMT=@IGST_AMT,BILL_ID=@BILL_ID,REMARKS=@REMARKS,CGST_RATE=@CGST_RATE, SGST_RATE=@SGST_RATE, IGST_RATE=@IGST_RATE,INVOICE_DATE=@INVOICE_DATE,Bil_Stutas=@Bil_Stutas,RECEIVER_ID=@RECEIVER_ID where INVOICE_ID=@INVOICE_ID",
                         CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                         CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                         CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                         CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                         CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                         CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                         CreateParameter("@CGST_AMT", SqlDbType.Decimal, CGST_AMT),
                         CreateParameter("@SGST_AMT", SqlDbType.Decimal, SGST_AMT),
                         CreateParameter("@IGST_AMT", SqlDbType.Decimal, IGST_AMT),
                         CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@CGST_RATE", SqlDbType.Decimal, CGST_RATE),
                         CreateParameter("@SGST_RATE", SqlDbType.Decimal, SGST_RATE),
                         CreateParameter("@IGST_RATE", SqlDbType.Decimal, IGST_RATE),
                         CreateParameter("@INVOICE_DATE", SqlDbType.Date, INVOICE_DATE),
                         CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                         CreateParameter("@RECEIVER_ID", SqlDbType.Int, RECEIVER_ID),
                         CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO ProductInvoice_Master VALUES (@INVOICE_ID, @ITEM_ID,@ITEMNAME,@HSNCODE, @QUANTITY, @RATE_PER, @TOTAL, @CGST_AMT, @SGST_AMT, @IGST_AMT, @BILL_ID, @REMARKS, @CGST_RATE, @SGST_RATE, @IGST_RATE, @INVOICE_DATE, @Bil_Stutas,@RECEIVER_ID)",
                         CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID),
                         CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                         CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                         CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                         CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                         CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                         CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                         CreateParameter("@CGST_AMT", SqlDbType.Decimal, CGST_AMT),
                         CreateParameter("@SGST_AMT", SqlDbType.Decimal, SGST_AMT),
                         CreateParameter("@IGST_AMT", SqlDbType.Decimal, IGST_AMT),
                         CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@CGST_RATE", SqlDbType.Decimal, CGST_RATE),
                         CreateParameter("@SGST_RATE", SqlDbType.Decimal, SGST_RATE),
                         CreateParameter("@IGST_RATE", SqlDbType.Decimal, IGST_RATE),
                         CreateParameter("@INVOICE_DATE", SqlDbType.Date, INVOICE_DATE),
                         CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                         CreateParameter("@RECEIVER_ID", SqlDbType.Int, RECEIVER_ID));

            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet ProductInvoice_Master_GetAll()
        {
            return ExecuteDataSet("select * from ProductInvoice_Master ", null, null);
        }
        public DataSet ProductInvoice_Master_GetByINVOICE_ID(int INVOICE_ID)
        {
            return ExecuteDataSet("select * from ProductInvoice_Master where INVOICE_ID=@INVOICE_ID", null,
            CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));
        }
        public void updateInvoiceDate(int BILL_ID, DateTime INVOICE_DATE)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, @"update ProductInvoice_Master set INVOICE_DATE=@INVOICE_DATE where BILL_ID=@BILL_ID", null,
                           CreateParameter("@INVOICE_DATE", SqlDbType.Date, INVOICE_DATE),
                           CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
            if (cmd != null)
                cmd.Dispose();
        }
        //public DataSet Bill_Master_UpdateBILLNO(string BILLNO, string Bil_Stutas)
        //{
        //    return ExecuteDataSet("UPDATE BILLMASTER set Bil_Stutas=@Bil_Stutas where BILLNO=@BILLNO", null,
        //    CreateParameter("@BILLNO", SqlDbType.VarChar, BILLNO),
        //     CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        //}
        public DataSet Bill_Master_UpdateBILLId(int BILL_ID, string Bil_Stutas)
        {
            return ExecuteDataSet("UPDATE ProductInvoice_Master set Bil_Stutas=@Bil_Stutas where BILL_ID=@BILL_ID", null,
            CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
             CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas));
        }
        public DataSet ProductInvoice_Master_GetByBILL_ID(int BILL_ID)
        {
            return ExecuteDataSet("select * from ProductInvoice_Master where BILL_ID=@BILL_ID", null,
            CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
        }
        public DataSet ProductInvoice_Master_DeleteBy_BILL_ID(int BILL_ID)
        {
            return ExecuteDataSet("Delete from ProductInvoice_Master where BILL_ID=@BILL_ID", null,
            CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID));
        }
        public DataSet ProductInvoice_Master_Delete(int INVOICE_ID)
        {
            return ExecuteDataSet("Delete from ProductInvoice_Master where INVOICE_ID=@INVOICE_ID", null,
            CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));
        }
        public void ProductInvoice_Master_Truncate()
        {
            ExecuteDataSet("TRUNCATE TABLE ProductInvoice_Master", null);

        }
        public DataSet ProductInvoice_Master_GetMAXId()
        {
            return ExecuteDataSet("select max(INVOICE_ID)  from ProductInvoice_Master", null, null);
        }
        #endregion
    }
}
