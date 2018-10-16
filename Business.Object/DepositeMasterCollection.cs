using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class DepositeMasterCollection : BusinessBaseCollection<DepositeMaster>
    {
        public static DepositeMasterCollection GetAll()
        {
            DepositeMasterCollection obj = new DepositeMasterCollection();
            obj.MapObjects(new DepositeMasterDataService().DepositeMaster_GetAll());
            return obj;

        }
        //public static PurchasingMasterCollection GetByPurchaser(string PURCHASER_ID)
        //{
        //    PurchasingMasterCollection obj = new PurchasingMasterCollection();
        //    obj.MapObjects(new PurchasingMasterDataService().PurchasingMaster_GetByPurchaser(PURCHASER_ID));
        //    return obj;
        //}
        //public static PurchasingMasterCollection GetByPURCHASE_DATE(DateTime PURCHASE_DATE)
        //{
        //    PurchasingMasterCollection obj = new PurchasingMasterCollection();
        //    obj.MapObjects(new PurchasingMasterDataService().PurchasingMaster_GetByPURCHASE_DATE(PURCHASE_DATE));
        //    return obj;
        //}
        //public static PurchasingMasterCollection GetAllById(int PURCHASE_ID)
        //{
        //    PurchasingMasterCollection obj = new PurchasingMasterCollection();
        //    obj.MapObjects(new PurchasingMasterDataService().PurchasingMaster_GetById(PURCHASE_ID));
        //    return obj;

        //}
        //public static PurchasingMasterCollection GetAllByDatePurchaser(DateTime PURCHASE_DATE, string PURCHASED_FROM)
        //{
        //    PurchasingMasterCollection obj = new PurchasingMasterCollection();
        //    obj.MapObjects(new PurchasingMasterDataService().PurchasingMaster_GetByDatePurchaser(PURCHASE_DATE, PURCHASED_FROM));
        //    return obj;

        //}
    }
}
