using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApplicationViewModels.ViewModels
{
    public class StocksViewModel : ViewModelBase
    {
        private ObservableCollection<Stock> m_stocks;

        public ObservableCollection<Stock> Stocks
        {
            get { return m_stocks; }
            set { Set(ref m_stocks, value); }
        }
        public StocksViewModel(IStockService stockService)
        {
            Stocks = new ObservableCollection<Stock>();
            List<Stock> stocks = stockService.GetStocks();

            foreach(Stock stock in stocks)
            {
                Stocks.Add(stock);
                stock.CalculateDividendYield(2.00);
                stock.CalculatePERatio(2.00);
            }
        }
    }
}
