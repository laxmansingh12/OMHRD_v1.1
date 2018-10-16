using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Object
{
    public class Totalamountcs : BusinessBaseObject
    {
        #region
        public int SrNo { get; set; }
        public int HOTEL_ID { get; set; }
        public string Hotel_Name { get; set; }
        public DateTime date { get; set; }
        public string Total { get; set; }
        public int Bill_no { get; set; }
        #endregion
    }
}
