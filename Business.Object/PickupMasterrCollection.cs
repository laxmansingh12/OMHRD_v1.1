using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class PickupMasterrCollection : BusinessBaseCollection<PickupMaster>
    {
        public static PickupMasterrCollection GetAll()
        {
            PickupMasterrCollection obj = new PickupMasterrCollection();
            obj.MapObjects(new PickUpMasterDataSevice().PickUpMasterGetAll());
            return obj;
        }
        public static PickupMasterrCollection GetByPickupID(int PickupID)
        {
            PickupMasterrCollection obj = new PickupMasterrCollection();
            obj.MapObjects(new PickUpMasterDataSevice().PickUpMasterGetByPickupID(PickupID));
            return obj;
        }
    }
}
