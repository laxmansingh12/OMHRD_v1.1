using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;
using Business.Common;
namespace Business.Object
{
    public class Supp : BusinessBaseObject
    {
        #region
        public int SrNo { get; set; }
        public string Hotel_Name { get; set; }
        public string Crop_Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public int Bill_No { get; set; }
        public DateTime Date { get; set; }
        public int CHALLAN_ID { get; set; }
        public int HOtel_ID { get; set; }
        public int CROP_ID { get; set; }
        public string CHALLAN_NO { get; set; }
        public float Qty { get; set; }
        public float Rate { get; set; }
        public string Mounth { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartCHALLAN_ID { get; set; }
        public int EndCHALLAN_ID { get; set; }
        public float total { get; set; }
        #endregion

    }
}
