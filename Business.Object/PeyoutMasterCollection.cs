using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class PeyoutMasterCollection : BusinessBaseCollection<PeyoutMaster>
    {
        public static PeyoutMasterCollection GetAll()
        {
            PeyoutMasterCollection obj = new PeyoutMasterCollection();
            obj.MapObjects(new PeyoutMasterDataService().PeyoutMaster_GetAll());
            return obj;

        }
        public static PeyoutMasterCollection GetAllByPeyoutID(int PeyoutID)
        {
            PeyoutMasterCollection obj = new PeyoutMasterCollection();
            obj.MapObjects(new PeyoutMasterDataService().PeyoutMaster_GetByPeyoutID(PeyoutID));
            return obj;

        }
        public static PeyoutMasterCollection GetAllByUser_ID(int User_ID)
        {
            PeyoutMasterCollection obj = new PeyoutMasterCollection();
            obj.MapObjects(new PeyoutMasterDataService().PeyoutMaster_GetByUser_ID(User_ID));
            return obj;

        }
    }
}
