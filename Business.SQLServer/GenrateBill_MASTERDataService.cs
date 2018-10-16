using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;


namespace Business.SQLServer
{
   public class GenrateBill_MASTERDataService: DataServiceBase 
    {
        #region Consturctor

        public GenrateBill_MASTERDataService() : base() { }
        public GenrateBill_MASTERDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void GenrateBill_MASTER_Save(int Bill_ID, int Bill_NO, int Hotel_ID, int Start_Challan_NO, int End_Challan_NO, float Total, DateTime Start_DAte, DateTime End_DAte)
        {
            SqlCommand cmd;
            DataSet ds = GenrateBill_MASTER_GetById(Bill_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE GENRATE_BILLMASTER set Bill_NO=@Bill_NO, Hotel_ID =@Hotel_ID, Start_Challan_NO=@Start_Challan_NO, End_Challan_NO=@End_Challan_NO,Total=@Total,Start_DAte=@Start_DAte,End_DAte=@End_DAte where Bill_ID=@Bill_ID",
                         CreateParameter("@Bill_NO", SqlDbType.Int, Bill_NO),
                         CreateParameter("@Hotel_ID", SqlDbType.Int, Hotel_ID),
                         CreateParameter("@Start_Challan_NO", SqlDbType.Int, Start_Challan_NO),
                         CreateParameter("@End_Challan_NO", SqlDbType.Int, End_Challan_NO),
                         CreateParameter("@Total", SqlDbType.Float, Total),
                         CreateParameter("@Start_DAte", SqlDbType.DateTime, Start_DAte),
                         CreateParameter("@End_DAte", SqlDbType.DateTime, End_DAte),
                         CreateParameter("@Bill_ID", SqlDbType.Int, Bill_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO GENRATE_BILLMASTER(Bill_ID,Bill_NO,Hotel_ID,Start_Challan_NO,End_Challan_NO,Total,Start_DAte,End_DAte)VALUES(@Bill_ID,@Bill_NO,@Hotel_ID,@Start_Challan_NO,@End_Challan_NO,@Total,@Start_DAte,@End_DAte)",
                         CreateParameter("@Bill_ID", SqlDbType.Int, Bill_ID),
                          CreateParameter("@Bill_NO", SqlDbType.Int, Bill_NO),
                         CreateParameter("@Hotel_ID", SqlDbType.Int, Hotel_ID),
                         CreateParameter("@Start_Challan_NO", SqlDbType.Int, Start_Challan_NO),
                         CreateParameter("@End_Challan_NO", SqlDbType.Int, End_Challan_NO),
                         CreateParameter("@Total", SqlDbType.Float, Total),
                         CreateParameter("@Start_DAte", SqlDbType.DateTime, Start_DAte),
                         CreateParameter("@End_DAte", SqlDbType.DateTime, End_DAte));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet GenrateBill_MASTER_GetAll()
        {
            return ExecuteDataSet("select * from GENRATE_BILLMASTER ", null, null);
        }
        public DataSet GenrateBill_MASTER_GetById(int Bill_ID)
        {
            return ExecuteDataSet("select * from GENRATE_BILLMASTER where Bill_ID=@Bill_ID", null,
            CreateParameter("@Bill_ID", SqlDbType.Int, Bill_ID));
        }
        public DataSet GenrateBill_MASTER_GetByBillNo(int Bill_NO)
        {
            return ExecuteDataSet("select * from GENRATE_BILLMASTER where Bill_NO=@Bill_NO", null,
            CreateParameter("@Bill_NO", SqlDbType.Int, Bill_NO));
        }
        public DataSet GenrateBill_MASTER_GetByHName(int Hotel_ID)
        {
            return ExecuteDataSet("select * from GENRATE_BILLMASTER where Hotel_ID=@Hotel_ID", null,
            CreateParameter("@Hotel_ID", SqlDbType.Int, Hotel_ID));
        }
        public DataSet Bill_Master_GetByFrom_BILLNO_TO_BILLNO(int From_BILLNO, int To_BILLNO)
        {
            return ExecuteDataSet("select * from GENRATE_BILLMASTER where Bill_NO between @From_BILLNO and @To_BILLNO", null,
            CreateParameter("@From_BILLNO", SqlDbType.Int, From_BILLNO),
            CreateParameter("@To_BILLNO", SqlDbType.Int, To_BILLNO));
        }
        //public DataSet GenrateBill_MASTER_GetByDATE(DateTime DATE)
        //{
        //    return ExecuteDataSet("select * from GenrateBill_MASTER where DATE=@DATE", null,
        //    CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        //}
        //public DataSet GenrateBill_MASTER_GetBybillno_bydate(string Hotel_ID, DateTime DATE, int GenrateBill_NO)
        //{
        //    return ExecuteDataSet("select * from GenrateBill_MASTER where DATE=@DATE", null,
        //    CreateParameter("@Hotel_ID", SqlDbType.VarChar, Hotel_ID), 
        //    CreateParameter("@DATE", SqlDbType.DateTime, DATE),
        //     CreateParameter("@GenrateBill_NO", SqlDbType.Int, GenrateBill_NO));
           
        //}

        public DataSet GenrateBill_MASTER_Delete(int Bill_ID)
        {
            return ExecuteDataSet("Delete from GENRATE_BILLMASTER where Bill_ID=@Bill_ID", null,
            CreateParameter("@Bill_ID", SqlDbType.Int, Bill_ID));
        }
        //public DataSet GenrateBill_MASTER_GetMAXIdbyhotel(int Hotel_ID, DateTime DATE)
        //{
        //    return ExecuteDataSet("select max(Bill_ID)  from GENRATE_BILLMASTER where Hotel_ID=@Hotel_ID and DATE=@DATE", null,
        //         CreateParameter("@Hotel_ID", SqlDbType.Int, Hotel_ID),
        //         CreateParameter("@DATE", SqlDbType.DateTime, DATE));
        //}
        public DataSet GenrateBill_MASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(Bill_ID)  from GENRATE_BILLMASTER", null, null);
        }

        #endregion

       
    }
}
