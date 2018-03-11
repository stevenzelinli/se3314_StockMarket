using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    abstract class StockMarket : IObservable<StockData>
    {
        public abstract IDisposable Subscribe(IObserver<StockData> observer);
    }
}
