using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class OwnerD : Form
    {
        public OwnerD()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button2.BorderThickness = 1;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 0; // Select the first tab
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 1;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 1; // Select the first tab
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 1;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 2; // Select the first tab
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 1;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 3; // Select the first tab
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel19_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
