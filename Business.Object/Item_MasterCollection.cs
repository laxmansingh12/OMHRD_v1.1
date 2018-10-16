using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class ITEM_MASTERCollection : BusinessBaseCollection<ITEM_MASTER>
    {
        public static ITEM_MASTERCollection GetAll()
        {
            ITEM_MASTERCollection obj = new ITEM_MASTERCollection();
            obj.MapObjects(new ITEM_MASTERDataService().ITEM_MASTER_GetAll());
            return obj;

        }
        public static ITEM_MASTER GetByITEMNAME(string ITEMNAME)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEMNAME(ITEMNAME));
            return obj;
        }
        public static ITEM_MASTERCollection GetByITEM_ID(int ITEM_ID)
        {
            ITEM_MASTERCollection obj = new ITEM_MASTERCollection();
            obj.MapObjects(new ITEM_MASTERDataService().ITEM_MASTER_GetByITEM_ID(ITEM_ID));
            return obj;

        }
    }
}
