using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class ShoppingInvoiceMaster : BusinessBaseObject
    {
        #region
        public int INVOICE_ID { get; set; }
        public int ITEM_ID { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal RATE_PER { get; set; }
        public decimal TOTAL { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal TEXABLEVALUE { get; set; }
        public int BILL_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public int Color_ID { get; set; }
        public int Size_ID { get; set; }
        public string Bil_Stutas { get; set; }
        public DateTime INVOICE_DATE { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            INVOICE_ID = GetInt(row, "INVOICE_ID");
            ITEM_ID = GetInt(row, "ITEM_ID");
            QUANTITY = GetDecimal(row, "QUANTITY");
            RATE_PER = GetDecimal(row, "RATE_PER");
            TOTAL = GetDecimal(row, "TOTAL");
            DISCOUNT = GetDecimal(row, "DISCOUNT");
            TEXABLEVALUE = GetDecimal(row, "TEXABLEVALUE");
            BILL_ID = GetInt(row, "BILL_ID");
            CATEGORY_ID = GetInt(row, "CATEGORY_ID");
            Color_ID = GetInt(row, "Color_ID");
            Size_ID = GetInt(row, "Size_ID");
            Bil_Stutas = GetString(row, "Bil_Stutas");
            INVOICE_DATE = GetDateTime(row, "INVOICE_DATE");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new ShopingInvoiceDataService().ShopingInvoiceSave(INVOICE_ID, ITEM_ID, QUANTITY, RATE_PER, TOTAL, DISCOUNT, TEXABLEVALUE, BILL_ID, CATEGORY_ID, Color_ID, Size_ID, Bil_Stutas, INVOICE_DATE);
        }
        public static ShoppingInvoiceMaster GetById(int INVOICE_ID)
        {
            ShoppingInvoiceMaster obj = new ShoppingInvoiceMaster();
            obj.MapData(new ShopingInvoiceDataService().ShopingInvoiceGetByINVOICE_ID(INVOICE_ID));
            return obj;
        }


        public static ShoppingInvoiceMaster GetByITEM_ID(int ITEM_ID)
        {
            ShoppingInvoiceMaster obj = new ShoppingInvoiceMaster();
            obj.MapData(new ShopingInvoiceDataService().ShopingInvoiceGetByITEM_ID(ITEM_ID));
            return obj;
        }

        public static ShoppingInvoiceMaster GetByINVOICE_DATE(DateTime INVOICE_DATE)
        {
            ShoppingInvoiceMaster obj = new ShoppingInvoiceMaster();
            obj.MapData(new ShopingInvoiceDataService().ShopingInvoiceGetByINVOICE_DATE(INVOICE_DATE));
            return obj;
        }
        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new ShopingInvoiceDataService().ShopingInvoiceDelete(INVOICE_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new ShopingInvoiceDataService().ShopingInvoiceGetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
