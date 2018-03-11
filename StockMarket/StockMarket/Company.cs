using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Company
    {
        string name, symbol;
        double openPrice, lastPrice;
        long volume;
        List<Order> orderList;
        public Company(string name, string symbol, double openPrice)
        {
            this.name = name;
            this.symbol = symbol;
            this.openPrice = openPrice;
            orderList = new List<Order>();
            lastPrice = 0;
            volume = 0;
        }
        public void addOrder(Order order)
        {
            volume += order.OrderSize;
            lastPrice = order.OrderPrice;
            orderList.Add(order);
        }
        public string CompanyName
        {
            get { return name; }
            set { name = value; }
        }
        public string CompanySymbol
        {
            get { return name; }
            set { name = value; }
        }
        public double OpenPrice
        {
            get { return openPrice; }
            set { openPrice = value; }
        }
        public double LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }
        public long Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public List<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }
    }
}
