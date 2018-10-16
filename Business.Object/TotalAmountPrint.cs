using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;
using Business.Common;
namespace Business.Object
{
  public  class TotalAmountPrint: BusinessBaseObject
  {
      #region
      public int SrNo { get; set; }
      public int HOTEL_ID { get; set; }
      public string HOTEL_NAME { get; set; }
      public float AMOUNT { get; set; }
      public DateTime DATE { get; set; }
      public string REMARK { get; set; }
      #endregion

  }
}
