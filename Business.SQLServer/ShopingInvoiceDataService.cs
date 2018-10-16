using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
    public class ShopingInvoiceDataService : DataServiceBase
    {
        #region Consturctor

        public ShopingInvoiceDataService() : base() { }
        public ShopingInvoiceDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void ShopingInvoiceSave(int INVOICE_ID, int ITEM_ID, decimal QUANTITY, decimal RATE_PER, decimal TOTAL, decimal DISCOUNT, decimal TEXABLEVALUE, int BILL_ID, int CATEGORY_ID, int Color_ID, int Size_ID, string Bil_Stutas, DateTime INVOICE_DATE)
        {
            SqlCommand cmd;
            DataSet ds = ShopingInvoiceGetByINVOICE_ID(INVOICE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE ShopingInvoiceMaster set  ITEM_ID = @ITEM_ID, QUANTITY=@QUANTITY, RATE_PER=@RATE_PER,TOTAL =@TOTAL, DISCOUNT=@DISCOUNT, TEXABLEVALUE=@TEXABLEVALUE,BILL_ID=@BILL_ID,CATEGORY_ID=@CATEGORY_ID,Color_ID=@Color_ID,Size_ID=@Size_ID,Bil_Stutas=@Bil_Stutas,INVOICE_DATE=@INVOICE_DATE where INVOICE_ID=@INVOICE_ID",
                         CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                         CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                         CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                         CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                         CreateParameter("@DISCOUNT", SqlDbType.Decimal, DISCOUNT),
                         CreateParameter("@TEXABLEVALUE", SqlDbType.Decimal, TEXABLEVALUE),
                         CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
                         CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                         CreateParameter("@Color_ID", SqlDbType.Int, Color_ID),
                         CreateParameter("@Size_ID", SqlDbType.Int, Size_ID),
                         CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                         CreateParameter("@INVOICE_DATE", SqlDbType.DateTime, INVOICE_DATE),
                          CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));

            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO ShopingInvoiceMaster( INVOICE_ID,  ITEM_ID,  QUANTITY,  RATE_PER,  TOTAL,  DISCOUNT,  TEXABLEVALUE,  BILL_ID, CATEGORY_ID, Color_ID, Size_ID, Bil_Stutas, INVOICE_DATE)VALUES(@INVOICE_ID, @ITEM_ID, @QUANTITY, @RATE_PER, @TOTAL, @DISCOUNT, @TEXABLEVALUE, @BILL_ID,@CATEGORY_ID,@Color_ID,@Size_ID,@Bil_Stutas,@INVOICE_DATE)",
                         CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID),
                         CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                         CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                         CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                         CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                         CreateParameter("@DISCOUNT", SqlDbType.Decimal, DISCOUNT),
                         CreateParameter("@TEXABLEVALUE", SqlDbType.Decimal, TEXABLEVALUE),
                         CreateParameter("@BILL_ID", SqlDbType.Int, BILL_ID),
                         CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                         CreateParameter("@Color_ID", SqlDbType.Int, Color_ID),
                         CreateParameter("@Size_ID", SqlDbType.Int, Size_ID),
                         CreateParameter("@Bil_Stutas", SqlDbType.VarChar, Bil_Stutas),
                         CreateParameter("@INVOICE_DATE", SqlDbType.DateTime, INVOICE_DATE));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet ShopingInvoiceGetAll()
        {
            return ExecuteDataSet("select * from ShopingInvoiceMaster ", null, null);
        }
        public DataSet ShopingInvoiceGetByINVOICE_ID(int INVOICE_ID)
        {
            return ExecuteDataSet("select * from ShopingInvoiceMaster where INVOICE_ID=@INVOICE_ID", null,
            CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));
        }
        public DataSet ShopingInvoiceGetByITEM_ID(int ITEM_ID)
        {
            return ExecuteDataSet("select * from ShopingInvoiceMaster where ITEM_ID=@ITEM_ID", null,
            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }

        public DataSet ShopingInvoiceGetByINVOICE_DATE(DateTime INVOICE_DATE)
        {
            return ExecuteDataSet("select * from ShopingInvoiceMaster where INVOICE_DATE=@INVOICE_DATE", null,
            CreateParameter("@INVOICE_DATE", SqlDbType.DateTime, INVOICE_DATE));
        }
        //public DataSet ShopingInvoiceGetBybillno_bydate(string HOTEL_NAME, DateTime DATE, int BILL_NO)
        //{
        //    return ExecuteDataSet("select * from ShopingInvoiceMaster where DATE=@DATE", null,
        //    CreateParameter("@HOTEL_NAME", SqlDbType.VarChar, HOTEL_NAME), 
        //    CreateParameter("@DATE", SqlDbType.DateTime, DATE),
        //     CreateParameter("@BILL_NO", SqlDbType.Int, BILL_NO));

        //}

        public DataSet ShopingInvoiceDelete(int INVOICE_ID)
        {
            return ExecuteDataSet("Delete from ShopingInvoiceMaster where INVOICE_ID=@INVOICE_ID", null,
            CreateParameter("@INVOICE_ID", SqlDbType.Int, INVOICE_ID));
        }

        public DataSet ShopingInvoiceGetMAXId()
        {
            return ExecuteDataSet("select max(INVOICE_ID)  from ShopingInvoiceMaster", null, null);
        }

        #endregion


    }
}
