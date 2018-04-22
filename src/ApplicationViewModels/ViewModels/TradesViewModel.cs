using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading;

namespace ApplicationViewModels.ViewModels
{
    public class TradesViewModel : ViewModelBase
    {
        #region private fields

        private ITradeService m_service;
        private ObservableCollection<Trade> m_trades;
        private SynchronizationContext uiContext;

        #endregion

        #region public properties

        public ObservableCollection<Trade> Trades
        {
            get { return m_trades; }
            set { Set(ref m_trades, value); }
        }

        #endregion

        #region Constructor

        public TradesViewModel(ITradeService service)
        {
            uiContext = SynchronizationContext.Current;
            Trades = new ObservableCollection<Trade>();

            m_service = service;
            m_service.TradeArrived += service_TradeArrived;
        }

        #endregion

        #region private methods

        private void service_TradeArrived(Trade obj)
        {
            uiContext.Send(x => Trades.Add(obj), null);
        }

        #endregion
    }
}
