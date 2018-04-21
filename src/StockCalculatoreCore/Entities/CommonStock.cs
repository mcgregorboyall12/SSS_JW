
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

        public override void CalculateDividendYield(double currentStockPrice)
        {
            if (currentStockPrice != 0)
            {
                DividendYield = (LastDividend / currentStockPrice) * 100;
            }
            else
            {
                DividendYield = 0;
            }
        }

        #endregion
    }
}
