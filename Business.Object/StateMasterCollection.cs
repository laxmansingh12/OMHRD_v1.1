using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class StateMasterCollection : BusinessBaseCollection<StateMaster>
    {
        public static StateMasterCollection GetAll()
        {
            StateMasterCollection obj = new StateMasterCollection();
            obj.MapObjects(new StateMasterDataService().StateMaster_GetAll());
            return obj;
        }
       
    }
}
