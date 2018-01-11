﻿using OrderManager.DAL.ExternalSysDAO;
using OrderManager.DAL.InternalSysDAO;
using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DTO
{
    class PercentageDiscountMapper : IMapperBase<Domain.Entity.PercentageDiscount>
    {
        private IPercentageDiscountDAO percentageDiscountDAO;
        private ICounterpartysStockDAO counterpartysStockDAO;

        public PercentageDiscountMapper(IPercentageDiscountDAO percentageDiscountDAO, ICounterpartysStockDAO counterpartysStockDAO)
        {
            this.percentageDiscountDAO = percentageDiscountDAO;
            this.counterpartysStockDAO = counterpartysStockDAO;
        }

        public List<Domain.Entity.PercentageDiscount> MapAllFrom(DataTable tDAO)
        {
            List<Domain.Entity.PercentageDiscount> result = new List<Domain.Entity.PercentageDiscount>();
            foreach (DataRow row in tDAO.Rows)
                result.Add(MapFrom(tDAO,
                    tDAO.Rows.IndexOf(row)));
            return result;
        }

        public Domain.Entity.PercentageDiscount MapFrom(DataTable tDAO)
        {
            return MapFrom(tDAO, 0);
        }

        private Domain.Entity.PercentageDiscount MapFrom(DataTable discountTable, int numberOfRow)
        {
            CounterpartysStockMapper counterpartysStockMapper = new CounterpartysStockMapper(counterpartysStockDAO);
            DataRow counterpartyRow = discountTable.Rows[numberOfRow];
            return new Domain.Entity.PercentageDiscount(
            Convert.ToInt32(counterpartyRow["ID"]),
            Convert.ToDateTime(counterpartyRow["OdKiedy"]),
            Convert.ToDateTime(counterpartyRow["DoKiedy"]),
            Convert.ToDouble(counterpartyRow["SumaWartosciPozycjiNetto"]),
            Convert.ToDouble(counterpartyRow["Wysokosc"]),
            Convert.ToBoolean(counterpartyRow["Sumowanie"]),
            Convert.ToBoolean(counterpartyRow["Aktywny"]),
            counterpartysStockMapper.MapAllFrom(percentageDiscountDAO.GetCounterpartiesStockWithDiscount(discountTable.Rows[numberOfRow])));
        }

        public DataTable MapTo(Domain.Entity.PercentageDiscount discountDomain)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("OdKiedy");
            dataTable.Columns.Add("DoKiedy");
            dataTable.Columns.Add("SumaWartosciPozycjiNetto");
            dataTable.Columns.Add("Wysokosc");
            dataTable.Columns.Add("Sumowanie");
            dataTable.Columns.Add("Aktywny");
            DataRow dataRow = dataTable.NewRow();
            dataRow["ID"] = discountDomain.Id;
            dataRow["OdKiedy"] = discountDomain.Since;
            dataRow["DoKiedy"] = discountDomain.Until;
            dataRow["SumaWartosciPozycjiNetto"] = discountDomain.SumNetto;
            dataRow["Wysokosc"] = discountDomain.Amount;
            dataRow["Sumowanie"] = discountDomain.Summing;
            dataRow["Aktywny"] = discountDomain.Active;
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }


    }
}
