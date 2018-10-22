using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class PickUpItemMasterCollection : BusinessBaseCollection<PickUpItemMaster>
    {
        public static PickUpItemMasterCollection GetAll()
        {
            PickUpItemMasterCollection obj = new PickUpItemMasterCollection();
            obj.MapObjects(new PickUpItemEnterMasterService().PickUpItemGetAll());
            return obj;
        }
        public static PickUpItemMasterCollection getOrderId(int OrderId)
        {
            PickUpItemMasterCollection obj = new PickUpItemMasterCollection();
            obj.MapObjects(new PickUpItemEnterMasterService().PickUpItemGetByOrderId(OrderId));
            return obj;
        }
    }
}
