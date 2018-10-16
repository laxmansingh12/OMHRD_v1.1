using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class KharchaMasterCollection : BusinessBaseCollection<KharchaMaster>
    {
        public static KharchaMasterCollection GetAll()
        {
            KharchaMasterCollection obj = new KharchaMasterCollection();
            obj.MapObjects(new KharchaMasterDataService().SaleMaster_GetAll());
            return obj;

        }

        public static KharchaMasterCollection GetAllById(int KHARCHA_ID)
        {
            KharchaMasterCollection obj = new KharchaMasterCollection();
            obj.MapObjects(new KharchaMasterDataService().SaleMaster_GetById(KHARCHA_ID));
            return obj;

        }
        //public static KharchaMasterCollection GetAllByDate(DateTime DATE)
        //{
        //    KharchaMasterCollection obj = new KharchaMasterCollection();
        //    obj.MapObjects(new KharchaMasterDataService().SaleMaster_GetByDATE(DATE));
        //    return obj;

        //}
    }
}
