using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMarket
{
    public partial class MarketByOrderForm : Form
    {
        MarketByOrder control;
        StockMarket market;
        string companyName;

        public MarketByOrderForm(string companyName)
        {
            InitializeComponent();
            this.companyName = companyName;
            this.Text += " - " + companyName;
        }
        public void linkToData()
        {
            StockMarketMainForm mdiParent = (StockMarketMainForm)this.MdiParent;

            market = mdiParent.RealTimeData;
            control = new MarketByOrder(this.companyName);
            control.Subscribe(market);
            dataGridView.DataSource = control.DataTable;
        }
        ~MarketByOrderForm()
        {
            market.UnSubscribe(control);
        }
    }
}
