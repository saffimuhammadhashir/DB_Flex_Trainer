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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Data_base_spring_2024
{
    public partial class GymRegistration : Form   
    {
        private string useremeail;
        private int count = 0,myid;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";

        public GymRegistration(string email)
        {
            InitializeComponent();
            useremeail = email;
            CheckRegisteredGymsCount();
        }
        private void CheckRegisteredGymsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*)  AS counting FROM registered_gyms INNER JOIN GymOwner ON GymOwner.GymOwner_id = registered_gyms.GymOwner_id WHERE email = @Email;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", useremeail);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            count = Convert.ToInt32(reader["counting"]);
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
                    if (count > 0)
                    {
                        this.Hide();
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT *  FROM GymOwner WHERE email = @Email;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", useremeail);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            myid = Convert.ToInt32(reader["GymOwner_id"]);
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
                    if (count > 0)
                    {
                        this.Hide();
                    }
                }
            }


            MessageBox.Show("count: "+count.ToString());
            MessageBox.Show("MYid: "+myid.ToString());

            if (count > 0)
            {
                
                this.Hide();

            }
        }

        private void GymRegistration_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "" && guna2TextBox5.Text != "" && guna2TextBox6.Text != "")
            {
                string name = guna2TextBox1.Text;
                int members = Convert.ToInt32(guna2TextBox2.Text);
                string facilityspecifications = guna2TextBox3.Text;
                string policy = guna2TextBox4.Text;
                DateTime dateis=DateTime.Now;
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Gym (GymOwner_id, facility_specifications,gym_policy_compliance_status ,curr_active_members, registration_date, gym_policy_desc, rating, performance_level, class_attendance_rates, financial_performance, membership_growth, legal_status, gym_name, status) 
VALUES (@id, @fspecs,'y' ,@mem, @date, @policy, 0, 0, 0, 0, 0, 'legal', @name, 1);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", myid);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@mem", members);
                        command.Parameters.AddWithValue("@fspecs", facilityspecifications);
                        command.Parameters.AddWithValue("@policy", policy);
                        command.Parameters.AddWithValue("@date", dateis);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                count = Convert.ToInt32(reader["counting"]);
                                guna2Button2.Visible = false;
                               
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


                int gymid = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"Select* from Gym where GymOwner_id=@id and gym_name=@name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", myid);
                        command.Parameters.AddWithValue("@name", name);


                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                gymid = Convert.ToInt32(reader["Gym_id"]);
                            
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
                        if (count > 0)
                        {
                            this.Hide();
                        }
                    }
                }





                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"insert into Gym_businessPlans(Gym_id,Gym_businessPlans) values (@id,@name); ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", gymid);
                        command.Parameters.AddWithValue("@name", guna2TextBox6.Text);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                count = Convert.ToInt32(reader["counting"]);
                                guna2Button2.Visible = false;

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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"insert into Gym_location(Gym_id,Gym_location) values (@id,@name); ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", gymid);
                        command.Parameters.AddWithValue("@name", guna2TextBox5.Text);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                count = Convert.ToInt32(reader["counting"]);
                                guna2Button2.Visible = false;

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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Gym_registration_request (GymOwner_id, Gym_id)
VALUES
    (@name, @id); ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", gymid);
                        command.Parameters.AddWithValue("@name", myid);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                count = Convert.ToInt32(reader["counting"]);
                                guna2Button2.Visible = false;

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

                guna2Button2.Visible = false;
                MessageBox.Show(gymid.ToString());
                this.Hide();
            }
        }
    }
}
