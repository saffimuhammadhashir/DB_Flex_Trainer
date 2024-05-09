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
    public partial class TrainerReview : Form
    {
        private string userEmail;

        public TrainerReview(string email)
        {

            
            InitializeComponent();
            userEmail = email;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Create an instance of Admin_dashboard
            Admin_dashboard newform = new Admin_dashboard(userEmail);


            newform.Show();


            this.Hide();
        }

        private void guna2Panel24_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
