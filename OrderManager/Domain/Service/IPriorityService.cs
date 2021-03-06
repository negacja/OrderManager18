﻿using OrderManager.Domain.Entity;
using OrderManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain.Service
{
    interface IPriorityService
    {
        List<Priority> GetStockPriority(Stock stock);
    }
}
