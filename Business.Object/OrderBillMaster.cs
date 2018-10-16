using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class OrderBillMaster : BusinessBaseObject
    {
        #region

        public int OrderBILL_ID { get; set; }
        public string BILLNO { get; set; }
        public decimal TOTAL { get; set; }
        public string STATUS { get; set; }
        public DateTime BILLDATE { get; set; }
        public string REMARKS { get; set; }
        public int LOGIN_ID { get; set; }
        public string Bil_Stutas { get; set; }
        public decimal Extra_Payment { get; set; }
        public string NO_OF_Items { get; set; }
        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            OrderBILL_ID = GetInt(row, "OrderBILL_ID");
            BILLNO = GetString(row, "BILLNO");
            BILLDATE = GetDateTime(row, "BILLDATE");
            TOTAL = GetDecimal(row, "TOTAL");
            STATUS = GetString(row, "STATUS");
            REMARKS = GetString(row, "REMARKS");
            LOGIN_ID = GetInt(row, "LOGIN_ID");
            Bil_Stutas = GetString(row, "Bil_Stutas");
            Extra_Payment = GetDecimal(row, "Extra_Payment");
            NO_OF_Items = GetString(row, "NO_OF_Items");
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }

        public static OrderBillMaster GetByOrderBILL_ID(int OrderBILL_ID)
        {
            OrderBillMaster obj = new OrderBillMaster();
            obj.MapData(new OrderBillMasterDataService().OrderBillMasterGetByOrderBILL_ID(OrderBILL_ID));
            return obj;
        }

        public static OrderBillMaster GetByDate(DateTime DATE)
        {
            OrderBillMaster obj = new OrderBillMaster();
            obj.MapData(new OrderBillMasterDataService().OrderBillMasterDate(DATE));
            return obj;
        }
        //public static Bill_Master GetByFromDate_ToDate(DateTime FromDATE,DateTime ToDate)
        //{
        //    Bill_Master obj = new Bill_Master();
        //    obj.MapData(new OrderBillMasterDataService().Bill_Master_FromDate_ToDate(FromDATE, ToDate));
        //    return obj;
        //}
        public static OrderBillMaster GetByBILLNO(string BILLNO)
        {
            OrderBillMaster obj = new OrderBillMaster();
            obj.MapData(new OrderBillMasterDataService().OrderBillMasterGetByBILLNO(BILLNO));
            return obj;
        }
        //public void UpdateChl_InvoiceDate(int CHALLAN_ID, DateTime CHA_INVOICE_DATE)
        //{
        //    new Chl_Invoice_MasterDataService().updateChl_InvoiceDate(CHALLAN_ID, CHA_INVOICE_DATE);
        //}
        public void UpdateStutas(string BILLNO, string Bil_Stutas)
        {
            new OrderBillMasterDataService().OrderBillMasterUpdateBILLNO(BILLNO, Bil_Stutas);
        }
        public void Save(IDbTransaction txn)
        {
            new OrderBillMasterDataService().OrderBillMasterSave(OrderBILL_ID, BILLNO, TOTAL, STATUS, BILLDATE, REMARKS, LOGIN_ID, Bil_Stutas, Extra_Payment, NO_OF_Items);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new OrderBillMasterDataService().OrderBillMasterDelete(OrderBILL_ID);
        }
        public static int MaxIdbyBillNo()
        {
            int result = 0;
            DataSet ds = new OrderBillMasterDataService().OrderBillMasterGetMaxbillNo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new OrderBillMasterDataService().OrderBillMasterGetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}
