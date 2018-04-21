using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StockCalculator.Core.MockServices
{
    public class MockStockService : IStockService
    {
        public List<Stock> Stocks = null;

        public MockStockService()
        {
            Stocks = new List<Stock>
            {
                new CommonStock(StockSymbol.TEA, 0, 100),
                new CommonStock(StockSymbol.POP, 8, 100),
                new CommonStock(StockSymbol.ALE, 23, 60),
                new PreferredStock(StockSymbol.GIN, 8, 2, 100),
                new CommonStock(StockSymbol.JOE, 13, 100),
            };
        }

        public Stock GetStock(StockSymbol symbol)
        {
            return Stocks.FirstOrDefault(item => item.Symbol == symbol);
        }

        public List<Stock> GetStocks()
        {
            return Stocks;
        }
    }
}
