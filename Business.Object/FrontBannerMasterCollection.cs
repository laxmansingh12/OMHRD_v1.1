using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class FrontBannerMasterCollection : BusinessBaseCollection<FrontBannerMaster>
    {
        public static FrontBannerMasterCollection GetAll()
        {
            FrontBannerMasterCollection obj = new FrontBannerMasterCollection();
            obj.MapObjects(new FrontBannerService().FrontBannerGetAll());
            return obj;
        }
        public static FrontBannerMasterCollection FILE_ID(int FILE_ID)
        {
            FrontBannerMasterCollection obj = new FrontBannerMasterCollection();
            obj.MapObjects(new FrontBannerService().FrontBannerGetByFILE_ID(FILE_ID));
            return obj;
        }
    }
}
