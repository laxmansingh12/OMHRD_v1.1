using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
    public class PeyoutMaster : BusinessBaseObject
    {
        #region
        public int PeyoutID { get; set; }
        public int User_ID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TDS { get; set; }
        public string DisInPerTDS { get; set; }
        public decimal TaxableValueTDS { get; set; }
        public decimal DiscountValueTDS { get; set; }
        public decimal Welfare { get; set; }
        public string DisInPerWel { get; set; }
        public decimal TaxableValueWel { get; set; }
        public decimal DiscountValueWel { get; set; }
        public decimal Charity { get; set; }
        public string DisInPerChar { get; set; }
        public decimal TaxableValueChar { get; set; }
        public decimal DiscountValuChar { get; set; }
        public decimal Miscell { get; set; }
        public string DisInPerMis { get; set; }
        public decimal TaxableValueMis { get; set; }
        public decimal DiscountValMis { get; set; }
        public decimal OtherAmount { get; set; }
        public string REMARKS { get; set; }

        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            PeyoutID = GetInt(row, "PeyoutID"); User_ID = GetInt(row, "User_ID");
            TotalAmount = GetDecimal(row, "TotalAmount"); TDS = GetDecimal(row, "TDS");
            DisInPerTDS = GetString(row, "DisInPerTDS"); TaxableValueTDS = GetDecimal(row, "TaxableValueTDS");
            DiscountValueTDS = GetDecimal(row, "DiscountValueTDS"); Welfare = GetDecimal(row, "Welfare");
            DisInPerWel = GetString(row, "DisInPerWel"); TaxableValueWel = GetDecimal(row, "TaxableValueWel");
            DiscountValueWel = GetDecimal(row, "DiscountValueWel"); Charity = GetDecimal(row, "Charity");
            DisInPerChar = GetString(row, "DisInPerChar"); TaxableValueChar = GetDecimal(row, "TaxableValueChar");
            DiscountValuChar = GetDecimal(row, "DiscountValuChar"); Miscell = GetDecimal(row, "Miscell");
            DisInPerMis = GetString(row, "DisInPerMis"); TaxableValueMis = GetDecimal(row, "TaxableValueMis");
            DiscountValMis = GetDecimal(row, "DiscountValMis"); OtherAmount = GetDecimal(row, "OtherAmount"); REMARKS = GetString(row, "REMARKS");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new PeyoutMasterDataService().PeyoutMaster_Save(PeyoutID, User_ID, TotalAmount, TDS, DisInPerTDS, TaxableValueTDS, DiscountValueTDS,
                                       Welfare, DisInPerWel, TaxableValueWel, DiscountValueWel, Charity, DisInPerChar,
                                       TaxableValueChar, DiscountValuChar, Miscell, DisInPerMis, TaxableValueMis, DiscountValMis,
                                       OtherAmount, REMARKS);
        }
        public static PeyoutMaster GetById(int PeyoutID)
        {
            PeyoutMaster obj = new PeyoutMaster();
            obj.MapData(new PeyoutMasterDataService().PeyoutMaster_GetByPeyoutID(PeyoutID));
            return obj;
        }

        public static PeyoutMaster GetByUser_ID(int User_ID)
        {
            PeyoutMaster obj = new PeyoutMaster();
            obj.MapData(new PeyoutMasterDataService().PeyoutMaster_GetByUser_ID(User_ID));
            return obj;
        }

        public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new PeyoutMasterDataService().PeyoutMaster_Delete(PeyoutID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new PeyoutMasterDataService().PeyoutMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
