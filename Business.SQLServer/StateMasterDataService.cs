using System;
using System.Data;
using Business.Common;

using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class StateMasterDataService : DataServiceBase
    {
        #region Constructors

        public StateMasterDataService() : base() { }
        public StateMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void StateMaster_Save(int STATE_ID, string STATE_NAME, int CountryId, string REMARKS, string STATECODE)
        {

            SqlCommand cmd;
            DataSet ds = StateMaster_GetBySTATE_ID(STATE_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE STATE_MASTER SET STATE_NAME=@STATE_NAME,CountryId=@CountryId,REMARKS=@REMARKS,STATECODE=@STATECODE WHERE STATE_ID=@STATE_ID",
                             CreateParameter("@STATE_NAME", SqlDbType.VarChar, STATE_NAME),
                            CreateParameter("@CountryId", SqlDbType.Int, CountryId),
                           CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                              CreateParameter("@STATECODE", SqlDbType.VarChar, STATECODE),
                           CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID));

            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO STATE_MASTER VALUES(@STATE_ID,@STATE_NAME,@CountryId,@REMARKS,@STATECODE)",
                           CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID),
                           CreateParameter("@STATE_NAME", SqlDbType.VarChar, STATE_NAME),
                             CreateParameter("@CountryId", SqlDbType.Int, CountryId),
                           CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                            CreateParameter("@STATECODE", SqlDbType.VarChar, STATECODE));


            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet StateMaster_GetBySTATE_ID(int STATE_ID)
        {
            return ExecuteDataSet("select * from STATE_MASTER where STATE_ID=@STATE_ID", null,
                CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID));
        }

        public DataSet StateMaster_GetBySTATE_NAME(string STATE_NAME)
        {
            return ExecuteDataSet("select * from STATE_MASTER where STATE_NAME=@STATE_NAME", null,
                CreateParameter("@STATE_NAME", SqlDbType.VarChar, STATE_NAME));
        }

        public DataSet StateMaster_GetAll()
        {
            return ExecuteDataSet("select * from STATE_MASTER  ", null, null);
        }


        public DataSet StateMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(STATE_ID)from STATE_MASTER", null, null);

        }
        public DataSet StateMaster_GetByDelete(int STATE_ID)
        {
            return ExecuteDataSet("Delete from STATE_MASTER where STATE_ID=@STATE_ID", null,
                CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID));
        }

        #endregion

    }
}
