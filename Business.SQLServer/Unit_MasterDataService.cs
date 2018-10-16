using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class Unit_MasterDataService : DataServiceBase
    {
        #region Consturctor
        public Unit_MasterDataService() : base() { }
        public Unit_MasterDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void UNITMASTER_Save(int UNIT_ID, string Code, string Name, string Description)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = UNITMASTER_GetByUNIT_ID(UNIT_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE UNITMASTER set Code=@Code, Name=@Name,Description=@Description where UNIT_ID=@UNIT_ID",
                         CreateParameter("@Code", SqlDbType.VarChar, Code),
                         CreateParameter("@Name", SqlDbType.VarChar, Name),
                            CreateParameter("@Description", SqlDbType.VarChar, Description),
                         CreateParameter("@UNIT_ID", SqlDbType.Int, UNIT_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO UNITMASTER VALUES (@UNIT_ID,@Code,@Name,@Description)",
                         CreateParameter("@UNIT_ID", SqlDbType.Int, UNIT_ID),
                         CreateParameter("@Code", SqlDbType.VarChar, Code),
                         CreateParameter("@Name", SqlDbType.VarChar, Name),
                          CreateParameter("@Description", SqlDbType.VarChar, Description));
                         
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet UNITMASTER_GetAll()
        {
            return ExecuteDataSet("select * from UNITMASTER ", null, null);
        }
        public DataSet UNITMASTER_GetByUNIT_ID(int UNIT_ID)
        {
            return ExecuteDataSet("select * from UNITMASTER where UNIT_ID=@UNIT_ID", null,
            CreateParameter("@UNIT_ID", SqlDbType.Int, UNIT_ID));
        }
        public DataSet UNITMASTER_GetByCode(string Code)
        {
            return ExecuteDataSet("select * from UNITMASTER where Code=@Code", null,
            CreateParameter("@Code", SqlDbType.VarChar, Code));
        }
        public DataSet UNITMASTER_Delete(int UNIT_ID)
        {
            return ExecuteDataSet("Delete from UNITMASTER where UNIT_ID=@UNIT_ID", null,
            CreateParameter("@UNIT_ID", SqlDbType.Int, UNIT_ID));
        }

        public DataSet UNITMASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(UNIT_ID)  from UNITMASTER", null, null);
        }
        #endregion
    }
}
