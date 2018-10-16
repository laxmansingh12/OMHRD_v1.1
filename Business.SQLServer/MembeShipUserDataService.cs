using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;

namespace Business.SQLServer
{
    public class MembeShipUserDataService : DataServiceBase
    {
        #region Consturctor
        public MembeShipUserDataService() : base() { }
        public MembeShipUserDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void MembeShipUser_Save(int MembeShip_ID, string MembeShip,string Email, string Password, int Member_Id,string Remark,DateTime RegDate,string ContactNo)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = MembeShipUser_GetByMembeShip_ID(MembeShip_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE MembeShipUser set MembeShip=@MembeShip,Email=@Email, Password=@Password,Member_Id=@Member_Id,Remark=@Remark,RegDate=@RegDate,ContactNo=@ContactNo where MembeShip_ID=@MembeShip_ID",
                         CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id),
                         CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                          CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                           CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo),
                         CreateParameter("@MembeShip_ID", SqlDbType.Int, MembeShip_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO MembeShipUser(MembeShip_ID,MembeShip,Email,Password,Member_Id,Remark,RegDate,ContactNo) VALUES (@MembeShip_ID,@MembeShip,@Email,@Password,@Member_Id,@Remark,@RegDate,@ContactNo)",
                         CreateParameter("@MembeShip_ID", SqlDbType.Int, MembeShip_ID),
                          CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@Member_Id", SqlDbType.Int, Member_Id),
                         CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                          CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                           CreateParameter("@ContactNo", SqlDbType.VarChar, ContactNo));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        //public DataSet MembeShipUser_GetByMembeShip(string MembeShip)
        //{
        //    return ExecuteDataSet("select * from MembeShipUser where MembeShip=@MembeShip", null,
        //    CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip));
        //}

        public DataSet MembeShipUser_GetAll()
        {
            return ExecuteDataSet("select * from MembeShipUser  ", null, null);
        }

        public DataSet MembeShipUser_GetByMembeShip_ID(int MembeShip_ID)
        {
            return ExecuteDataSet("select * from MembeShipUser where MembeShip_ID=@MembeShip_ID", null,
                CreateParameter("@MembeShip_ID", SqlDbType.Int, MembeShip_ID));
        }
        public DataSet MembeShip_And_Password(string MembeShip, string Password)
        {
            return ExecuteDataSet("select * from MembeShipUser where MembeShip=@MembeShip and Password=@Password", null,
                CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip),
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public DataSet User_GetByquestionand_answer(string MembeShip, string QUESTION, string ANSWER)
        {
            return ExecuteDataSet("select * from MembeShipUser where QUESTION=@QUESTION and ANSWER=@ANSWER and MembeShip=@MembeShip", null,
                CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
            CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
            CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip));
        }
        public DataSet UserMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from MembeShipUser where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }

        public DataSet MembeShipUser_GetByMembeShip(string MembeShip)
        {
            return ExecuteDataSet("select * from MembeShipUser where MembeShip=@MembeShip", null,
            CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip));
        }

        public void GetByUpdate_PASSWORD(string MembeShip, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update MembeShipUser set [Password]=@Password where [MembeShip]=@MembeShip",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@MembeShip", SqlDbType.VarChar, MembeShip));
        }

        public DataSet MembeShipUser_GetMAXId()
        {
            return ExecuteDataSet("select max(MembeShip_ID)  from MembeShipUser", null, null);
        }

        public DataSet MembeShipUser_Delete(int MembeShip_ID)
        {
            return ExecuteDataSet("Delete from MembeShipUser where MembeShip_ID=@MembeShip_ID", null,
            CreateParameter("@MembeShip_ID", SqlDbType.Int, MembeShip_ID));
        }

        #endregion
    }
}

