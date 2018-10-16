using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Business.Common;

namespace Business.SQLServer
{
    public class DataServiceBase
    {
        private class State
        {
            public SqlConnection Cnx = null;
            public SqlCommand Cmd = null;
            public string TableName = string.Empty;
            public AsyncResult asyncResult = null;
        }

        private bool _isOwner = false;   //True if service owns the transaction        
        private SqlTransaction _txn;
        public DataServiceBase() : this(null) { }


        public DataServiceBase(IDbTransaction txn)
        {
            if (txn == null)
            {
                _isOwner = true;
            }
            else
            {
                _txn = (SqlTransaction)txn;
                _isOwner = false;
            }
        }

        public static string GetConnectionString()
        {
            if (DateTime.Today.Subtract(Util.stringToDate("27/04/2020")).Days <= 0)
            {
                return ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                //return "Data Source=SIMS-PC; Initial Catalog=mskveg; User ID=sa;Password=123456";
                // return "Data Source=SIMS-PC; Initial Catalog=WEAVER_DB; User ID=sa;Password=123456";
                //return "Data Source=USER-PC\\SQLEXPRESS; Initial Catalog=FMS; User ID=sa;Password=123456";
            }
            else
            {
                return "";
            }
        }

        public static string GetConnectionStringAsync()
        {
            return ConfigurationManager.ConnectionStrings["DBAsync"].ConnectionString;
        }

        protected DataSet ExecuteDataSet(string sql, string tableName,
            params IDataParameter[] sqlParams)
        {
            SqlCommand cmd;
            return ExecuteDataSet(out cmd, sql, tableName, sqlParams);
        }
        //public static IDbTransaction BeginTransaction()
        //{
        //    SqlConnection txnConnection =
        //        new SqlConnection(GetConnectionString());
        //    txnConnection.Open();
        //    return txnConnection.BeginTransaction();
        //}

        //protected IAsyncResult BeginExecuteDataSet(string sql, AsyncCallback cb, object state, string tableName, params IDataParameter[] sqlParams)
        //{
        //    SqlCommand cmd;
        //    SqlConnection cnx = null;

        //    cmd = null;

        //    try
        //    {
        //        //Setup command object
        //        cmd = new SqlCommand(sql);
        //        if (sqlParams != null)
        //        {
        //            for (int index = 0; index < sqlParams.Length; index++)
        //            {
        //                cmd.Parameters.Add(sqlParams[index]);
        //            }
        //        }


        //        //Determine the transaction owner and process accordingly
        //        if (_isOwner)
        //        {
        //            cnx = new SqlConnection(GetConnectionStringAsync());
        //            cmd.Connection = cnx;
        //            cnx.Open();
        //        }
        //        else
        //        {
        //            cmd.Connection = _txn.Connection;
        //            cmd.Transaction = _txn;
        //        }

        //        //Fill the dataset
        //        State stateObject = new State();
        //        stateObject.Cnx = cnx;
        //        stateObject.TableName = tableName;
        //        stateObject.Cmd = cmd;
        //        stateObject.asyncResult = new AsyncResult(cb, state);
        //        IAsyncResult result = cmd.BeginExecuteReader(new AsyncCallback(RespCallBack), stateObject);
        //        return stateObject.asyncResult;

        //    }
        //    catch
        //    {
        //        throw;
        //    }


        //}
        //private void RespCallBack(IAsyncResult ar)
        //{
        //    DataSet ds = new DataSet();
        //    State stateObject = (State)ar.AsyncState;
        //    try
        //    {
        //        SqlDataReader reader = stateObject.Cmd.EndExecuteReader(ar);
        //        DataTable dataTable = null;
        //        if (!string.IsNullOrEmpty(stateObject.TableName))
        //        {
        //            dataTable = new DataTable(stateObject.TableName);
        //        }
        //        else
        //        {
        //            dataTable = new DataTable();
        //        }
        //        dataTable.Load(reader);
        //        ds.Tables.Add(dataTable);
        //        stateObject.asyncResult.Result = ds;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {

