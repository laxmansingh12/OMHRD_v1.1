using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class DayalDataset : BusinessBaseObject
    {
        #region

      public int SR_NO { get; set; }
      public string CROP_NAME { get; set; }
      public int Quantity { get; set; }
      public float PRICE { get; set; }
      public float TOTAL { get; set; }
      public string PURCHASED_FROM { get; set; }
     
        #endregion

      
    }
}
