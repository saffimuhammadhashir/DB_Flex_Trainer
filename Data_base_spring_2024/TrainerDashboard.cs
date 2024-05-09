using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Data_base_spring_2024
{

    public partial class TrainerDashboard : Form
    {

        private string userEmail, username, firstName, lastName, gender, membershipStatus, gymlocation,info,street,city,country;
        private DateTime registrationDate;
        private int gymId, trainerid, performancescore, appointments;
        private float attendance;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";

        public TrainerDashboard(string passingemail)
        {
            InitializeComponent();
            userEmail = passingemail;
            label8.Text = userEmail;

            guna2Button40.Visible = false;
            guna2Button41.Visible = false;
            guna2Shapes42.Visible = true;
            guna2Shapes43.Visible = false;
            guna2Shapes44.Visible = false;
            guna2Shapes45.Visible = false;
            guna2Shapes46.Visible = false;
            guna2Shapes47.Visible = true;
            guna2Shapes86.Visible = true;
            guna2Shapes87.Visible = false;
            guna2Shapes88.Visible = false;
            guna2Button3.Visible = false;
            guna2Button2.Visible = true;
            guna2TextBox1.Visible = false;
            guna2Button4.Visible = false;
            guna2Button5.Visible = true;
            guna2TextBox2.Visible = false;
            guna2Button14.Visible = true;
            guna2Button12.Visible = false;
            guna2TextBox8.Visible = false;
            guna2Button14.Visible = true;
            guna2Button12.Visible = false;
            guna2TextBox8.Visible = false;
            guna2Button11.Visible = false;
            guna2Button13.Visible = true;
            guna2TextBox7.Visible = false;
            guna2Button10.Visible = false;
            guna2Button15.Visible = true;
            guna2TextBox5.Visible = false;
            guna2Button35.Visible = false;
            guna2TextBox15.Visible = false;
            guna2TextBox16.Visible = false;
            guna2Button36.Visible = true;



            // Email to search for
            string emailToSearch = userEmail;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to select data against the email
                string query = "SELECT * FROM USERS WHERE email = @Email";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", emailToSearch);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            username = reader["username"].ToString();
                            firstName = reader["firstName"].ToString();
                            lastName = reader["lastName"].ToString();
                            registrationDate = Convert.ToDateTime(reader["registration_date"]);
                            gender = reader["gender"].ToString();
                            membershipStatus = reader["membership_status"].ToString();
                            street = reader["streetaddress"].ToString() ;
                            city = reader["cityaddress"].ToString();
                            country = reader["countryaddress"].ToString();
                            label6.Text = username;
                            label11.Text = firstName;
                            label12.Text = lastName;
                            label16.Text = street;
                            label21.Text = city;
                            label20.Text = country;

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

                string query = "SELECT * FROM Trainer WHERE email = @Email";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", emailToSearch);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            trainerid = reader.GetInt32(reader.GetOrdinal("Trainer_id"));
                            performancescore = reader.GetInt32(reader.GetOrdinal("performance"));
                            attendance = reader.GetInt32(reader.GetOrdinal("attendance"));
                            attendance = (attendance / 30) * 100;
                            int val = (int)attendance;
                            info = reader["personal_info"].ToString();
                            label201.Text = info;
                            guna2ProgressBar1.Value = val;
                            guna2CircleProgressBar1.Value = performancescore;

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                        MessageBox.Show("error");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("error");
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Appointment WHERE trainer_id = @trainerid";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainerid", trainerid); // Assuming trainerId is the parameter for the trainer's ID

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    appointments = count;
                    guna2ProgressBar2.Value = appointments;
                    Console.WriteLine("Number of appointments: " + count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Gym.Gym_id
                    FROM Gym_hired_trainers
                    JOIN Trainer ON Trainer.Trainer_id = Gym_hired_trainers.trainer_id
                    JOIN Gym ON Gym.Gym_id = Gym_hired_trainers.Gym_id
                    WHERE Trainer.email = @Email";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", emailToSearch);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            gymId = reader.GetInt32(reader.GetOrdinal("Gym_id"));

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
                // SQL command to retrieve gym location based on gymId
                string query = "SELECT * FROM Gym_location WHERE Gym_id = @id";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", gymId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            gymlocation = reader["Gym_id"].ToString();
                            label62.Text = gymlocation;

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
            for (int i = 0; i < 10; i++)
            {
                var item = new guna2Panel12();
                label+=label85
                    item+=
                item.ItemText = "Item " + i; // Set any properties or data for each item
                // Attach event handlers or configure the item as needed
                // item.SomeEvent += Item_SomeEvent;
                flowLayoutPanel1.Controls.Add(item);
            }


        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 0;
            guna2Shapes45.Visible = false;
            guna2Shapes46.Visible = false;
            guna2Shapes47.Visible = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 3;
            guna2Shapes45.Visible = false;
            guna2Shapes46.Visible = true;
            guna2Shapes47.Visible = false;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedIndex = 2;
            guna2Shapes45.Visible = true;
            guna2Shapes46.Visible = false;
            guna2Shapes47.Visible = false;
        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {


        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 2;
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            guna2TabControl3.SelectedIndex = 1;
            guna2Shapes42.Visible = false;
            guna2Shapes43.Visible = true;
            guna2Shapes44.Visible = false;
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            guna2TabControl3.SelectedIndex = 0;
            guna2Shapes42.Visible = true;
            guna2Shapes43.Visible = false;
            guna2Shapes44.Visible = false;
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            guna2TabControl3.SelectedIndex = 2;
            guna2Shapes42.Visible = false;
            guna2Shapes43.Visible = false;
            guna2Shapes44.Visible = true;
        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button39_Click(object sender, EventArgs e)
        {
            guna2Button40.Visible = !guna2Button40.Visible;
            guna2Button41.Visible = !guna2Button41.Visible;

        }

        private void guna2Button40_Click(object sender, EventArgs e)
        {
            guna2Button39.Visible = !guna2Button39.Visible;
            guna2Button41.Visible = !guna2Button41.Visible;
        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {
            guna2Button40.Visible = !guna2Button40.Visible;
            guna2Button39.Visible = !guna2Button39.Visible;
        }

        private void guna2Shapes37_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes43_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes44_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes42_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes46_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes45_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes47_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;
        }

        private void label146_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes60_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes59_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button44_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 4;
        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button45_Click(object sender, EventArgs e)
        {
            guna2TabControl4.SelectedIndex = 0;
            guna2Shapes86.Visible = true;
            guna2Shapes87.Visible = false;
            guna2Shapes88.Visible = false;
        }

        private void guna2Button46_Click(object sender, EventArgs e)
        {
            guna2TabControl4.SelectedIndex = 1;
            guna2Shapes86.Visible = false;
            guna2Shapes87.Visible = true;
            guna2Shapes88.Visible = false;
        }

        private void guna2Button47_Click(object sender, EventArgs e)
        {
            guna2TabControl4.SelectedIndex = 2;
            guna2Shapes86.Visible = false;
            guna2Shapes87.Visible = false;
            guna2Shapes88.Visible = true;
        }

        private void guna2Shapes86_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes87_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes88_Click(object sender, EventArgs e)
        {

        }

        private void label283_Click(object sender, EventArgs e)
        {

        }

        private void label292_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes91_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel67_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button3.Visible = false;
            guna2Button6.Visible = true;
            guna2TextBox1.Visible = false;


            string usernameToUpdate = userEmail;

            string newFirstName = guna2TextBox1.Text;
            label11.Text = newFirstName;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE USERS SET firstName = @NewFirstName WHERE email = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                command.Parameters.AddWithValue("@Username", userEmail);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated");
                    }
                    else
                    {
                        MessageBox.Show("No rows updated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception occurred: {ex.Message}");
                    // Consider logging the exception for debugging purposes
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Button3.Visible = true;
            guna2Button6.Visible = false;
            guna2TextBox1.Visible = true;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button4.Visible = false;
            guna2Button5.Visible = true;
            guna2TextBox2.Visible = false;

            string usernameToUpdate = userEmail;

            string newFirstName = guna2TextBox2.Text;
            label12.Text = newFirstName;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE USERS SET lastname = @NewFirstName WHERE email = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                command.Parameters.AddWithValue("@Username", userEmail);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated");
                    }
                    else
                    {
                        MessageBox.Show("No rows updated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception occurred: {ex.Message}");
                    // Consider logging the exception for debugging purposes
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Button4.Visible = true;
            guna2Button5.Visible = false;
            guna2TextBox2.Visible = true;
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            guna2Button10.Visible = true;
            guna2Button15.Visible = false;
            guna2TextBox5.Visible = true;
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2Button10.Visible = false;
            guna2Button15.Visible = true;
            guna2TextBox5.Visible = false;
            string usernameToUpdate = userEmail;

            if (guna2TextBox5.Text != "")
            {
                string newFirstName = guna2TextBox5.Text;
                label16.Text = newFirstName;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE USERS SET streetaddress = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception occurred: {ex.Message}");
                        // Consider logging the exception for debugging purposes
                    }
                }
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            guna2Button14.Visible = false;
            guna2Button12.Visible = true;
            guna2TextBox8.Visible = true;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2Button14.Visible = true;
            guna2Button12.Visible = false;
            guna2TextBox8.Visible = false;
            if (guna2TextBox8.Text != "")
            {
                string newFirstName = guna2TextBox8.Text;
                label21.Text = newFirstName;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE USERS SET cityaddress = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception occurred: {ex.Message}");
                        // Consider logging the exception for debugging purposes
                    }
                }
            }

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

            guna2Button13.Visible = false;
            guna2Button11.Visible = true;
            guna2TextBox7.Visible = true;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            guna2Button13.Visible = true;
            guna2Button11.Visible = false;
            guna2TextBox7.Visible = false;
            if (guna2TextBox7.Text != "")
            {
                string newFirstName = guna2TextBox7.Text;
                label20.Text = newFirstName;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE USERS SET countryaddress = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception occurred: {ex.Message}");
                        // Consider logging the exception for debugging purposes
                    }
                }
            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {

            if (guna2TextBox15.Text == guna2TextBox16.Text && guna2TextBox16.Text != "")
            {

                guna2Button35.Visible = false;
                guna2TextBox15.Visible = false;
                guna2TextBox16.Visible = false;
                guna2Button36.Visible = true;



                string usernameToUpdate = userEmail;

                string newFirstName = guna2TextBox16.Text;
                label12.Text = guna2TextBox16.Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE USERS SET password = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception occurred: {ex.Message}");
                        // Consider logging the exception for debugging purposes
                    }
                }
            }

        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            guna2Button35.Visible = true;
            guna2TextBox15.Visible = true;
            guna2TextBox16.Visible = true;
            guna2Button36.Visible = false;
        }

        private void guna2Button77_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 5;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            //guna2ProgressIndicator1.Visible = true;
            Form next = new Trainee_details();
            next.Show();
            this.Hide();
        }

        private void guna2ProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button43_Click(object sender, EventArgs e)
        {
            guna2TabControl3.SelectedIndex = 4;
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            guna2TabControl3.SelectedIndex = 3;
        }

        private void guna2Shapes97_Click(object sender, EventArgs e)
        {

        }

        private void tabPage17_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button92_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 2;
            //guna2TabControl3.SelectedIndex = 2;
        }

        private void guna2CirclePictureBox9_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 6;
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

        }

        private void label201_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void TrainerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox10_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 7;
        }

        private void guna2Panel82_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 8;
        }

        private void guna2Button78_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
