using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductAddtoCartMasterCollection : BusinessBaseCollection<ProductAddtoCartMaster>
    {
        public static ProductAddtoCartMasterCollection GetAll()
        {
            ProductAddtoCartMasterCollection obj = new ProductAddtoCartMasterCollection();
            obj.MapObjects(new ProductAddtoCartDataService().AddtoCartMaster_GetAll());
            return obj;
        }
       
    }
}
