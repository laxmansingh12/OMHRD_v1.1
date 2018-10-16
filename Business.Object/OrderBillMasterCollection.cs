using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class OrderBillMasterCollection : BusinessBaseCollection<OrderBillMaster>
    {
        public static OrderBillMasterCollection GetAll()
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterGetAll());
            return obj;
        }
        public static OrderBillMasterCollection GetByFromDate_ToDate(DateTime FromDATE, DateTime ToDate)
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterFromDate_ToDate(FromDATE, ToDate));
            return obj;
        }
        public static OrderBillMasterCollection GetByFromDate_ToDateAndStatus(DateTime FromDATE, DateTime ToDate, string Bil_Stutas)
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterFromDate_ToDateAndStatus(FromDATE, ToDate, Bil_Stutas));
            return obj;
        }
        public static OrderBillMasterCollection GetByBillNo(string BILLNO)
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterGetByBILLNO(BILLNO));
            return obj;
        }
        public static OrderBillMasterCollection GetByFrom_BillNo_TOBillNO(int FromBILLNO, int ToBILLNO)
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterGetByFrom_BILLNO_TO_BILLNO(FromBILLNO, ToBILLNO));
            return obj;
        }
        public static OrderBillMasterCollection GetByFrom_BillNo_TOBillNOAndStatus(int FromBILLNO, int ToBILLNO, string Bil_Stutas)
        {
            OrderBillMasterCollection obj = new OrderBillMasterCollection();
            obj.MapObjects(new OrderBillMasterDataService().OrderBillMasterGetByFrom_BILLNO_TO_BILLNOAndStatus(FromBILLNO, ToBILLNO, Bil_Stutas));
            return obj;
        }
    }
}
