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
                Console.WriteLine(exc.Message);
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
                    
                    for (int i = 0; i < 1000; i++)
                    {
                        if (TradeArrived != null)
                        {
                            TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 10.4));
                            TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 3.5));
                            TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 3.4));
                            TradeArrived(new Trade(StockSymbol.GIN, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.SELL, 3.4));

                            TradeArrived(new Trade(StockSymbol.ALE, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 10));
                            TradeArrived(new Trade(StockSymbol.ALE, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 3.5));
                            TradeArrived(new Trade(StockSymbol.ALE, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 3.4));
                            TradeArrived(new Trade(StockSymbol.ALE, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.SELL, 3.4));

                            TradeArrived(new Trade(StockSymbol.JOE, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 12));
                            TradeArrived(new Trade(StockSymbol.JOE, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 2.5));
                            TradeArrived(new Trade(StockSymbol.JOE, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 2.6));
                            TradeArrived(new Trade(StockSymbol.JOE, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.SELL, 2.4));

                            TradeArrived(new Trade(StockSymbol.POP, DateTime.Now.AddMinutes(-12), 3, BuySellIndicator.BUY, 3.6));
                            TradeArrived(new Trade(StockSymbol.POP, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 3.4));
                            TradeArrived(new Trade(StockSymbol.POP, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.SELL, 3.1));

                            TradeArrived(new Trade(StockSymbol.TEA, DateTime.Now.AddMinutes(-12), 30, BuySellIndicator.BUY, 10.5));
                            TradeArrived(new Trade(StockSymbol.TEA, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.BUY, 10.7));
                            TradeArrived(new Trade(StockSymbol.TEA, DateTime.Now.AddMinutes(-12), 10, BuySellIndicator.SELL, 10.9));
                        }
                    }
                }
            });
            return true;
        }
    }
}
