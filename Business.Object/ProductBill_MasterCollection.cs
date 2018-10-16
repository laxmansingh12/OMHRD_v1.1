using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductBill_MasterCollection : BusinessBaseCollection<ProductBill_Master>
    {
        public static ProductBill_MasterCollection GetAll()
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterGetAll());
            return obj;
        }
        public static ProductBill_MasterCollection GetByFromDate_ToDate(DateTime FromDATE, DateTime ToDate)
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterFromDate_ToDate(FromDATE, ToDate));
            return obj;
        }
        public static ProductBill_MasterCollection GetByFromDate_ToDateAndStatus(DateTime FromDATE, DateTime ToDate, string Bil_Stutas)
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterFromDate_ToDateAndStatus(FromDATE, ToDate, Bil_Stutas));
            return obj;
        }
        public static ProductBill_MasterCollection GetByBillNo(string BILLNO)
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterGetByBILLNO(BILLNO));
            return obj;
        }
        public static ProductBill_MasterCollection GetByFrom_BillNo_TOBillNO(int FromBILLNO, int ToBILLNO)
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterGetByFrom_BILLNO_TO_BILLNO(FromBILLNO, ToBILLNO));
            return obj;
        }
        public static ProductBill_MasterCollection GetByFrom_BillNo_TOBillNOAndStatus(int FromBILLNO, int ToBILLNO, string Bil_Stutas)
        {
            ProductBill_MasterCollection obj = new ProductBill_MasterCollection();
            obj.MapObjects(new ProductBill_MasterDataService().ProductBill_MasterGetByFrom_BILLNO_TO_BILLNOAndStatus(FromBILLNO, ToBILLNO, Bil_Stutas));
            return obj;
        }
    }
}
