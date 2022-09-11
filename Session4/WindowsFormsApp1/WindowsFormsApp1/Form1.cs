using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WSC2019_Session4Entities ent = new WSC2019_Session4Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InventoryReport().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
            
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(Application.StartupPath, "Helvetica-Normal.ttf"));
            
            foreach (Control c in this.Controls)
            {
                if (c.GetType() != typeof(DataGridView))
                {
                    c.Font = new Font(pfc.Families[0], 8.25f, FontStyle.Regular);
                }
            }

            this.loadData();
        }

        public void loadData()
        {
            dataGridViewPartItem.Rows.Clear();

            var orderItems = ent.OrderItems.OrderBy(x => x.Order.Date).ThenBy(x => x.Order.TransactionTypeID).ToList();

            for (int i = 0; i < orderItems.Count; i++)
            {
                dataGridViewPartItem.Rows.Add(
                    orderItems[i].ID, 
                    orderItems[i].Part.Name,
                    orderItems[i].Order.TransactionType,
                    orderItems[i].Order.Date,
                    (int) orderItems[i].Amount,
                    orderItems[i].Order.SupplierID != null ? orderItems[i].Order.Supplier.Name : orderItems[i].Order.Warehouse.Name, 
                    orderItems[i].Order.Warehouse1.Name, 
                    "Edit", "Remove");

                if (orderItems[i].Order.TransactionTypeID == 1)
                {
                    dataGridViewPartItem.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void purchaseOrderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchaseOrder().Show();
            this.Hide();
        }

        private void dataGridViewPartItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderItemId = (long) dataGridViewPartItem.Rows[e.RowIndex].Cells[0].Value;

            if (e.ColumnIndex == 8)
            {
                var whichOrderItem = ent.OrderItems.FirstOrDefault(x => x.ID == orderItemId);
                var destCount = ent.OrderItems.Where(x => x.Order.DestinationWarehouseID == whichOrderItem.Order.DestinationWarehouseID && x.PartID == whichOrderItem.PartID).Sum(x => x.Amount);
                var sourceCount = ent.OrderItems.Where(x => x.Order.SourceWarehouseID == whichOrderItem.Order.DestinationWarehouseID && x.PartID == whichOrderItem.PartID).Sum(x => x.Amount);

                if (destCount - sourceCount < whichOrderItem.Part.MinimumAmount)
                {
                    DialogResult dr = MessageBox.Show("You cant remove this record. Removing this record would make the inventory of a part in a warehouse negative!!", "Alert", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Are you sure to remove this order item?", "Alert", MessageBoxButtons.OKCancel);

                    if (dr == DialogResult.OK)
                    {
                        ent.OrderItems.Remove(whichOrderItem);
                        ent.SaveChanges();
                        loadData();
                    }
                }

            }
            else if (e.ColumnIndex == 7)
            {
                var order = ent.OrderItems.First(x => x.ID == orderItemId).Order;
                if (order.TransactionTypeID != 1)
                {
                    new PurchaseOrder(orderItemId).Show();
                }
                else
                {
                    new WarehouseManagementForm(orderItemId).Show();
                }
                this.Hide();
            }
        }

        private void warehouseMangementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WarehouseManagementForm().Show();
            this.Hide();
        }
    }
}
