﻿using System.Collections.Generic;
using OrderManager.Domain.Entity;

namespace OrderManager.Domain.Service
{
    class PriorityPriceChoice : IOffersChoice
    {
        Dictionary<Stock, int> stockToOrder;
        ICounterpartysStockService counterpartysStockService;
        IStockService stockService;

        public PriorityPriceChoice(Dictionary<Stock, int> stockToOrder,
            ICounterpartysStockService counterpartysStockService, IStockService stockService)
        {
            this.stockToOrder = stockToOrder;
            this.counterpartysStockService = counterpartysStockService;
            this.stockService = stockService;
        }

        public List<Tranche> BestChosenOfferts()
        {
            return (new DiscountCounter(stockToOrder, counterpartysStockService, stockService)).BestChosenDiscounts();
        }
    }
}
