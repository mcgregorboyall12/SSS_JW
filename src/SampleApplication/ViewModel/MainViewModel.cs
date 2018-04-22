using ApplicationViewModels.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using StockCalculator.Core.Interfaces;

namespace SampleApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase Stocks
        {
            get { return SimpleIoc.Default.GetInstance<StocksViewModel>(); }
        }

        public ViewModelBase Trades
        {
            get { return SimpleIoc.Default.GetInstance<TradesViewModel>(); }
        }

        public MainViewModel(ITradeService tradeService)
        {
            tradeService.StartAsync();
        }
    }
}