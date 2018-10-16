using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class GallarymasterCollection : BusinessBaseCollection<GallaryMaster>
    {
        public static GallarymasterCollection GetAll()
        {
            GallarymasterCollection obj = new GallarymasterCollection();
            obj.MapObjects(new GalleryDataService().GalleryGetAll());
            return obj;
        }
        public static GallarymasterCollection FILE_ID(int FILE_ID)
        {
            GallarymasterCollection obj = new GallarymasterCollection();
            obj.MapObjects(new GalleryDataService().GalleryGetById(FILE_ID));
            return obj;
        }
    }
}
