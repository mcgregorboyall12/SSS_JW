using System;
using System.Collections.Generic;

namespace StockCalculator.Core.Entities
{
    public class StockExchange
    {

        public StockExchange(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public double AllShareIndex { get; set; }

        public void CalculateShareIndex(List<Stock> stocks)
        {
            double product = 1.0;

            foreach(Stock stock in stocks)
            {
                if (stock.StockPrice != 0)
                {
                    product *= stock.StockPrice;
                }
            }

            double power = 1.0 / stocks.Count;
            AllShareIndex = Math.Pow(product, power);
        }
    }
}
