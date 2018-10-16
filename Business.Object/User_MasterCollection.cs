using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class User_MasterCollection : BusinessBaseCollection<User_Master>
    {
        public static User_MasterCollection GetAll()
        {
            User_MasterCollection obj = new User_MasterCollection();
            obj.MapObjects(new User_MasterDataService().User_Master_GetAll());
            return obj;

        }
        public static User_Master GetByUser_Name(string User_Name)
        {
            User_Master obj = new User_Master();
            obj.MapData(new User_MasterDataService().User_Master_GetByUser_Name(User_Name));
            return obj;
        }
        public static User_MasterCollection GetByUser_Id(int User_Id)
        {
            User_MasterCollection obj = new User_MasterCollection();
            obj.MapObjects(new User_MasterDataService().User_Master_GetByUser_Id(User_Id));
            return obj;

        }
    }
}
