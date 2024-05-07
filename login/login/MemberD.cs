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
    public partial class MemberD : Form
    {
        public MemberD()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 1;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 2; // Select the first tab
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 1;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 0; // Select the first tab
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 1;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 1; // Select the first tab
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 1;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 3; // Select the first tab
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 1;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 4; // Select the first tab
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 1;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 1; // Select the first tab
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel10_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            MemberReviewTrainer obj = new MemberReviewTrainer();
            obj.Show();
        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            guna2Button49.Text = "✓";
        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            ViewDiet obj = new ViewDiet();
            obj.Show();
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            ViewDiet obj = new ViewDiet();
            obj.Show();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            ViewWorkout obj = new ViewWorkout();
            obj.Show();
        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {
            CreateDiet obj = new CreateDiet();
            obj.Show();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            CreateWorkout obj = new CreateWorkout();
            obj.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            OwnerD obj = new OwnerD();
            obj.Show();
        }
    }
}
