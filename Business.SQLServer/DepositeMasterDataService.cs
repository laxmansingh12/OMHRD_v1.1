using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class DepositeMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public DepositeMasterDataService() : base() { }
        public DepositeMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void DepositeMaster_Save(int DEPOSITE_ID,string ACCOUNT_NO, string MONEY, DateTime DATE)
        {
            SqlCommand cmd;
            DataSet ds = DepositeMaster_GetById(DEPOSITE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                 //ExecuteNonQuery(out cmd, @"UPDATE PURCHASING_MASTER set  CROP_ID = @CROP_ID, QUANTITY=@QUANTITY,PRICE=@PRICE,STOCK_AREA =@STOCK_AREA, PURCHASED_FROM=@PURCHASED_FROM,PURCHASED_ID=@PURCHASED_ID,PURCHASE_DATE=@PURCHASE_DATE,REMARK=@REMARK,LOGIN_ID=@LOGIN_ID,LOGINFO=@LOGINFO where PURCHASE_ID=@PURCHASE_ID",
                ExecuteNonQuery(out cmd, @"UPDATE DEPOSITE_MASTER set MONEY=@MONEY where DEPOSITE_ID=@DEPOSITE_ID",
                               CreateParameter("@MONEY", SqlDbType.VarChar, MONEY));
                     
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO DEPOSITE_MASTER VALUES(@DEPOSITE_ID,@ACCOUNT_NO,@MONEY,@DATE)",
                         CreateParameter("@DEPOSITE_ID", SqlDbType.Int, DEPOSITE_ID),
                         CreateParameter("@ACCOUNT_NO", SqlDbType.VarChar,ACCOUNT_NO),
                         CreateParameter("@MONEY", SqlDbType.VarChar, MONEY),
                         CreateParameter("@DATE", SqlDbType.DateTime, DATE)); 
                       
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet DepositeMaster_GetAll()
        {
            return ExecuteDataSet("select * from DEPOSITE_MASTER ", null, null);
        }

        public DataSet DepositeMaster_GetById(int DEPOSITE_ID)
        {
            return ExecuteDataSet("select * from DEPOSITE_MASTER where DEPOSITE_ID=@DEPOSITE_ID", null,
            CreateParameter("@DEPOSITE_ID", SqlDbType.Int, DEPOSITE_ID));
        }
        //public DataSet SaleMaster_GetBySaleArea(string SALE_AREA)
        //{
        //    return ExecuteDataSet("select * from DEPOSITE_MASTER where SALE_AREA=@SALE_AREA", null,
        //    CreateParameter("@SALE_AREA", SqlDbType.Int, SALE_AREA));
        //}
        public DataSet DepositeMaster_GetByDATE(DateTime DATE)
        {
            return ExecuteDataSet("select * from DEPOSITE_MASTER where DATE=@DATE", null,
            CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        }
        //public DataSet SaleMaster_GetByDateSaleArea(DateTime SALE_DATE, string SALE_AREA)
        //{
        //    return ExecuteDataSet("select * from DEPOSITE_MASTER where SALE_DATE=@SALE_DATE and SALE_AREA=@SALE_AREA", null,
        //    CreateParameter("@SALE_DATE", SqlDbType.DateTime, SALE_DATE),
        //    CreateParameter("@SALE_AREA", SqlDbType.VarChar, SALE_AREA));
        //}
        //public DataSet PurchasingMaster_GetByName(string NAME)
        //{
        //    return ExecuteDataSet("select * from PURCHASING_MASTER where NAME=@NAME", null,
        //    CreateParameter("@NAME", SqlDbType.VarChar, NAME));
        //}

        public DataSet DepositeMaster_Delete(int DEPOSITE_ID)
        {
            return ExecuteDataSet("Delete from DEPOSITE_MASTER where DEPOSITE_ID=@DEPOSITE_ID", null,
            CreateParameter("@DEPOSITE_ID", SqlDbType.Int, DEPOSITE_ID));
        }

        public DataSet DepositeMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(DEPOSITE_ID)  from DEPOSITE_MASTER", null, null);
        }

        #endregion

       
    }
}
