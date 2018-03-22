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
    public partial class StockStateSummaryForm : Form
    {
        StockStateSummary control;
        StockMarket market;

        public StockStateSummaryForm()
        {
            InitializeComponent();
        }

        public void setupControl()
        {
            control = new StockStateSummary();

            StockMarketMainForm mdiParent = (StockMarketMainForm)this.MdiParent;
            market = mdiParent.RealTimeData;
            control.Subscribe(market);
            dataGridView.DataSource = control.DataTable;
        }

        ~StockStateSummaryForm()
        {
            market.UnSubscribe(control);
        }

        /**
         * Pulling changes
         */
        public void UpdateData()
        {
            dataGridView.DataSource = control.DataTable;
        }

        private void StockStateSummaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void StockStateSummaryForm_Load(object sender, EventArgs e)
        {
           
        }

        private void StockStateSummaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            ToolStripMenuItem ti = (ToolStripMenuItem)ms.Items["watchToolStripMenuItem"];
            ti.DropDownItems["stockStateSummaryToolStripMenuItem"].Enabled = true;
        }
    }
}
