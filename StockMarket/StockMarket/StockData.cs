using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class StockData
    {
        StockMarket market;
        List<Company> companyList;
        public StockData(StockMarket _market)
        {
            market = _market;
            companyList = new List<Company>();
            companyList.Add(new Company("Microsoft Corporation", "MSFT", 46.13));
            companyList.Add(new Company("Apple Inc", "AAPL", 105.22));
            companyList.Add(new Company("Facebook Inc", "FB", 80.67));
        }

        public List<Order> getHighestBidsByOrder(string companyName)
        {
            Company company = companyList.Find(x => x.CompanyName.Contains(companyName));
            return company.BuyOrders.OrderByDescending(o => o.OrderPrice).ToList();
        }

        public List<Order> getLowestSellsByOrder(string companyName)
        {
            Company company = companyList.Find(x => x.CompanyName.Contains(companyName));
            return company.SellOrders.OrderBy(o => o.OrderPrice).ToList();
        }

        //Gets top 10 highest bids by price
        public List<Tuple<List<Order>, int>> getHighestBidsByPrice(string companyName)
        {
            List<Tuple<List<Order>, int>> highestBids = new List<Tuple<List<Order>, int>>();

            Company company = companyList.Find(x => x.CompanyName.Contains(companyName));
            List<Order> bids = company.BuyOrders.OrderByDescending(o => o.OrderPrice).ToList();

            double currentPrice = 0;
            int counter = 0;
            List<Order> priceGroup = new List<Order>();

            foreach (var order in bids)
            {
                counter++;
                if (order.OrderPrice != currentPrice)
                {
                    if (currentPrice != 0) highestBids.Add(new Tuple<List<Order>, int>(priceGroup, priceGroup.Count));

                    priceGroup = new List<Order>();
                    priceGroup.Add(order);
                    currentPrice = order.OrderPrice;
                }
                else
                {
                    priceGroup.Add(order);
                }

                if (counter == bids.Count)
                {
                    highestBids.Add(new Tuple<List<Order>, int>(priceGroup, priceGroup.Count));
                }
            }

            return highestBids;
        }

        //Gets top 10 lowest sells by price
        public List<Tuple<List<Order>, int>> getLowestSellsByPrice(string companyName)
        {
            List<Tuple<List<Order>, int>> lowestSells = new List<Tuple<List<Order>, int>>();

            Company company = companyList.Find(x => x.CompanyName.Contains(companyName));
            List<Order> sells = company.SellOrders.OrderBy(o => o.OrderPrice).ToList();

            double currentPrice = 0;
            int counter = 0;
            List<Order> priceGroup = new List<Order>();

            foreach (var order in sells)
            {
                counter++;
                if (order.OrderPrice != currentPrice)
                {
                    if (currentPrice != 0) lowestSells.Add(new Tuple<List<Order>, int>(priceGroup, priceGroup.Count));

                    priceGroup = new List<Order>();
                    priceGroup.Add(order);
                    currentPrice = order.OrderPrice;
                }
                else
                {
                    priceGroup.Add(order);
                }

                if (counter == sells.Count)
                {
                    lowestSells.Add(new Tuple<List<Order>, int>(priceGroup, priceGroup.Count));
                }
            }
            return lowestSells;
        }

        public void buyOrder(string symbol, int amount, double price)
        {
            foreach (var company in companyList)
            {
                if (symbol == company.CompanySymbol)
                {
                    company.buyOrder(amount, price);
                }
            }

            market.Notify(this);
        }

        public void sellOrder(string symbol, int amount, double price)
        {
            foreach (var company in companyList)
            {
                if (symbol == company.CompanySymbol)
                {
                    company.sellOrder(amount, price);
                }
            }

            market.Notify(this);
        }

        public List<Company> CompanyList
        {
            get { return companyList; }
            set { companyList = value; }
        }
    }
}
