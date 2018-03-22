using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class Order
    {
        DateTime orderDate ;
        double orderPrice;
        int orderSize;
        public Order(int size, double price)
        {
            orderDate = DateTime.Now;
            orderSize = size;
            orderPrice = price;
        }
        public DateTime OrderDate {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public int OrderSize
        {
            get { return orderSize; }
            set { orderSize = value; }
        }
        public double OrderPrice
        {
            get { return orderPrice; }
            set { orderPrice = value; }
        }
        public Order ShallowCopy()
        {
            return (Order)this.MemberwiseClone();
        }
    }
}
