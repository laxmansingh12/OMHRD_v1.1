using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductBill_Master : BusinessBaseObject
    {
        #region
        public int BILL_ID { get; set; }
        public string BILLNO { get; set; }
        public decimal TOTAL { get; set; }
        public string STATUS { get; set; }
        public DateTime BILLDATE { get; set; }
        public int RECEIVER_ID { get; set; }
        public string REMARKS { get; set; }
        public int LOGIN_ID { get; set; }
        public string Bil_Stutas { get; set; }
        public decimal Extra_Payment { get; set; }
        public string NO_OF_BOXES { get; set; }
        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            BILL_ID = GetInt(row, "BILL_ID");
            BILLNO = GetString(row, "BILLNO");
            BILLDATE = GetDateTime(row, "BILLDATE");
            TOTAL = GetDecimal(row, "TOTAL");
            STATUS = GetString(row, "STATUS");
            RECEIVER_ID = GetInt(row, "RECEIVER_ID");
            REMARKS = GetString(row, "REMARKS");
            LOGIN_ID = GetInt(row, "LOGIN_ID");
            Bil_Stutas = GetString(row, "Bil_Stutas");
            Extra_Payment = GetDecimal(row, "Extra_Payment");
            NO_OF_BOXES = GetString(row, "NO_OF_BOXES");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }

        public static ProductBill_Master GetByBILL_ID(int BILL_ID)
        {
            ProductBill_Master obj = new ProductBill_Master();
            obj.MapData(new ProductBill_MasterDataService().ProductBill_MasterGetByBILL_ID(BILL_ID));
            return obj;
        }
               public static ProductBill_Master GetByDate(DateTime DATE)
        {
            ProductBill_Master obj = new ProductBill_Master();
            obj.MapData(new ProductBill_MasterDataService().ProductBill_MasterDate(DATE));
            return obj;
        }
       
        public static ProductBill_Master GetByBILLNO(string BILLNO)
        {
            ProductBill_Master obj = new ProductBill_Master();
            obj.MapData(new ProductBill_MasterDataService().ProductBill_MasterGetByBILLNO(BILLNO));
            return obj;
        }
        //public void UpdateChl_InvoiceDate(int CHALLAN_ID, DateTime CHA_INVOICE_DATE)
        //{
        //    new Chl_Invoice_MasterDataService().updateChl_InvoiceDate(CHALLAN_ID, CHA_INVOICE_DATE);
        //}
        public void UpdateStutas(string BILLNO, string Bil_Stutas)
        {
            new ProductBill_MasterDataService().ProductBill_MasterUpdateBILLNO(BILLNO, Bil_Stutas);
        }
        public void Save(IDbTransaction txn)
        {
            new ProductBill_MasterDataService().ProductBill_MasterSave(BILL_ID, BILLNO, TOTAL, STATUS, BILLDATE,  RECEIVER_ID, REMARKS, LOGIN_ID, Bil_Stutas, Extra_Payment, NO_OF_BOXES);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new ProductBill_MasterDataService().ProductBill_MasterDelete(BILL_ID);
        }
        public static int MaxIdbyBillNo()
        {
            int result = 0;
            DataSet ds = new ProductBill_MasterDataService().ProductBill_MasterGetMaxbillNo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new ProductBill_MasterDataService().ProductBill_MasterGetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}
