using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;

namespace Business.SQLServer
{
    public class User_MasterDataService : DataServiceBase
    {
        #region Consturctor
        public User_MasterDataService() : base() { }
        public User_MasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void User_Master_Save(int User_Id, string User_Name, string Password, string Login_Access, string Roll, string QUESTION, string ANSWER, int Member_Id)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = User_Master_GetByUser_Id(User_Id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE User_Master set User_Name=@User_Name, Password = @Password,Login_Access=@Login_Access,Roll=@Roll,QUESTION=@QUESTION,ANSWER=@ANSWER,Member_Id=@Member_Id where User_Id=@User_Id",
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Login_Access", SqlDbType.VarChar, Login_Access),
                         CreateParameter("@Roll", SqlDbType.VarChar, Roll),
                         CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
                         CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id),
                         CreateParameter("@User_Id", SqlDbType.Int, User_Id));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO User_Master(User_Id,User_Name,Password,Login_Access,Roll,QUESTION,ANSWER,Member_Id) VALUES (@User_Id,@User_Name,@Password,@Login_Access,@Roll,@QUESTION,@ANSWER,@Member_Id)",
                         CreateParameter("@User_Id", SqlDbType.Int, User_Id),
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Login_Access", SqlDbType.VarChar, Login_Access),
                         CreateParameter("@Roll", SqlDbType.VarChar, Roll),
                         CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
                         CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        //public DataSet User_Master_GetByUser_Name(string User_Name)
        //{
        //    return ExecuteDataSet("select * from User_Master where User_Name=@User_Name", null,
        //    CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        //}

        public DataSet User_Master_GetAll()
        {
            return ExecuteDataSet("select * from User_Master  ", null, null);
        }

        public DataSet User_Master_GetByUser_Id(int User_Id)
        {
            return ExecuteDataSet("select * from User_Master where User_Id=@User_Id", null,
                CreateParameter("@User_Id", SqlDbType.Int, User_Id));
        }
        public DataSet User_Name_And_Password(string User_Name, string Password)
        {
            return ExecuteDataSet("select * from User_Master where User_Name=@User_Name and Password=@Password", null,
                CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public DataSet User_GetByquestionand_answer(string User_Name, string QUESTION, string ANSWER)
        {
            return ExecuteDataSet("select * from User_Master where QUESTION=@QUESTION and ANSWER=@ANSWER and User_Name=@User_Name", null,
                CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
            CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }
        public DataSet UserMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from User_Master where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }

        public DataSet User_Master_GetByUser_Name(string User_Name)
        {
            return ExecuteDataSet("select * from User_Master where User_Name=@User_Name", null,
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }

        public void GetByUpdate_PASSWORD(string User_Name, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update User_Master set [Password]=@Password where [User_Name]=@User_Name",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }

        public DataSet User_Master_GetMAXId()
        {
            return ExecuteDataSet("select max(User_Id)  from User_Master", null, null);
        }

        public DataSet User_Master_Delete(int User_Id)
        {
            return ExecuteDataSet("Delete from User_Master where User_Id=@User_Id", null,
            CreateParameter("@User_Id", SqlDbType.Int, User_Id));
        }

        #endregion
    }
}

