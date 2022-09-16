using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class InventoryControlForm : Form
    {
        public InventoryControlForm()
        {
            InitializeComponent();
        }

        WSC2019_Session6Entities ent = new WSC2019_Session6Entities();

        private void InventoryControlForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session6DataSet.Warehouses' table. You can move, or remove it, as needed.
            this.warehousesTableAdapter.Fill(this.wSC2019_Session6DataSet.Warehouses);
            groupBoxSearchPart.Enabled = false;

            this.BackColor = Color.FromArgb(0, 92, 185);

            var asset = ent.EmergencyMaintenances.ToList().Where(x => x.EMStartDate.HasValue && x.EMEndDate == null).
                Select(x => new
                {
                    x.ID,
                    Name =  $"{x.Asset.AssetName} (EM workID : {x.ID})"
                }).ToList();

            var allocationMethod = new List<Temp>
            {
                new Temp{ID = 1, Name = "FIFO" },
                new Temp{ID = 2, Name = "LIFO" },
                new Temp{ID = 2, Name = "Minumum First" },
            };

            comboBoxAllocationMethod.DataSource = allocationMethod;
            comboBoxAllocationMethod.DisplayMember = "Name";
            comboBoxAllocationMethod.ValueMember = "ID";

            comboBoxAllocationMethod.SelectedValue = 1;

            comboBoxAsset.DataSource = asset;
            comboBoxAsset.DisplayMember = "Name";
            comboBoxAsset.ValueMember = "ID";

            comboBoxAsset.SelectedItem = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void comboBoxAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAsset.SelectedItem != null)
            {
                groupBoxSearchPart.Enabled = true;
                return;
            }

            groupBoxSearchPart.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxAsset.SelectedItem != null)
            {
                groupBoxSearchPart.Enabled = true;
                return;
            }

            groupBoxSearchPart.Enabled = false;
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedItem != null)
            {
                var date = dateTimePicker1.Value.Date;
                var selectedWarehouse = (long) comboBoxWarehouse.SelectedValue;

                var contents = ent.Parts.ToList().Select(x => new
                {
                    ID = x.ID,
                    Name = x.Name,
                    CurrentStock = new Func<int>(() =>
                    {
                        var destCount = ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == selectedWarehouse && y.PartID == x.ID && y.Order.Date < date).Any() ? ent.OrderItems.Where(y => y.Order.DestinationWarehouseID == selectedWarehouse && y.PartID == x.ID && y.Order.Date < date).Sum(y => y.Amount) : 0;
                        var sourceCount = ent.OrderItems.Where(y => y.Order.SourceWarehouseID == selectedWarehouse && y.PartID == x.ID && y.Order.Date < date).Any() ? ent.OrderItems.Where(y => y.Order.SourceWarehouseID == selectedWarehouse && y.PartID == x.ID && y.Order.Date < date).Sum(y => y.Amount) : 0;
                        return (int)(destCount - sourceCount);
                    })(),
                }).Where(x => x.CurrentStock > 0).ToList();

                comboBoxPart.DataSource = contents;
                comboBoxPart.DisplayMember = "Name";
                comboBoxPart.ValueMember = "ID";
            }
        }

        private void buttonAllocate_Click(object sender, EventArgs e)
        {
            var selectedPart = comboBoxPart.SelectedValue;
            var selectedMethod = comboBoxAllocationMethod.SelectedValue;
            var date = dateTimePicker1.Value.Date;
            int amount = 0;
            
            try
            {
                amount = int.Parse(textBoxAmount.Text);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Invalid value");
                return;
            }

            var selectedWarehouse = (long)comboBoxWarehouse.SelectedValue;
            var searchResult = ent.OrderItems.Where(x => x.PartID == (long)selectedPart && x.Order.Date < date).ToList();

            if ((int)selectedMethod == 1)
            {
                // FIFO, order by date
                searchResult = searchResult.OrderBy(x => x.Order.Date).ToList();

            }
            else if ((int)selectedMethod == 2)
            {
                // LIFO, order desc by date
                searchResult = searchResult.OrderByDescending(x => x.Order.Date).ToList();
            }
            else
            {
                searchResult = searchResult.OrderBy(x => x.UnitPrice).ToList();
            }

            dataGridViewAllocatedPart.Rows.Clear();
            assignEMs = new List<AssignEM>();

            for (int i = 0; i < searchResult.Count; i++)
            {
                if (amount < 0)
                {
                    break;
                }
                var item = searchResult[i];
                dataGridViewAllocatedPart.Rows.Add(item.ID, item.Part.Name, item.BatchNumber, (int)item.UnitPrice, (int)item.Amount);
                assignEMs.Add(new AssignEM
                {
                    ID = item.ID,
                    Name = item.Part.Name,
                    BatchNumber = item.BatchNumber,
                    UnitPrice = (int)item.UnitPrice,
                    Amount = (int)item.Amount,
                    OrderId = item.OrderID
                });
                amount -= (int) item.Amount;
            }
        }

        List <AssignEM> assignEMs { set; get; }

        private void buttonAssingToEM_Click(object sender, EventArgs e)
        {
            dataGridViewAssignedPart.Rows.Clear();

            for (int i = 0; i < assignEMs.Count; i++)
            {
                var item = assignEMs[i];
                dataGridViewAssignedPart.Rows.Add(item.ID, item.Name, item.BatchNumber, item.UnitPrice, item.Amount, "Remove");
            }
        }

        private void dataGridViewAssignedPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridViewAssignedPart.Rows[e.RowIndex].Cells[0].Value;
            if (e.ColumnIndex == 5)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete this record?", "Alert", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    assignEMs.Remove(assignEMs.FirstOrDefault(x => x.ID == (long)id));
                    buttonAssingToEM_Click(null, null);
                }
            }

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            foreach (var item in assignEMs)
            {
                var orderItem = new OrderItem();
                orderItem.BatchNumber = item.BatchNumber;
                orderItem.UnitPrice = item.UnitPrice;
                orderItem.Amount = item.Amount;
                orderItem.PartID = (long)comboBoxPart.SelectedValue;
                orderItem.OrderID = item.OrderId;

                ent.OrderItems.Add(orderItem);
            }

            ent.SaveChanges();

            MessageBox.Show("Order item succesfully saved", "Alert");

            this.Close();
            new Form1().Show();
        }
    }
}
