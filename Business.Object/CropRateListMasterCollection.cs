using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class CropRateListMasterCollection : BusinessBaseCollection<CropRateListMaster>
    {
        public static CropRateListMasterCollection GetAll()
        {
            CropRateListMasterCollection obj = new CropRateListMasterCollection();
            obj.MapObjects(new CropRateListDataService().CropRateList_GetAll());
            return obj;

        }
        public static CropRateListMasterCollection GetByMONTHName(string MONTH)
        {
            CropRateListMasterCollection obj = new CropRateListMasterCollection();
            obj.MapObjects(new CropRateListDataService().CropRateList_GetByMonthName(MONTH));
            return obj;
        }
        public static CropRateListMasterCollection GetAllByRate(string CROP_NAME, int HOtel_ID, string MONTH)
        {
            CropRateListMasterCollection obj = new CropRateListMasterCollection();
            obj.MapObjects(new CropRateListDataService().CropRateList_GetByrate(CROP_NAME, HOtel_ID,MONTH));
            return obj;

        }
    }
}
