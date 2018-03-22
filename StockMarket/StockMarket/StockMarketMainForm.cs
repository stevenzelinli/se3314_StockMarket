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
    public partial class StockMarketMainForm : Form
    {
        // determines whether the market is open or not (intialized?)
        private Boolean marketIsOpen;
        // UP TO DATE DATA
        public StockMarket realTimeData;

        public StockMarketMainForm()
        {
            InitializeComponent();
            stopTradingToolStripMenuItem.Enabled = false;
            watchToolStripMenuItem.Visible = false;
            ordersToolStripMenuItem.Visible = false;
            //CREATE NEW INSTANCE OF DATA
            realTimeData = new RealTimeData();
            //LOAD TABS FOR COMPANIES
            foreach (var company in realTimeData.CurrentStocks.CompanyList)
            {
                ToolStripMenuItem orderItem = new ToolStripMenuItem(company.CompanyName);
                orderItem.Click += new EventHandler(WatchMarketByOrderClickHandler);
                marketByOrderToolStripMenuItem.DropDownItems.Add(orderItem);

                ToolStripMenuItem priceItem = new ToolStripMenuItem(company.CompanyName);
                priceItem.Click += new EventHandler(WatchMarketByPriceClickHandler);
                marketByPriceToolStripMenuItem.DropDownItems.Add(priceItem);

            }
        }

        public StockMarket RealTimeData
        {
            get { return realTimeData; }
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms vertically.
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cascade all MDI child windows.
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms horizontally.
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            // Set the parent form of the child window.
            aboutForm.MdiParent = this;
            aboutForm.Text = "About Form";
            // Display the new form.
            aboutForm.Show();
        }

        private void beginTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marketIsOpen = true;
            beginTradingToolStripMenuItem.Enabled = false;
            stopTradingToolStripMenuItem.Enabled = true;
            marketToolStripMenuItem.Text = "Market <<Open>>";
            watchToolStripMenuItem.Visible = true;
            ordersToolStripMenuItem.Visible = true;
        }

        private void stopTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marketIsOpen = false;
            stopTradingToolStripMenuItem.Enabled = false;
            beginTradingToolStripMenuItem.Enabled = true;
            marketToolStripMenuItem.Text = "Market <<Closed>>";
            watchToolStripMenuItem.Visible = false;
            ordersToolStripMenuItem.Visible = false;
        }

        private void microsoftToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockStateSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockStateSummaryForm summaryForm = new StockStateSummaryForm();
            summaryForm.MdiParent = this;
            summaryForm.setupControl();
            summaryForm.Show();
            stockStateSummaryToolStripMenuItem.Enabled = false;
        }

        private void WatchMarketByOrderClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            MarketByOrderForm form = new MarketByOrderForm(clickedItem.Text);
            form.MdiParent = this;
            form.linkToData();
            form.Show();
        }

        private void WatchMarketByPriceClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            MarketByPriceForm form = new MarketByPriceForm(clickedItem.Text);
            form.MdiParent = this;
            form.linkToData();
            form.Show();
        }

        private void StockMarketMainForm_Load(object sender, EventArgs e)
        {

        }

        private void watchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BidForm bidForm = new BidForm();
            bidForm.MdiParent = this;
            bidForm.Show();
        }

        private void askToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellForm sellForm = new SellForm();
            sellForm.MdiParent = this;
            sellForm.Show();
        }
    }
}
