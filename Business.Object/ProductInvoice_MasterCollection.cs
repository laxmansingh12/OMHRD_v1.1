using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductInvoice_MasterCollection : BusinessBaseCollection<ProductInvoice_Master>
    {
        public static ProductInvoice_MasterCollection GetAll()
        {
            ProductInvoice_MasterCollection obj = new ProductInvoice_MasterCollection();
            obj.MapObjects(new ProductInvoice_MasterDataService().ProductInvoice_Master_GetAll());
            return obj;
        }
        public static ProductInvoice_MasterCollection GetByBILL_ID(int BILL_ID)
        {
            ProductInvoice_MasterCollection obj = new ProductInvoice_MasterCollection();
            obj.MapObjects(new ProductInvoice_MasterDataService().ProductInvoice_Master_GetByBILL_ID(BILL_ID));
            return obj;
        }
    }
}
