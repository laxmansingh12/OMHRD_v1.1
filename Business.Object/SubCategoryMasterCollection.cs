using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class SubCategoryMasterCollection : BusinessBaseCollection<SubCategoryMaster>
    {
        public static SubCategoryMasterCollection GetAll()
        {
            SubCategoryMasterCollection obj = new SubCategoryMasterCollection();
            obj.MapObjects(new SubCategoryMasterDataService().SubCategoryMaster_GetAll());
            return obj;
        }
        public static SubCategoryMasterCollection GetbySubcateid(int SubCATEGORY_ID)
        {
            SubCategoryMasterCollection obj = new SubCategoryMasterCollection();
            obj.MapObjects(new SubCategoryMasterDataService().SubCategoryMaster_GetBySubCategory_ID(SubCATEGORY_ID));
            return obj;
        }
    }
}
