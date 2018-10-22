using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class PickUpItemMaster : BusinessBaseObject
    {
        #region Properties
        public int Id { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEMNAME { get; set; }
        public string HSNCODE { get; set; }
        public string ItemName
        {
            get
            {
                ITEM_MASTER sm = ITEM_MASTER.GetByITEM_ID(ITEM_ID);
                return sm.ITEMNAME.ToString();
            }
        }
        public int CGST { get; set; }
        public int SGST { get; set; }
        public int IGST { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal RATE_PER { get; set; }
        public decimal TOTAL { get; set; }
        public DateTime EntryDate { get; set; }
        public int PickupID { get; set; }
        #endregion


        #region Methods
        public override bool MapData(DataRow row)
        {
            Id = GetInt(row, "Id");
            ITEM_ID = GetInt(row, "ITEM_ID");
            ITEMNAME = GetString(row, "ITEMNAME");
            HSNCODE = GetString(row, "HSNCODE");
            CGST = GetInt(row, "CGST");
            SGST = GetInt(row, "SGST");
            IGST = GetInt(row, "IGST");
            QUANTITY = GetDecimal(row, "QUANTITY");
            RATE_PER = GetDecimal(row, "RATE_PER");
            TOTAL = GetDecimal(row, "TOTAL");
            EntryDate = GetDateTime(row, "EntryDate");
            PickupID = GetInt(row, "PickupID");
            return base.MapData(row);
        }
        public static PickUpItemMaster GetByOrderId(int Id)
        {
            PickUpItemMaster obj = new PickUpItemMaster();
            obj.MapData(new PickUpItemEnterMasterService().PickUpItemGetByOrderId(Id));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new PickUpItemEnterMasterService().PickUpItemEnterMasterSave(Id, ITEM_ID, ITEMNAME, HSNCODE, CGST, SGST, IGST, QUANTITY, RATE_PER, TOTAL, EntryDate, PickupID);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new PickUpItemEnterMasterService().PickUpItemGetByDelete(Id);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new PickUpItemEnterMasterService().PickUpItemGetMaxID();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
