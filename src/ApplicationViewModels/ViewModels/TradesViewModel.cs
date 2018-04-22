using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading;

namespace ApplicationViewModels.ViewModels
{
    public class TradesViewModel : ViewModelBase
    {
        private ITradeService m_service;
        private ObservableCollection<Trade> m_trades;
        private SynchronizationContext uiContext;

        public ObservableCollection<Trade> Trades
        {
            get { return m_trades; }
            set { Set(ref m_trades, value); }
        }

        public TradesViewModel(ITradeService service)
        {
            uiContext = SynchronizationContext.Current;
            Trades = new ObservableCollection<Trade>();

            m_service = service;
            m_service.TradeArrived += service_TradeArrived;
        }

        private void service_TradeArrived(Trade obj)
        {
            uiContext.Send(x => Trades.Add(obj), null);
        }
    }
}
