using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class MarketByOrder : StockMarketDisplay
    {
        string companyName;
        DataTable dataTable;

        public MarketByOrder(string companyName)
        {
            this.companyName = companyName;

            dataTable = new DataTable();
            dataTable.Columns.Add("Buy Volume");
            dataTable.Columns.Add("Buy Price");
            dataTable.Columns.Add("Sell Price");
            dataTable.Columns.Add("Sell Volume");
        }

        public DataTable DataTable
        {
            get { return dataTable; }
        }

        public override void OnNext(StockData data)
        {
            LoadDataTable(data);
        }

        private void LoadDataTable(StockData data)
        {
            dataTable.Clear();

            List<Order> highestBids = data.getHighestBidsByOrder(this.companyName);
            List<Order> lowestSells = data.getLowestSellsByOrder(this.companyName);

            for (int i = 0; i < 10; i++)
            {
                DataRow row = DataTable.NewRow();

                if (highestBids.Count - 1 >= i)
                {
                    row["Buy Volume"] = highestBids[i].OrderSize;
                    row["Buy Price"] = highestBids[i].OrderPrice;
                }

                if (lowestSells.Count - 1 >= i)
                {
                    row["Sell Price"] = lowestSells[i].OrderPrice;
                    row["Sell Volume"] = lowestSells[i].OrderSize;
                }

                dataTable.Rows.Add(row);
            }
        }
    }
}
