using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class ShoppingInvoiceMasterCollection : BusinessBaseCollection<ShoppingInvoiceMaster>
    {
        public static ShoppingInvoiceMasterCollection GetAll()
        {
            ShoppingInvoiceMasterCollection obj = new ShoppingInvoiceMasterCollection();
            obj.MapObjects(new ShopingInvoiceDataService().ShopingInvoiceGetAll());
            return obj;

        }
      
        public static ShoppingInvoiceMasterCollection GetByINVOICE_DATE(DateTime INVOICE_DATE)
        {
            ShoppingInvoiceMasterCollection obj = new ShoppingInvoiceMasterCollection();
            obj.MapObjects(new ShopingInvoiceDataService().ShopingInvoiceGetByINVOICE_DATE(INVOICE_DATE));
            return obj;
        }
      }
}
