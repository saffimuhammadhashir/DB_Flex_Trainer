using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Data_base_spring_2024
{
    public partial class Admin_dashboard : Form
    {
        private string userEmail;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        private int myid = 0;
        public Admin_dashboard(string email)
        {
            InitializeComponent();
            this.userEmail = email;
            label4.Text = userEmail;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = @"select*from Admin inner join USERS on Users.email=Admin.email where Admin.email=@id";
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
                            label3.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
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
                // SQL command to select data against the email
                string query = @"SELECT 
    Member.Member_id,
    Member.email AS Member_email,
    Member.membership_type,
    Member.membership_expiry,
    Member.attendance,
    Member.dietconsistency,
    Member.workoutconsistency,
    USERS.username,
    USERS.password,
    USERS.firstName,
    USERS.lastName,
    USERS.registration_date,
    USERS.gender,
    USERS.membership_status,
    USERS.height,
    USERS.weight,
    USERS.street,
    USERS.city,
    USERS.country
FROM 
    Member
INNER JOIN 
    USERS ON USERS.email = Member.email;";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel obj=new Guna2Panel();
                            obj.Size = guna2Panel4.Size;
                            obj.BackColor = guna2Panel4.BackColor;
                            obj.FillColor = guna2Panel4.FillColor;
                            obj.BorderRadius = guna2Panel4.BorderRadius;
                            obj.Margin = guna2Panel4.Margin;


                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label6.Size;
                            l0.Text = label6.Text + "  " + reader["username"].ToString();
                            l0.Font=label6.Font;
                            l0.ForeColor = label6.ForeColor;
                            l0.Location=label6.Location; l0.Margin = label6.Margin;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label7.Size;
                            l1.Text = label7.Text + "  " + reader["firstName"].ToString() + reader["lastName"].ToString();
                            l1.Font = label7.Font;
                            l1.ForeColor = label7.ForeColor;
                            l1.Location = label7.Location; l0.Margin = label7.Margin;

                            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                            l3.Size = label7.Size;
                            l3.Text = reader["Member_email"].ToString();
                            l3.Font = label7.Font;
                            l3.ForeColor = label7.ForeColor;
                            l3.Location = label7.Location; l3.Margin = label3.Margin;
                            l3.Visible = false;


                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Size = label8.Size;
                            l2.Text = label8.Text+"  " + reader["Member_email"].ToString();
                            l2.Font = label8.Font;
                            l2.ForeColor = label8.ForeColor;
                            l2.Location = label8.Location; l0.Margin = label8.Margin;

                            Guna2Button b = new Guna2Button();
                            b.Size= guna2Button8.Size;
                            b.Text = guna2Button8.Text;
                            b.FillColor = guna2Button8.FillColor;
                            b.BackColor = guna2Button8.BackColor;
                            b.ForeColor = guna2Button8.ForeColor; b.Location = guna2Button8.Location;
                            b.Margin = guna2Button8.Margin;
                            b.BorderRadius = guna2Button8.BorderRadius;
                            b.Font  = guna2Button8.Font;
                            b.Click += (sender, e) => Button_Click1(l3.Text, sender, e);

                            obj.Controls.Add(l0);
                            obj.Controls.Add(l1);
                            obj.Controls.Add(l2);
                            obj.Controls.Add(b);
                            flowLayoutPanel1.Controls.Add(obj);
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
                // SQL command to select data against the email
                string query = @"SELECT 
    Trainer.Trainer_id,
    Trainer.email AS Trainer_email,
    Trainer.rating,
    Trainer.performance,
    Trainer.numClients,
    Trainer.personal_info,
    USERS.username,
    USERS.password,
    USERS.firstName,
    USERS.lastName,
    USERS.registration_date,
    USERS.gender,
    USERS.membership_status,
    USERS.height,
    USERS.weight,
    USERS.street,
    USERS.city,
    USERS.country
FROM 
    Trainer
INNER JOIN 
    USERS ON USERS.email = Trainer.email;
";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel obj = new Guna2Panel();
                            obj.Size = guna2Panel12.Size;
                            obj.BackColor = guna2Panel12.BackColor;
                            obj.FillColor = guna2Panel12.FillColor;
                            obj.BorderRadius = guna2Panel12.BorderRadius;
                            obj.Margin = guna2Panel12.Margin;


                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label38.Size;
                            l0.Text = label38.Text + "  " + reader["username"].ToString();
                            l0.Font = label38.Font;
                            l0.ForeColor = label38.ForeColor;
                            l0.Location = label38.Location; l0.Margin = label38.Margin;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label37.Size;
                            l1.Text = label37.Text + "  " + reader["firstName"].ToString() + reader["lastName"].ToString();
                            l1.Font = label37.Font;
                            l1.ForeColor = label37.ForeColor;
                            l1.Location = label37.Location; l0.Margin = label37.Margin;

                            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                            l3.Size = label36.Size;
                            l3.Text = reader["Trainer_email"].ToString();
                            l3.Font = label36.Font;
                            l3.ForeColor = label7.ForeColor;
                            l3.Location = label7.Location; l3.Margin = label3.Margin;
                            l3.Visible = false;

                            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                            l5.Size = label36.Size;
                            l5.Text = reader["Trainer_id"].ToString();
                            l5.Font = label36.Font;
                            l5.ForeColor = label7.ForeColor;
                            l5.Location = label7.Location; l3.Margin = label3.Margin;
                            l5.Visible = false;


                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Size = label36.Size;
                            l2.Text = label36.Text + "  " + reader["Trainer_email"].ToString();
                            l2.Font = label36.Font;
                            l2.ForeColor = label36.ForeColor;
                            l2.Location = label36.Location; l2.Margin = label36.Margin;

                            System.Windows.Forms.Label l4 = new System.Windows.Forms.Label();
                            l4.Size = label35.Size;
                            l4.Text = label35.Text + "  " + reader["rating"].ToString()+"/5";
                            l4.Font = label35.Font;
                            l4.ForeColor = label35.ForeColor;
                            l4.Location = label35.Location; l2.Margin = label36.Margin;

                            Guna2Button b = new Guna2Button();
                            b.Size = guna2Button23.Size;
                            b.Text = guna2Button23.Text;
                            b.FillColor = guna2Button23.FillColor;
                            b.BackColor = guna2Button23.BackColor;
                            b.ForeColor = guna2Button23.ForeColor; b.Location = guna2Button23.Location;
                            b.Margin = guna2Button23.Margin;
                            b.BorderRadius = guna2Button23.BorderRadius;
                            b.Font = guna2Button23.Font;
                            b.Click += (sender, e) => Button_Click2(l3.Text,Convert.ToInt32(l5.Text), sender, e);

                            obj.Controls.Add(l0);
                            obj.Controls.Add(l1);
                            obj.Controls.Add(l2);
                            obj.Controls.Add(l4);
                            obj.Controls.Add(b);
                            flowLayoutPanel2.Controls.Add(obj);
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
                // SQL command to select data against the email
                string query = @"SELECT 
    GymOwner.GymOwner_id,
    GymOwner.email AS GymOwner_email,
    NULL AS rating,
    NULL AS performance,
    NULL AS numClients,
    GymOwner.ownership_info AS personal_info,
    U.username,
    U.password,
    U.firstName,
    U.lastName,
    U.registration_date,
    U.gender,
    U.membership_status,
    U.height,
    U.weight,
    U.street,
    U.city,
    U.country
FROM 
    GymOwner
INNER JOIN 
    USERS AS U ON U.email = GymOwner.email;
";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Guna2Panel obj = new Guna2Panel();
                            obj.Size = guna2Panel14.Size;
                            obj.BackColor = guna2Panel14.BackColor;
                            obj.FillColor = guna2Panel14.FillColor;
                            obj.BorderRadius = guna2Panel14.BorderRadius;
                            obj.Margin = guna2Panel14.Margin;


                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label46.Size;
                            l0.Text = label46.Text + "  " + reader["username"].ToString();
                            l0.Font = label46.Font;
                            l0.ForeColor = label46.ForeColor;
                            l0.Location = label46.Location; l0.Margin = label46.Margin;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label45.Size;
                            l1.Text = label45.Text + "  " + reader["firstName"].ToString() + reader["lastName"].ToString();
                            l1.Font = label45.Font;
                            l1.ForeColor = label45.ForeColor;
                            l1.Location = label45.Location; l0.Margin = label45.Margin;

                            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                            l3.Size = label44.Size;
                            l3.Text = reader["GymOwner_email"].ToString();
                            l3.Font = label44.Font;
                            l3.ForeColor = label44.ForeColor;
                            l3.Location = label44.Location; l3.Margin = label44.Margin;
                            l3.Visible = false;

                            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                            l5.Size = label44.Size;
                            l5.Text = reader["GymOwner_id"].ToString();
                            l5.Font = label44.Font;
                            l5.ForeColor = label44.ForeColor;
                            l5.Location = label44.Location; l3.Margin = label44.Margin;
                            l5.Visible = false;


                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Size = label44.Size;
                            l2.Text = label44.Text + "  " + reader["GymOwner_email"].ToString();
                            l2.Font = label44.Font;
                            l2.ForeColor = label44.ForeColor;
                            l2.Location = label44.Location; l2.Margin = label44.Margin;



                            Guna2Button b = new Guna2Button();
                            b.Size = guna2Button25.Size;
                            b.Text = guna2Button25.Text;
                            b.FillColor = guna2Button25.FillColor;
                            b.BackColor = guna2Button25.BackColor;
                            b.ForeColor = guna2Button25.ForeColor; b.Location = guna2Button25.Location;
                            b.Margin = guna2Button25.Margin;
                            b.BorderRadius = guna2Button25.BorderRadius;
                            b.Font = guna2Button25.Font;
                            b.Click += (sender, e) => Button_Click3(l3.Text, Convert.ToInt32(l5.Text), sender, e);

                            obj.Controls.Add(l0);
                            obj.Controls.Add(l1);
                            obj.Controls.Add(l2);

                            obj.Controls.Add(b);
                            flowLayoutPanel3.Controls.Add(obj);
                          
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
                // SQL command to select data against the email
                string query = @"select * from Gym inner join Gym_location on Gym.Gym_id=Gym_location.Gym_id inner join Gym_businessPlans on Gym_businessPlans.Gym_id=Gym.Gym_id where Gym.status=1;";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Guna2Panel obj = new Guna2Panel();
                            obj.Size = guna2Panel23.Size;
                            obj.BackColor = guna2Panel23.BackColor;
                            obj.FillColor = guna2Panel23.FillColor;
                            obj.BorderRadius = guna2Panel23.BorderRadius;
                            obj.Margin = guna2Panel23.Margin;

                            Guna2Panel obj1 = new Guna2Panel();
                            obj1.Size = guna2Panel37.Size;
                            obj1.BackColor = guna2Panel37.BackColor;
                            obj1.FillColor = guna2Panel37.FillColor;
                            obj1.BorderRadius = guna2Panel37.BorderRadius;
                            obj1.Margin = guna2Panel37.Margin;
                            obj1.Location = guna2Panel37.Location;

                            Guna2Panel obj2 = new Guna2Panel();
                            obj2.Size = guna2Panel24.Size;
                            obj2.BackColor = guna2Panel24.BackColor;
                            obj2.FillColor = guna2Panel24.FillColor;
                            obj2.BorderRadius = guna2Panel24.BorderRadius;
                            obj2.Margin = guna2Panel24.Margin;
                            obj2.Location = guna2Panel24.Location;



                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label129.Size;
                            l0.Text = label129.Text + "  " + reader["gym_name"].ToString();
                            l0.Font = label129.Font;
                            l0.ForeColor = label129.ForeColor;
                            l0.Location = label129.Location; l0.Margin = label129.Margin;

                            System.Windows.Forms.Label l01 = new System.Windows.Forms.Label();
                            l01.Size = label129.Size;
                            l01.Text =  reader["Gym_id"].ToString();
                            l01.Font = label129.Font;
                            l01.ForeColor = label129.ForeColor;
                            l01.Location = label129.Location; l0.Margin = label129.Margin;
                            l01.Visible = false;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label83.Size;
                            l1.Text = label83.Text + "  " + reader["Gym_location"].ToString() ;
                            l1.Font = label83.Font;
                            l1.ForeColor = label83.ForeColor;
                            l1.Location = label83.Location; l0.Margin = label83.Margin;
                            l1.BackColor = label83.BackColor;

                            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                            l3.Size = label82.Size;
                            l3.Text = label82.Text+" "+ reader["curr_active_members"].ToString();
                            l3.Font = label82.Font;
                            l3.ForeColor = label82.ForeColor;
                            l3.Location = label82.Location; l3.Margin = label82.Margin;
                            l3.BackColor = label82.BackColor;



                            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                            l5.Size = label81.Size;
                            l5.Text = label81.Text +" "+reader["facility_specifications"].ToString();
                            l5.Font = label81.Font;
                            l5.ForeColor = label81.ForeColor;
                            l5.Location = label81.Location; l3.Margin = label81.Margin;
                            l5.BackColor = label81.BackColor;

                            obj1.Controls.Add(l1);
                            obj1.Controls.Add(l3);
                            obj1.Controls.Add(l5);


                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Size = label78.Size;
                            l2.Text = label78.Text + "  " + reader["Gym_businessPlans"].ToString();
                            l2.Font = label78.Font;
                            l2.ForeColor = label78.ForeColor;
                            l2.Location = label78.Location; l2.Margin = label78.Margin;
                            l2.BackColor = label78.BackColor;
                           

                            obj2.Controls.Add(l2);




                            Guna2Button b = new Guna2Button();
                            b.Size = guna2Button9.Size;
                            b.Text = guna2Button9.Text;
                            b.FillColor = guna2Button9.FillColor;
                            b.BackColor = guna2Button9.BackColor;
                            b.ForeColor = guna2Button9.ForeColor; b.Location = guna2Button9.Location;
                            b.Margin = guna2Button9.Margin;
                            b.BorderRadius = guna2Button9.BorderRadius;

                            b.Font = guna2Button9.Font;
                            b.Click += (sender, e) => Button_Click4( Convert.ToInt32(l01.Text), sender, e);

                            obj.Controls.Add(l0);
                            obj.Controls.Add(obj1);
                            obj.Controls.Add(obj2);
                            obj.Controls.Add(b);
                            flowLayoutPanel4.Controls.Add(obj);

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
                // SQL command to select data against the email
                string query = @"SELECT *
FROM Gym_registration_request
INNER JOIN Gym ON Gym_registration_request.Gym_id = Gym.Gym_id
INNER JOIN Gym_businessPlans ON Gym_registration_request.Gym_id = Gym_businessPlans.Gym_id
INNER JOIN Gym_location ON Gym.Gym_id = Gym_location.Gym_id where Gym.status=0;";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Guna2Panel obj = new Guna2Panel();
                            obj.Size = guna2Panel5.Size;
                            obj.BackColor = guna2Panel5.BackColor;
                            obj.FillColor = guna2Panel5.FillColor;
                            obj.BorderRadius = guna2Panel5.BorderRadius;
                            obj.Margin = guna2Panel5.Margin;

                            Guna2Panel obj1 = new Guna2Panel();
                            obj1.Size = guna2Panel7.Size;
                            obj1.BackColor = guna2Panel7.BackColor;
                            obj1.FillColor = guna2Panel7.FillColor;
                            obj1.BorderRadius = guna2Panel7.BorderRadius;
                            obj1.Margin = guna2Panel7.Margin;
                            obj1.Location = guna2Panel7.Location;

                            Guna2Panel obj2 = new Guna2Panel();
                            obj2.Size = guna2Panel6.Size;
                            obj2.BackColor = guna2Panel6.BackColor;
                            obj2.FillColor = guna2Panel6.FillColor;
                            obj2.BorderRadius = guna2Panel6.BorderRadius;
                            obj2.Margin = guna2Panel6.Margin;
                            obj2.Location = guna2Panel6.Location;



                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label129.Size;
                            l0.Text = label129.Text + "  " + reader["gym_name"].ToString();
                            l0.Font = label129.Font;
                            l0.ForeColor = label129.ForeColor;
                            l0.Location = label129.Location; l0.Margin = label129.Margin;

                            System.Windows.Forms.Label l01 = new System.Windows.Forms.Label();
                            l01.Size = label129.Size;
                            l01.Text = reader["Gym_id"].ToString();
                            l01.Font = label129.Font;
                            l01.ForeColor = label129.ForeColor;
                            l01.Location = label129.Location; l0.Margin = label129.Margin;
                            l01.Visible = false;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label83.Size;
                            l1.Text = label83.Text + "  " + reader["Gym_location"].ToString();
                            l1.Font = label83.Font;
                            l1.ForeColor = label83.ForeColor;
                            l1.Location = label83.Location; l0.Margin = label83.Margin;
                            l1.BackColor = label83.BackColor;

                            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                            l3.Size = label82.Size;
                            l3.Text = label82.Text + " " + reader["curr_active_members"].ToString();
                            l3.Font = label82.Font;
                            l3.ForeColor = label82.ForeColor;
                            l3.Location = label82.Location; l3.Margin = label82.Margin;
                            l3.BackColor = label82.BackColor;



                            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                            l5.Size = label81.Size;
                            l5.Text = label81.Text + " " + reader["facility_specifications"].ToString();
                            l5.Font = label81.Font;
                            l5.ForeColor = label81.ForeColor;
                            l5.Location = label81.Location; l3.Margin = label81.Margin;
                            l5.BackColor = label81.BackColor;
                            obj1.Controls.Add(l1);
                            obj1.Controls.Add(l3);
                            obj1.Controls.Add(l5);


                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Size = label78.Size;
                            l2.Text = label78.Text + "  " + reader["Gym_businessPlans"].ToString();
                            l2.Font = label78.Font;
                            l2.ForeColor = label78.ForeColor;
                            l2.Location = label78.Location; l2.Margin = label78.Margin;
                            l2.BackColor = label78.BackColor;
                            obj2.Controls.Add(l2);


                            Guna2Button b1 = new Guna2Button();
                            b1.Size = guna2Button10.Size;
                            b1.Text = guna2Button10.Text;
                            b1.FillColor = guna2Button10.FillColor;
                            b1.BackColor = guna2Button10.BackColor;
                            b1.ForeColor = guna2Button10.ForeColor; b1.Location = guna2Button10.Location;
                            b1.Margin = guna2Button10.Margin;
                            b1.BorderRadius = guna2Button10.BorderRadius;

                            b1.Font = guna2Button10.Font;
                            b1.Click += (sender, e) => Button_Click5(Convert.ToInt32(l01.Text), sender, e);

                            Guna2Button b2 = new Guna2Button();
                            b2.Size = guna2Button11.Size;
                            b2.Text = guna2Button11.Text;
                            b2.FillColor = guna2Button11.FillColor;
                            b2.BackColor = guna2Button11.BackColor;
                            b2.ForeColor = guna2Button11.ForeColor; b2.Location = guna2Button11.Location;
                            b2.Margin = guna2Button11.Margin;
                            b2.BorderRadius = guna2Button11.BorderRadius;

                            b2.Font = guna2Button11.Font;
                            b2.Click += (sender, e) => Button_Click6(Convert.ToInt32(l01.Text), sender, e);

                            obj.Controls.Add(l0);
                            obj.Controls.Add(obj1);
                            obj.Controls.Add(obj2);
                            obj.Controls.Add(b1);
                            obj.Controls.Add(b2);
                            flowLayoutPanel5.Controls.Add(obj);

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
        private void Button_Click1(string name, object sender, EventArgs e)
        {
            MemberReview newform = new MemberReview(name);
            newform.Show();
        }
        private void Button_Click2(string name,int id, object sender, EventArgs e)
        {
            TrainerReview newform = new TrainerReview(name,id);
            newform.Show();
        }
        private void Button_Click3(string name, int id, object sender, EventArgs e)
        {
            OwnerReview newform = new OwnerReview(name,id);
            newform.Show();
        }

        private void Button_Click4( int id, object sender, EventArgs e)
        {
            GymReview newform = new GymReview( id);
            newform.Show();
        }

        private void Button_Click5(int id, object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = @"update Gym set status = 2 where Gym_id = @id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
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

        private void Button_Click6(int id, object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = @"update Gym set status = 1 where Gym_id = @id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
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

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {


            this.Hide();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;

        }

        private void flowLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
