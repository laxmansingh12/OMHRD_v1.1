using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class ITEM_MASTERDataService : DataServiceBase
    {
        #region Consturctor

        public ITEM_MASTERDataService() : base() { }
        public ITEM_MASTERDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void ITEM_MASTER_Save(int ITEM_ID, string ITEMNAME, int SubCategory_ID, string CODE, string HSNCODE, decimal CGST, decimal SGST, decimal IGST, string Description, decimal OPEN_STOCK, string Image, string Image1, string Image2)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = ITEM_MASTER_GetByITEM_ID(ITEM_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE ITEM_MASTER set ITEMNAME=@ITEMNAME,SubCategory_ID=@SubCategory_ID,CODE=@CODE,HSNCODE=@HSNCODE,CGST=@CGST,SGST=@SGST,IGST=@IGST,Description=@Description,OPEN_STOCK=@OPEN_STOCK,Image=@Image, Image1=@Image1,Image2=@Image2 where ITEM_ID=@ITEM_ID",
                            CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                            CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID),
                            CreateParameter("@CODE", SqlDbType.VarChar, CODE),
                            CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                            CreateParameter("@CGST", SqlDbType.Decimal, CGST),
                            CreateParameter("@SGST", SqlDbType.Decimal, SGST),
                            CreateParameter("@IGST", SqlDbType.Decimal, IGST),
                            CreateParameter("@Description", SqlDbType.VarChar, Description),
                            CreateParameter("@OPEN_STOCK", SqlDbType.Decimal, OPEN_STOCK),
                            CreateParameter("@Image", SqlDbType.VarChar, Image),
                            CreateParameter("@Image1", SqlDbType.VarChar, Image1),
                            CreateParameter("@Image2", SqlDbType.VarChar, Image2),
                            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO ITEM_MASTER VALUES (@ITEM_ID,@ITEMNAME,@SubCategory_ID,@CODE,@HSNCODE,@CGST,@SGST,@IGST,@Description,@OPEN_STOCK,@Image, @Image1,@Image2)",
                            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                            CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                            CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID),
                            CreateParameter("@CODE", SqlDbType.VarChar, CODE),
                            CreateParameter("@HSNCODE", SqlDbType.VarChar, HSNCODE),
                            CreateParameter("@CGST", SqlDbType.Decimal, CGST),
                            CreateParameter("@SGST", SqlDbType.Decimal, SGST),
                            CreateParameter("@IGST", SqlDbType.Decimal, IGST),
                            CreateParameter("@Description", SqlDbType.VarChar, Description),
                            CreateParameter("@OPEN_STOCK", SqlDbType.Decimal, OPEN_STOCK),
                            CreateParameter("@Image", SqlDbType.VarChar, Image),
                            CreateParameter("@Image1", SqlDbType.VarChar, Image1),
                            CreateParameter("@Image2", SqlDbType.VarChar, Image2));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet ITEM_MASTER_GetAll()
        {
            return ExecuteDataSet("SELECT *,(select min( DisscountPrice) as dis from  ItemUnitRel where ItemUnitRel.ItemId=ITEM_MASTER.ITEM_ID and ItemUnitRel.Quantity>0) as Price FROM ITEM_MASTER ", null, null);
        }
        public DataSet ITEM_MASTER_GetByITEM_ID(int ITEM_ID)
        {
            return ExecuteDataSet("select *, 0 as Price  from ITEM_MASTER where ITEM_ID=@ITEM_ID", null,
            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }

        public DataSet ITEM_MASTER_GetByITEM_IDRATE(int ITEM_ID)
        {
            return ExecuteDataSet("SELECT  *, (select  DisscountPrice from  ItemUnitRel where ItemUnitRel.ItemId=ITEM_MASTER.ITEM_ID)as Price  FROM ITEM_MASTER where ITEM_ID=@ITEM_ID", null,
            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }
        public DataSet ITEM_MASTER_GetBySubCategory_ID(int SubCategory_ID)
        {
            return ExecuteDataSet("select *,0 as Price  from ITEM_MASTER where SubCategory_ID=@SubCategory_ID", null,
            CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID));
        }

        public DataSet ITEM_MASTER_GetByITEM_IDColorAndUnit(string UnitCode, string Color_Code, int ITEM_ID)
        {
            return ExecuteDataSet("SELECT *,(select DisscountPrice from  ItemUnitRel where UnitCode=@UnitCode and Color_Code=@Color_Code and ItemUnitRel.ItemId=ITEM_MASTER.ITEM_ID ) as Price FROM ITEM_MASTER where ITEM_ID=@ITEM_ID", null,
           CreateParameter("@UnitCode", SqlDbType.VarChar, UnitCode),
           CreateParameter("@Color_Code", SqlDbType.VarChar, Color_Code),
                CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }



        public DataSet ITEM_MASTER_GetByITEMNAME(string ITEMNAME)
        {
            return ExecuteDataSet("select * from ITEM_MASTER where ITEMNAME=@ITEMNAME", null,
            CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME));
        }
        public DataSet ITEM_MASTER_Delete(int ITEM_ID)
        {
            return ExecuteDataSet("Delete from ITEM_MASTER where ITEM_ID=@ITEM_ID", null,
            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }
        public DataSet ITEM_MASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(ITEM_ID)  from ITEM_MASTER", null, null);
        }

        #endregion
    }
}
