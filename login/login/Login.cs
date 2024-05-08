using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Data_base_spring_2024.Form1 obj = new Data_base_spring_2024.Form1();
            obj.Show();
            this.Hide();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=ABDULLAHS-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True";
            string email = guna2TextBox1.Text;
            string pass = guna2TextBox2.Text;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from USERS where email = '" + email + "' AND password = '" + pass+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                string queryM = "select * from member where email = '" + email+"'";
                SqlCommand commandM = new SqlCommand(queryM, connection);
                SqlDataReader readerM = commandM.ExecuteReader();
                if (readerM.Read())
                {
                    MemberD objM = new MemberD(email);
                    objM.Show();
                    this.Hide();
                }
            }
            else
            {
                label9.ForeColor = System.Drawing.Color.Maroon;
            }
            connection.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}