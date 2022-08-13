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
    public partial class EMRequestForm : Form
    {
        public WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();
        public EMRequestForm()
        {
            InitializeComponent();
        }

        List<TempChangedPart> changedParts = new List<TempChangedPart>();
        EmergencyMaintenance Em = new EmergencyMaintenance();

        public EMRequestForm(int emId)
        {
            InitializeComponent();

            Em = ent.EmergencyMaintenances.Where(x => x.ID == emId).FirstOrDefault();

            if (Em != null)
            {
                labelAssetName.Text = Em.Asset.AssetName;
                labelAssetSN.Text = Em.Asset.AssetSN;
                labelDepartment.Text = Em.Asset.DepartmentLocation.Department.Name;

                dateTimePickerCompletedDate.Visible = false;
                label10.Visible = false;

                if (Em.EMEndDate != null)
                {
                    dateTimePickerCompletedDate.Visible = true;
                    label10.Visible = true;

                    dateTimePickerStartDate.Enabled = false;
                    dateTimePickerCompletedDate.Enabled = false;
                    richTextBoxTechnicianNote.Enabled = false;
                    comboBoxPart.Enabled = false;
                    numericUpDownAmount.Enabled = false;
                    buttonSubmit.Enabled = false;
                    buttonAddtoList.Enabled = false;
                    dataGridViewPart.Columns[3].Visible = false;
                }

                if (Em.EMStartDate != null)
                {
                    dateTimePickerStartDate.Value = DateTime.Parse(Em.EMStartDate.ToString());
                }

                if (Em.EMEndDate != null)
                {
                    dateTimePickerCompletedDate.Value = DateTime.Parse(Em.EMEndDate.ToString());
                }

                if (Em.EMTechnicianNote != null)
                {
                    richTextBoxTechnicianNote.Text = Em.EMTechnicianNote;
                }

                var allPartChanged = Em.ChangedParts.ToList();

                foreach (var partChanged in allPartChanged)
                {
                    TempChangedPart tempChangedPart = new TempChangedPart
                    {
                        partID = partChanged.ID,
                        partName = partChanged.Part.Name,
                        amount = partChanged.Amount,
                    };

                    changedParts.Add(tempChangedPart);
                }

                loadDataGrid();
            }
        }

        private void loadDataGrid()
        {
            dataGridViewPart.Rows.Clear();

            foreach (var changedPart in changedParts)
            {
                dataGridViewPart.Rows.Add(changedPart.partID, changedPart.partName, changedPart.amount.ToString(), "Remove");
            }
        }

        private void EMRequestForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wSC2019_Session2DataSet.Parts' table. You can move, or remove it, as needed.
            this.partsTableAdapter.Fill(this.wSC2019_Session2DataSet.Parts);

        }

        private void richTextBoxTechnicianNote_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBoxTechnicianNote.Text))
            {
                dateTimePickerCompletedDate.Visible = true;
                label10.Visible = true;
            }
            else
            {
                dateTimePickerCompletedDate.Visible = false;
                label10.Visible = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridViewPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Are Sure to Delete the Part?", "Alert", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var id = int.Parse(dataGridViewPart.Rows[e.RowIndex].Cells[0].Value.ToString());
                    changedParts.Remove(changedParts.Where(x => x.partID == id).FirstOrDefault());
                }

                loadDataGrid();
            }
        }

        private void buttonAddtoList_Click(object sender, EventArgs e)
        {
            double amount;

            if (!Double.TryParse(numericUpDownAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please insert the right number of amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var selectedPart = ent.Parts.FirstOrDefault(x => x.ID == (long)comboBoxPart.SelectedValue);
            var lastService = ent.EmergencyMaintenances.OrderByDescending(x => x.EMReportDate).FirstOrDefault(x => x.EMEndDate != null);

            if (changedParts.Where(x => x.partID == (long)comboBoxPart.SelectedValue).FirstOrDefault() != null)
            {
                MessageBox.Show("Item is already Selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (lastService != null)
            {
                var part = ent.ChangedParts.FirstOrDefault(x => x.EmergencyMaintenanceID == lastService.ID && x.PartID == selectedPart.ID);

                if (part != null && part.Part.EffectiveLife != null)
                {
                    if (DateTime.Now < DateTime.Parse(lastService.EMEndDate.ToString()).AddDays(Convert.ToInt32(part.Part.EffectiveLife)))
                    {
                        MessageBox.Show("The part selected still have effective life", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }

            TempChangedPart tempChangedPart = new TempChangedPart
            {
                partID = (long)comboBoxPart.SelectedValue,
                partName = ent.Parts.Where(x => x.ID == (long)comboBoxPart.SelectedValue).First().Name,
                amount = numericUpDownAmount.Value,
            };

            changedParts.Add(tempChangedPart);
            loadDataGrid();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (dateTimePickerStartDate.Value.Date < Em.EMReportDate)
            {
                MessageBox.Show("Start date cannot be earlier than report date", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (dateTimePickerStartDate.Value.Date < dateTimePickerCompletedDate.Value.Date)
            {
                MessageBox.Show("End date cannot be earlier than start date", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                Em.EMStartDate = dateTimePickerStartDate.Value.Date;
                if (dateTimePickerCompletedDate.Visible == true)
                {
                    Em.EMTechnicianNote = richTextBoxTechnicianNote.Text;
                    Em.EMEndDate = dateTimePickerCompletedDate.Value.Date;
                }

                foreach (var changedPart in changedParts)
                {
                    ChangedPart cp = new ChangedPart
                    {
                        EmergencyMaintenanceID = Em.ID,
                        PartID = changedPart.partID,
                        Amount = changedPart.amount
                    };

                    ent.ChangedParts.Add(cp);
                    ent.SaveChanges();
                }

                MessageBox.Show("Request has been saved.");
                Hide();
            }
        }
    }
}
