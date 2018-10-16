using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using Business.SQLServer;
using System.Data;

namespace Business.Object
{
  public  class KharchaMaster : BusinessBaseObject
    {
        #region

      public int KHARCHA_ID { get; set; }
      public string NAME { get; set; }
      public float AMMOUNT { get; set; }
      public string REMARKS { get; set; }
      public DateTime DATE { get; set; }
       #endregion

        #region Methods

        public override bool MapData(DataRow row)
        {
            KHARCHA_ID = GetInt(row, "KHARCHA_ID");
            NAME = GetString(row, "NAME");
            AMMOUNT = GetFloat(row, "AMMOUNT");
            REMARKS = GetString(row, "REMARKS");
            DATE = GetDateTime(row, "DATE");
            return base.MapData(row);
        }

        public void Save()
        {
            Save(null);
        }
        public void Save(IDbTransaction txn)
        {
            new KharchaMasterDataService().SaleMaster_Save(KHARCHA_ID, NAME, AMMOUNT, REMARKS, DATE);
        }
        public static KharchaMaster GetById(int KHARCHA_ID)
        {
            KharchaMaster obj = new KharchaMaster();
            obj.MapData(new KharchaMasterDataService().SaleMaster_GetById(KHARCHA_ID));
            return obj;
        }
      
         public void Delete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new KharchaMasterDataService().SaleMaster_Delete(KHARCHA_ID);
        }

        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new KharchaMasterDataService().SaleMaster_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }
        #endregion
    }
}
