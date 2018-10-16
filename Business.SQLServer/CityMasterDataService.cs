using System;
using System.Data;
using Business.Common;

using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class CityMasterDataService : DataServiceBase
    {
        #region Constructors

        public CityMasterDataService() : base() { }
        public CityMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void CityMaster_Save(int CITY_ID, string CITY_NAME, int STATE_ID, string REMARKS)
        {

            SqlCommand cmd;
            DataSet ds = CityMaster_GetByCITY_ID(CITY_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE CITY_MASTER SET CITY_NAME=@CITY_NAME,STATE_ID=@STATE_ID,REMARKS=@REMARKS WHERE CITY_ID=@CITY_ID",

                    CreateParameter("@CITY_NAME", SqlDbType.VarChar, CITY_NAME),
                      CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID),
                           CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                           CreateParameter("@CITY_ID", SqlDbType.Int, CITY_ID));

            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO CITY_MASTER VALUES(@CITY_ID,@CITY_NAME,@STATE_ID,@REMARKS)",
                           CreateParameter("@CITY_ID", SqlDbType.Int, CITY_ID),

                           CreateParameter("@CITY_NAME", SqlDbType.VarChar, CITY_NAME),
                              CreateParameter("@STATE_ID", SqlDbType.Int, STATE_ID),
                           CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS)
                          );


            }
            if (cmd != null)
                cmd.Dispose();
        }

        public DataSet CityMaster_GetByCITY_ID(int CITY_ID)
        {
            return ExecuteDataSet("select * from CITY_MASTER where CITY_ID=@CITY_ID", null,
                CreateParameter("@CITY_ID", SqlDbType.Int, CITY_ID));
        }

        public DataSet CityMaster_GetByCITY_NAME(string CITY_NAME)
        {
            return ExecuteDataSet("select * from CITY_MASTER where CITY_NAME=@CITY_NAME", null,
                CreateParameter("@CITY_NAME", SqlDbType.VarChar, CITY_NAME));
        }

        public DataSet CityMaster_GetAll()
        {
            return ExecuteDataSet("select * from CITY_MASTER", null, null);
        }


        public DataSet CityMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(CITY_ID)from CITY_MASTER", null, null);

        }
        public DataSet CityMaster_GetByDelete(int CITY_ID)
        {
            return ExecuteDataSet("Delete from CITY_MASTER where CITY_ID=@CITY_ID", null,
                CreateParameter("@CITY_ID", SqlDbType.Int, CITY_ID));
        }

        #endregion

    }
}
