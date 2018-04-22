using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using System;

namespace ApplicationViewModels.Models
{
    public class UIStock : ObservableObject
    {
        private Stock m_stock;
        private double m_stockPrice;

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

        public UIStock(Stock stock)
        {
            m_stock = stock;
        }

        public void AddTrade(Trade trade)
        {
            m_stock.AddTrade(trade);
        }

        public void CalculateStockPrice(DateTime start, DateTime end)
        {
            StockPrice = m_stock.CalculateStockPrice(start, end);
        }
    }
}
