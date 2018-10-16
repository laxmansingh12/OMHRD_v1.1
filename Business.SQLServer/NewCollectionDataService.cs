using System;
using System.Data;
using Business.Common;
using System.Data.SqlClient;

namespace Business.SQLServer
{
    public class NewCollectionDataService : DataServiceBase
    {
        #region Consturctor

        public NewCollectionDataService() : base() { }
        public NewCollectionDataService(IDbTransaction txn) : base(txn) { }

        #endregion

        #region Methods

        public void NewCollection_Save(int NewCollection_ID,int ITEM_ID, string ITEMNAME, int CATEGORY_ID, int SubCategory_ID, string Description,decimal DiscountPrice, decimal Price, string Image)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = NewCollection_GetByNewCollection_ID(NewCollection_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE NewCollectionMaster set ITEM_ID=@ITEM_ID, ITEMNAME=@ITEMNAME,CATEGORY_ID=@CATEGORY_ID,SubCategory_ID=@SubCategory_ID,Description=@Description,DiscountPrice=@DiscountPrice,Price=@Price,Image=@Image NewCollection_ID=@NewCollection_ID",
                           CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                           CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                           CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                           CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID),
                            CreateParameter("@Description", SqlDbType.VarChar, Description),
                            CreateParameter("@DiscountPrice", SqlDbType.Decimal, DiscountPrice),
                            CreateParameter("@Price", SqlDbType.Decimal, Price),
                            CreateParameter("@Image", SqlDbType.VarChar, Image),
                            CreateParameter("@NewCollection_ID", SqlDbType.Int, NewCollection_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO NewCollectionMaster VALUES (@NewCollection_ID,@ITEM_ID,@ITEMNAME,@CATEGORY_ID,@SubCategory_ID,@Description,@DiscountPrice,@Price,@Image)",
                            CreateParameter("@NewCollection_ID", SqlDbType.Int, NewCollection_ID),
                            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID),
                            CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME),
                            CreateParameter("@CATEGORY_ID", SqlDbType.Int, CATEGORY_ID),
                            CreateParameter("@SubCategory_ID", SqlDbType.Int, SubCategory_ID),
                            CreateParameter("@Description", SqlDbType.VarChar, Description),
                            CreateParameter("@DiscountPrice", SqlDbType.Decimal, DiscountPrice),
                            CreateParameter("@Price", SqlDbType.Decimal, Price),
                            CreateParameter("@Image", SqlDbType.VarChar, Image));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
        public DataSet NewCollection_GetAll()
        {
            return ExecuteDataSet("select * from NewCollectionMaster ", null, null);
        }
        public DataSet NewCollection_GetByNewCollection_ID(int NewCollection_ID)
        {
            return ExecuteDataSet("select * from NewCollectionMaster where NewCollection_ID=@NewCollection_ID", null,
            CreateParameter("@NewCollection_ID", SqlDbType.Int, NewCollection_ID));
        }
        public DataSet NewCollection_GetByITEM_ID(int ITEM_ID)
        {
            return ExecuteDataSet("select * from NewCollectionMaster where ITEM_ID=@ITEM_ID", null,
            CreateParameter("@ITEM_ID", SqlDbType.Int, ITEM_ID));
        }
        public DataSet NewCollection_GetByITEMNAME(string ITEMNAME)
        {
            return ExecuteDataSet("select * from NewCollectionMaster where ITEMNAME=@ITEMNAME", null,
            CreateParameter("@ITEMNAME", SqlDbType.VarChar, ITEMNAME));
        }
        public DataSet NewCollection_Delete(int NewCollection_ID)
        {
            return ExecuteDataSet("Delete from NewCollectionMaster where NewCollection_ID=@NewCollection_ID", null,
            CreateParameter("@NewCollection_ID", SqlDbType.Int, NewCollection_ID));
        }
        public DataSet NewCollection_GetMAXId()
        {
            return ExecuteDataSet("select max(NewCollection_ID)  from NewCollectionMaster", null, null);
        }

        #endregion
    }
}
