using ApplicationViewModels.ViewModels;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;
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

            //act
            StocksViewModel viewmodel = new StocksViewModel(service);

            //assert
            Assert.True(viewmodel.Stocks.Count == service.GetStocks().Count);
        }
    }
}
