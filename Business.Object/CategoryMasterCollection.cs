using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class CategoryMasterCollection : BusinessBaseCollection<CategoryMaster>
    {
        public static CategoryMasterCollection GetAll()
        {
            CategoryMasterCollection obj = new CategoryMasterCollection();
            obj.MapObjects(new CategoryMasterDataService().CategoryMaster_GetAll());
            return obj;
        }
        public static CategoryMasterCollection Getbycateid(int CATEGORY_ID)
        {
            CategoryMasterCollection obj = new CategoryMasterCollection();
            obj.MapObjects(new CategoryMasterDataService().CategoryMaster_GetByCATEGORY_ID(CATEGORY_ID));
            return obj;
        }
    }
}
