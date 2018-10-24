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
    public class PickUpMasterDataSevice : DataServiceBase
    {

        #region Constructors

        public PickUpMasterDataSevice() : base() { }
        public PickUpMasterDataSevice(IDbTransaction txn) : base(txn) { }

        #endregion
        #region Methods
        public void PickUpMasterSave(int PickupID, string FirstName, string LastName, string UserName, string Password, string CenterName, string CenterCode, string Address, string Pincode, int City, int State, string ContactNo, string Alternate1, string Alternate2, string GstinNo, DateTime RegDate, string Status, string Action, decimal PickUpWallet)
        {
            SqlCommand cmd;
            DataSet ds = PickUpMasterGetByPickupID(PickupID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, "Update PicupMaster set [FirstName]=@FirstName,[LastName]=@LastName, [UserName]=@UserName,[Password]=@Password,[CenterName]=@CenterName, [CenterCode]=@CenterCode,[Address]=@Address ,[Pincode]=@Pincode,[City]=@City ,[State]=@State,[ContactNo]=@ContactNo,[Alternate1]=@Alternate1,[Alternate2]=@Alternate2,[GstinNo]=@GstinNo,[Regdate]=@Regdate,[Status]=@Status,[Action]=@Action,[PickUpWallet]=@PickUpWallet WHERE PickupID=@PickupID",
                                 CreateParameter("@FirstName", SqlDbType.VarChar, FirstName),
                                 CreateParameter("@LastName", SqlDbType.VarChar, LastName),
                                 CreateParameter("@UserName", SqlDbType.VarChar, UserName),
                                 CreateParameter("@Password", SqlDbType.VarChar, Password),
                                 CreateParameter("@CenterName", SqlDbType.VarChar, CenterName),
                                 CreateParameter("@CenterCode", SqlDbType.VarChar, CenterCode),
                                 CreateParameter("@Address", SqlDbType.VarChar, Address),
                                 CreateParameter("@Pincode", SqlDbType.VarChar, Pincode),
                                 CreateParameter("@City", SqlDbType.Int, City),
                                 CreateParameter("@State", SqlDbType.Int, State),
                                 CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo),
                                 CreateParameter("@Alternate1", SqlDbType.VarChar, Alternate1),
                                 CreateParameter("@Alternate2", SqlDbType.VarChar, Alternate2),
                                 CreateParameter("@GstinNo", SqlDbType.VarChar, GstinNo),
                                 CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                                 CreateParameter("@Status", SqlDbType.VarChar, Status),
                                  CreateParameter("@Action", SqlDbType.VarChar, Action),
                                   CreateParameter("@PickUpWallet", SqlDbType.Decimal, PickUpWallet),
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID));
            }
            else
            {
                ExecuteNonQuery(out cmd, "Insert into PicupMaster values(@PickupID,@FirstName,@LastName,@UserName,@Password,@CenterName, @CenterCode, @Address, @Pincode, @City, @State, @ContactNo,@Alternate1,@Alternate2, @GstinNo,@RegDate,@Status,@Action,@PickUpWallet)",
                                 CreateParameter("@PickupID", SqlDbType.Int, PickupID),
                                 CreateParameter("@FirstName", SqlDbType.VarChar, FirstName),
                                 CreateParameter("@LastName", SqlDbType.VarChar, LastName),
                                 CreateParameter("@UserName", SqlDbType.VarChar, UserName),
                                 CreateParameter("@Password", SqlDbType.VarChar, Password),
                                 CreateParameter("@CenterName", SqlDbType.VarChar, CenterName),
                                 CreateParameter("@CenterCode", SqlDbType.VarChar, CenterCode),
                                 CreateParameter("@Address", SqlDbType.VarChar, Address),
                                 CreateParameter("@Pincode", SqlDbType.VarChar, Pincode),
                                 CreateParameter("@City", SqlDbType.Int, City),
                                 CreateParameter("@State", SqlDbType.Int, State),
                                 CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo),
                                 CreateParameter("@Alternate1", SqlDbType.VarChar, Alternate1),
                                 CreateParameter("@Alternate2", SqlDbType.VarChar, Alternate2),
                                 CreateParameter("@GstinNo", SqlDbType.VarChar, GstinNo),
                                 CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                                 CreateParameter("@Status", SqlDbType.VarChar, Status),
                                 CreateParameter("@Action", SqlDbType.VarChar, Action),
                              
                                  CreateParameter("@PickUpWallet", SqlDbType.Decimal, PickUpWallet));
            }
            if (cmd != null)
                cmd.Dispose();
        }
        public DataSet PickUpMasterGetAll()
        {
            return ExecuteDataSet("Select * from PicupMaster ", null, null);
        }
        public DataSet PickUpMasterGetByCenterCode(string CenterCode)
        {
            return ExecuteDataSet("select * from PicupMaster where CenterCode=@CenterCode", null,
                CreateParameter("@CenterCode", SqlDbType.VarChar, CenterCode));
        }
        public DataSet PickUpMasterGetByPickupID(int PickupID)
        {
            return ExecuteDataSet("select * from PicupMaster where PickupID=@PickupID", null,
                CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        public DataSet PickUpMasterGetByPickupUserName(string  UserName)
        {
            return ExecuteDataSet("select * from PicupMaster where UserName=@UserName", null,
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }

        public void GetByPaymentByWallet(int PickupID, decimal PickUpWallet)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update PicupMaster set [PickUpWallet]=@PickUpWallet where [PickupID]=@PickupID",
                  CreateParameter("@PickUpWallet", SqlDbType.Decimal, PickUpWallet),
                  CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        public DataSet PickUpMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from PicupMaster where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public void GetByUpdate_PASSWORD(int PickupID, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update PicupMaster set [Password]=@Password where [PickupID]=@PickupID",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        public DataSet PickUpMasterGetByAction(string Action)
        {
            return ExecuteDataSet("select * from PicupMaster where Action=@Action", null,
                CreateParameter("@Action", SqlDbType.VarChar, Action));
        }
        public void GetByUpdate_Action(int PickupID, string Action)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update PicupMaster set [Action]=@Action where [PickupID]=@PickupID",
                  CreateParameter("@Action", SqlDbType.VarChar, Action),
                  CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        public DataSet PickUpMasterGetByStatus(string Status)
        {
            return ExecuteDataSet("select * from PicupMaster where Status=@Status", null,
                CreateParameter("@Status", SqlDbType.VarChar, Status));
        }
        public void GetByUpdate_Status(int PickupID, string Status)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update PicupMaster set [Status]=@Status where [PickupID]=@PickupID",
                  CreateParameter("@Status", SqlDbType.VarChar, Status),
                  CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        public DataSet PickUpMasterGetMaxID()
        {
            return ExecuteDataSet("select MAX(PickupID)from PicupMaster", null, null);
        }

        public DataSet PickUpMasterGetByDelete(int PickupID)
        {
            return ExecuteDataSet("Delete from PicupMaster where PickupID=@PickupID", null,
                CreateParameter("@PickupID", SqlDbType.Int, PickupID));
        }
        #endregion
    }
}
