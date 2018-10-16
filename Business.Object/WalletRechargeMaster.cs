﻿using System;
using System.Data;
using Business.Common;
using Business.SQLServer;

namespace Business.Object
{
    public class WalletRechargeMaster : BusinessBaseObject
    {
        #region

        public int Id { get; set; }
         public int ByUser_id { get; set; }
        public int User_id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        #endregion
        #region Methods

        public override bool MapData(DataRow row)
        {
            Id = GetInt(row, "Id");
            ByUser_id = GetInt(row, "ByUser_id");
            User_id = GetInt(row, "User_id");
            Amount = GetDecimal(row, "Amount");
            Date = GetDateTime(row, "Date");

            return base.MapData(row);
        }
        public void Save()
        {
            Save(null);
        }
        public static WalletRechargeMaster GetById(int Id)
        {
            WalletRechargeMaster obj = new WalletRechargeMaster();
            obj.MapData(new WalletRechargeDataService().WalletRechargeGetById(Id));
            return obj;
        }
        public static WalletRechargeMaster GetByUser_id(int User_id)
        {
            WalletRechargeMaster obj = new WalletRechargeMaster();
            obj.MapData(new WalletRechargeDataService().WalletRechargeGetByUser_id(User_id));
            return obj;
        }

        public void Save(IDbTransaction txn)
        {
            new WalletRechargeDataService().WalletRechargeSave(Id, ByUser_id, User_id, Amount, Date);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(IDbTransaction txn)
        {
            new WalletRechargeDataService().WalletRechargeDelete(Id);
        }
        public static int MaxId()
        {
            int result = 0;
            DataSet ds = new WalletRechargeDataService().WalletRechargeGetMAXId();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString());

            }
            return result;
        }


        #endregion
    }
}