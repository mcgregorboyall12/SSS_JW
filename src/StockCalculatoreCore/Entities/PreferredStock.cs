namespace StockCalculator.Core.Entities
{
    public class PreferredStock : Stock
    {
        #region private members

        private double m_fixedDividend;

        #endregion

        #region Constructor

        public PreferredStock(StockSymbol symbol, double lastDividend, double fixedDividend, double parValue) :
            base(symbol, lastDividend, parValue)
        {
            m_fixedDividend = fixedDividend;
        }

        #endregion

        #region public methods

        public override void CalculateDividendYield(double currentStockPrice)
        {
            if (currentStockPrice != 0)
            {
                DividendYield = ((m_fixedDividend / 100) * ParValue) / currentStockPrice;
            }
            else
            {
                DividendYield = 0;
            }
        }

        #endregion
    }
}
