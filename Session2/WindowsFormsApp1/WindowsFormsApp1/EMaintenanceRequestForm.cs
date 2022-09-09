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
    public partial class EMaintenanceRequestForm : Form
    {
        EmergencyMaintenance Em = new EmergencyMaintenance();
        WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();
        public EMaintenanceRequestForm(int emId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(0, 92, 185);

            Em = ent.EmergencyMaintenances.Where(x => x.ID == emId).FirstOrDefault();

            labelAssetName.Text = Em.Asset.AssetName;
            labelAssetSN.Text = Em.Asset.AssetSN;
            labelDepartment.Text = Em.Asset.DepartmentLocation.Department.Name;
        }

        private void EMRequest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session2DataSet.Priorities' table. You can move, or remove it, as needed.
            this.prioritiesTableAdapter.Fill(this.wSC2019_Session2DataSet.Priorities);

            this.BackColor = Color.FromArgb(0, 92, 185);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBoxPriority.SelectedValue == null)
            {
                MessageBox.Show("Please select priority value");
            }
            else if (String.IsNullOrWhiteSpace(richTextBoxDesc.Text))
            {
                MessageBox.Show("Please fill in Description of Emergency");
            }
            else
            { 
                EmergencyMaintenance emergencyMaintenance = new EmergencyMaintenance();
                emergencyMaintenance.AssetID = Em.AssetID;
                emergencyMaintenance.PriorityID = (long) comboBoxPriority.SelectedValue;
                emergencyMaintenance.DescriptionEmergency = richTextBoxDesc.Text;
                emergencyMaintenance.OtherConsiderations = (String.IsNullOrWhiteSpace(richTextBoxOtherCon.Text)) ? "none" : richTextBoxOtherCon.Text;
                ent.EmergencyMaintenances.Add(emergencyMaintenance);
                ent.SaveChanges();
                MessageBox.Show("Request created successfully");
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
