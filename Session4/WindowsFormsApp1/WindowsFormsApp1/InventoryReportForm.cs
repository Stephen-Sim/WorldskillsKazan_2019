using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InventoryReportForm : Form
    {
        WSC2019_Session4Entities ent = new WSC2019_Session4Entities();
        public InventoryReportForm()
        {
            InitializeComponent();
        }

        private void InventoryReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session4DataSet.Warehouses' table. You can move, or remove it, as needed.
            this.warehousesTableAdapter.Fill(this.wSC2019_Session4DataSet.Warehouses);
        }

        private void loadDataGrid()
        {
            var content = ent.OrderItems.Where(x => x.Order.DestinationWarehouseID == (long)comboBoxWarehouse.SelectedValue)
                .Select(x => new
                {
                    x.Part.Name,
                    Current = x.Part.OrderItems.Sum(y => y.Amount),
                    Retrived = x.Part.OrderItems.Sum(y => y.Amount),

                });
        }
    }
}
