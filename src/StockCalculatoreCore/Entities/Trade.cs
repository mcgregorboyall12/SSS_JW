using System;

namespace StockCalculator.Core.Entities
{
    public enum BuySellIndicator
    {
        BUY,
        SELL
    }

    public class Trade
    {
        #region Public properties

        public DateTime Timestamp { get; private set; }
        public int Volume { get; private set; }
        public BuySellIndicator Indicator { get; private set; }
        public double Price { get; private set; }
        public StockSymbol Symbol { get; private set; }

        #endregion

        #region Constructor

        public Trade(StockSymbol symbol, DateTime timestamp, int volume, BuySellIndicator indicator, double price)
        {
            Symbol = symbol;
            Timestamp = timestamp;
            Volume = volume;
            Indicator = indicator;
            Price = price;
        }

        #endregion 
    }
}
