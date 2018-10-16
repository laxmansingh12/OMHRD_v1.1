using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class NewCollectionMasterCollection : BusinessBaseCollection<NewCollectionMaster>
    {
        public static NewCollectionMasterCollection GetAll()
        {
            NewCollectionMasterCollection obj = new NewCollectionMasterCollection();
            obj.MapObjects(new NewCollectionDataService().NewCollection_GetAll());
            return obj;

        }
        public static ITEM_MASTER GetByITEMNAME(string ITEMNAME)
        {
            ITEM_MASTER obj = new ITEM_MASTER();
            obj.MapData(new NewCollectionDataService().NewCollection_GetByITEMNAME(ITEMNAME));
            return obj;
        }
        public static NewCollectionMasterCollection GetByNewCollection_ID(int NewCollection_ID)
        {
            NewCollectionMasterCollection obj = new NewCollectionMasterCollection();
            obj.MapObjects(new NewCollectionDataService().NewCollection_GetByNewCollection_ID(NewCollection_ID));
            return obj;

        }
    }
}