        //        if (stateObject.Cmd != null) stateObject.Cmd.Dispose();
        //        if (_isOwner)
        //        {
        //            stateObject.Cnx.Dispose(); //Implicitly calls cnx.Close()
        //        }
        //        stateObject.asyncResult.Complete();
        //    }

        //    return;

        //}
        //protected DataSet EndExecuteDataSet(IAsyncResult ar)
        //{
        //    if (null == ar)
        //        throw new ArgumentNullException("ar");
        //    AsyncResult asyncResult = ar as AsyncResult;
        //    if (null == asyncResult)
        //        throw new ArgumentException("", "ar");
        //    asyncResult.Validate();
        //    asyncResult.AsyncWaitHandle.WaitOne();
        //    DataSet res = asyncResult.Result;
        //    asyncResult.Dispose();
        //    return res;
        //}

        protected DataSet ExecuteDataSet(out SqlCommand cmd, string sql, string tableName,
            params IDataParameter[] sqlParams)
        {
            SqlConnection cnx = null;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = null;

            try
            {
                //Setup command object
                cmd = new SqlCommand(sql);
                if (sqlParams != null)
                {
                    for (int index = 0; index < sqlParams.Length; index++)
                    {
                        cmd.Parameters.Add(sqlParams[index]);
                    }
                }
                da.SelectCommand = (SqlCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new SqlConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }

                //Fill the dataset
                if (!string.IsNullOrEmpty(tableName))
                    da.Fill(ds, tableName);
                else
                    da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
            }
            return ds;
        }

        protected void ExecuteNonQuery(string sql,
            params IDataParameter[] procParams)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, sql, procParams);
        }


        protected void ExecuteNonQuery(out SqlCommand cmd, string sql,
            params IDataParameter[] procParams)
        {
            //Method variables
            SqlConnection cnx = null;
            cmd = null;  //Avoids "Use of unassigned variable" compiler error

            try
            {
                //Setup command object
                cmd = new SqlCommand(sql);
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        if (procParams[index] != null)
                            cmd.Parameters.Add(procParams[index]);
                    }
                }

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new SqlConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }

                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
                if (cmd != null) cmd.Dispose();
            }
        }

        protected SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);

            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case SqlDbType.VarChar:
                    case SqlDbType.NVarChar:
                    case SqlDbType.Char:
                    case SqlDbType.NChar:
                    case SqlDbType.Text:
                        paramValue = CheckParamValue((string)paramValue);
                        break;
                    case SqlDbType.DateTime:
                        paramValue = CheckParamValue((DateTime)paramValue);
                        break;
                    case SqlDbType.Int:
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                    case SqlDbType.Bit:
                        if (paramValue is bool) paramValue = (int)((bool)paramValue ? 1 : 0);
                        if ((int)paramValue < 0 || (int)paramValue > 1) paramValue = Constants.NullInt;
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                    case SqlDbType.Float:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;
                    case SqlDbType.Decimal:
                        paramValue = CheckParamValue((decimal)paramValue);
                        break;
                    case SqlDbType.Image:
                        paramValue = CheckParamValue((byte[])paramValue);
                        break;

                }
            }
            param.Value = paramValue;
            return param;
        }

        protected object CheckParamValue(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }


        protected object CheckParamValue(DateTime paramValue)
        {
            if (paramValue.Equals(Constants.NullDateTime))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(double paramValue)
        {
            if (paramValue.Equals(Constants.NullDouble))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(float paramValue)
        {
            if (paramValue.Equals(Constants.NullFloat))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(Decimal paramValue)
        {
            if (paramValue.Equals(Constants.NullDecimal))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(int paramValue)
        {
            if (paramValue.Equals(Constants.NullInt))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(byte[] paramValue)
        {
            if (paramValue.Equals(Constants.NullByteArray))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
    }
}
