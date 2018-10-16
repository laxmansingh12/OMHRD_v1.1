using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class FarmerMasterCollection : BusinessBaseCollection<FarmerMaster>
    {
        public static FarmerMasterCollection GetAll()
        {
            FarmerMasterCollection obj = new FarmerMasterCollection();
            obj.MapObjects(new FarmerMasterDataService().FarmerMaster_GetAll());
            return obj;

        }
        public static FarmerMasterCollection GetByName(string HOTEL_NAME)
        {
            FarmerMasterCollection obj = new FarmerMasterCollection();
            obj.MapObjects(new FarmerMasterDataService().FarmerMaster_GetByName(HOTEL_NAME));
            return obj;
        }
        public static FarmerMasterCollection GetAllById(int HOTEL_ID)
        {
            FarmerMasterCollection obj = new FarmerMasterCollection();
            obj.MapObjects(new FarmerMasterDataService().FarmerMaster_GetById(HOTEL_ID));
            return obj;

        }
       
    }
}
