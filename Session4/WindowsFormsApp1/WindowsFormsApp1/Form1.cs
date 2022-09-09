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
    public partial class Form1 : Form
    {
        WSC2019_Session4Entities ent = new WSC2019_Session4Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InventoryReport().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
            
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(Application.StartupPath, "Helvetica-Normal.ttf"));
            
            foreach (Control c in this.Controls)
            {
                if (c.GetType() != typeof(DataGridView))
                {
                    c.Font = new Font(pfc.Families[0], 10f, FontStyle.Regular);
                }
            }
        }
    }
}
