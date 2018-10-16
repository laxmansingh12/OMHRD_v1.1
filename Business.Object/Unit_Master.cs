using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class Unit_Master : BusinessBaseObject
    {
        #region

        public int UNIT_ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        #endregion
        #region Methods
 
        public override bool MapData(DataRow row)
        {
            UNIT_ID = GetInt(row, "UNIT_ID");
            Code = GetString(row, "Code");
            Name = GetString(row, "Name");
            Description = GetString(row, "Description");
            
            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static Unit_Master GetByUNIT_ID(int UNIT_ID)
        {
            Unit_Master obj = new Unit_Master();
            obj.MapData(new Unit_MasterDataService().UNITMASTER_GetByUNIT_ID(UNIT_ID));
            return obj;
        }
        public static Unit_Master GetByCode(string Code)
        {
            Unit_Master obj = new Unit_Master();
            obj.MapData(new Unit_MasterDataService().UNITMASTER_GetByCode(Code));
            return obj;
        }
      
        public void Save(IDbTransaction txn)
        {
            new Unit_MasterDataService().UNITMASTER_Save(UNIT_ID, Code, Name, Description);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new Unit_MasterDataService().UNITMASTER_Delete(UNIT_ID);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new Unit_MasterDataService().UNITMASTER_GetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
                
            }
            return result;
        }
        

        #endregion
    }
}
