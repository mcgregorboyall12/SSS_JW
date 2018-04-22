using System;
using System.Collections.Generic;

namespace StockCalculator.Core.Entities
{
    public enum StockSymbol
    {
        TEA,
        POP,
        ALE,
        GIN,
        JOE,
        NONE
    }

    public abstract class Stock
    {
        #region public members

        public StockSymbol Symbol { get; private set; }
        public double LastDividend { get; private set; }
        public double ParValue { get; private set; }
        public double StockPrice { get; private set; }
        public List<Trade> Trades;

        #endregion

        #region Constructor

        public Stock(StockSymbol symbol, double lastDividend, double parValue)
        {
            StockPrice = 0.0;

            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;

            Trades = new List<Trade>();
        }

        #endregion

        #region Public methods

        public abstract double CalculateDividendYield(double currentStockPrice);

        public double CalculatePERatio(double currentStockPrice)
        {
            double peRatio = 0;
            if (LastDividend != 0)
            {
                peRatio = currentStockPrice / LastDividend;
            }
            return peRatio;
        }

        public double CalculateStockPrice(DateTime startTime, DateTime endTime)
        {
            DateTime pastFifteenMinutes = DateTime.Now.AddMinutes(-15);
            double totalCostOfTrades = 0.0;
            double totalQuantity = 0.0;

            foreach(Trade trade in Trades)
            {
                if (trade.Timestamp > pastFifteenMinutes)
                {
                    totalCostOfTrades += (trade.Price * trade.Volume);
                    totalQuantity += trade.Volume;
                }
            }
            if (totalQuantity != 0)
            {
                StockPrice = totalCostOfTrades / totalQuantity;
            }
            return StockPrice;
        }

        public void AddTrade(Trade trade)
        {
            Trades.Add(trade);
        }

        #endregion
    }
}
