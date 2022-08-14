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
    public partial class EMRequest : Form
    {
        EmergencyMaintenance Em = new EmergencyMaintenance();
        WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();
        public EMRequest(int emId)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(0, 92, 185);

            Em = ent.EmergencyMaintenances.Where(x => x.ID == emId).FirstOrDefault();

            labelAssetName.Text = Em.Asset.AssetName;
            labelAssetSN.Text = Em.Asset.AssetSN;
            labelDepartment.Text = Em.Asset.DepartmentLocation.Department.Name;
            comboBoxPriority.SelectedValue = Em.PriorityID;
            comboBoxPriority.DisplayMember = ent.Priorities.Where(x => x.ID == Em.PriorityID).First().Name;
            richTextBoxDesc.Text = Em.DescriptionEmergency;
            richTextBoxOtherCon.Text = Em.OtherConsiderations;
        }

        private void EMRequest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session2DataSet.Priorities' table. You can move, or remove it, as needed.
            this.prioritiesTableAdapter.Fill(this.wSC2019_Session2DataSet.Priorities);

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
                Em.PriorityID = (long) comboBoxPriority.SelectedValue;
                Em.DescriptionEmergency = richTextBoxDesc.Text;
                Em.OtherConsiderations = (String.IsNullOrWhiteSpace(richTextBoxOtherCon.Text)) ? "none" : richTextBoxOtherCon.Text;
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
