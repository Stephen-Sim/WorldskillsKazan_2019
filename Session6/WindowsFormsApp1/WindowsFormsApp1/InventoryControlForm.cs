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
    public partial class InventoryControlForm : Form
    {
        public InventoryControlForm()
        {
            InitializeComponent();
        }

        private void InventoryControlForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
