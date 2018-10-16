using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class PURCHASE_MASTERCollection : BusinessBaseCollection<PURCHASE_MASTER>
    {
        public static PURCHASE_MASTERCollection GetAll()
        {
            PURCHASE_MASTERCollection obj = new PURCHASE_MASTERCollection();
            obj.MapObjects(new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetAll());
            return obj;

        }
        //public static PaymentMasterCollection GetByPURCHASER(string SALE_AREA)
        //{
        //    PaymentMasterCollection obj = new PaymentMasterCollection();
        //    obj.MapObjects(new PaymentMasterDataService().PaymentMaster_GetBySALEAREA(SALE_AREA));
        //    return obj;
        //}
        public static PURCHASE_MASTERCollection GetByDATE(DateTime PURCHASE_DATE)
        {
            PURCHASE_MASTERCollection obj = new PURCHASE_MASTERCollection();
            obj.MapObjects(new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetByDATE(PURCHASE_DATE));
            return obj;
        }
        public static PURCHASE_MASTERCollection GetAllById(int PURCHASE_ID)
        {
            PURCHASE_MASTERCollection obj = new PURCHASE_MASTERCollection();
            obj.MapObjects(new PURCHASE_MASTERDataService().PURCHASE_MASTER_GetById(PURCHASE_ID));
            return obj;

        }
     
    }
}
