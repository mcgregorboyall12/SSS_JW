using ApplicationViewModels.ViewModels;
using GalaSoft.MvvmLight.Threading;
using StockCalculator.Core.MockServices;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationViewModels.Facts
{
    public class TradesViewModelFacts
    {
        public TradesViewModelFacts()
        {
            DispatcherHelper.Initialize();
        }

        [Fact]
        public async Task CheckThatAll10GINTradesArePopulatedOnTheTradesList()
        {
            //arrange
            var service = new MockTradeService();
            service.HowToBehave = MockTradeService.Behave.Return10GINTrades;
            TradesViewModel viewmodel = new TradesViewModel(service);

            //act
            var result = await service.StartAsync();

            //assert 
            Assert.True(viewmodel.Trades.Count == 10);
        }

        [Fact]
        void CheckThatDuplicateTradesAreNotAddedToTheList()
        {

        }
    }
}
