using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;
using Business.Common;
namespace Business.Object
{
  public  class QuickSearchPrint: BusinessBaseObject
  {
      #region
      public int SrNo { get; set; }
      public string Hotel_Name { get; set; }
      public string Crop_Name { get; set; }
      public string Quantity { get; set; }
      public string Price { get; set; }
      public string date { get; set; }
      public string Total { get; set; }
      #endregion

  }
}
