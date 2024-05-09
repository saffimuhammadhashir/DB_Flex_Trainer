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
    public partial class OwnerReview : Form
    {
        private string userEmail;

        public OwnerReview(string email)
        {
            InitializeComponent();
            userEmail = email;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Admin_dashboard newform = new Admin_dashboard(userEmail);


            newform.Show();


            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
