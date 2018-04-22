using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace StockCalculator.Core.MockServices
{
    public class MockTradeService : ITradeService
    {
        public enum Behave
        {
            DesignDataService,
            Return10GINTrades,
            Return1GINTrade,
            Return0Trades,
        }
        public event Action<Trade> TradeArrived;
        public Behave HowToBehave { get; set; }

        public async Task<bool> StartAsync()
        {
            try
            {
                var x = await StartMonitoring();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        private async Task<bool> StartMonitoring()
        {
            await Task.Run(() =>
            {
                if (HowToBehave == Behave.Return1GINTrade)
                {
                    if (TradeArrived != null)
                    {
                        TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now, 10, BuySellIndicator.BUY, 20.00));
                    }
                }
                else if (HowToBehave == Behave.Return10GINTrades)
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
                else if (HowToBehave == Behave.DesignDataService)
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        if (TradeArrived != null)
                        {
                            TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), i, BuySellIndicator.BUY, i + 1));

                        }
                    }
                }
            });
            return true;
        }
    }
}
