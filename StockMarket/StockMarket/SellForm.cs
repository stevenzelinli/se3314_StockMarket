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
    public partial class SellForm : Form
    {
        StockMarket market;

        public SellForm()
        {
            InitializeComponent();
        }

        private void SellForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            ToolStripMenuItem ti = (ToolStripMenuItem)ms.Items["ordersToolStripMenuItem"];
            ti.DropDownItems["askToolStripMenuItem"].Enabled = true;
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            StockMarketMainForm stockMarketForm = (StockMarketMainForm)this.MdiParent;
            market = stockMarketForm.RealTimeData;
            foreach (var company in market.CurrentStocks.CompanyList)
            {
                comboBox1.Items.Add(company.CompanySymbol);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            StockMarketMainForm stockMarketForm = (StockMarketMainForm)this.MdiParent;
            market = stockMarketForm.RealTimeData;
            string symbol = comboBox1.Text;
            int amount = Int32.Parse(amountTextBox.Text);
            double price = Double.Parse(priceTextBox.Text);

            market.CurrentStocks.sellOrder(symbol, amount, price);

            this.Close();
        }
    }
}
