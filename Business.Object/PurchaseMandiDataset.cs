using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class PurchaseMandiDataset : BusinessBaseObject
    {
        #region

      public int SR_NO { get; set; }
      public string CROP_NAME { get; set; }
      public int Quantity { get; set; }
      public float PUR_PRICE { get; set; }
      public float PURCHASE_VALUE { get; set; }
      public float SALE_PRICE { get; set; }
      public float SALE_VALUE { get; set; }
      public float MARGIN_VALUE { get; set; }
      public float MARGIN { get; set; }
     
        #endregion

      
    }
}
