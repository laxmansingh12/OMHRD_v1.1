using System;
using System.Data;
using Business.Common;


namespace Business.Object
{
   public abstract class BusinessBaseObject
    {
       public virtual bool MapData(DataSet ds)
       {
         if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
           {
               return MapData(ds.Tables[0].Rows[0]);
           }
           else
           {
               return false;
           }
       }

       public virtual bool MapData(DataTable dt)
       {
           if (dt != null && dt.Rows.Count > 0)
           {
               return MapData(dt.Rows[0]);
           }
           else
           {
               return false;
           }
       }
       public virtual bool MapData(DataRow row,DataRelation dr)
       {
           return true;
       }

       public virtual bool MapData(DataRow row)
       {
           return true;
       }

       #region Get Functions

       //////////////////////////////////////////////////////////////////////////////
       protected static int GetInt(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToInt32(row[columnName]) : Constants.NullInt;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static DateTime GetDateTime(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToDateTime(row[columnName]) : Constants.NullDateTime;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static Decimal GetDecimal(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToDecimal(row[columnName]) : Constants.NullDecimal;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static bool GetBool(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToBoolean(row[columnName]) : false;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static string GetString(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToString(row[columnName]) : Constants.NullString;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static double GetDouble(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToDouble(row[columnName]) : Constants.NullDouble;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static Guid GetGuid(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? (Guid)(row[columnName]) : Constants.NullGuid;
       }
       

       //////////////////////////////////////////////////////////////////////////////
       protected static float GetFloat(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? Convert.ToSingle(row[columnName]) : Constants.NullFloat;
       }

       
       //////////////////////////////////////////////////////////////////////////////
       protected static long GetLong(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? (long)(row[columnName]) : Constants.NullLong;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static char GetChar(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? (char)(row[columnName]) : Constants.NullChar;
       }

       //////////////////////////////////////////////////////////////////////////////
       protected static byte[] GetByteArray(DataRow row, string columnName)
       {
           return (row[columnName] != DBNull.Value) ? (byte[])(row[columnName]) : Constants.NullByteArray;
       }
     
       #endregion

    }
}
