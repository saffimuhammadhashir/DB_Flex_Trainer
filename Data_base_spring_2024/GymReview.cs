using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_base_spring_2024
{
    public partial class GymReview : Form
    {
        private int myid=0,chk=0;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        public GymReview(int id)
        {
            InitializeComponent();
            myid = id;
            MessageBox.Show(id.ToString());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = @"select * from Gym inner join Gym_location on Gym.Gym_id=Gym_location.Gym_id inner join Gym_businessPlans on Gym_businessPlans.Gym_id=Gym.Gym_id where Gym.Gym_id=@id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", myid);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            label1.Text = label1.Text + " " + reader["gym_name"];
                            label2.Text = label2.Text + " " + reader["Gym_location"];
                            label3.Text = label3.Text + " " + reader["curr_active_members"];
                            label5.Text = reader["rating"].ToString() + "/5";
                            guna2CircleProgressBar1.Value = (Convert.ToInt32(reader["rating"].ToString()) * 100) / 5;
                            guna2CircleProgressBar2.Value = Convert.ToInt32(reader["performance_level"].ToString());
                            guna2CircleProgressBar3.Value = Convert.ToInt32(reader["class_attendance_rates"].ToString());
                            guna2CircleProgressBar4.Value = Convert.ToInt32(reader["membership_growth"].ToString());
                            guna2CircleProgressBar5.Value = Convert.ToInt32(reader["financial_performance"].ToString());
                            chk = Convert.ToInt32(reader["is_active"]);


 
                        }
                    }
                    else
                    {


                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            if (chk == 0)
            {
                guna2Panel6.Visible = true;
                guna2Panel5.Visible = false;
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel6.Visible = true;
            guna2Panel5.Visible = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = @"Update Gym Set is_active=0 where Gym.Gym_id=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", myid);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                        }
                    }
                    else
                    {


                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
