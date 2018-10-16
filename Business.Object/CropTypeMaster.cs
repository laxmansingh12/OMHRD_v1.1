using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class CropTypeMaster : BusinessBaseObject
    {
        #region
     
      public int CROPS_TYPE_ID { get; set; }
      public string CROPS_TYPE { get; set; }
      public string REMARKS { get; set; }
        #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
       
            CROPS_TYPE_ID = GetInt(row, "CROPS_TYPE_ID");
            CROPS_TYPE = GetString(row, "CROPS_TYPE");
            REMARKS = GetString(row, "REMARKS");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new CropTypeMasterDataService().CropTypeMaster_Save(CROPS_TYPE_ID, CROPS_TYPE,REMARKS);
        }
        public static CropTypeMaster GetById(int CROPS_TYPE_ID)
        {
            CropTypeMaster obj = new CropTypeMaster();
            obj.MapData(new CropTypeMasterDataService().CropTypeMaster_GetById(CROPS_TYPE_ID));
            return obj;
        }

        public static CropTypeMaster GetByName(string CROPS_TYPE)
        {
            CropTypeMaster obj = new CropTypeMaster();
            obj.MapData(new CropTypeMasterDataService().CropTypeMaster_GetByName(CROPS_TYPE));
            return obj;
        }
       
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new CropTypeMasterDataService().CropTypeMaster_Delete(CROPS_TYPE_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new CropTypeMasterDataService().CropTypeMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
