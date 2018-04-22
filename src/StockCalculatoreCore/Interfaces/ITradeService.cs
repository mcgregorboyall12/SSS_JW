using StockCalculator.Core.Entities;
using System;
using System.Threading.Tasks;

namespace StockCalculator.Core.Interfaces
{
    public interface ITradeService
    {
        event Action<Trade> TradeArrived;
        Task<bool> StartAsync();
    }
}
