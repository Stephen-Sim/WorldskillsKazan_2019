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
        public Form1()
        {
            InitializeComponent();
        }

        public WSC2019_Session2Entities1 ent = new WSC2019_Session2Entities1();

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;

                var isFound = ent.Employees.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

                if (isFound != null)
                {
                    if (isFound.isAdmin == true)
                    {
                        new ManagerForm().Show();
                        this.Hide();
                    }
                    else
                    {
                        new EMManagementForm().Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("User detail is not found!!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("All the inputs are required!!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 92, 185);
        }
    }
}
