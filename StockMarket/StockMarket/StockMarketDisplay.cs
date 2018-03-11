using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    abstract class StockMarketDisplay : IObserver<RealTimeData>
    {
        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(RealTimeData value);
    }
}
