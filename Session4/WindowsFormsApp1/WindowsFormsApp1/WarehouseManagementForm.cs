using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class WarehouseManagementForm : Form
    {
        public List<AddPart> Parts { get; set; }

        public WarehouseManagementForm()
        {
            InitializeComponent();

            textBoxBatchNumber.Enabled = false;
            Parts = new List<AddPart>();

            textBoxAmount.Text = "0";
            textBoxBatchNumber.Text = "";
        }

        Order order { set; get; } = null;
        public WarehouseManagementForm(long orderItemId)
        {
            InitializeComponent();
            textBoxBatchNumber.Enabled = false;

            this.order = ent.OrderItems.FirstOrDefault(x => x.ID == orderItemId).Order;

            Parts = new List<AddPart>();

            foreach (var item in order.OrderItems)
            {
                AddPart addPart = new AddPart();
                addPart.PartId = item.PartID;
                addPart.PartName = item.Part.Name;
                addPart.BatchNumber = item.BatchNumber;
                addPart.Amount = item.Amount;

                Parts.Add(addPart);
            }

            loadDataGrid();

            comboBoxWarehouse.SelectedItem = order.Warehouse;
            comboBoxWarehouse1.SelectedItem = order.Warehouse1;
            dateTimePickerDate.Value = order.Date;

            textBoxAmount.Text = "0";
            textBoxBatchNumber.Text = "";
        }

        WSC2019_Session4Entities ent = new WSC2019_Session4Entities();

        private void comboBoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var partId = (long)comboBoxPart.SelectedValue;
            var part = ent.Parts.FirstOrDefault(x => x.ID == partId);

            textBoxBatchNumber.Enabled = (bool)part.BatchNumberHasRequired;
        }

        private void buttonAddtoList_Click(object sender, EventArgs e)
        {

            if (comboBoxPart.SelectedItem == null || string.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("All Fields are required!", "Alert");
                return;
            }

            var partId = (long)comboBoxPart.SelectedValue;
            var part = ent.Parts.FirstOrDefault(x => x.ID == partId);

            if (Parts.FirstOrDefault(x => x.PartId == partId) != null)
            {
                MessageBox.Show("Part Already Exist!", "Alert");
                return;
            }

            if (part.BatchNumberHasRequired == true && string.IsNullOrEmpty(textBoxBatchNumber.Text))
            {
                MessageBox.Show("All Fields are required!", "Alert");
                return;
            }

            try
            {
                var amount = int.Parse(textBoxAmount.Text);

                if (amount <= 0)
                {
                    MessageBox.Show("Invalid Amount!", "Alert");
                    return;
                }

                Parts.Add(new AddPart { PartId = part.ID, PartName = part.Name, BatchNumber = textBoxBatchNumber.Text, Amount = amount });
                loadDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Amount!", "Alert");
                return;
            }

            textBoxAmount.Text = "0";
            textBoxBatchNumber.Text = "";
        }

        private void loadDataGrid()
        {
            dataGridViewPart.Rows.Clear();

            foreach (var part in Parts)
            {
                dataGridViewPart.Rows.Add(part.PartId, part.PartName, part.BatchNumber, part.Amount, "Remove");
            }
        }

        private void dataGridViewPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var partId = dataGridViewPart.Rows[e.RowIndex].Cells[0].Value;

                DialogResult dr = MessageBox.Show("Are you sure to delete this result?", "Alert", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    Parts.Remove(Parts.FirstOrDefault(x => x.PartId == (long)partId));
                    loadDataGrid();
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouse1.SelectedItem == null || comboBoxWarehouse.SelectedItem == null || Parts.Count == 0)
            {
                var text = Parts.Count == 0 ? "All Fields are required! Part List cannot be empty" : "All Fields are required!";
                MessageBox.Show(text, "Alert");
                return;
            }

            try
            {
                Order order = this.order == null ? new Order() : this.order;
                order.TransactionTypeID = 1;
                order.SourceWarehouseID = (long)comboBoxWarehouse.SelectedValue;
                order.DestinationWarehouseID = (long)comboBoxWarehouse1.SelectedValue;
                order.Date = dateTimePickerDate.Value.Date;

                foreach (var item in Parts)
                {
                    OrderItem oi = (this.order == null || this.order.OrderItems.FirstOrDefault(x => x.PartID == item.PartId) == null) ? new OrderItem() : this.order.OrderItems.FirstOrDefault(x => x.PartID == item.PartId);
                    oi.OrderID = order.ID;
                    oi.PartID = item.PartId;
                    oi.BatchNumber = item.BatchNumber;
                    oi.Amount = item.Amount;

                    if (this.order == null || this.order.OrderItems.FirstOrDefault(x => x.PartID == item.PartId) == null)
                    {
                        ent.OrderItems.Add(oi);
                    }
                }

                if (this.order == null)
                {
                    ent.Orders.Add(order);
                }

                ent.SaveChanges();

                MessageBox.Show("Order successfully added or updated", "Alert");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Order failed to add!", "Alert");
            }

            this.Hide();
            Form1 form = (Form1)Application.OpenForms["Form1"];
            form.loadData();
            form.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = (Form1)Application.OpenForms["Form1"];
            form.loadData();
            form.Show();
        }

        private void WarehouseManagementForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session4DataSet.Parts' table. You can move, or remove it, as needed.
            this.partsTableAdapter.Fill(this.wSC2019_Session4DataSet.Parts);
            // TODO: This line of code loads data into the 'wSC2019_Session4DataSet.Warehouses' table. You can move, or remove it, as needed.
            this.warehousesTableAdapter.Fill(this.wSC2019_Session4DataSet.Warehouses);
            this.BackColor = Color.FromArgb(0, 92, 185);
        }
    }
}
