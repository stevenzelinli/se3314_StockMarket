using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class MarketByPrice : StockMarketDisplay
    {
        string companyName;
        DataTable dataTable;

        public MarketByPrice(string companyName)
        {
            this.companyName = companyName;

            dataTable = new DataTable();
            dataTable.Columns.Add("# of Buy Orders");
            dataTable.Columns.Add("Buy Volume");
            dataTable.Columns.Add("Buy Price");
            dataTable.Columns.Add("Sell Price");
            dataTable.Columns.Add("Sell Volume");
            dataTable.Columns.Add("# of Sell Orders");
        }

        public DataTable DataTable
        {
            get { return dataTable; }
        }

        public override void OnNext(StockData data)
        {
            UpdateTable(data);
        }

        private void UpdateTable(StockData data)
        {
            dataTable.Clear();

            List<Tuple<List<Order>, int>> highestBids = data.getHighestBidsByPrice(this.companyName);
            List<Tuple<List<Order>, int>> lowestSells = data.getLowestSellsByPrice(this.companyName);

            for (int i = 0; i < 10; i++)
            {
                DataRow row = DataTable.NewRow();

                if (highestBids.Count - 1 >= i)
                {
                    row["# of Buy Orders"] = highestBids[i].Item2.ToString();

                    double P = highestBids[i].Item1[0].OrderPrice;
                    int V = 0;
                    foreach (var order in highestBids[i].Item1)
                    {
                        V += order.OrderSize;
                    }

                    row["Buy Volume"] = V;
                    row["Buy Price"] = P;
                }

                if (lowestSells.Count - 1 >= i)
                {
                    row["# of Sell Orders"] = lowestSells[i].Item2.ToString();

                    double P = lowestSells[i].Item1[0].OrderPrice;
                    int V = 0;
                    foreach (var order in lowestSells[i].Item1)
                    {
                        V += order.OrderSize;
                    }

                    row["Sell Volume"] = V;
                    row["Sell Price"] = P;
                }

                dataTable.Rows.Add(row);
            }

        }
    }
}
