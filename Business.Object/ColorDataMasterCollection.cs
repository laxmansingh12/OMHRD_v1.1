
using System;
using System.Text;
using System.Collections.Generic;
using Business.SQLServer;

namespace Business.Object
{
    public class ColorDataMasterCollection : BusinessBaseCollection<ColorDataMaster>
    {
        public static ColorDataMasterCollection GetAll()
        {
            ColorDataMasterCollection obj = new ColorDataMasterCollection();
            obj.MapObjects(new ColorMasterDataService().ColorMaster_GetAll());
            return obj;
        }
        public static ColorDataMasterCollection GetbyColor_ID(int Color_ID)
        {
            ColorDataMasterCollection obj = new ColorDataMasterCollection();
            obj.MapObjects(new ColorMasterDataService().ColorMaster_GetByColor_ID(Color_ID));
            return obj;
        }
    }
}
