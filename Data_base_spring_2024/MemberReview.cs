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
using System.Xml.Linq;

namespace Data_base_spring_2024
{
    public partial class MemberReview : Form
    {
        private string userEmail;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";

        public MemberReview(string email)
        {
            InitializeComponent();
            userEmail = email;
            label2.Text = email;
            int myid = 0;
            int chk = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to retrieve gym location based on gymId
                string query = @"SELECT *
                     FROM Member
                     INNER JOIN USERS ON Member.email = USERS.email
                     WHERE Member.email = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", userEmail);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            label1.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                            label16.Text = "Weight : " + reader["Weight"].ToString();
                            label36.Text = "Height : " + reader["height"].ToString();
                            myid = Convert.ToInt32(reader["Member_id"]);
                            int val = Convert.ToInt32(reader["attendance"]);
                            val *= 100;
                            val /= 30;
                            chk = Convert.ToInt16(reader["is_active"]);
                            guna2ProgressBar1.Value = Convert.ToInt32(reader["workoutconsistency"]) * 10;
                            guna2ProgressBar2.Value = Convert.ToInt32(reader["dietconsistency"]) * 10;
                            guna2ProgressBar3.Value = val;
                            guna2CircleProgressBar1.Value = (guna2ProgressBar1.Value + guna2ProgressBar2.Value + guna2ProgressBar3.Value) / 3;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found for the specified email.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving data:\n" + ex.Message);
                }
            }





            if (chk == 0) {
                guna2Panel1.Visible = false;
                guna2Panel2.Visible = true;
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"Update  Users SET is_active=0 WHERE email=@mem_id;";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand


                        command.Parameters.AddWithValue("@mem_id", userEmail);


                    try
                    {

                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            guna2Panel2.Visible = true;
                            guna2Panel1.Visible = false;
                            Console.WriteLine("Data inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows inserted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
