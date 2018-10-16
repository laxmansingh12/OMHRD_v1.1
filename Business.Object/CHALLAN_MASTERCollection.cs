using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class CHALLAN_MASTERCollection : BusinessBaseCollection<CHALLAN_MASTER>
    {
        public static CHALLAN_MASTERCollection GetAll()
        {
            CHALLAN_MASTERCollection obj = new CHALLAN_MASTERCollection();
            obj.MapObjects(new Challan_MASTERDataService().Challan_MASTER_GetAll());
            return obj;

        }
        public static CHALLAN_MASTERCollection GetByFrom_BillNo_TOBillNO(string From_ChallanNO, string To_ChallanNO)
        {
            CHALLAN_MASTERCollection obj = new CHALLAN_MASTERCollection();
            obj.MapObjects(new Challan_MASTERDataService().Bill_Master_GetByFrom_BILLNO_TO_BILLNO(From_ChallanNO, To_ChallanNO));
            return obj;
        }
        public static CHALLAN_MASTERCollection GetByFromDate_ToDate(DateTime FromDATE, DateTime ToDate)
        {
            CHALLAN_MASTERCollection obj = new CHALLAN_MASTERCollection();
            obj.MapObjects(new Challan_MASTERDataService().Challan_MASTER_GetByFromDate_ToDate(FromDATE, ToDate));
            return obj;
        }
        public static CHALLAN_MASTERCollection GetByDATE(DateTime DATE)
        {
            CHALLAN_MASTERCollection obj = new CHALLAN_MASTERCollection();
            obj.MapObjects(new Challan_MASTERDataService().Challan_MASTER_GetByDATE(DATE));
            return obj;
        }
      }
}
