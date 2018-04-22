
namespace StockCalculator.Core.Entities
{
    public class CommonStock : Stock
    {

        #region Constructor

        public CommonStock(StockSymbol symbol, double lastDividend, double parValue)
            : base(symbol, lastDividend, parValue)
        {

        }

        #endregion

        #region public methods

        public override double CalculateDividendYield(double currentStockPrice)
        {
            double dividendYield = 0.0;
            if (currentStockPrice != 0)
            {
                dividendYield = (LastDividend / currentStockPrice) * 100;
            }
            else
            {
                dividendYield = 0;
            }
            return dividendYield;
        }

        #endregion
    }
}
