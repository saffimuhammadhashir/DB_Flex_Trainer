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
    public partial class GymRegistration : Form   
    {
        private string useremeail;
        private int count = 0;
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
                string query = @"SELECT COUNT(*) AS counting FROM registered_gyms INNER JOIN GymOwner ON GymOwner.GymOwner_id = registered_gyms.GymOwner_id WHERE email = @Email;";

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

            MessageBox.Show(count.ToString());


            Timer timer = new Timer();
            timer.Interval = 3000; 
            timer.Tick += (sender, e) =>
            {

                this.Hide();
            };
            timer.Start();
        }

        private void GymRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
