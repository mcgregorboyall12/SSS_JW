using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using System;

namespace ApplicationViewModels.Models
{
    public class UIStock : ObservableObject
    {
        #region Private fields

        private Stock m_stock;
        private double m_stockPrice;
        private double m_peRatio;
        private double m_dividendYield;

        #endregion

        #region Public properties

        public Stock Stock
        {
            get { return m_stock; }
            set { Set(ref m_stock, value); }
        }

        public double StockPrice
        {
            get { return m_stockPrice; }
            set { Set(ref m_stockPrice, value); }
        }

        public double DividendYield
        {
            get { return m_dividendYield; }
            set { Set(ref m_dividendYield, value); }
        }

        public double PERatio
        {
            get { return m_peRatio; }
            set { Set(ref m_peRatio, value); }
        }

        #endregion

        #region Constructor

        public UIStock(Stock stock)
        {
            m_stock = stock;
        }

        #endregion

        #region Public methods

        public void AddTrade(Trade trade)
        {
            m_stock.AddTrade(trade);
        }

        public void CalculateStockPrice(DateTime start, DateTime end)
        {
            StockPrice = m_stock.CalculateStockPrice(start, end);
        }

        public void CalculateDividendYield()
        {
            DividendYield = m_stock.CalculateDividendYield(StockPrice);
        }

        public void CalculatePERatio()
        {
            PERatio = m_stock.CalculatePERatio(StockPrice);
        }

        #endregion
    }
}
