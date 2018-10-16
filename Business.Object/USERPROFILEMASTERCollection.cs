using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class USERPROFILEMASTERCollection : BusinessBaseCollection<USERPROFILEMASTER>
    {
        public static USERPROFILEMASTERCollection GetAll()
        {
            USERPROFILEMASTERCollection obj = new USERPROFILEMASTERCollection();
            obj.MapObjects(new USERPROFILEMASTERDataService().USERPROFILEMASTER_GetAll());
            return obj;

        }
        public static USERPROFILEMASTERCollection GetByRegistration_ID(int Registration_ID)
        {
            USERPROFILEMASTERCollection obj = new USERPROFILEMASTERCollection();
            obj.MapObjects(new USERPROFILEMASTERDataService().USERPROFILEMASTER_GetByRegistration_ID(Registration_ID));
            return obj;

        }
        public static USERPROFILEMASTERCollection GetByReference_Id(string Reference_Id)
        {
            USERPROFILEMASTERCollection obj = new USERPROFILEMASTERCollection();
            obj.MapObjects(new USERPROFILEMASTERDataService().USERPROFILEMASTERGetByReference_Id(Reference_Id));
            return obj;

        }
        public static USERPROFILEMASTERCollection GetByUser_Name(string User_Name)
        {
            USERPROFILEMASTERCollection obj = new USERPROFILEMASTERCollection();
            obj.MapObjects(new USERPROFILEMASTERDataService().USERPROFILEMASTERGetByUser_Name(User_Name));
            return obj;

        }
        public static USERPROFILEMASTERCollection GetByEmail(string Email)
        {
            USERPROFILEMASTERCollection obj = new USERPROFILEMASTERCollection();
            obj.MapObjects(new USERPROFILEMASTERDataService().USERPROFILEMASTERGetByEmail(Email));
            return obj;

        }
    }
}
