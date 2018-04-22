using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;
using System;
using System.Threading.Tasks;
using Xunit;
using static StockCalculator.Core.MockServices.MockTradeService;

namespace StockCalculatorCore.Facts
{
    public class TradeServiceFacts
    {
        [Fact]
        public async Task TradeServiceDelivers10TradesForGINCheckGINStockTradesCountIs10()
        {
            //arrange
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = Behave.Return10GINTrades;

            IStockService stockService = new MockStockService();
            Stock stock = stockService.GetStock(StockSymbol.GIN);

            tradeService.TradeArrived += (trade) =>
            {
                stock.AddTrade(trade);
            };

            //act
            await tradeService.StartAsync();

            //assert
            Assert.True(stock.Trades.Count == 10);
        }

        [Fact]
        public async Task TradeServiceDeliversATradeForGINCheckGINStockTradesCountIs1()
        {
            //arrange
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = Behave.Return1GINTrade;

            IStockService stockService = new MockStockService();
            Stock stock = stockService.GetStock(StockSymbol.GIN);

            tradeService.TradeArrived += (trade) =>
            {
                stock.AddTrade(trade);
            };

            //act
            await tradeService.StartAsync();

            //assert
            Assert.Single(stock.Trades);
            Assert.True(stock.Trades[0].Indicator == BuySellIndicator.BUY);
            Assert.True(stock.Trades[0].Volume == 10);
            Assert.True(stock.Trades[0].Price == 20);
            Assert.True(stock.Trades[0].Timestamp != DateTime.MinValue);
            Assert.True(stock.Trades[0].Symbol == StockSymbol.GIN);
        }

        [Fact]
        public async Task TradeArrivesForExistingStockVolume10Price20CheckThatStockPriceIs20()
        {
            //arrange
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = Behave.Return1GINTrade;

            IStockService stockService = new MockStockService();
            Stock stock = stockService.GetStock(StockSymbol.GIN);

            tradeService.TradeArrived += (trade) =>
            {
                stock.AddTrade(trade);
            };
            await tradeService.StartAsync();

            //act
            stock.CalculateStockPrice(DateTime.Now, DateTime.Now.AddMinutes(-15));

            //assert
            Assert.True(stock.StockPrice == 20);
        }
    }
}
