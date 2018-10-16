using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class GenrateBill_MASTER : BusinessBaseObject
    {
        #region

        public int Bill_ID { get; set; }
        public int Bill_NO { get; set; }
        public int Hotel_ID { get; set; }
         public int Start_Challan_NO { get; set; }
        public int End_Challan_NO { get; set; }
        public float Total { get; set; }
        public DateTime Start_DAte { get; set; }
        public DateTime  End_DAte { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            Bill_ID = GetInt(row, "Bill_ID");
            Bill_NO = GetInt(row, "Bill_NO");
            Hotel_ID = GetInt(row, "Hotel_ID");
            Start_Challan_NO = GetInt(row, "Start_Challan_NO");
            End_Challan_NO = GetInt(row, "End_Challan_NO");
            Total = GetFloat(row, "Total");
            Start_DAte = GetDateTime(row, "Start_DAte");
            End_DAte = GetDateTime(row, "End_DAte");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new GenrateBill_MASTERDataService().GenrateBill_MASTER_Save(Bill_ID, Bill_NO, Hotel_ID, Start_Challan_NO, End_Challan_NO, Total, Start_DAte, End_DAte);
        }
        public static GenrateBill_MASTER GetById(int Bill_ID)
        {
            GenrateBill_MASTER obj = new GenrateBill_MASTER();
            obj.MapData(new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetById(Bill_ID));
            return obj;
        }
        public static GenrateBill_MASTER GetByBillNo(int Bill_NO)
        {
            GenrateBill_MASTER obj = new GenrateBill_MASTER();
            obj.MapData(new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetByBillNo(Bill_NO));
            return obj;
        }

        public static GenrateBill_MASTER GetByName(int Hotel_ID)
        {
            GenrateBill_MASTER obj = new GenrateBill_MASTER();
            obj.MapData(new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetByHName(Hotel_ID));
            return obj;
        }

        //public static GenrateBill_MASTER GetByDATE(DateTime DATE)
        //{
        //    GenrateBill_MASTER obj = new GenrateBill_MASTER();
        //    obj.MapData(new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetByDATE(DATE));
        //    return obj;
        //}
        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new GenrateBill_MASTERDataService().GenrateBill_MASTER_Delete(Bill_ID);
        }
        //public static int MaxIdbyhotel(int HOtel_ID, DateTime DATE)
        //{
        //    int result = 0;
        //    DataSet ds = new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetMAXIdbyhotel(HOtel_ID, DATE);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

        //    }
        //    return result;
        //}

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new GenrateBill_MASTERDataService().GenrateBill_MASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
