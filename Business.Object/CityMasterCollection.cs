using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class CityMasterCollection : BusinessBaseCollection<CityMaster>
    {
        public static CityMasterCollection GetAll()
        {
            CityMasterCollection obj = new CityMasterCollection();
            obj.MapObjects(new CityMasterDataService().CityMaster_GetAll());
            return obj;
        }
       
    }
}
