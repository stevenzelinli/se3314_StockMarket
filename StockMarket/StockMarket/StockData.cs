using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class StockData
    {
        List<Company> companyList;
        public StockData()
        {
            companyList = new List<Company>();
            companyList.Add(new Company("Microsoft Corporation", "MSFT", 46.13));
            companyList.Add(new Company("Apple Inc", "AAPL", 105.22));
            companyList.Add(new Company("Facebook Inc", "FB", 80.67));
        }
        public List<Company> CompanyList
        {
            get { return companyList; }
            set { companyList = value; }
        }
    }
}
