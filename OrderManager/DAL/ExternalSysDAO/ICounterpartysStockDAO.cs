﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DAL.ExternalSysDAO
{
    interface ICounterpartysStockDAO : IReadableDAO
    {
        DataTable GetCounterparty(DataTable counterpartysStock);
        DataTable GetStock(DataRow counterpartysStock);
        DataTable GetCounterparty(DataRow counterpartysStock);
        DataTable GetStock(DataTable counterpartysStock);
        DataTable GetCounterpartysStockValidDicounts(DataTable counterpartysStock);
    }
}
