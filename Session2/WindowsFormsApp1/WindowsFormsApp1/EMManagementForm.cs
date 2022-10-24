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
    public partial class EMManagementForm : Form
    {
        WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();
        public EMManagementForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(0, 92, 185);

            loadData();
        }

        private void loadData()
        {
            dataGridViewAssets.Rows.Clear();

            var allAssetInfo = ent.Assets.ToList().Select(x => new
            {
                x.ID,
                x.AssetSN,
                x.AssetName,
                LastClosed = x.EmergencyMaintenances.Where(y => y.EMEndDate.HasValue).OrderByDescending(y => y.EMEndDate).Any() ? x.EmergencyMaintenances.Where(y => y.EMEndDate.HasValue).OrderByDescending(y => y.EMEndDate).First().EMEndDate.Value.ToString("dd/MM/yyyy") : "--",
                NumberOfEms = x.EmergencyMaintenances.Where(y => y.EMEndDate.HasValue).Count(),
                IsNotCompleted = x.EmergencyMaintenances.Where(y => y.EMEndDate == null).Any()
            }).ToList();

            for (int i = 0; i < allAssetInfo.Count; i++)
            {
                dataGridViewAssets.Rows.Add(allAssetInfo[i].ID, allAssetInfo[i].AssetSN, allAssetInfo[i].AssetName, allAssetInfo[i].LastClosed, allAssetInfo[i].NumberOfEms);

                if (allAssetInfo[i].IsNotCompleted)
                {
                    dataGridViewAssets.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }

        }

        private void dataGridViewAssets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAssets.Rows[dataGridViewAssets.SelectedCells[0].RowIndex].Selected = true;
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                new EMaintenanceRequestForm(int.Parse(dataGridViewAssets.SelectedRows[0].Cells[0].Value.ToString())).ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void EMManagementForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
        }
    }
}
