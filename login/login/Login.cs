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
using Data_base_spring_2024;



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
            Data_base_spring_2024.Form1 obj = new Form1();
            obj.Show();
            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        string email = guna2TextBox1.Text;
            string pass = guna2TextBox2.Text;
            string username = " ";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from USERS where email = '" + email + "' AND password = '" + pass+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                int active =Convert.ToInt32( reader["is_active"]);
                username =  reader["username"].ToString();
                reader.Close();
                if (active == 1)
                {

                    string queryM = "select * from member where email = '" + email + "'";
                    SqlCommand commandM = new SqlCommand(queryM, connection);

                    SqlDataReader readerM = commandM.ExecuteReader();

                    if (readerM.Read())
                    {
                        MemberD objM = new MemberD(email, connectionString);
                        objM.Show();

                    }
                    readerM.Close();

                    string queryA = "select * from Admin where email = '" + email + "'";
                    SqlCommand commandA = new SqlCommand(queryA, connection);
                    SqlDataReader readerA = commandA.ExecuteReader();
                    if (readerA.Read())
                    {
                        Admin_dashboard obj = new Admin_dashboard(email);
                        obj.Show();

                    }
                    readerA.Close();

                    string queryT = "select * from Trainer where email = '" + email + "'";
                    SqlCommand commandT = new SqlCommand(queryT, connection);
                    SqlDataReader readerT = commandT.ExecuteReader();
                    if (readerT.Read())
                    {

                        RegisterTrainer obj = new RegisterTrainer(email);
                        obj.Show();

                    }
                    readerT.Close();

                    string queryG = "select * from GymOwner where email = '" + email + "'";
                    SqlCommand commandG = new SqlCommand(queryG, connection);
                    SqlDataReader readerG = commandG.ExecuteReader();
                    if (readerG.Read())
                    {

                        GymRegistration obj = new GymRegistration(email);
                        obj.Show();

                    }
                    readerG.Close();

                }
                else
                {
                    label10.Visible = true;
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