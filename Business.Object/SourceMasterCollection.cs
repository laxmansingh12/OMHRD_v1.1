using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class SourceMasterCollection : BusinessBaseCollection<Source_master>
    {
        public static SourceMasterCollection GetAll()
        {
            SourceMasterCollection obj = new SourceMasterCollection();
            obj.MapObjects(new SourceMasterDataService().SourceMaster_GetAll());
            return obj;

        }

        public static SourceMasterCollection GetAllById(int AMOUNT_ID)
        {
            SourceMasterCollection obj = new SourceMasterCollection();
            obj.MapObjects(new SourceMasterDataService().SourceMaster_GetById(AMOUNT_ID));
            return obj;

        }
        //public static KharchaMasterCollection GetAllByDate(DateTime DATE)
        //{
        //    KharchaMasterCollection obj = new KharchaMasterCollection();
        //    obj.MapObjects(new KharchaMasterDataService().SaleMaster_GetByDATE(DATE));
        //    return obj;

        //}
    }
}
