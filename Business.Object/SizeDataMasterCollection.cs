
using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class SizeDataMasterCollection : BusinessBaseCollection<SizeDataMaster>
    {
        public static SizeDataMasterCollection GetAll()
        {
            SizeDataMasterCollection obj = new SizeDataMasterCollection();
            obj.MapObjects(new SizeMasterDataService().SizeMaster_GetAll());
            return obj;
        }
        public static SizeDataMasterCollection GetbySize_ID(int Size_ID)
        {
            SizeDataMasterCollection obj = new SizeDataMasterCollection();
            obj.MapObjects(new SizeMasterDataService().SizeMaster_GetBySize_ID(Size_ID));
            return obj;
        }
    }
}
