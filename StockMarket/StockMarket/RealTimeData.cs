using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class RealTimeData : StockMarket
    {
        public RealTimeData()
        {
            this.observers = new List<IObserver<StockData>>();
            this.stockData = new StockData(this);
        }
    }
}
