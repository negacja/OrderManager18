﻿using OrderManager.DAL.InternalSysDAO;
using OrderManager.Domain.Entity;
using OrderManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain.Service
{
    public interface ICounterpartysStockService : IEntityServiceBase<Entity.CounterpartysStock>
    {
        List<Entity.PercentageDiscount> GetValidDiscounts(Entity.CounterpartysStock counterpartysStock);
    }
}
