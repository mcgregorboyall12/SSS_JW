using ApplicationViewModels.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;

namespace SampleApplication.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IStockService, MockStockService>();
            SimpleIoc.Default.Register<ITradeService, MockTradeService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<StocksViewModel>(true);
            SimpleIoc.Default.Register<TradesViewModel>(true);
        }

        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        public StocksViewModel Stocks
        {
            get
            {
                return SimpleIoc.Default.GetInstance<StocksViewModel>();
            }
        }

        public TradesViewModel Trades
        {
            get
            {
                return SimpleIoc.Default.GetInstance<TradesViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}