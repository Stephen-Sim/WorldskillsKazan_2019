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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class InventoryReport : Form
    {
        WSC2019_Session4Entities ent = new WSC2019_Session4Entities();
        public InventoryReport()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(0, 92, 185);
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedIndex != -1)
            {
                loadData();
            }

        }

        private void loadData()
        {
            dataGridViewPartList.Rows.Clear();

            var warehouseID = (long) comboBoxWarehouse.SelectedValue;

            dataGridViewPartList.Columns[2].Visible = true;
            dataGridViewPartList.Columns[3].Visible = true;

            var contents = ent.Parts.ToList().Select(x => new
            {
                ID = x.ID,
                PartName = x.Name,
                CurrentStock = new Func<int>(() =>
                {
                    var destCount = ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Any() ? ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount) : 0;
                    var sourceCount = ent.OrderItems.Where(y => y.Order.SourceWarehouseID == warehouseID && y.PartID == x.ID).Any() ? ent.OrderItems.Where(y => y.Order.SourceWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount) : 0;
                    return (int)(destCount - sourceCount);
                })(),
                ReceivedStock = new Func<int>(() =>
                {
                    if (ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Any())
                    {
                        int item = (int)(ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount));
                        return item;
                    }
                    else
                    {
                        return 0;
                    }
                })(),
                HasBatchNumber = x.BatchNumberHasRequired == true ? "View Batch Numbers" : ""
            });

            foreach (var item in contents)
            {
                dataGridViewPartList.Rows.Add(item.ID, item.PartName, item.CurrentStock, item.ReceivedStock, item.HasBatchNumber);
            }
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session4DataSet.Warehouses' table. You can move, or remove it, as needed.
            this.warehousesTableAdapter.Fill(this.wSC2019_Session4DataSet.Warehouses);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(Application.StartupPath, "Helvetica-Normal.ttf"));

            foreach (Control c in this.Controls)
            {
                if (c.GetType() != typeof(DataGridView))
                {
                    c.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
                }
            }
        }

        private void radioButtonCurrentStock_CheckedChanged(object sender, EventArgs e)
        {
            this.loadData();
            dataGridViewPartList.Columns[2].Visible = true;
            dataGridViewPartList.Columns[3].Visible = false;
        }

        private void radioButtonReceivedStock_CheckedChanged(object sender, EventArgs e)
        {
            this.loadData();
            dataGridViewPartList.Columns[2].Visible = false;
            dataGridViewPartList.Columns[3].Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewPartList.Columns[2].Visible = true;
            dataGridViewPartList.Columns[3].Visible = true;

            dataGridViewPartList.Rows.Clear();
            var warehouseID = (long) comboBoxWarehouse.SelectedValue;

            var contents = ent.Parts.ToList().Select(x => new
            {
                ID = x.ID,
                PartName = x.Name,
                CurrentStock = new Func<int>(() =>
                {
                    var destCount = ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Any() ? ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount) : 0;
                    var sourceCount = ent.OrderItems.Where(y => y.Order.SourceWarehouseID == warehouseID && y.PartID == x.ID).Any() ? ent.OrderItems.Where(y => y.Order.SourceWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount) : 0;
                    return (int)(destCount - sourceCount);
                })(),
                ReceivedStock = new Func<int>(() =>
                {
                    if (ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Any())
                    {
                        int item = (int)(ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == warehouseID && y.PartID == x.ID).Sum(y => y.Amount));
                        return item;
                    }
                    else
                    {
                        return 0;
                    }
                })(),
                HasBatchNumber = x.BatchNumberHasRequired == true ? "View Batch Numbers" : ""
            });

            foreach (var item in contents)
            {
                if (item.CurrentStock == 0)
                {
                    dataGridViewPartList.Rows.Add(item.ID, item.PartName, item.CurrentStock, item.ReceivedStock, item.HasBatchNumber);
                }
            }

        }

        private void dataGridViewPartList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && dataGridViewPartList.Columns[e.ColumnIndex].HeaderText != "")
            {
                var partId = (long)dataGridViewPartList.Rows[e.RowIndex].Cells[0].Value;

                var warehouseID = (long)comboBoxWarehouse.SelectedValue;

                var allSourceItems = ent.OrderItems.Where(x => x.Order.SourceWarehouseID == warehouseID).ToList();
                var allDestItems = ent.OrderItems.Where(x => x.Order.DestinationWarehouseID == warehouseID).ToList();

                var allPart = ent.OrderItems.Where(x => x.PartID == partId).GroupBy(x => x.BatchNumber).ToList();
                string str = "";

                for (int i = 0; i < allPart.Count; i++)
                {
                    if (!string.IsNullOrEmpty(allPart[i].Key))
                    {
                        decimal itemCount = allDestItems.Where(x => x.BatchNumber == allPart[i].Key).Sum(x => x.Amount) - allSourceItems.Where(x => x.BatchNumber == allPart[i].Key).Sum(x => x.Amount);

                        str += $"{i + 1}. {allPart[i].Key}\n\tCurrent Stock:{(int)itemCount}\n\tReceived Stock:{(int)allDestItems.Where(x => x.BatchNumber == allPart[i].Key).Sum(x => x.Amount)}\n";
                    }
                }

                MessageBox.Show(str, "Part Info");
            }
        }
    }
}
