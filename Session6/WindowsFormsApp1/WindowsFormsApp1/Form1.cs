using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WSC2019_Session6Entities ent = new WSC2019_Session6Entities();
        public Form1()
        {
            InitializeComponent();

            loadData();
            loadChartRatio();
        }

        private void loadData()
        {
            var columns = ent.EmergencyMaintenances.Where(x => x.EMEndDate.HasValue).Select(x => new
            {
                x.EMEndDate.Value.Year,
                x.EMStartDate.Value.Month
            }).Distinct().ToList();

            foreach (var item in columns)
            {
                dataGridViewDepartment.Columns.Add($"{item.Year}-{item.Month}", $"{item.Year}-{item.Month}");
                dataGridViewNote.Columns.Add($"{item.Year}-{item.Month}", $"{item.Year}-{item.Month}");
                dataGridViewAssetName.Columns.Add($"{item.Year}-{item.Month}", $"{item.Year}-{item.Month}");
            }

            // department
            var alldepartments = ent.Departments.ToList();

            for (int i = 0; i < alldepartments.Count; i++)
            {
                var selectedLocation = alldepartments[i];

                dataGridViewDepartment.Rows.Add(selectedLocation.Name);

                for (int j = 0; j < columns.Count; j++)
                {
                    var ordersItems = ent.OrderItems.ToList().Where(x =>
                        x.Order.EmergencyMaintenance != null &&
                        x.Order.EmergencyMaintenance.EMEndDate.HasValue &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Year == columns[j].Year &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Month == columns[j].Month &&
                        x.Order.EmergencyMaintenance.Asset.DepartmentLocation.DepartmentID == selectedLocation.ID).ToList();

                    dataGridViewDepartment.Rows[i].Cells[j + 1].Value = double.Parse(ordersItems.Sum(x => x.UnitPrice * x.Amount).ToString()).ToString("0.00");
                }

            }

            for (int i = 1; i < dataGridViewDepartment.ColumnCount; i++)
            {
                decimal [] columnValue = new decimal[alldepartments.Count];

                for (int j = 0; j < alldepartments.Count; j++)
                {
                    decimal value = decimal.Parse(dataGridViewDepartment.Rows[j].Cells[i].Value.ToString());
                    columnValue[j] = value;
                }

                var highest = columnValue.Where(x => x != 0).Max();
                var lowest = columnValue.Where(x => x != 0).Min();

                for (int j = 0; j < alldepartments.Count; j++)
                {
                    decimal value = decimal.Parse(dataGridViewDepartment.Rows[j].Cells[i].Value.ToString());

                    if (highest == lowest && value == highest)
                    {
                        dataGridViewDepartment.Rows[j].Cells[i].Style.ForeColor = Color.Red;
                    }
                    else if (value == highest)
                    {
                        dataGridViewDepartment.Rows[j].Cells[i].Style.ForeColor = Color.Red;
                    }
                    else if(value == lowest)
                    {
                        dataGridViewDepartment.Rows[j].Cells[i].Style.ForeColor = Color.Green;
                    }
                }

            }

            // most-used parts
            dataGridViewNote.Rows.Add("Highest Cost");
            dataGridViewNote.Rows.Add("Most Number");

            for (int i = 0; i < dataGridViewNote.ColumnCount - 1; i++)
            {
                var highcostPart = ent.OrderItems.ToList()
                    .Where(x =>
                        x.Order.EmergencyMaintenance != null &&
                        x.Order.EmergencyMaintenance.EMEndDate.HasValue &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Year == columns[i].Year &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Month == columns[i].Month &&
                        x.Order.TransactionTypeID == 3)
                    .Select(x => new
                    {
                        x.Part.Name,
                        Cost = x.UnitPrice * x.Amount
                    }).OrderByDescending(x => x.Cost).ToList();

                var partNames = new string[highcostPart.Count];
                var highescost = highcostPart.First().Cost;

                int count = 0;

                foreach (var item in highcostPart)
                {
                    if (item.Cost == highescost)
                    {
                        partNames[count] = item.Name;
                        count++;
                    }
                }

                partNames = partNames.Where(x => x != null).Distinct().ToArray();


                var mostUseds = ent.OrderItems.ToList()
                    .Where(x =>
                        x.Order.EmergencyMaintenance != null &&
                        x.Order.EmergencyMaintenance.EMEndDate.HasValue &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Year == columns[i].Year &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Month == columns[i].Month &&
                        x.Order.TransactionTypeID == 3)
                    .GroupBy(x => new
                    {
                        x.Part
                    }).Select(x => new
                    {
                        x.Key.Part.Name,
                        Amount = x.Sum(z => z.Amount)
                    }).OrderByDescending(x => x.Amount).ToList();

                count = 0;
                var departments = new string[mostUseds.Count];
                var mostUsedcount = mostUseds.First().Amount;

                foreach (var item in mostUseds)
                {
                    if (item.Amount == mostUsedcount)
                    {
                        departments[count] = item.Name;
                        count++;
                    }
                }

                departments = departments.Where(x => x != null).Distinct().ToArray();

                dataGridViewNote.Rows[0].Cells[i + 1].Value = string.Join(", ", partNames);
                dataGridViewNote.Rows[1].Cells[i + 1].Value = string.Join(", ", departments);
            }

            // asset
            dataGridViewAssetName.Rows.Add("Asset");
            dataGridViewAssetName.Rows.Add("Department");

            for (int i = 0; i < dataGridViewNote.ColumnCount - 1; i++)
            {
                var highcostAsset = ent.OrderItems.ToList()
                    .Where(x =>
                        x.Order.EmergencyMaintenance != null &&
                        x.Order.EmergencyMaintenance.EMEndDate.HasValue &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Year == columns[i].Year &&
                        x.Order.EmergencyMaintenance.EMEndDate.Value.Month == columns[i].Month &&
                        x.Order.TransactionTypeID == 3)
                    .Select(x => new
                    {
                        x.Order.EmergencyMaintenance.Asset.AssetName,
                        Department = x.Order.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name,
                        Cost = x.UnitPrice * x.Amount
                    }).OrderByDescending(x => x.Cost).ToList();

                highcostAsset = highcostAsset.Where(x => x.Cost == highcostAsset.First().Cost).ToList();

                var highestcost = highcostAsset.First().Cost;

                var name = new string[highcostAsset.Count];
                var department = new string[highcostAsset.Count];

                int count = 0;

                foreach (var item in highcostAsset)
                {
                    if (item.Cost == highestcost)
                    {
                        name[count] = item.AssetName;
                        department[count] = item.Department;
                        count++;
                    }
                }

                name = name.Distinct().ToArray();
                department = department.Distinct().ToArray();

                dataGridViewAssetName.Rows[0].Cells[i + 1].Value = string.Join(", ", name);
                dataGridViewAssetName.Rows[1].Cells[i + 1].Value = string.Join(", ", department);
            }
        }

        private void loadChartRatio()
        {
            var allDepartment = ent.Departments.ToList();

            foreach (var item in allDepartment)
            {
                var usedItem = ent.OrderItems.ToList().Where(x => x.Order.EmergencyMaintenance != null &&
                x.Order.Date != null && x.Order.EmergencyMaintenance.Asset.DepartmentLocation.DepartmentID == item.ID).ToList();

                chartRatio.Series["Department"].Points.AddXY(item.Name, usedItem.Sum(x => x.Amount * x.UnitPrice));
            }

            chartSpending.Visible = false;
        }

        private void chartRatio_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chartRatio.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            string department = "";

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = (DataPoint)hit.Object;
                var selectedPie = chartRatio.Series["Department"];
                department = selectedPie.Points[hit.PointIndex].AxisLabel;
            }

            chartSpending.Visible = true;
            chartSpending.Series.Clear();
            chartSpending.Series.Add("Month");
            chartSpending.Series["Month"].ChartType = SeriesChartType.Column;

            var allOrderItems = ent.OrderItems.ToList()
                .Where(x =>
                    x.Order.EmergencyMaintenance != null &&
                    x.Order.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name == department &&
                    x.Order.Date != null)
                .GroupBy(x => new
                {
                    x.Order.Date.Month,
                })
                .Select(x => new
                {
                    x.Key.Month,
                    Amount = x.Sum(z => z.Amount * z.UnitPrice)
                }).ToList();

            for (int i = 0; i < 12; i++)
            {
                if (allOrderItems.Where(x => x.Month == i + 1).FirstOrDefault() == null)
                {
                    chartSpending.Series["Month"].Points.AddXY(i + 1, 0);
                }
                else
                {
                    chartSpending.Series["Month"].Points.AddXY(i + 1, allOrderItems.Where(x => x.Month == i + 1).FirstOrDefault().Amount);
                }
            }

            chartSpending.ChartAreas[0].RecalculateAxesScale();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInventoryControl_Click(object sender, EventArgs e)
        {
            this.Hide();
            new InventoryControlForm().Show();
        }
    }
}
