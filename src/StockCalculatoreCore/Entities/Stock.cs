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
        public StockSymbol Symbol { get; private set; }
        public double LastDividend { get; private set; }
        public double ParValue { get; private set; }
        public double StockPrice { get; private set; }

        public double DividendYield { get; set; }
        public double PERatio { get; set; }
        public List<Trade> Trades;

        public abstract void CalculateDividendYield(double currentStockPrice);

        public void CalculatePERatio(double currentStockPrice)
        {
            PERatio = currentStockPrice / LastDividend;
        }

        public void CalculateStockPrice(DateTime startTime, DateTime endTime)
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
        }

        public void AddTrade(Trade trade)
        {
            Trades.Add(trade);
        }

        public Stock(StockSymbol symbol, double lastDividend, double parValue)
        {
            StockPrice = 0.0;
            PERatio = 0.0;
            DividendYield = 0.0;

            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;

            Trades = new List<Trade>();
        }
    }
}
