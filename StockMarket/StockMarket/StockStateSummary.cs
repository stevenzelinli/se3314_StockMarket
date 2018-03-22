using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMarket
{
    class StockStateSummary : StockMarketDisplay
    {
        DataTable dataTable;

        public StockStateSummary()
        {
            //INSTANTIATING NEW DATA TABLE WITH COLUMNS
            dataTable = new DataTable();
            dataTable.Columns.Add("Company");
            dataTable.Columns.Add("Symbol");
            dataTable.Columns.Add("Open Price");
            dataTable.Columns.Add("Last Sale");
            dataTable.Columns.Add("Change Net");
            dataTable.Columns.Add(" ", typeof(System.Drawing.Bitmap));
            dataTable.Columns.Add("Change %");
            dataTable.Columns.Add("Share Volume");
        }

        public DataTable DataTable
        {
            get { return dataTable; }
        }

        //UPDATE
        public override void OnNext(StockData value)
        {
            UpdateTable(value);
        }

        //UPDATE METHOD
        private void UpdateTable(StockData data)
        {
            dataTable.Clear();

            foreach (var company in data.CompanyList)
            {
                double netChange = 0;
                double percentChange = 0;
                //IF VOLUME IS ZERO THEN NO CHANGE HAS OCCURED
                if (company.Volume == 0)
                {
                    netChange = 0;
                    percentChange = 0;
                }
                else
                {
                    netChange = company.LastPrice - company.OpenPrice;
                    percentChange = ((company.LastPrice - company.OpenPrice) / company.OpenPrice) * 100;
                }
                string imgURL;
                Console.WriteLine(company.CompanyName);
                Console.WriteLine(company.CompanySymbol);
                if (netChange > 0)
                {
                    imgURL = "C:\\Users\\steve\\Documents\\Visual Studio 2017\\Projects\\se3314_StockMarket\\StockMarket\\StockMarket\\assets\\up.bmp";
                }
                else if (netChange < 0)
                {
                    imgURL = "C:\\Users\\steve\\Documents\\Visual Studio 2017\\Projects\\se3314_StockMarket\\StockMarket\\StockMarket\\assets\\down.bmp";
                }
                else
                {
                    imgURL = "C:\\Users\\steve\\Documents\\Visual Studio 2017\\Projects\\se3314_StockMarket\\StockMarket\\StockMarket\\assets\\noChange.bmp";
                }

                DataRow row = DataTable.NewRow();
                row["Company"] = company.CompanyName;
                row["Symbol"] = company.CompanySymbol;
                row["Open Price"] = company.OpenPrice;
                row["Last Sale"] = company.LastPrice;
                row["Change Net"] = netChange;
                row[" "] = new System.Drawing.Bitmap(imgURL);
                row["Change %"] = percentChange;
                row["Share Volume"] = company.Volume;
                dataTable.Rows.Add(row);
            }
        }
    }
}
