using StockCalculator.Core.Entities;
using Xunit;

namespace StockCalculatorCoreFacts
{
    public class StockCalculatorFacts
    {
        [Fact]
        void CommonTypeTickerPriceEquals50LastDividendEquals1YieldShouldEqual2Percent()
        {
            //arrange
            double currentStockPrice = 50.0;
            double dividend = 1.0;
            Stock stock = new CommonStock(StockSymbol.ALE, dividend, 60);

            //act
            stock.CalculateDividendYield(currentStockPrice);

            //assert
            Assert.Equal(2, stock.DividendYield);
        }
        [Fact]
        void CommonTypeTickerPriceEquals50LastDividendEquals2YieldShouldEqual2point67Percent()
        {
            //arrange
            double currentStockPrice = 50.0;
            double dividend = 2.0;
            Stock stock = new CommonStock(StockSymbol.ALE, dividend, 60);

            //act
            stock.CalculateDividendYield(currentStockPrice);

            //assert
            Assert.Equal(4, stock.DividendYield);
        }
        [Fact]
        void CommonTypeTickerPriceEquals0LastDividendEquals2ShouldReturn0()
        {
            //arrange
            double currentStockPrice = 0.0;
            double dividend = 2.0;
            Stock stock = new CommonStock(StockSymbol.ALE, dividend, 60);

            //act
            stock.CalculateDividendYield(currentStockPrice);

            //assert
            Assert.Equal(0, stock.DividendYield);
        }

        [Fact]
        void CommonTypeCheckWeCanRetreiveASymbolFromStock()
        {
            //arrange
            double dividend = 2.0;

            //act
            Stock stock = new CommonStock(StockSymbol.ALE, dividend, 60);

            //assert
            Assert.True(stock.Symbol != StockSymbol.NONE);
        }
        [Fact]
        void PreferredTypeTickerPriceEquals50LastDividendEquals2YieldShouldEqual0point15Percent()
        {
            //arrange
            double currentStockPrice = 50.0;
            double fixedDividend = 2.0;
            double lastDividend = 8.0;
            Stock stock = new PreferredStock(StockSymbol.GIN, lastDividend, fixedDividend, 60);

            //act
            stock.CalculateDividendYield(currentStockPrice);

            //assert
            Assert.Equal(0.024, stock.DividendYield);
        }
        [Fact]
        void PreferredTypeTickerPriceEquals0LastDividendEquals2ShouldReturn0()
        {
            //arrange
            double currentStockPrice = 0.0;
            double fixedDividend = 2.0;
            double lastDividend = 8.0;

            Stock stock = new PreferredStock(StockSymbol.GIN, lastDividend, fixedDividend, 60);

            //act
            stock.CalculateDividendYield(currentStockPrice);

            //assert
            Assert.Equal(0, stock.DividendYield);
        }

        [Fact]
        void PreferredTypeCheckWeCanRetreiveASymbolFromStock()
        {
            //arrange

            //act
            Stock stock = new PreferredStock(StockSymbol.GIN, 8.0, 2.0, 60);

            //assert
            Assert.True(stock.Symbol != StockSymbol.NONE);
        }
        [Fact]
        void CommonTypeTickerPriceEquals50LastDividendEquals1PEShouldEqual50()
        {
            //arrange
            double currentStockPrice = 50.0;
            double lastDividend = 1.0;
            Stock stock = new CommonStock(StockSymbol.ALE, lastDividend, 60);

            //act
            stock.CalculatePERatio(currentStockPrice);

            //assert
            Assert.Equal(50, stock.PERatio);
        }
        [Fact]
        void PreferredTypeTickerPriceEquals50LastDividendEquals1PEShouldEqual50()
        {
            //arrange
            double currentStockPrice = 50.0;
            double lastDividend = 1.0;
            Stock stock = new PreferredStock(StockSymbol.ALE, lastDividend, 2, 100);

            //act
            stock.CalculatePERatio(currentStockPrice);

            //assert
            Assert.Equal(50, stock.PERatio);
        }
    }
}
