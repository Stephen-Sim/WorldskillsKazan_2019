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
            ent = new WSC2019_Session2Entities1();

            dataGridViewAssets.Rows.Clear();

            var allAsset = ent.Assets.ToList();

            for (int i = 0; i < allAsset.Count(); i++)
            {
                string lastClosed = "--";
                var assetEm = allAsset[i].EmergencyMaintenances.OrderByDescending(x => x.EMReportDate).ToList();

                if (assetEm.Any() && assetEm.OrderByDescending(x => x.EMEndDate).FirstOrDefault().EMEndDate != null)
                    lastClosed = DateTime.Parse(assetEm.OrderByDescending(x => x.EMEndDate).FirstOrDefault().EMEndDate.ToString()).ToString("dd/MM/yyyy");

                dataGridViewAssets.Rows.Add(allAsset[i].ID.ToString(), allAsset[i].AssetSN, allAsset[i].AssetName, lastClosed, assetEm.Where(x => x.EMEndDate != null).Count());

                for (int j = 0; j < assetEm.Count; j++)
                {
                    if (assetEm[j].EMStartDate != null && assetEm[j].EMEndDate == null)
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
