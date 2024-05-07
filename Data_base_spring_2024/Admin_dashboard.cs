using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_base_spring_2024
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 2;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
            guna2TabControl2.SelectedIndex = 0;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {
            guna2TabControl2.SelectedIndex = 1;
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {
            guna2TabControl2.SelectedIndex = 3;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 0;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 1;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 2;
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            MemberReview newform = new MemberReview();

            // Show the new form
            newform.Show();

            // Hide the current form (Form1)
            this.Hide();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            TrainerReview newform = new TrainerReview();

            // Show the new form
            newform.Show();

            // Hide the current form (Form1)
            this.Hide();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            OwnerReview newform = new OwnerReview();

            // Show the new form
            newform.Show();

            // Hide the current form (Form1)
            this.Hide();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            GymReview newform = new GymReview();

            // Show the new form
            newform.Show();

            // Hide the current form (Form1)
            this.Hide();
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;

        }

        private void flowLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
