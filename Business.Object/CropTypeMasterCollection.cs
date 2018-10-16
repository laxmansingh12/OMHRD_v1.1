using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class CropTypeMasterCollection : BusinessBaseCollection<CropTypeMaster>
    {
        public static CropTypeMasterCollection GetAll()
        {
            CropTypeMasterCollection obj = new CropTypeMasterCollection();
            obj.MapObjects(new CropTypeMasterDataService().CropTypeMaster_GetAll());
            return obj;

        }
        public static CropTypeMasterCollection GetByName(string CROPS_TYPE)
        {
            CropTypeMasterCollection obj = new CropTypeMasterCollection();
            obj.MapObjects(new CropTypeMasterDataService().CropTypeMaster_GetByName(CROPS_TYPE));
            return obj;
        }
        public static CropTypeMasterCollection GetAllById(int CROPS_TYPE_ID)
        {
            CropTypeMasterCollection obj = new CropTypeMasterCollection();
            obj.MapObjects(new CropTypeMasterDataService().CropTypeMaster_GetById(CROPS_TYPE_ID));
            return obj;

        }
    }
}
