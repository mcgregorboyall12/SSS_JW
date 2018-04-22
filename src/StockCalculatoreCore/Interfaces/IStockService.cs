using System.Collections.Generic;
using StockCalculator.Core.Entities;

namespace StockCalculator.Core.Interfaces
{
    public interface IStockService
    {
        Stock GetStock(StockSymbol symbol);
        List<Stock> GetStocks();
    }
}
