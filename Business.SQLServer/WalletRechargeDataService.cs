using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class WalletRechargeDataService : DataServiceBase
    {
        #region Consturctor
        public WalletRechargeDataService() : base() { }
        public WalletRechargeDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void WalletRechargeSave(int Id, int ByUser_id, int User_id, decimal Amount, DateTime Date)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = WalletRechargeGetById(Id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE WalletRecharge set ByUser_id=@ByUser_id, User_id=@User_id, Amount=@Amount,Date=@Date where Id=@Id",
                      CreateParameter("@ByUser_id", SqlDbType.Int, ByUser_id),
                    CreateParameter("@User_id", SqlDbType.Int, User_id),
                         CreateParameter("@Amount", SqlDbType.Decimal, Amount),
                            CreateParameter("@Date", SqlDbType.DateTime, Date),
                         CreateParameter("@Id", SqlDbType.Int, Id));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO WalletRecharge VALUES (@Id,@ByUser_id,@User_id,@Amount,@Date)",
                         CreateParameter("@Id", SqlDbType.Int, Id),
                            CreateParameter("@ByUser_id", SqlDbType.Int, ByUser_id),
                         CreateParameter("@User_id", SqlDbType.Int, User_id),
                         CreateParameter("@Amount", SqlDbType.Decimal, Amount),
                          CreateParameter("@Date", SqlDbType.DateTime, Date));

            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet WalletRechargeGetAll()
        {
            return ExecuteDataSet("select * from WalletRecharge ", null, null);
        }
        public DataSet WalletRechargeGetById(int Id)
        {
            return ExecuteDataSet("select * from WalletRecharge where Id=@Id", null,
            CreateParameter("@Id", SqlDbType.Int, Id));
        }
        public DataSet WalletRechargeGetByUser_id(int User_id)
        {
            return ExecuteDataSet("select * from WalletRecharge where User_id=@User_id", null,
            CreateParameter("@User_id", SqlDbType.Int, User_id));
        }
        public DataSet WalletRechargeDelete(int Id)
        {
            return ExecuteDataSet("Delete from WalletRecharge where Id=@Id", null,
            CreateParameter("@Id", SqlDbType.Int, Id));
        }

        public DataSet WalletRechargeGetMAXId()
        {
            return ExecuteDataSet("select max(Id)  from WalletRecharge", null, null);
        }
        #endregion
    }
}
