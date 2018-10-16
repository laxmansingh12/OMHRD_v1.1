using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class BannerMasterCollection : BusinessBaseCollection<BannerMaster>
    {
        public static BannerMasterCollection GetAll()
        {
            BannerMasterCollection obj = new BannerMasterCollection();
            obj.MapObjects(new BannerService().BannerGetAll());
            return obj;
        }
        public static BannerMasterCollection FILE_ID(int FILE_ID)
        {
            BannerMasterCollection obj = new BannerMasterCollection();
            obj.MapObjects(new BannerService().BannerGetByFILE_ID(FILE_ID));
            return obj;
        }
    }
}
