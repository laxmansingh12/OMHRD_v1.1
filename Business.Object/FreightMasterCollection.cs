using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class FreightMasterCollection : BusinessBaseCollection<FreightMaster>
    {
        public static FreightMasterCollection GetAll()
        {
            FreightMasterCollection obj = new FreightMasterCollection();
            obj.MapObjects(new FreightMasterDataService().FreightMaster_GetAll());
            return obj;

        }
        public static FreightMasterCollection GetByName(string FREIGHT)
        {
            FreightMasterCollection obj = new FreightMasterCollection();
            obj.MapObjects(new FreightMasterDataService().FreightMaster_GetByFreight(FREIGHT));
            return obj;
        }
        public static FreightMasterCollection GetAllById(int FREIGHT_ID)
        {
            FreightMasterCollection obj = new FreightMasterCollection();
            obj.MapObjects(new FreightMasterDataService().FreightMaster_GetById(FREIGHT_ID));
            return obj;

        }
        public static FreightMasterCollection GetAllByFreightDate(DateTime DATE)
        {
            FreightMasterCollection obj = new FreightMasterCollection();
            obj.MapObjects(new FreightMasterDataService().FreightMaster_GetByFreightDate(DATE));
            return obj;

        }
    }
}
