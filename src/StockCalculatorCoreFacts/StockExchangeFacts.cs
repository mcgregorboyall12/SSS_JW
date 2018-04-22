using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static StockCalculator.Core.MockServices.MockTradeService;

namespace StockCalculatorCore.Facts
{
    public class StockExchangeFacts
    {
        [Fact]
        public void CheckTheStockExchangeHasAName()
        {
            //act
            StockExchange exchange = new StockExchange("Global Beverage Corporation Exchange");

            //assert
            Assert.True(exchange.Name != string.Empty);
        }

        [Fact]
        public async Task CheckTheAllShareIndexForOneGINStockEquals1000()
        {
            //arrange
            StockExchange exchange = new StockExchange("Global Beverage Corporation Exchange");
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = Behave.Return1GINTrade;

            IStockService stockService = new MockStockService();
            Stock stock = stockService.GetStock(StockSymbol.GIN);

            tradeService.TradeArrived += (trade) =>
            {
                stock.AddTrade(trade);
            };
            await tradeService.StartAsync();
            stock.CalculateStockPrice(DateTime.Now, DateTime.Now.AddMinutes(-15));

            //act
            exchange.CalculateShareIndex(new List<Stock> { stock });

            //assert
            Assert.Equal(20, exchange.AllShareIndex);
        }

        [Fact]
        public async Task CheckTheAllShareIndexForAllStocksEquals1point58()
        {
            //arrange
            StockExchange exchange = new StockExchange("Global Beverage Corporation Exchange");
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = Behave.Return10GINTrades;

            IStockService stockService = new MockStockService();
            List<Stock> stocks = stockService.GetStocks();

            tradeService.TradeArrived += (trade) =>
            {
                Stock stock = stocks.FirstOrDefault(item => item.Symbol == trade.Symbol);
                stock.AddTrade(trade);
            };
            await tradeService.StartAsync();

            foreach (Stock stock in stocks)
            {
                stock.CalculateStockPrice(DateTime.Now, DateTime.Now.AddMinutes(-15));
            }

            //act
            exchange.CalculateShareIndex(stocks);

            //assert
            Assert.Equal(1.82, Math.Round(exchange.AllShareIndex, 2));
        }
    }
}
