using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public abstract class StockMarketDisplay : IObserver<StockData>
    {
        private IDisposable unSubscriber; // used to remove observer from list
        /**
         * Subscribe the observer
         */
        public virtual void Subscribe(IObservable<StockData> provider)
        {
            unSubscriber = provider.Subscribe(this);
        }
        /**
         * Method called after Observable unsubscribes an Observer or when Observable is done transmitting data
         */
        public virtual void OnCompleted()
        {
            this.UnSubscribe();
        }
        /**
         * Unsubscribing
         */
        public virtual void UnSubscribe()
        {
            unSubscriber.Dispose();
        }
        /**
         * Not necessary to implement
         */
        public virtual void OnError(Exception error)
        {
            // do nothing
        }

        /**
         * This functions as the 'Update()' for observers
         */
        public abstract void OnNext(StockData value);
    }
}
