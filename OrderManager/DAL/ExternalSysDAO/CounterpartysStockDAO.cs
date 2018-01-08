﻿using OrderManager.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DAL.ExternalSysDAO
{
    class CounterpartysStockDAO : ReaderDAO, ICounterpartysStockDAO
    {
        public CounterpartysStockDAO() : base("TowarKontrahenta") { }

        public DataTable GetCounterparty(DataTable counterpartysStock)
        {
           return DBOperations.Query("SELECT * FROM Kontrahent WHERE ID IN ("
                + counterpartysStock.Rows[0]["KontrahentID"] + ")");
        }

        public DataTable GetCounterparty(DataRow counterpartysStock)
        {
            return DBOperations.Query("SELECT * FROM Kontrahent WHERE ID IN ("
               + counterpartysStock["KontrahentID"] + ")");
        }

        public DataTable GetPercentageDiscounts(DataTable counterpartysStock)
        {
            throw new NotImplementedException();
        }

        public DataTable GetStock(DataTable counterpartysStock)
        {
            return DBOperations.Query("SELECT * FROM Towar WHERE ID IN ("
                + counterpartysStock.Rows[0]["TowarID"] + ")");
        }

        public DataTable GetStock(DataRow counterpartysStock)
        {
            return DBOperations.Query("SELECT * FROM Towar WHERE ID IN ("
               + counterpartysStock["TowarID"] + ")");
        }

        public DataTable GetCounterpartysStockValidDicounts(DataTable counterpartysStock)
        {

            if (counterpartysStock.Rows.Count != 1 && !counterpartysStock.Columns.Contains("ID"))
                throw new ArgumentOutOfRangeException();
            return DBOperations.Query(
              @"SELECT * FROM RabatProcentowy WHERE ID IN 
              (SELECT RabatProcentowyID FROM RabatProcentowy_TowarKontrahenta 
              WHERE TowarKontrahentaID = " + counterpartysStock.Rows[0]["ID"].ToString() + @")
              AND OdKiedy <= GETDATE() AND DoKiedy >= GETDATE() AND Aktywny = 1");
        }
    }
}