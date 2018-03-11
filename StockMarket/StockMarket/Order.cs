using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Order
    {
        public enum OrderType { BUY, SELL };
        OrderType orderType;
        string orderDate ;
        double orderPrice;
        long orderSize;
        public Order(string date, OrderType type, long size, double price)
        {
            orderDate = date;
            orderSize = size;
            orderPrice = price;
            orderType = type;
        }
        public string OrderDate {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public long OrderSize
        {
            get { return orderSize; }
            set { orderSize = value; }
        }
        public double OrderPrice
        {
            get { return orderPrice; }
            set { orderPrice = value; }
        }
        public OrderType Type
        {
            get { return orderType; }
            set { orderType = value; }
        }
    }
}
