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
    public class PaymentMasterDataSevice : DataServiceBase
    {

        #region Constructors

        public PaymentMasterDataSevice() : base() { }
        public PaymentMasterDataSevice(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void PaymentMasterSave(int Paymemt_ID, string User_Name, string User_ID,decimal Amount, string Remark)
        {
            SqlCommand cmd;
            DataSet ds = PaymentMasterGetByPaymemt_ID(Paymemt_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update PaymentReceived set [User_Name]=@User_Name,[User_ID]=@User_ID ,[Amount]=@Amount,[Remark]=@Remark WHERE Paymemt_ID=@Paymemt_ID",
                                 CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                                 CreateParameter("@User_ID", SqlDbType.VarChar, User_ID),
                                  CreateParameter("@Amount", SqlDbType.Decimal, Amount),
                                CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                               CreateParameter("@Paymemt_ID", SqlDbType.Int, Paymemt_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into PaymentReceived values(@Paymemt_ID, @User_Name, @User_ID,@Amount,@Remark)",
                               CreateParameter("@Paymemt_ID", SqlDbType.Int, Paymemt_ID),
                                CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                                 CreateParameter("@User_ID", SqlDbType.VarChar, User_ID),
                                  CreateParameter("@Amount", SqlDbType.Decimal, Amount),
                                CreateParameter("@Remark", SqlDbType.VarChar, Remark));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet PaymentMasterGetAll()
        {
            return ExecuteDataSet("Select * from PaymentReceived ", null, null);
        }
        public DataSet PaymentMasterGetByUser_Name(string  User_Name)
        {
            return ExecuteDataSet("select * from PaymentReceived where User_Name=@User_Name", null,
                CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }
        public DataSet PaymentMasterGetByPaymemt_ID(int Paymemt_ID)
        {
            return ExecuteDataSet("select * from PaymentReceived where Paymemt_ID=@Paymemt_ID", null,
                CreateParameter("@Paymemt_ID", SqlDbType.Int, Paymemt_ID));
        }

        public DataSet PaymentMasterGetMaxID()
        {
            return ExecuteDataSet("select MAX(Paymemt_ID)from PaymentReceived", null, null);
        }

        public DataSet PaymentMasterGetByDelete(int Paymemt_ID)
        {
            return ExecuteDataSet("Delete from PaymentReceived where Paymemt_ID=@Paymemt_ID", null,
                CreateParameter("@Paymemt_ID", SqlDbType.Int, Paymemt_ID));
        }
        #endregion
    }
}
