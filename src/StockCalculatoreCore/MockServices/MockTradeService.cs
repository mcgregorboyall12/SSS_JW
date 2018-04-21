using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System;

namespace StockCalculator.Core.MockServices
{
    public class MockTradeService : ITradeService
    {
        public enum Behave
        {
            Return1GINTrade,
            Return0Trades,
            Return10GINTrades
        }
        public event Action<Trade> TradeArrived;
        public Behave HowToBehave { get; set; }

        public void StartMonitoring()
        {
            if(HowToBehave == Behave.Return1GINTrade)
            {
                if(TradeArrived != null)
                {
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now, 10, BuySellIndicator.BUY, 20.00));
                }
            }
            else if(HowToBehave == Behave.Return10GINTrades)
            {
                if (TradeArrived != null)
                {
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now, 10, BuySellIndicator.BUY, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-1), 10, BuySellIndicator.BUY, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-2), 10, BuySellIndicator.SELL, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-3), 10, BuySellIndicator.SELL, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-5), 10, BuySellIndicator.BUY, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-7), 10, BuySellIndicator.BUY, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-8), 10, BuySellIndicator.SELL, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-10), 10, BuySellIndicator.SELL, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-11), 10, BuySellIndicator.BUY, 20.00));
                    TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 20.00));
                }
            }
        }
    }
}
