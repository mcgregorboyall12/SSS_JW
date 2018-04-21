using ApplicationViewModels.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace SampleApplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }
    }
}