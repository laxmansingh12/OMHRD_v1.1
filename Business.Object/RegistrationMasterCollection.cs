using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class RegistrationMasterCollection : BusinessBaseCollection<RegistrationMaster>
    {
        public static RegistrationMasterCollection GetAll()
        {
            RegistrationMasterCollection obj = new RegistrationMasterCollection();
            obj.MapObjects(new RegistrationMasterDataService().RegistrationMaster_GetAll());
            return obj;

        }
        public static User_Master GetByUser_Name(string User_Name)
        {
            User_Master obj = new User_Master();
            obj.MapData(new RegistrationMasterDataService().RegistrationMaster_GetByUser_Name(User_Name));
            return obj;
        }
        public static RegistrationMasterCollection GetByRegistration_ID(int Registration_ID)
        {
            RegistrationMasterCollection obj = new RegistrationMasterCollection();
            obj.MapObjects(new RegistrationMasterDataService().RegistrationMaster_GetByRegistration_ID(Registration_ID));
            return obj;

        }
    }
}
