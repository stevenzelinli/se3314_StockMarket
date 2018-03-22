using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class Company
    {
        string name, symbol;
        double openPrice, lastPrice;
        long volume;
        List<Order> buyOrders;
        List<Order> sellOrders;
        List<Tuple<Order, Order>> resolvedOrders;
        public Company(string name, string symbol, double openPrice)
        {
            this.name = name;
            this.symbol = symbol;
            this.openPrice = openPrice;
            buyOrders = new List<Order>();
            sellOrders = new List<Order>();
            resolvedOrders = new List<Tuple<Order, Order>>();
            lastPrice = 0;
            volume = 0;
        }
        //BUYING
        public void buyOrder(int newOrderSize, double newOrderPrice)
        {
            volume = volume + newOrderSize;
            lastPrice = newOrderPrice;
            if (newOrderSize > 0)
            {
                buyOrders.Add(new Order(newOrderSize, newOrderPrice));
            }
        }
        //SELLING
        public void sellOrder(int newOrderSize, double newOrderPrice)
        {
            volume = volume + newOrderSize;
            lastPrice = newOrderPrice;
            if (newOrderSize > 0)
            {
                sellOrders.Add(new Order(newOrderSize, newOrderPrice));
            }
        }

        public string CompanyName
        {
            get { return name; }
            set { name = value; }
        }
        public string CompanySymbol
        {
            get { return symbol; }
            set { symbol = value; }
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
        public List<Order> BuyOrders
        {
            get { return buyOrders; }
        }

        public List<Order> SellOrders
        {
            get { return sellOrders; }
        }
    }
}
