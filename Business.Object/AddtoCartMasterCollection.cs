using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class AddtoCartMasterCollection : BusinessBaseCollection<AddtoCartMaster>
    {
        public static AddtoCartMasterCollection GetAll()
        {
            AddtoCartMasterCollection obj = new AddtoCartMasterCollection();
            obj.MapObjects(new AddtoCartDataService().AddtoCartMaster_GetAll());
            return obj;
        }
       
    }
}
