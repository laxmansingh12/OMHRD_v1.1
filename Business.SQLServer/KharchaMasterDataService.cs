using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class KharchaMasterDataService: DataServiceBase 
    {
        #region Consturctor

        public KharchaMasterDataService() : base() { }
        public KharchaMasterDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void SaleMaster_Save(int KHARCHA_ID, string NAME, float AMMOUNT, string REMARKS, DateTime DATE)
        {
            SqlCommand cmd;
            DataSet ds = SaleMaster_GetById(KHARCHA_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE Kharcha_Master set  NAME=@NAME,AMMOUNT=@AMMOUNT,REMARKS=@REMARKS, DATE=@DATE where KHARCHA_ID=@KHARCHA_ID",
                         CreateParameter("@NAME", SqlDbType.VarChar, NAME),
                         CreateParameter("@AMMOUNT", SqlDbType.Float, AMMOUNT),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                            CreateParameter("@DATE", SqlDbType.Date, DATE),
                         CreateParameter("@KHARCHA_ID", SqlDbType.Int, KHARCHA_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO Kharcha_Master VALUES(@KHARCHA_ID,@NAME,@AMMOUNT,@REMARKS,@DATE)",
                         CreateParameter("@KHARCHA_ID", SqlDbType.Int, KHARCHA_ID),
                         CreateParameter("@NAME", SqlDbType.VarChar, NAME),
                         CreateParameter("@AMMOUNT", SqlDbType.Float, AMMOUNT),
                         CreateParameter("@REMARKS", SqlDbType.VarChar, REMARKS),
                          CreateParameter("@DATE", SqlDbType.Date, DATE));
                    
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet SaleMaster_GetAll()
        {
            return ExecuteDataSet("select * from Kharcha_Master ", null, null);
        }

        public DataSet SaleMaster_GetById(int KHARCHA_ID)
        {
            return ExecuteDataSet("select * from Kharcha_Master where KHARCHA_ID=@KHARCHA_ID", null,
            CreateParameter("@KHARCHA_ID", SqlDbType.Int, KHARCHA_ID));
        }
      
        public DataSet SaleMaster_GetByDATE(DateTime DATE )
        {
            return ExecuteDataSet("select * from Kharcha_Master where DATE=@DATE ", null,
            CreateParameter("@SALE_DATE", SqlDbType.Date, DATE));
           
        }


        public DataSet SaleMaster_Delete(int KHARCHA_ID)
        {
            return ExecuteDataSet("Delete from Kharcha_Master where KHARCHA_ID=@KHARCHA_ID", null,
            CreateParameter("@KHARCHA_ID", SqlDbType.Int, KHARCHA_ID));
        }

        public DataSet SaleMaster_GetMAXId()
        {
            return ExecuteDataSet("select max(KHARCHA_ID)  from Kharcha_Master", null, null);
        }

        #endregion

       
    }
}
