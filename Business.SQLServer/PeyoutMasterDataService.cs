using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
    public class PeyoutMasterDataService : DataServiceBase
    {
        #region Consturctor

        public PeyoutMasterDataService() : base() { }
        public PeyoutMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void PeyoutMaster_Save(int PeyoutID, int User_ID, decimal TotalAmount, decimal TDS, string DisInPerTDS, decimal TaxableValueTDS, decimal DiscountValueTDS,
                                      decimal Welfare, string DisInPerWel, decimal TaxableValueWel, decimal DiscountValueWel, decimal Charity, string DisInPerChar,
                                      decimal TaxableValueChar, decimal DiscountValuChar, decimal Miscell, string DisInPerMis, decimal TaxableValueMis, decimal DiscountValMis,
                                      decimal OtherAmount, string REMARKS)
        {
            SqlCommand cmd;
            DataSet ds = PeyoutMaster_GetByPeyoutID(PeyoutID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE PeyoutMaster set int User_ID,  TotalAmount=@TotalAmount, TDS=@TDS,  DisInPerTDS=@DisInPerTDS, TaxableValueTD=@TaxableValueTDS, DiscountValueTDS=@DiscountValueTDS,
                                         Welfare=@Welfare, DisInPerWel=@DisInPerWel, TaxableValueWel=@TaxableValueWel, DiscountValueWel=@DiscountValueWel, Charity=@Charity, DisInPerChar=@DisInPerChar, TaxableValueChar=@TaxableValueChar, DiscountValuChar=@DiscountValuChar,
                                         Miscell=@Miscell, DisInPerMis=@DisInPerMis, TaxableValueMis=@TaxableValueMis, DiscountValMis=@DiscountValMis, OtherAmount=@OtherAmount, REMARKS=@REMARKS where PeyoutID=@PeyoutID",
                         CreateParameter("@User_ID", SqlDbType.Int, User_ID),
                         CreateParameter("@TotalAmount", SqlDbType.Decimal, TotalAmount),
                         CreateParameter("@TDS", SqlDbType.Decimal, TDS),
                         CreateParameter("@DisInPerTDS", SqlDbType.VarChar, DisInPerTDS),
                         CreateParameter("@TaxableValueTDS", SqlDbType.Decimal, TaxableValueTDS),
                         CreateParameter("@DiscountValueTDS", SqlDbType.Decimal, DiscountValueTDS),
                         CreateParameter("@Welfare", SqlDbType.Decimal, Welfare),
                         CreateParameter("@DisInPerWel", SqlDbType.VarChar, DisInPerWel),
                         CreateParameter("@TaxableValueWel", SqlDbType.Decimal, TaxableValueWel),
                         CreateParameter("@DiscountValueWel", SqlDbType.Decimal, DiscountValueWel),
                         CreateParameter("@Charity", SqlDbType.Decimal, Charity),
                         CreateParameter("@DisInPerChar", SqlDbType.VarChar, DisInPerChar),
                         CreateParameter("@TaxableValueChar", SqlDbType.Decimal, TaxableValueChar),
                         CreateParameter("@DiscountValuChar", SqlDbType.Decimal, DiscountValuChar),
                         CreateParameter("@Miscell", SqlDbType.Decimal, Miscell),
                         CreateParameter("@DisInPerMis", SqlDbType.VarChar, DisInPerMis),
                         CreateParameter("@TaxableValueMis", SqlDbType.Decimal, TaxableValueMis),
                         CreateParameter("@DiscountValMis", SqlDbType.Decimal, DiscountValMis),
                         CreateParameter("@OtherAmount", SqlDbType.Decimal, OtherAmount),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@PeyoutID", SqlDbType.Int, PeyoutID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO PeyoutMaster VALUES(@PeyoutID, @User_ID, @TotalAmount, @TDS, @DisInPerTDS, @TaxableValueTDS, @DiscountValueTDS,
                                                                           @Welfare, @DisInPerWel, @TaxableValueWel, @DiscountValueWel, @Charity, @DisInPerChar,
                                                                           @TaxableValueChar, @DiscountValuChar, @Miscell, @DisInPerMis, @TaxableValueMis, @DiscountValMis,
                                                                           @OtherAmount, @REMARKS)",
                         CreateParameter("@PeyoutID", SqlDbType.Int, PeyoutID),
                         CreateParameter("@User_ID", SqlDbType.Int, User_ID),
                         CreateParameter("@TotalAmount", SqlDbType.Decimal, TotalAmount),
                         CreateParameter("@TDS", SqlDbType.Decimal, TDS),
                         CreateParameter("@DisInPerTDS", SqlDbType.VarChar, DisInPerTDS),
                         CreateParameter("@TaxableValueTDS", SqlDbType.Decimal, TaxableValueTDS),
                         CreateParameter("@DiscountValueTDS", SqlDbType.Decimal, DiscountValueTDS),
                         CreateParameter("@Welfare", SqlDbType.Decimal, Welfare),
                         CreateParameter("@DisInPerWel", SqlDbType.VarChar, DisInPerWel),
                         CreateParameter("@TaxableValueWel", SqlDbType.Decimal, TaxableValueWel),
                         CreateParameter("@DiscountValueWel", SqlDbType.Decimal, DiscountValueWel),
                         CreateParameter("@Charity", SqlDbType.Decimal, Charity),
                         CreateParameter("@DisInPerChar", SqlDbType.VarChar, DisInPerChar),
                         CreateParameter("@TaxableValueChar", SqlDbType.Decimal, TaxableValueChar),
                         CreateParameter("@DiscountValuChar", SqlDbType.Decimal, DiscountValuChar),
                         CreateParameter("@Miscell", SqlDbType.Decimal, Miscell),
                         CreateParameter("@DisInPerMis", SqlDbType.VarChar, DisInPerMis),
                         CreateParameter("@TaxableValueMis", SqlDbType.Decimal, TaxableValueMis),
                         CreateParameter("@DiscountValMis", SqlDbType.Decimal, DiscountValMis),
                         CreateParameter("@OtherAmount", SqlDbType.Decimal, OtherAmount),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet PeyoutMaster_GetAll()
        {
            return ExecuteDataSet("select * from PeyoutMaster ", null, null);
        }

        public DataSet PeyoutMaster_GetByPeyoutID(int PeyoutID)
        {
            return ExecuteDataSet("select * from PeyoutMaster where PeyoutID=@PeyoutID", null,
            CreateParameter("@PeyoutID", SqlDbType.Int, PeyoutID));
        }
        public DataSet PeyoutMaster_GetByUser_ID(int User_ID)
        {
            return ExecuteDataSet("select * from PeyoutMaster where User_ID=@User_ID", null,
            CreateParameter("@User_ID", SqlDbType.VarChar, User_ID));
        }

        public DataSet PeyoutMaster_Delete(int PeyoutID)
        {
            return ExecuteDataSet("Delete from PeyoutMaster where PeyoutID=@PeyoutID", null,
            CreateParameter("@PeyoutID", SqlDbType.Int, PeyoutID));
        }

        public DataSet PeyoutMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(PeyoutID)  from PeyoutMaster", null, null);
        }

        #endregion
    }
}
