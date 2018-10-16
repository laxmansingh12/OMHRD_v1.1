using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Object
{
    public abstract class BusinessBaseCollection<T>:List<T> where T: BusinessBaseObject,new()
        
    {
        public bool MapObjects(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                if(ds.Relations.Count>0)
                    return MapObjects(ds.Tables[0], ds.Relations[0]);
                else
                    return MapObjects(ds.Tables[0]);
            }
            else
            {
                return false;
            }
        }
        public bool MapObjects(DataTable dt,DataRelation dr)
        {
            Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj = new T();
                obj.MapData(dt.Rows[i],dr);
                this.Add(obj);
            }
            return true;
        }
        public bool MapObjects(DataTable dt)
        {
            Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj = new T();
                obj.MapData(dt.Rows[i]);
                this.Add(obj);
            }
            return true;
        }
    }
}
