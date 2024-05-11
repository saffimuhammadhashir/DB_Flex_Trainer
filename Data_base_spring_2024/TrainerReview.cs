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
    public partial class TrainerReview : Form
    {
        private string userEmail;
        private int myid;
        private int chk;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        public TrainerReview(string email,int id)
        {
            
            InitializeComponent();
            userEmail = email;
            myid = id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"SELECT 
    F.feedback_id,
    F.appointment_id,
    F.trainer_id,
    F.member_id,
    F.rating,
    F.comment,
    M.email AS member_email,
    M.membership_type,
    M.membership_expiry,
    U.username AS member_username,
    U.firstName AS member_firstName,
    U.lastName AS member_lastName,
    U.registration_date AS member_registration_date,
    U.gender AS member_gender,
    U.membership_status,
    U.height,
    U.weight,
    U.street,
    U.city,
    U.country,
    U.DOB
FROM 
    Feedback AS F
INNER JOIN 
    Member AS M ON M.Member_id = F.member_id
INNER JOIN 
    USERS AS U ON U.email = M.email
where trainer_id=@id;
";


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
                            Guna2Panel l1 = new Guna2Panel();
                            l1.Size = guna2Panel3.Size;
                            l1.BackColor = guna2Panel3.BackColor;
                            l1.FillColor = guna2Panel3.FillColor;
                            l1.Margin = guna2Panel3.Margin;
                            l1.BorderRadius = guna2Panel3.BorderRadius;

                            Guna2Button b1 = new Guna2Button();
                            b1.Size = guna2Button91.Size;
                            b1.BackColor = guna2Button91.BackColor;
                            b1.Text = reader["member_firstName"].ToString();
                            b1.Font = guna2Button91.Font;
                            b1.Location = guna2Button91.Location;
                            b1.Margin = guna2Button91.Margin;
                            b1.FillColor = guna2Button91.FillColor;
                            b1.BorderRadius = guna2Button91.BorderRadius;
                            b1.ForeColor = guna2Button91.ForeColor;

                            System.Windows.Forms.Label b2 = new System.Windows.Forms.Label();
                            b2.Size = label6.Size;
                            b2.Font = label6.Font;
                            b2.Text = reader["member_lastName"].ToString();
                            b2.Location = label6.Location;
                            b2.Visible = label6.Visible;

                            System.Windows.Forms.Label b3 = new System.Windows.Forms.Label();
                            b3.Size = label6.Size;
                            b3.Font = label6.Font;
                            b3.Text = reader["member_email"].ToString();
                            b3.Location = label6.Location;
                            b3.Visible = label6.Visible;
                     

                            System.Windows.Forms.Label b4 = new System.Windows.Forms.Label();
                            b4.Size = label6.Size;
                            b4.Font = label6.Font;
                            b4.Text = reader["comment"].ToString();
                            b4.Location = label6.Location;
                            b4.Visible = label6.Visible;

                            System.Windows.Forms.Label b5 = new System.Windows.Forms.Label();
                            b5.Size = label6.Size;
                            b5.Font = label6.Font;
                            b5.Text = reader["rating"].ToString();
                            b5.Location = label6.Location;
                            b5.Visible = label6.Visible;

                            b1.Click += (sender, e) => Button_Click0(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, sender, e);

                            l1.Controls.Add(b1);
                            l1.Controls.Add(b2);
                            l1.Controls.Add(b3);
                            l1.Controls.Add(b4);
                            l1.Controls.Add(b5);
                            flowLayoutPanel16.Controls.Add(l1);
                         




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


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"Select USERS.* from Trainer inner join USERS on USERS.email=Trainer.email where Trainer.Trainer_id=@id;
";


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
                guna2Panel1.Visible=false;
                guna2Panel2.Visible=true;
            }



        }
        private void Button_Click0(string b1,string b2,string b3,string b4,string b5,object sender, EventArgs e)
        {

            label299.Text = "Comment: "+b4;
            label302.Text = "Name: "+b1+" "+b2;
            label5.Text = "Rating: "+b5+"/5";
         
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2Panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button91_Click(object sender, EventArgs e)
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

        private void label299_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
