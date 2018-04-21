using ApplicationViewModels.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using StockCalculator.Core.Interfaces;
using StockCalculator.Core.MockServices;

namespace SampleApplication.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<IStockService, MockStockService>();

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