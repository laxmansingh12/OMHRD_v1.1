using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class MembeShipUserMasterCollection : BusinessBaseCollection<MembeShipUserMaster>
    {
        public static MembeShipUserMasterCollection GetAll()
        {
            MembeShipUserMasterCollection obj = new MembeShipUserMasterCollection();
            obj.MapObjects(new MembeShipUserDataService().MembeShipUser_GetAll());
            return obj;

        }
        //public static MembeShipUserMaster GetByGuest_Name(string Guest_Name)
        //{
        //    MembeShipUserMaster obj = new MembeShipUserMaster();
        //    obj.MapData(new MembeShipUserDataService().GuestUser_GetByGuest_Name(Guest_Name));
        //    return obj;
        //}
        //public static MembeShipUserMasterCollection GetByGuest_Id(int Guest_Id)
        //{
        //    MembeShipUserMasterCollection obj = new MembeShipUserMasterCollection();
        //    obj.MapObjects(new MembeShipUserDataService().GuestUser_GetByGuest_Id(Guest_Id));
        //    return obj;

        //}
    }
}
