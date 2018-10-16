using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class ProductAddCollection : BusinessBaseCollection<ProductAdd>
    {
        public static ProductAddCollection GetAll()
        {
            ProductAddCollection obj = new ProductAddCollection();
            obj.MapObjects(new ProductAddService().ProductAddGetAll());
            return obj;
        }
        public static ProductAddCollection PRO_ID(int PRO_ID)
        {
            ProductAddCollection obj = new ProductAddCollection();
            obj.MapObjects(new ProductAddService().ProductAddGetByPRO_ID(PRO_ID));
            return obj;
        }
    }
}
