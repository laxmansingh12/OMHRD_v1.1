using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class GuestUserMasterCollection : BusinessBaseCollection<GuestUserMaster>
    {
        public static GuestUserMasterCollection GetAll()
        {
            GuestUserMasterCollection obj = new GuestUserMasterCollection();
            obj.MapObjects(new GuestUserDataService().GuestUser_GetAll());
            return obj;

        }
        public static User_Master GetByGuest_Name(string Guest_Name)
        {
            User_Master obj = new User_Master();
            obj.MapData(new GuestUserDataService().GuestUser_GetByGuest_Name(Guest_Name));
            return obj;
        }
        public static GuestUserMasterCollection GetByGuest_Id(int Guest_Id)
        {
            GuestUserMasterCollection obj = new GuestUserMasterCollection();
            obj.MapObjects(new GuestUserDataService().GuestUser_GetByGuest_Id(Guest_Id));
            return obj;

        }
    }
}
