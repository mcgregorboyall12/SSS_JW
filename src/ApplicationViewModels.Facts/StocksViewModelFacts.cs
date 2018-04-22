using ApplicationViewModels.Models;
using ApplicationViewModels.ViewModels;
using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationViewModels.Facts
{
    public class StocksViewModelFacts
    {
        [Fact]
        public void CheckAllCompaniesFromTheStockServiceAreListed()
        {
            //arrange
            IStockService service = new MockStockService();
            ITradeService tradeService = new MockTradeService();

            //act
            StocksViewModel viewmodel = new StocksViewModel(service, tradeService);

            //assert
            Assert.True(viewmodel.Stocks.Count == service.GetStocks().Count);
        }

        [Fact]
        public async Task CheckStockPriceIsUpdatedfterTradesArrive()
        {
            //arrange
            IStockService service = new MockStockService();
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = MockTradeService.Behave.Return10GINTrades;
            StocksViewModel viewmodel = new StocksViewModel(service, tradeService);

            //act
            await tradeService.StartAsync();

            //assert
            foreach (UIStock stock in viewmodel.Stocks)
            {
                if (stock.Stock.Symbol == StockSymbol.GIN) // test data only setup for GIN at the moment
                {
                    Assert.True(stock.StockPrice != 0);
                }
            }
        }

        [Fact]
        public async Task CheckFundamentalsAreUpdatedfterTradesComplete()
        {
            //arrange
            IStockService service = new MockStockService();
            var tradeService = new MockTradeService();
            tradeService.HowToBehave = MockTradeService.Behave.Return10GINTrades;
            StocksViewModel viewmodel = new StocksViewModel(service, tradeService);

            //act
            await tradeService.StartAsync();

            //assert
            foreach (UIStock stock in viewmodel.Stocks)
            {
                if (stock.Stock.Symbol == StockSymbol.GIN) // test data only setup for GIN at the moment
                {
                    Assert.True(stock.DividendYield != 0);
                    Assert.True(stock.PERatio != 0);
                }
            }
        }
    }
}
