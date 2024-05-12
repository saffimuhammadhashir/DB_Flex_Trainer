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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Data_base_spring_2024
{
    public partial class RegisterTrainer : Form
    {
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        private int count = 0;
        private string useremail = "";
        public RegisterTrainer(string email)
        {

           

            InitializeComponent();
         
            int id = 0;
            useremail = email;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select count(*) counting from Trainer_registration_request inner join Trainer on Trainer.trainer_id=Trainer_registration_request.trainer_id where email=@Email and  decision='accepted';";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(reader.GetOrdinal("counting"));

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

                string query = @"select* from Trainer inner join USERS on Trainer.email=USERS.email where USERS.email=@Email;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", useremail);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            id = Convert.ToInt32(reader["Trainer_id"]);
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


            MessageBox.Show("Count: " + count.ToString());

            if (count == 0)
            {
                guna2Button1.Visible = false;
            }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

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
                                obj.Size = guna2Panel4.Size;
                                obj.BackColor = guna2Panel4.BackColor;
                                obj.FillColor = guna2Panel4.FillColor;
                                obj.BorderRadius = guna2Panel4.BorderRadius;
                                obj.Margin = guna2Panel4.Margin;



                                System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                                l0.Size = label6.Size;
                                l0.Text = "Gym Name:  " + reader["gym_name"].ToString();
                                l0.Font = label6.Font;
                                l0.ForeColor = label6.ForeColor;
                                l0.Location = label6.Location; l0.Margin = label6.Margin;

                                System.Windows.Forms.Label l01 = new System.Windows.Forms.Label();
                                l01.Size = label2.Size;
                                l01.Text = "Id: " + reader["Gym_id"].ToString();
                                l01.Font = label2.Font;
                                l01.ForeColor = label2.ForeColor;
                                l01.Location = label2.Location;


                                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                                l2.Size = label4.Size;
                                l2.Text = "Gym Owner Id: " + reader["GymOwner_id"].ToString();
                                l2.Font = label4.Font;
                                l2.ForeColor = label4.ForeColor;
                                l2.Location = label4.Location;

                                System.Windows.Forms.Label l6 = new System.Windows.Forms.Label();
                                l6.Size = label4.Size;
                                l6.Text = reader["GymOwner_id"].ToString();
                                l6.Font = label4.Font;
                                l6.ForeColor = label4.ForeColor;
                                l6.Location = label4.Location;
                                l6.Visible = false;

                                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                                l1.Size = label1.Size;
                                l1.Text = "Location:  " + reader["Gym_location"].ToString();
                                l1.Font = label1.Font;
                                l1.ForeColor = label1.ForeColor;
                                l1.Location = label1.Location; l0.Margin = label1.Margin;
                                l1.BackColor = label1.BackColor;

                                System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                                l3.Size = label8.Size;
                                l3.Text = label8.Text + " " + reader["facility_specifications"].ToString();
                                l3.Font = label8.Font;
                                l3.ForeColor = label8.ForeColor;
                                l3.Location = label8.Location; l3.Margin = label8.Margin;
                                l3.BackColor = label8.BackColor;

                                System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                                l5.Size = label7.Size;
                                l5.Text = label7.Text + " " + reader["rating"].ToString() + "/5";
                                l5.Font = label7.Font;
                                l5.ForeColor = label7.ForeColor;
                                l5.Location = label7.Location; l3.Margin = label7.Margin;
                                l5.BackColor = label7.BackColor;


                                Guna2Button l4 = new Guna2Button();
                                l4.Size = guna2Button8.Size;
                                l4.Text = guna2Button8.Text;
                                l4.Font = guna2Button8.Font;
                                l4.ForeColor = guna2Button8.ForeColor;
                                l4.Location = guna2Button8.Location;
                                l4.Margin = guna2Button8.Margin;
                                l4.BackColor = guna2Button8.BackColor;
                                l4.FillColor = guna2Button8.FillColor;
                                l4.BorderRadius = guna2Button8.BorderRadius;
                                l4.Click += (sender, e) => Button_Click1(Convert.ToInt32(l6.Text), id, l4, sender, e);

                                obj.Controls.Add(l0);
                                obj.Controls.Add(l01);
                                obj.Controls.Add(l2);
                                obj.Controls.Add(l1);
                                obj.Controls.Add(l3);
                                obj.Controls.Add(l5);
                                obj.Controls.Add(l4);
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
                        MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                
            }

        }
        private void Button_Click1(int ownerid,int trainerid, Guna2Button b,object sender, EventArgs e)
        {

            int count = 0;
            b.Visible = false;
            MessageBox.Show(trainerid.ToString());
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @" insert into Trainer_registration_request(trainer_id,GymOwner_id,decision) values(@tid,@gymowner,'pending');";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@gymowner", ownerid);
                    command.Parameters.AddWithValue("@tid", trainerid);
                    try
                    {
                        connection.Open();

                    command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }

            



        }
        private void RegisterTrainer_Load(object sender, EventArgs e)
        {
            if (count > 0)
            {
                this.Hide();
 
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TrainerDashboard obj = new TrainerDashboard(useremail);
            obj.Show();
            this.Hide();
        }
    }
}
