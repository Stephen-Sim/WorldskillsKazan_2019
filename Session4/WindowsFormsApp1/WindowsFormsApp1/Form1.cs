using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

            this.loadDataGridView();
        }

        private void loadDataGridView()
        {
            ent = new WSC2019_Session4Entities();
            dataGridViewInventory.Rows.Clear();

            var content = ent.OrderItems.OrderByDescending(x => x.Order.Date).ThenBy(x => x.Order.TransactionTypeID).ToList();

            for (int i = 0; i < content.Count; i++)
            {
                var orderItem = content[i];
                dataGridViewInventory.Rows.Add(
                    orderItem.ID,
                    orderItem.Order.ID,
                    orderItem.Part.Name,
                    orderItem.Order.TransactionType.Name,
                    orderItem.Order.Date.ToShortDateString(),
                    (int) orderItem.Amount,
                    new Func<string>(() => { return orderItem.Order.SupplierID != null? orderItem.Order.Supplier.Name : orderItem.Order.Warehouse.Name; })(),
                    orderItem.Order.Warehouse1.Name,
                    "Edit",
                    "Remove"
                );

                if (orderItem.Order.TransactionTypeID == 1)
                {
                    //dataGridViewInventory.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    dataGridViewInventory.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void dataGridViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                var item = ent.OrderItems.ToList().FirstOrDefault(x => x.ID == (long) dataGridViewInventory.Rows[e.RowIndex].Cells[0].Value);
                var SourcePartAmount = ent.OrderItems.Where(x => x.Order.SourceWarehouseID == item.Order.SourceWarehouseID && x.PartID == item.PartID).Sum(x => x.Amount);
                var ReqeustPartAmount = ent.OrderItems.Where(x => x.Order.DestinationWarehouseID == item.Order.DestinationWarehouseID && x.PartID == item.PartID).Sum(x => x.Amount);

                if (ReqeustPartAmount - SourcePartAmount > 0)
                {
                    MessageBox.Show("Removing a record that would make the inventory of a part in a warehouse negative!!", "Ok");
                }
                else
                {
                    ent.OrderItems.Remove(item);
                    ent.SaveChanges();
                }
            }
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InventoryReportForm().ShowDialog();
        }
    }
}
