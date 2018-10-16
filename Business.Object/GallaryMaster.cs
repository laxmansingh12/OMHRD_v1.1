using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data;
using Business.SQLServer;

namespace Business.Object
{
    public class GallaryMaster : BusinessBaseObject
    {
        #region Properties
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Heading { get; set; }
        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            Id = GetInt(row, "Id");
            FileName = GetString(row, "FileName");
            Heading = GetString(row, "Heading");
            return base.MapData(row);
        }
        public static GallaryMaster GetById(int Id)
        {
            GallaryMaster obj = new GallaryMaster();
            obj.MapData(new GalleryDataService().GalleryGetById(Id));
            return obj;
        }
        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new GalleryDataService().GallerySave(Id, FileName, Heading);
        }

        public void GetByDelete()
        {
            Delete(null);
        }

        public void Delete(IDbTransaction txn)
        {
            new GalleryDataService().GalleryDelete(Id);
        }

        public static int GetMaxID()
        {
            int result = 0;
            DataSet ds = new GalleryDataService().GalleryGetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());
            }
            return result;
        }

        #endregion
    }
}
