using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class PickUpItemEnterMasterService : DataServiceBase
    {

        #region Constructors

        public PickUpItemEnterMasterService() : base() { }
        public PickUpItemEnterMasterService(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void PickUpItemEnterMasterSave(int Id, int ITEM_ID, string ITEMNAME, string HSNCODE, int CGST, int SGST, int IGST, decimal QUANTITY, decimal RATE_PER, decimal TOTAL, DateTime EntryDate, int PickupID)
        {
            SqlCommand cmd;
            DataSet ds = PickUpItemGetByOrderId(Id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update PickUpItemEntry set [ITEM_ID]=@ITEM_ID,[ITEMNAME]=@ITEMNAME,[HSNCODE]=@HSNCODE,[CGST]=@CGST,[SGST]=@SGST,[IGST]=@IGST,[QUANTITY]=@QUANTITY,[RATE_PER]=@RATE_PER,[TOTAL]=@TOTAL,[EntryDate]=@EntryDate,[PickupID]=@PickupID WHERE Id=@Id",
                                 CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                                   CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                                  CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                                    CreateParameter("@CGST", SqlDbType.Int, CGST),
                                    CreateParameter("@SGST", SqlDbType.Int, SGST),
                                 CreateParameter("@IGST", SqlDbType.Int, IGST),
                                 CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                                 CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                                 CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                 CreateParameter("@EntryDate", SqlDbType.DateTime, EntryDate),
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID),
                                 CreateParameter("@Id", SqlDbType.Int, Id));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into PickUpItemEntry values(@Id, @ITEM_ID,@ITEMNAME,@HSNCODE, @CGST, @SGST, @IGST, @QUANTITY, @RATE_PER, @TOTAL, @EntryDate, @PickupID)",
                                 CreateParameter("@Id", SqlDbType.Int, Id),
                                 CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                                   CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                                  CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                                    CreateParameter("@CGST", SqlDbType.Int, CGST),
                                    CreateParameter("@SGST", SqlDbType.Int, SGST),
                                 CreateParameter("@IGST", SqlDbType.Int, IGST),
                                 CreateParameter("@QUANTITY", SqlDbType.Decimal, QUANTITY),
                                 CreateParameter("@RATE_PER", SqlDbType.Decimal, RATE_PER),
                                 CreateParameter("@TOTAL", SqlDbType.Decimal, TOTAL),
                                 CreateParameter("@EntryDate", SqlDbType.DateTime, EntryDate),
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet PickUpItemGetAll()
        {
            return ExecuteDataSet("Select * from PickUpItemEntry ", null, null);
        }

        public DataSet PickUpItemGetByOrderId(int Id)
        {
            return ExecuteDataSet("select * from PickUpItemEntry where Id=@Id", null,
                CreateParameter("@Id", SqlDbType.Int, Id));
        }

        public DataSet PickUpItemGetMaxID()
        {
            return ExecuteDataSet("select MAX(Id)from PickUpItemEntry", null, null);
        }

        public DataSet PickUpItemGetByDelete(int Id)
        {
            return ExecuteDataSet("Delete from PickUpItemEntry where Id=@Id", null,
                CreateParameter("@Id", SqlDbType.Int, Id));
        }
        #endregion
    }
}
