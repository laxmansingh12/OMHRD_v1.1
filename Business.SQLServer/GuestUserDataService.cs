using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;

namespace Business.SQLServer
{
    public class GuestUserDataService : DataServiceBase
    {
        #region Consturctor
        public GuestUserDataService() : base() { }
        public GuestUserDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void GuestUser_Save(int Guest_Id, string Guest_Name,string Email, string Password, int Member_Id,string Remark,string ContactNo,string Address, DateTime RegDate)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = GuestUser_GetByGuest_Id(Guest_Id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE GuestUser set Guest_Name=@Guest_Name,Email=@Email, Password=@Password,Member_Id=@Member_Id,Remark=@Remark,ContactNo=@ContactNo,Address=@Address,RegDate=@RegDate where Guest_Id=@Guest_Id",
                         CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id),
                         CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                          CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo),
                           CreateParameter("@Address", SqlDbType.VarChar, Address),
                        CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                         CreateParameter("@Guest_Id", SqlDbType.Int, Guest_Id));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO GuestUser(Guest_Id,Guest_Name,Email,Password,Member_Id,Remark,ContactNo,Address,RegDate) VALUES (@Guest_Id,@Guest_Name,@Email,@Password,@Member_Id,@Remark,@ContactNo,@Address,@RegDate)",
                         CreateParameter("@Guest_Id", SqlDbType.Int, Guest_Id),
                          CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id),
                         CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                           CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo),
                           CreateParameter("@Address", SqlDbType.VarChar, Address),
                          CreateParameter("@RegDate", SqlDbType.DateTime, RegDate));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        //public DataSet GuestUser_GetByGuest_Name(string Guest_Name)
        //{
        //    return ExecuteDataSet("select * from GuestUser where Guest_Name=@Guest_Name", null,
        //    CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name));
        //}

        public DataSet GuestUser_GetAll()
        {
            return ExecuteDataSet("select * from GuestUser  ", null, null);
        }

        public DataSet GuestUser_GetByGuest_Id(int Guest_Id)
        {
            return ExecuteDataSet("select * from GuestUser where Guest_Id=@Guest_Id", null,
                CreateParameter("@Guest_Id", SqlDbType.Int, Guest_Id));
        }
        public DataSet Guest_Name_And_Password(string Guest_Name, string Password)
        {
            return ExecuteDataSet("select * from GuestUser where Guest_Name=@Guest_Name and Password=@Password", null,
                CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name),
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public DataSet User_GetByquestionand_answer(string Guest_Name, string QUESTION, string ANSWER)
        {
            return ExecuteDataSet("select * from GuestUser where QUESTION=@QUESTION and ANSWER=@ANSWER and Guest_Name=@Guest_Name", null,
                CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
            CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
            CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name));
        }
        public DataSet UserMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from GuestUser where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }

        public DataSet GuestUser_GetByGuest_Name(string Guest_Name)
        {
            return ExecuteDataSet("select * from GuestUser where Guest_Name=@Guest_Name", null,
            CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name));
        }

        public void GetByUpdate_PASSWORD(string Guest_Name, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update GuestUser set [Password]=@Password where [Guest_Name]=@Guest_Name",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@Guest_Name", SqlDbType.VarChar, Guest_Name));
        }

        public DataSet GuestUser_GetMAXId()
        {
            return ExecuteDataSet("select max(Guest_Id)  from GuestUser", null, null);
        }

        public DataSet GuestUser_Delete(int Guest_Id)
        {
            return ExecuteDataSet("Delete from GuestUser where Guest_Id=@Guest_Id", null,
            CreateParameter("@Guest_Id", SqlDbType.Int, Guest_Id));
        }

        #endregion
    }
}

