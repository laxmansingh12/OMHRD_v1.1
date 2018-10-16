using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class Unit_MasterCollection : BusinessBaseCollection<Unit_Master>
    {
        public static Unit_MasterCollection GetAll()
        {
            Unit_MasterCollection obj = new Unit_MasterCollection();
            obj.MapObjects(new Unit_MasterDataService().UNITMASTER_GetAll());
            return obj;

        }
        public static Unit_Master GetByCode(string Code)
        {
            Unit_Master obj = new Unit_Master();
            obj.MapData(new Unit_MasterDataService().UNITMASTER_GetByCode(Code));
            return obj;
        }
        public static Unit_MasterCollection GetByUNIT_ID(int UNIT_ID)
        {
            Unit_MasterCollection obj = new Unit_MasterCollection();
            obj.MapObjects(new Unit_MasterDataService().UNITMASTER_GetByUNIT_ID(UNIT_ID));
            return obj;

        }
    }
}
