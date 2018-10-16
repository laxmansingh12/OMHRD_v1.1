using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class WalletRechargeMasterCollection : BusinessBaseCollection<WalletRechargeMaster>
    {
        public static WalletRechargeMasterCollection GetAll()
        {
            WalletRechargeMasterCollection obj = new WalletRechargeMasterCollection();
            obj.MapObjects(new WalletRechargeDataService().WalletRechargeGetAll());
            return obj;

        }
        public static Unit_Master GetByCode(int User_Id)
        {
            Unit_Master obj = new Unit_Master();
            obj.MapData(new WalletRechargeDataService().WalletRechargeGetByUser_id(User_Id));
            return obj;
        }
        public static WalletRechargeMasterCollection GetByID(int ID)
        {
            WalletRechargeMasterCollection obj = new WalletRechargeMasterCollection();
            obj.MapObjects(new WalletRechargeDataService().WalletRechargeGetById(ID));
            return obj;

        }
    }
}
