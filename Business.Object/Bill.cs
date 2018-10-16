using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Object
{
    public class Bill : BusinessBaseObject
    {
        public int Sr_No { get; set; }
        public string Item_name { get; set; }
        public string Item_code { get; set; }
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public decimal Rate_per { get; set; }
        public decimal Total { get; set; }
        public string Discount { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal CGST_rate { get; set; }
        public decimal CGST_amt { get; set; }
        public decimal SGST_rate { get; set; }
        public decimal SGST_amt { get; set; }
        public decimal IGST_rate { get; set; }
        public decimal IGST_amt { get; set; }
        public string Freight_rate { get; set; }
        public string Insurance_rate { get; set; }
        public string Packing_rate { get; set; }
        public string Freight_igstrate { get; set; }
        public string Insurance_igstrate { get; set; }
        public string packing_igstrate { get; set; }
        public string Freight_amt { get; set; }
        public string Insurance_amt { get; set; }
        public string Packing_amt { get; set; }
        public string Freight_igstamt { get; set; }
        public string Insurance_igstamt { get; set; }
        public string Packing_igstamt { get; set; }
    }
}
