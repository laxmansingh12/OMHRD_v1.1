using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class FreightMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public FreightMasterDataService() : base() { }
        public FreightMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void FreightMaster_Save(int FREIGHT_ID, string STOCK, string FREIGHT, DateTime DATE, int BILL_NO, string REMARKS)
        {
            SqlCommand cmd;
            DataSet ds = FreightMaster_GetById(FREIGHT_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE FREIGHT_MASTER set STOCK=@STOCK,FREIGHT=@FREIGHT,REMARKS=@REMARKS where FREIGHT_ID=@FREIGHT_ID",
                         CreateParameter("@FREIGHT", SqlDbType.VarChar, FREIGHT),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                         CreateParameter("@FREIGHT_ID", SqlDbType.Int, FREIGHT_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO FREIGHT_MASTER VALUES(@FREIGHT_ID,@STOCK,@FREIGHT,@DATE,@BILL_NO,@REMARKS)",
                         CreateParameter("@FREIGHT_ID", SqlDbType.Int, FREIGHT_ID),
                         CreateParameter("@STOCK",SqlDbType.VarChar,STOCK),
                         CreateParameter("@FREIGHT", SqlDbType.VarChar, FREIGHT),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE),
                         CreateParameter("@BILL_NO", SqlDbType.Int,BILL_NO),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet FreightMaster_GetAll()
        {
            return ExecuteDataSet("select * from FREIGHT_MASTER ", null, null);
        }

        public DataSet FreightMaster_GetById(int FREIGHT_ID)
        {
            return ExecuteDataSet("select * from FREIGHT_MASTER where FREIGHT_ID=@FREIGHT_ID", null,
            CreateParameter("@FREIGHT_ID", SqlDbType.Int, FREIGHT_ID));
        }

        public DataSet FreightMaster_GetByFreight(string FREIGHT)
        {
            return ExecuteDataSet("select * from FREIGHT_MASTER where FREIGHT=@FREIGHT", null,
            CreateParameter("@FREIGHT", SqlDbType.VarChar, FREIGHT));
        }
        public DataSet FreightMaster_GetByFreightDate(DateTime DATE)
        {
            return ExecuteDataSet("select * from FREIGHT_MASTER where DATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        }

        public DataSet FreightMaster_Delete(int FREIGHT_ID)
        {
            return ExecuteDataSet("Delete from FREIGHT_MASTER where FREIGHT_ID=@FREIGHT_ID", null,
            CreateParameter("@FREIGHT_ID", SqlDbType.Int, FREIGHT_ID));
        }

        public DataSet FreightMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(FREIGHT_ID)  from FREIGHT_MASTER", null, null);
        }

        #endregion

        //public void FarmerMaster_Save(int FARMER_ID, string DAYAL_ID, string NAME, string ADDRESS, string PINCODE, string CONTACT, string REMARKS)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
