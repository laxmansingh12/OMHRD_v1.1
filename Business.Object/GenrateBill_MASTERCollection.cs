using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class GenrateBill_MASTERCollection : BusinessBaseCollection<GenrateBill_MASTER>
    {
        public static GenrateBill_MASTERCollection GetAll()
        {
            GenrateBill_MASTERCollection obj = new GenrateBill_MASTERCollection();
            obj.MapObjects(new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetAll());
            return obj;

        }
        public static GenrateBill_MASTERCollection GetByFrom_BillNo_TOBillNO(int FromBILLNO, int ToBILLNO)
        {
            GenrateBill_MASTERCollection obj = new GenrateBill_MASTERCollection();
            obj.MapObjects(new GenrateBill_MASTERDataService().Bill_Master_GetByFrom_BILLNO_TO_BILLNO(FromBILLNO, ToBILLNO));
            return obj;
        }
        //public static GenrateBill_MASTERCollection GetByDATE(DateTime DATE)
        //{
        //    GenrateBill_MASTERCollection obj = new GenrateBill_MASTERCollection();
        //    obj.MapObjects(new GenrateBill_MASTERDataService().Challan_MASTER_GetByDATE(DATE));
        //    return obj;
        //}
      }
}
