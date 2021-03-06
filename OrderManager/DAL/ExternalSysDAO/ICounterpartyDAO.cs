﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DAL.InternalSysDAO
{
    interface ICounterpartyDAO : IReadableDAO
    {
        DataTable GetCounterpartysStock(DataTable counterparty);
        DataTable GetCounterpartysOrders(DataTable counterparty);
    }
}
