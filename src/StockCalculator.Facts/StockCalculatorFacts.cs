using Xunit;
using StockCalculatoreCore;

namespace StockCalculator.Facts
{
    public class StockCalculatorFacts
    {
        [Fact]
        void TickerPriceEquals50LastDividendEquals1YieldShouldEqual2Percent()
        {
            //arrange
            double stockPrice = 50.0;
            double dividend = 1.0;
            StockCalculatoreCore.StockCalculator calculator = new StockCalculatoreCore.StockCalculator();

            //act
            double dividendYield = calculator.CalculateDividendYield(stockPrice, dividend);

            //assert
            Assert.Equal(2, dividendYield);
        }
    }
}


//For example, if stock XYZ had a share price of $50 and an annualized dividend of $1.00, its yield would be 2%.
//$1.00 / $50 = .02
//When the 0.02 is put into percentage terms, it would make a 2% yield.
//If this share price rose to $60, but the dividend payout was not increased, its yield would fall to 1.66%.
//Remember: The dividend yield is calculated using the annual yield(every regular payout paid that year). It is not calculated by using quarterly, semi annual or monthly payouts.