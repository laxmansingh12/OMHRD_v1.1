using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;
using Business.Common;

namespace Business.Object
{
   public class CropentryPrint:BusinessBaseObject
    {
        #region
        public int SrNo { get; set; }
        public string Crop_name { get; set; }
        public string Quantity { get; set; }
        public string Purchasing_Rate { get; set; }
        public DateTime Purchasing_date { get; set; }
        #endregion

    }
}
