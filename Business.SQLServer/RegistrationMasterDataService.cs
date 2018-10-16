using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;

namespace Business.SQLServer
{
    public class RegistrationMasterDataService : DataServiceBase
    {
        #region Consturctor
        public RegistrationMasterDataService() : base() { }
        public RegistrationMasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void RegistrationMaster_Save(int Registration_ID, string First_Name, string Last_Name, string Email, string User_Name, string Password, DateTime DOB, string AdharCard, string PanCard, string ContactNumber, string NomineeName, string NomineeId, string NomineeRelation, string Reference_Id, DateTime RegDate,string COUNTRY)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = RegistrationMaster_GetByRegistration_ID(Registration_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE RegistrationMaster set First_Name=@First_Name, Last_Name=@Last_Name, Email=@Email, User_Name=@User_Name,  Password=@Password, DOB=@DOB, AdharCard=@AdharCard, PanCard=@PanCard, ContactNumber=@ContactNumber, NomineeName=@NomineeName,NomineeId=@NomineeId,NomineeRelation=@NomineeRelation,Reference_Id=@Reference_Id, RegDate=@RegDate,COUNTRY=@COUNTRY where Registration_ID=@Registration_ID",
                          CreateParameter("@First_Name", SqlDbType.VarChar, First_Name),
                         CreateParameter("@Last_Name", SqlDbType.VarChar, Last_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@DOB", SqlDbType.DateTime, DOB),
                         CreateParameter("@AdharCard", SqlDbType.VarChar, AdharCard),
                         CreateParameter("@PanCard", SqlDbType.VarChar, PanCard),
                         CreateParameter("@ContactNumber", SqlDbType.VarChar, ContactNumber),
                         CreateParameter("@NomineeName", SqlDbType.VarChar, NomineeName),
                         CreateParameter("@NomineeId", SqlDbType.VarChar, NomineeId),
                         CreateParameter("@NomineeRelation", SqlDbType.VarChar, NomineeRelation),
                         CreateParameter("@Reference_Id", SqlDbType.VarChar, Reference_Id),
                         CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                          CreateParameter("@COUNTRY", SqlDbType.VarChar, COUNTRY),
                         CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO RegistrationMaster(Registration_ID,First_Name, Last_Name, Email, User_Name,  Password, DOB, AdharCard, PanCard, ContactNumber, NomineeName,NomineeId,NomineeRelation,Reference_Id, RegDate,COUNTRY) VALUES (@Registration_ID,@First_Name, @Last_Name, @Email, @User_Name,  @Password, @DOB, @AdharCard, @PanCard, @ContactNumber, @NomineeName,@NomineeId,@NomineeRelation,@Reference_Id,@RegDate,@COUNTRY)",
                         CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID),
                          CreateParameter("@First_Name", SqlDbType.VarChar, First_Name),
                         CreateParameter("@Last_Name", SqlDbType.VarChar, Last_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@DOB", SqlDbType.DateTime, DOB),
                         CreateParameter("@AdharCard", SqlDbType.VarChar, AdharCard),
                         CreateParameter("@PanCard", SqlDbType.VarChar, PanCard),
                         CreateParameter("@ContactNumber", SqlDbType.VarChar, ContactNumber),
                         CreateParameter("@NomineeName", SqlDbType.VarChar, NomineeName),
                         CreateParameter("@NomineeId", SqlDbType.VarChar, NomineeId),
                         CreateParameter("@NomineeRelation", SqlDbType.VarChar, NomineeRelation),
                         CreateParameter("@Reference_Id", SqlDbType.VarChar, Reference_Id),
                         CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                          CreateParameter("@COUNTRY", SqlDbType.VarChar, COUNTRY));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        //public DataSet RegistrationMaster_GetByUser_Name(string User_Name)
        //{
        //    return ExecuteDataSet("select * from RegistrationMaster where User_Name=@User_Name", null,
        //    CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        //}

        public DataSet RegistrationMaster_GetAll()
        {
            return ExecuteDataSet("select * from RegistrationMaster  ", null, null);
        }

        public DataSet RegistrationMaster_GetByRegistration_ID(int Registration_ID)
        {
            return ExecuteDataSet("select * from RegistrationMaster where Registration_ID=@Registration_ID", null,
                CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }
        public DataSet RegistrationMaster_GetByReference_Id(int Reference_Id)
        {
            return ExecuteDataSet("select * from RegistrationMaster where Reference_Id=@Reference_Id", null,
                CreateParameter("@Reference_Id", SqlDbType.Int, Reference_Id));
        }
        public DataSet User_Name_And_Password(string User_Name, string Password)
        {
            return ExecuteDataSet("select * from RegistrationMaster where User_Name=@User_Name and Password=@Password", null,
                CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public DataSet User_GetByquestionand_answer(string User_Name, string QUESTION, string ANSWER)
        {
            return ExecuteDataSet("select * from RegistrationMaster where QUESTION=@QUESTION and ANSWER=@ANSWER and User_Name=@User_Name", null,
                CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
            CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }
        public DataSet UserMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from RegistrationMaster where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }

        public DataSet RegistrationMaster_GetByUser_Name(string User_Name)
        {
            return ExecuteDataSet("select * from RegistrationMaster where User_Name=@User_Name", null,
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }

        public void GetByUpdate_PASSWORD(string User_Name, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update RegistrationMaster set [Password]=@Password where [User_Name]=@User_Name",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }

        public DataSet RegistrationMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(Registration_ID)  from RegistrationMaster", null, null);
        }

        public DataSet RegistrationMaster_Delete(int Registration_ID)
        {
            return ExecuteDataSet("Delete from RegistrationMaster where Registration_ID=@Registration_ID", null,
            CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }

        #endregion
    }
}

