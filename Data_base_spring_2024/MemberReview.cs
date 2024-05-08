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
    public partial class MemberReview : Form
    {
        public MemberReview()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            //Admin_dashboard newform = new Admin_dashboard();

            // Show the new form
            //newform.Show();

            // Hide the current form (Form1)
            this.Hide();
        }
    }
}
