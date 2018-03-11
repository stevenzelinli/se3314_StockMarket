using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    abstract class StockMarket : IObservable<StockData>
    {
        private List<IObserver<StockData>> observers;
        public StockMarket()
        {
            observers = new List<IObserver<StockData>>();
        }
        /**
         * This functions as the 'Register' for observables
         */
        public virtual IDisposable Subscribe(IObserver<StockData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

        /**
         * This functions as the 'unRegister' for observables
         */
        public virtual void UnSubscribe(IObserver<StockData> observer)
        {
            observer.OnCompleted();
        }

        /**
         * This functions as the 'notify' for observables
         */
        public virtual void Notify(StockData updatedData)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(updatedData);
            }
        }

        /**
         * For unsubscribing observers.
         */ 
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<StockData>> _observers;
            private IObserver<StockData> _observer;

            public Unsubscriber(List<IObserver<StockData>> observers, IObserver<StockData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
