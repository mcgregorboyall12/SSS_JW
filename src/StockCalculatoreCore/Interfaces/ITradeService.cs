using StockCalculator.Core.Entities;
using System;

namespace StockCalculator.Core.Interfaces
{
    public interface ITradeService
    {
        event Action<Trade> TradeArrived;
        void StartMonitoring();
    }
}
