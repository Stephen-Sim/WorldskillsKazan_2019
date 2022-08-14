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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(0, 92, 185);

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Asset SN", "Asset SN");
            dataGridView1.Columns.Add("Asset Name", "Asset Name");
            dataGridView1.Columns.Add("Request Date", "Request Date");
            dataGridView1.Columns.Add("Employee Full Name", "Employee Full Name");
            dataGridView1.Columns.Add("Department", "Department");

            dataGridView1.Columns[0].Visible = false;

            loaddata();
        }

        public WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();

        private void loaddata()
        {
            dataGridView1.Rows.Clear();

            var allEm = ent.EmergencyMaintenances.OrderByDescending(x => x.PriorityID).ThenByDescending(x => x.EMReportDate).ToList();

            foreach (var Em in allEm)
            {
                dataGridView1.Rows.Add(Em.ID, Em.Asset.AssetSN, Em.Asset.AssetName, Em.EMReportDate.ToShortDateString(), Em.Asset.Employee.FirstName + " " + Em.Asset.Employee.LastName, Em.Asset.DepartmentLocation.Department.Name);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new EMRequestForm(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())).ShowDialog();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
