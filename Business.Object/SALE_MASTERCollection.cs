using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class SALE_MASTERCollection : BusinessBaseCollection<SALE_MASTER>
    {
        public static SALE_MASTERCollection GetAll()
        {
            SALE_MASTERCollection obj = new SALE_MASTERCollection();
            obj.MapObjects(new SALE_MASTERDataService().SALE_MASTER_GetAll());
            return obj;

        }
      
        public static SALE_MASTERCollection GetByDATE(DateTime DATE)
        {
            SALE_MASTERCollection obj = new SALE_MASTERCollection();
            obj.MapObjects(new SALE_MASTERDataService().SALE_MASTER_GetByDATE(DATE));
            return obj;
        }
      }
}
