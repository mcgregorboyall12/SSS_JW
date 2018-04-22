using ApplicationViewModels.Models;
using GalaSoft.MvvmLight;
using StockCalculator.Core.Entities;
using StockCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ApplicationViewModels.ViewModels
{
    public class StocksViewModel : ViewModelBase
    {
        #region Private fields

        private ObservableCollection<UIStock> m_stocks;
        private IStockService m_stockService;
        private ITradeService m_tradeService;

        #endregion

        #region public properties

        public ObservableCollection<UIStock> Stocks
        {
            get { return m_stocks; }
            set { Set(ref m_stocks, value); }
        }

        #endregion

        #region Constructor

        public StocksViewModel(IStockService stockService, ITradeService tradeService)
        {
            m_stockService = stockService;
            m_tradeService = tradeService;
            m_tradeService.TradeArrived += tradeService_TradeArrived;

            Stocks = new ObservableCollection<UIStock>();
            List<Stock> stocks = stockService.GetStocks();

            foreach(Stock stock in stocks)
            {
                Stocks.Add(new UIStock(stock));
            }
        }

        #endregion

        #region private Methods

        private void tradeService_TradeArrived(Trade obj)
        {
            UIStock stock = Stocks.FirstOrDefault(item => item.Stock.Symbol == obj.Symbol);
            if (stock != null)
            {
                stock.AddTrade(obj);
                stock.CalculateStockPrice(DateTime.Now, DateTime.Now.AddMinutes(-15));
                stock.CalculateDividendYield();
                stock.CalculatePERatio();
            }
        }

        #endregion
    }
}
