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
    public partial class BidForm : Form
    {
        StockMarket market;

        public BidForm()
        {
            InitializeComponent();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            StockMarketMainForm stockMarketForm = (StockMarketMainForm)this.MdiParent;
            market = stockMarketForm.RealTimeData;
            string symbol = comboBox1.Text;
            int amount = Int32.Parse(amountTextBox.Text);
            double price = Double.Parse(priceTextBox.Text);

            market.CurrentStocks.buyOrder(symbol, amount, price);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BidForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            ToolStripMenuItem ti = (ToolStripMenuItem)ms.Items["ordersToolStripMenuItem"];
            ti.DropDownItems["bidToolStripMenuItem"].Enabled = true;
        }

        private void BidForm_Load(object sender, EventArgs e)
        {
            StockMarketMainForm stockMarketForm = (StockMarketMainForm)this.MdiParent;
            market = stockMarketForm.RealTimeData;
            foreach (var company in market.CurrentStocks.CompanyList)
            {
                comboBox1.Items.Add(company.CompanySymbol);
            }
        }
    }
}
