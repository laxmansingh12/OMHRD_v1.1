using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductInvoice_Master : BusinessBaseObject
    {
        #region
        public int INVOICE_ID { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEMNAME { get; set; }
        public string HSNCODE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal RATE_PER { get; set; }
        public decimal TOTAL { get; set; }
        public decimal CGST_AMT { get; set; }
        public decimal SGST_AMT { get; set; }
        public decimal IGST_AMT { get; set; }
        public int BILL_ID { get; set; }
        public string REMARKS { get; set; }
        public decimal CGST_RATE { get; set; }
        public decimal SGST_RATE { get; set; }
        public decimal IGST_RATE { get; set; }
        public DateTime INVOICE_DATE { get; set; }
        public string Bil_Stutas { get; set; }
        public int RECEIVER_ID { get; set; }
        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            INVOICE_ID = GetInt(row, "INVOICE_ID");
            ITEM_ID = GetInt(row, "ITEM_ID");
            ITEMNAME = GetString(row, "ITEMNAME");
            HSNCODE = GetString(row, "HSNCODE");
            QUANTITY = GetDecimal(row, "QUANTITY");
            RATE_PER = GetDecimal(row, "RATE_PER");
            TOTAL = GetDecimal(row, "TOTAL");
            CGST_AMT = GetDecimal(row, "CGST_AMT");
            SGST_AMT = GetDecimal(row, "SGST_AMT");
            IGST_AMT = GetDecimal(row, "IGST_AMT");
            BILL_ID = GetInt(row, "BILL_ID");
            REMARKS = GetString(row, "REMARKS");
            CGST_RATE = GetDecimal(row, "CGST_RATE");
            SGST_RATE = GetDecimal(row, "SGST_RATE");
            IGST_RATE = GetDecimal(row, "IGST_RATE");
            INVOICE_DATE = GetDateTime(row, "INVOICE_DATE");
            Bil_Stutas = GetString(row, "Bil_Stutas");
            RECEIVER_ID = GetInt(row, "RECEIVER_ID");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public void UpdateStutas(int BILL_ID, string Bil_Stutas)
        {
            new ProductInvoice_MasterDataService().Bill_Master_UpdateBILLId(BILL_ID, Bil_Stutas);
        }
        public void UpdateInvoiceDate(int BILL_ID, DateTime INVOICE_DATE)
        {
            new ProductInvoice_MasterDataService().updateInvoiceDate(BILL_ID, INVOICE_DATE);
        }
        public static ProductInvoice_Master GetByINVOICE_ID(int INVOICE_ID)
        {
            ProductInvoice_Master obj = new ProductInvoice_Master();
            obj.MapData(new ProductInvoice_MasterDataService().ProductInvoice_Master_GetByINVOICE_ID(INVOICE_ID));
            return obj;
        }
        public static ProductInvoice_Master GetByBILL_ID(int BILL_ID)
        {
            ProductInvoice_Master obj = new ProductInvoice_Master();
            obj.MapData(new ProductInvoice_MasterDataService().ProductInvoice_Master_GetByBILL_ID(BILL_ID));
            return obj;
        }

        public void Save(IDbTransaction txn)
        {
            new ProductInvoice_MasterDataService().ProductInvoice_Master_Save(INVOICE_ID, ITEM_ID, ITEMNAME, HSNCODE, QUANTITY, RATE_PER, TOTAL, CGST_AMT, SGST_AMT, IGST_AMT, BILL_ID, REMARKS, CGST_RATE, SGST_RATE, IGST_RATE, INVOICE_DATE, Bil_Stutas, RECEIVER_ID);
        }
        public void DeleteByBILL_ID()
        {
            DeleteByBILL_ID(null);
        }
        public void DeleteByBILL_ID(IDbTransaction txn)
        {
            new ProductInvoice_MasterDataService().ProductInvoice_Master_DeleteBy_BILL_ID(BILL_ID);
        }
        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new ProductInvoice_MasterDataService().ProductInvoice_Master_Delete(INVOICE_ID);
        }
        public void deleteall()
        {
            new ProductInvoice_MasterDataService().ProductInvoice_Master_Truncate();

        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new ProductInvoice_MasterDataService().ProductInvoice_Master_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}
