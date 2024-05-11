
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

        private string userEmail, username, firstName, lastName, gender, membershipStatus, gymlocation, info, street, city, country, days, exercisename, machinename, experience_level, muscle_info, gym_name;
        private DateTime registrationDate;
        private int trainerid, performancescore, activemembers, mymembers, dietplanid, totalplan, workoutplan, weeklyschedule, numofreps = 0, session_id, step = 0, appointment_count;
        private float attendance;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
        FlowLayoutPanel obj_diet = new FlowLayoutPanel();
        public TrainerDashboard(string passingemail)
        {
            InitializeComponent();
            userEmail = passingemail;
            label8.Text = userEmail;
            guna2Button43.Visible = false;



            flowLayoutPanel17.Visible = false;
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
            flowLayoutPanel1.Visible = false;
            guna2Panel76.Visible = false;
            guna2Button43.Visible = false;
            guna2Button43.Visible = false;
            guna2Button27.Visible = true;


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
                            street = reader["street"].ToString();
                            city = reader["city"].ToString();
                            country = reader["country"].ToString();
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

                            myinformation.Text = info;
                            guna2ProgressBar1.Value = val;
                            guna2CircleProgressBar1.Value = performancescore;

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
                string query = @"SELECT *
        FROM Gym_location
        WHERE Gym_id = (
        SELECT Gym_id
        FROM Gym_hired_trainers
        WHERE trainer_id = @trainerid)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainerid", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            gymlocation = reader["Gym_location"].ToString();
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
        FROM Gym
        WHERE Gym_id = (
        SELECT Gym_id
        FROM Gym_hired_trainers
        WHERE trainer_id = @trainerid)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainerid", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            gym_name = reader["Gym_name"].ToString();
                            label64.Text = gym_name;

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
                string query = @"SELECT  * from Trainer where trainer_id=@id ;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            mymembers = reader.GetInt32(reader.GetOrdinal("numClients"));

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
                string query = @"SELECT *
FROM Gym
WHERE Gym_id = (
    SELECT Gym_id
    FROM Gym_hired_trainers
    WHERE trainer_id = @id
);
";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            activemembers = reader.GetInt32(reader.GetOrdinal("curr_active_members"));

                            guna2ProgressBar2.Value = (mymembers * 100) / activemembers;


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
                string query = @"SELECT *
FROM member_trainer_log
LEFT JOIN Member ON Member.Member_id = member_trainer_log.Member_id
LEFT JOIN USERS ON USERS.email = Member.email
WHERE USERS.email IN (SELECT email FROM USERS) and member_trainer_log.trainer_id=@id ;
";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel obj = new Guna2Panel();

                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Text = reader["email"].ToString();
                            l0.Visible = false;
                            System.Windows.Forms.Label l01 = new System.Windows.Forms.Label();
                            l01.Text = reader["Member_id"].ToString();
                            l01.Visible = false;




                            obj.Size = guna2Panel12.Size;
                            obj.FillColor = guna2Panel12.FillColor;
                            obj.ForeColor = guna2Panel12.ForeColor;
                            obj.BackColor = guna2Panel12.BackColor;
                            obj.Margin = guna2Panel12.Margin;
                            obj.BorderRadius = guna2Panel12.BorderRadius;

                            Guna2Button obj2 = new Guna2Button();
                            //obj2.Size= guna2Button21.Size;
                            //obj2.FillColor = guna2Button21.FillColor;
                            //obj2.ForeColor = guna2Button21.ForeColor;
                            //obj2.BackColor = guna2Button21.BackColor;
                            //obj2.BorderRadius= guna2Button21.BorderRadius;
                            //obj2.Margin= guna2Button21.Margin;
                            obj2.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                            obj2.Click += (sender, e) => Button_Click1(obj2.Text, l01.Text, sender, e);

                            Guna2Button obj3 = new Guna2Button();
                            //obj3.Size = guna2Button21.Size;
                            //obj3.FillColor = guna2Button21.FillColor;
                            //obj3.ForeColor = guna2Button21.ForeColor;
                            //obj3.BackColor = guna2Button21.BackColor;
                            //obj3.BorderRadius = guna2Button21.BorderRadius;
                            //obj3.Margin = guna2Button21.Margin;
                            //obj3.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                            obj3.Click += (sender, e) => Button_Click4(obj2.Text, l01.Text, sender, e);



                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Location = label85.Location;
                            l1.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                            l1.ForeColor = label85.ForeColor;
                            l1.BackColor = label85.BackColor;
                            l1.Margin = label85.Margin;
                            l1.Font = label85.Font;
                            l1.BorderStyle = label85.BorderStyle;
                            l1.Size = label85.Size;
                            l1.TextAlign = label85.TextAlign;
                            l1.Padding = label85.Padding;

                            Guna2Panel l1_0 = new Guna2Panel();
                            l1_0.Size = guna2Panel25.Size;
                            l1_0.BorderRadius = guna2Panel25.BorderRadius;
                            l1_0.Margin = guna2Panel25.Margin;


                            Guna2Button l1_1 = new Guna2Button();
                            l1_1.Location = guna2Button52.Location;
                            l1_1.Size = guna2Button52.Size;
                            l1_1.Margin = guna2Button52.Margin;
                            l1_1.ForeColor = guna2Button52.ForeColor;
                            l1_1.BackColor = guna2Button52.BackColor;
                            l1_1.FillColor = guna2Button52.FillColor;
                            l1_1.Font = guna2Button52.Font;
                            l1_1.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                            System.Windows.Forms.Label l1_2 = new System.Windows.Forms.Label();
                            l1_2.Size = label48.Size;
                            l1_2.ForeColor = label48.ForeColor;
                            l1_2.BackColor = label48.BackColor;
                            l1_2.Text = reader["Member_id"].ToString();
                            l1_2.Location = l1_2.Location;
                            l1_0.Controls.Add(l1_1);
                            l1_0.Controls.Add(l1_2);
                            l1_1.Click += (sender, e) => Button_Click10(l1_2.Text, l1_0, sender, e);
                            flowLayoutPanel13.Controls.Add(l1_0);

                            Guna2Panel l2_0 = new Guna2Panel();
                            l2_0.Size = guna2Panel25.Size;
                            l2_0.BorderRadius = guna2Panel25.BorderRadius;
                            l2_0.Margin = guna2Panel25.Margin;


                            Guna2Button l2_1 = new Guna2Button();
                            l2_1.Location = guna2Button52.Location;
                            l2_1.Size = guna2Button52.Size;
                            l2_1.Margin = guna2Button52.Margin;
                            l2_1.ForeColor = guna2Button52.ForeColor;
                            l2_1.BackColor = guna2Button52.BackColor;
                            l2_1.FillColor = guna2Button52.FillColor;
                            l2_1.Font = guna2Button52.Font;
                            l2_1.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                            System.Windows.Forms.Label l2_2 = new System.Windows.Forms.Label();
                            l2_2.Size = label48.Size;
                            l2_2.ForeColor = label48.ForeColor;
                            l2_2.BackColor = label48.BackColor;
                            l2_2.Text = reader["Member_id"].ToString();
                            l2_2.Location = l1_2.Location;
                            l2_0.Controls.Add(l2_1);
                            l2_0.Controls.Add(l2_2);
                            l2_1.Click += (sender, e) => Button_Click11(l2_2.Text, l2_0, sender, e);



                            flowLayoutPanel11.Controls.Add(l2_0);

                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Location = label83.Location;
                            l2.Text = "Email : " + reader["email"].ToString();
                            l2.ForeColor = label83.ForeColor;
                            l2.BackColor = label83.BackColor;
                            l2.Margin = label83.Margin;
                            l2.Font = label83.Font;
                            l2.BorderStyle = label83.BorderStyle;
                            l2.Size = label83.Size;
                            l2.TextAlign = label83.TextAlign;
                            l2.Padding = label83.Padding;

                            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                            l5.Location = label84.Location;
                            l5.Text = "Weight : " + reader["Weight"].ToString();
                            l5.ForeColor = label84.ForeColor;
                            l5.BackColor = label84.BackColor;
                            l5.Margin = label84.Margin;
                            l5.Font = label84.Font;
                            l5.BorderStyle = label84.BorderStyle;
                            l5.Size = label84.Size;
                            l5.TextAlign = label84.TextAlign;
                            l5.Padding = label83.Padding;

                            System.Windows.Forms.Label l6 = new System.Windows.Forms.Label();
                            l6.Location = label82.Location;
                            l6.Text = "Height : " + reader["Height"].ToString();
                            l6.ForeColor = label82.ForeColor;
                            l6.BackColor = label82.BackColor;
                            l6.Margin = label82.Margin;
                            l6.Font = label82.Font;
                            l6.BorderStyle = label82.BorderStyle;
                            l6.Size = label82.Size;
                            l6.TextAlign = label82.TextAlign;
                            l6.Padding = label82.Padding;


                            System.Windows.Forms.Label l7 = new System.Windows.Forms.Label();
                            l7.Location = label32.Location;
                            l7.Text = "Gender : " + reader["gender"].ToString();
                            l7.ForeColor = label32.ForeColor;
                            l7.BackColor = label32.BackColor;
                            l7.Margin = label32.Margin;
                            l7.Font = label32.Font;
                            l7.BorderStyle = label32.BorderStyle;
                            l7.Size = label32.Size;
                            l7.TextAlign = label32.TextAlign;
                            l7.Padding = label32.Padding;

                            Guna2Shapes l4 = new Guna2Shapes();
                            l4.Location = guna2Shapes35.Location;
                            l4.Size = guna2Shapes35.Size;
                            l4.Shape = guna2Shapes35.Shape;
                            l4.LineThickness = guna2Shapes35.LineThickness;
                            l4.ForeColor = guna2Shapes35.ForeColor;
                            l4.BackColor = guna2Shapes35.BackColor;
                            l4.FillColor = guna2Shapes35.FillColor;

                            Guna2Shapes l3 = new Guna2Shapes();
                            l3.Location = guna2Shapes34.Location;
                            l3.Size = guna2Shapes34.Size;
                            l3.Shape = guna2Shapes34.Shape;
                            l3.LineThickness = guna2Shapes34.LineThickness;
                            l3.ForeColor = guna2Shapes34.ForeColor;
                            l3.BackColor = guna2Shapes34.BackColor;
                            l3.FillColor = guna2Shapes34.FillColor;

                            Guna2Button l8 = new Guna2Button();
                            l8.Location = guna2Button26.Location;
                            l8.Size = guna2Button26.Size;
                            l8.ForeColor = guna2Button26.ForeColor;
                            l8.BackColor = guna2Button26.BackColor;
                            l8.FillColor = guna2Button26.FillColor;
                            l8.Font = guna2Button26.Font;
                            l8.Margin = guna2Button26.Margin;
                            l8.BorderRadius = guna2Button26.BorderRadius;
                            l8.Text = guna2Button26.Text;
                            l8.Click += (sender, e) => Button_Click0(l0.Text, sender, e);




                            obj.Controls.Add(l8);
                            obj.Controls.Add(l7);
                            obj.Controls.Add(l6);
                            obj.Controls.Add(l5);
                            obj.Controls.Add(l4);
                            obj.Controls.Add(l3);
                            obj.Controls.Add(l2);
                            obj.Controls.Add(l1);
                            obj.Controls.Add(l0);
                            flowLayoutPanel3.Controls.Add(obj);
                            //flowLayoutPanel20.Controls.Add(obj2);

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
                string query = @"select count(*) as counting from Diet_plan;";


                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            totalplan = reader.GetInt32(reader.GetOrdinal("counting"));
                           
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


            for (int i = 1; i <= totalplan; i++)
            {

                Guna2Panel obj = new Guna2Panel();
                FlowLayoutPanel box = new FlowLayoutPanel();
                box.FlowDirection = flowLayoutPanel6.FlowDirection;
                box.AutoSize = flowLayoutPanel6.AutoSize;
                box.Size = flowLayoutPanel6.Size;
                box.Location = flowLayoutPanel6.Location;
                box.BackColor = flowLayoutPanel6.BackColor;
                box.ForeColor = flowLayoutPanel6.ForeColor;
                box.Padding = flowLayoutPanel6.Padding;


                string breakfast = "", lunch = "", dinner = "";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @"SELECT DISTINCT
    Diet_plan.Diet_id,
    Diet_plan.trainer_id,
    Diet_plan.num_meals,
    Diet_plan.B AS Breakfast,
    Diet_plan.L AS Lunch,
    Diet_plan.D AS Dinner,
    USERS.firstName,
	USERS.lastName,
    USERS.email,
    diet_plan_objectives.objective
FROM 
    Diet_plan
INNER JOIN 
    Trainer ON Trainer.trainer_id = Diet_plan.trainer_id
INNER JOIN 
    USERS ON USERS.email = Trainer.email
INNER JOIN 
    diet_plan_objectives ON diet_plan_objectives.Diet_id = Diet_plan.Diet_id
where Diet_plan.Diet_id=@id;   
";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", i);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                                l0.Size = label143.Size;
                                l0.ForeColor = label143.ForeColor;
                                l0.BackColor = label143.BackColor;
                                l0.Font = label143.Font;
                                l0.Text = label143.Text + " " + i.ToString();
                                l0.Location = label143.Location;
                                l0.Margin = label143.Margin;
                                breakfast = reader["Breakfast"].ToString();
                                lunch = reader["Lunch"].ToString();
                                dinner = reader["Dinner"].ToString();
                                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                                l1.Size = label143.Size;
                                l1.Text = label144.Text + "   " + reader["firstName"] + " " + reader["lastName"];
                                l1.Location = label144.Location;
                                l1.Font = label144.Font;
                                l1.AutoSize = false;
                                l1.BackColor = label144.BackColor;
                                l1.ForeColor = label144.ForeColor;
                                l1.Location = label144.Location;
                                l1.Margin = label144.Margin;

                                Guna2Shapes l2 = new Guna2Shapes();
                                l2.Size = guna2Shapes51.Size;
                                l2.LineThickness = guna2Shapes51.LineThickness;
                                l2.BackColor = guna2Shapes51.BackColor;
                                l2.ForeColor = guna2Shapes51.ForeColor;
                                l2.Location = guna2Shapes51.Location;
                                l2.Margin = guna2Shapes51.Margin;
                                l2.FillColor = guna2Shapes51.FillColor;
                                l2.Shape = guna2Shapes51.Shape;

                                System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                                l3.Size = label181.Size;
                                l3.Text = label181.Text + "   " + reader["objective"];
                                l3.Location = label181.Location;
                                l3.Font = label181.Font;
                                l3.AutoSize = false;
                                l3.BackColor = label181.BackColor;
                                l3.ForeColor = label181.ForeColor;
                                l3.Location = label181.Location;
                                l3.Margin = label181.Margin;

                                System.Windows.Forms.Label l4 = new System.Windows.Forms.Label();
                                l4.Size = label148.Size;
                                l4.Text = label148.Text;
                                l4.Location = label148.Location;
                                l4.Font = label148.Font;
                                l4.AutoSize = false;
                                l4.BackColor = label148.BackColor;
                                l4.ForeColor = label148.ForeColor;
                                l4.Location = label148.Location;
                                l4.Margin = label148.Margin;


                                System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                                l5.Size = label147.Size;
                                l5.Text = label147.Text;
                                l5.Location = label147.Location;
                                l5.Font = label147.Font;
                                l5.AutoSize = false;
                                l5.BackColor = label147.BackColor;
                                l5.ForeColor = label147.ForeColor;
                                l5.Location = label147.Location;
                                l5.Margin = label147.Margin;

                                Guna2Shapes l6 = new Guna2Shapes();
                                l6.Size = guna2Shapes53.Size;
                                l6.LineThickness = guna2Shapes53.LineThickness;
                                l6.BackColor = guna2Shapes53.BackColor;
                                l6.ForeColor = guna2Shapes53.ForeColor;
                                l6.Location = guna2Shapes53.Location;
                                l6.Margin = guna2Shapes53.Margin;
                                l6.FillColor = guna2Shapes53.FillColor;
                                l6.Shape = guna2Shapes53.Shape;

                                Guna2Shapes l7 = new Guna2Shapes();
                                l7.Size = guna2Shapes52.Size;
                                l7.LineThickness = guna2Shapes52.LineThickness;
                                l7.BackColor = guna2Shapes52.BackColor;
                                l7.ForeColor = guna2Shapes52.ForeColor;
                                l7.Location = guna2Shapes52.Location;
                                l7.Margin = guna2Shapes52.Margin;
                                l7.FillColor = guna2Shapes52.FillColor;
                                l7.Shape = guna2Shapes52.Shape;

                                Guna2Shapes l8 = new Guna2Shapes();
                                l8.Size = guna2Shapes50.Size;
                                l8.LineThickness = guna2Shapes50.LineThickness;
                                l8.BackColor = guna2Shapes50.BackColor;
                                l8.ForeColor = guna2Shapes50.ForeColor;
                                l8.Location = guna2Shapes50.Location;
                                l8.Margin = guna2Shapes50.Margin;
                                l8.FillColor = guna2Shapes50.FillColor;
                                l8.Shape = guna2Shapes50.Shape;
                                l8.PolygonSides = guna2Shapes50.PolygonSides;

                                obj.Size = guna2Panel24.Size;
                                obj.Width = guna2Panel24.Width;
                                obj.Height = guna2Panel24.Height;
                                obj.FillColor = guna2Panel24.FillColor;
                                obj.BackColor = guna2Panel24.BackColor;
                                obj.ForeColor = guna2Panel24.ForeColor;
                                obj.BorderRadius = guna2Panel24.BorderRadius;
                                obj.BorderStyle = guna2Panel24.BorderStyle;
                                obj.Margin = guna2Panel24.Margin;

                                obj.Controls.Add(l8);
                                obj.Controls.Add(l7);
                                obj.Controls.Add(l6);
                                obj.Controls.Add(l5);
                                obj.Controls.Add(l4);
                                obj.Controls.Add(l3);
                                obj.Controls.Add(l2);
                                obj.Controls.Add(l1);
                                obj.Controls.Add(l0);

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
                    string query = @"select*from Food where food_name=@id;;
                ";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", breakfast);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Guna2Panel obj2 = new Guna2Panel();
                                obj2.Size = guna2Panel28.Size;
                                obj2.FillColor = guna2Panel28.FillColor;
                                obj2.BackColor = guna2Panel28.BackColor;
                                obj2.ForeColor = guna2Panel28.ForeColor;
                                obj2.BorderRadius = guna2Panel28.BorderRadius;

                                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                                l1.Text = reader["food_name"].ToString();
                                l1.Location = label154.Location;
                                l1.Size = label154.Size;
                                l1.ForeColor = label154.ForeColor;
                                l1.BackColor = label154.BackColor;
                                l1.TextAlign = label154.TextAlign;
                                l1.Margin = label154.Margin;
                                l1.Font = label154.Font;

                                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                                l2.Text = "Breakfast";
                                l2.Location = label153.Location;
                                l2.Size = label153.Size;
                                l2.ForeColor = label153.ForeColor;
                                l2.BackColor = label153.BackColor;
                                l2.TextAlign = label153.TextAlign;
                                l2.Margin = label153.Margin;
                                l2.Font = label153.Font;

                                Guna2Button l3 = new Guna2Button();
                                l3.Location = guna2Button23.Location;
                                l3.Size = guna2Button23.Size;
                                l3.ForeColor = guna2Button23.ForeColor;
                                l3.BackColor = guna2Button23.BackColor;
                                l3.TextAlign = guna2Button23.TextAlign;
                                l3.Margin = guna2Button23.Margin;
                                l3.Font = guna2Button23.Font;
                                l3.BorderRadius = guna2Button23.BorderRadius;
                                l3.Text = guna2Button23.Text;
                                l3.Click += (sender, e) => Button_Click3(l1.Text, l2.Text, sender, e);

                                obj2.Controls.Add(l1);
                                obj2.Controls.Add(l2);
                                obj2.Controls.Add(l3);
                                box.Controls.Add(obj2);
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
                    string query = @"select*from Food where food_name=@id;;
                ";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", lunch);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Guna2Panel obj2 = new Guna2Panel();
                                obj2.Size = guna2Panel28.Size;
                                obj2.FillColor = guna2Panel28.FillColor;
                                obj2.BackColor = guna2Panel28.BackColor;
                                obj2.ForeColor = guna2Panel28.ForeColor;
                                obj2.BorderRadius = guna2Panel28.BorderRadius;

                                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                                l1.Text = reader["food_name"].ToString();
                                l1.Location = label154.Location;
                                l1.Size = label154.Size;
                                l1.ForeColor = label154.ForeColor;
                                l1.BackColor = label154.BackColor;
                                l1.TextAlign = label154.TextAlign;
                                l1.Margin = label154.Margin;
                                l1.Font = label154.Font;

                                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                                l2.Text = "Lunch";
                                l2.Location = label153.Location;
                                l2.Size = label153.Size;
                                l2.ForeColor = label153.ForeColor;
                                l2.BackColor = label153.BackColor;
                                l2.TextAlign = label153.TextAlign;
                                l2.Margin = label153.Margin;
                                l2.Font = label153.Font;

                                Guna2Button l3 = new Guna2Button();
                                l3.Location = guna2Button23.Location;
                                l3.Size = guna2Button23.Size;
                                l3.ForeColor = guna2Button23.ForeColor;
                                l3.BackColor = guna2Button23.BackColor;
                                l3.TextAlign = guna2Button23.TextAlign;
                                l3.Margin = guna2Button23.Margin;
                                l3.Font = guna2Button23.Font;
                                l3.BorderRadius = guna2Button23.BorderRadius;
                                l3.Text = guna2Button23.Text;
                                l3.Click += (sender, e) => Button_Click3(l1.Text, l2.Text, sender, e);

                                obj2.Controls.Add(l1);
                                obj2.Controls.Add(l2);
                                obj2.Controls.Add(l3);
                                box.Controls.Add(obj2);
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
                    string query = @"select*from Food where food_name=@id;;
                ";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", dinner);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Guna2Panel obj2 = new Guna2Panel();
                                obj2.Size = guna2Panel28.Size;
                                obj2.FillColor = guna2Panel28.FillColor;
                                obj2.BackColor = guna2Panel28.BackColor;
                                obj2.ForeColor = guna2Panel28.ForeColor;
                                obj2.BorderRadius = guna2Panel28.BorderRadius;

                                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                                l1.Text = reader["food_name"].ToString();
                                l1.Location = label154.Location;
                                l1.Size = label154.Size;
                                l1.ForeColor = label154.ForeColor;
                                l1.BackColor = label154.BackColor;
                                l1.TextAlign = label154.TextAlign;
                                l1.Margin = label154.Margin;
                                l1.Font = label154.Font;

                                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                                l2.Text = "Dinner";
                                l2.Location = label153.Location;
                                l2.Size = label153.Size;
                                l2.ForeColor = label153.ForeColor;
                                l2.BackColor = label153.BackColor;
                                l2.TextAlign = label153.TextAlign;
                                l2.Margin = label153.Margin;
                                l2.Font = label153.Font;

                                Guna2Button l3 = new Guna2Button();
                                l3.Location = guna2Button23.Location;
                                l3.Size = guna2Button23.Size;
                                l3.ForeColor = guna2Button23.ForeColor;
                                l3.BackColor = guna2Button23.BackColor;
                                l3.TextAlign = guna2Button23.TextAlign;
                                l3.Margin = guna2Button23.Margin;
                                l3.Font = guna2Button23.Font;
                                l3.BorderRadius = guna2Button23.BorderRadius;
                                l3.Text = guna2Button23.Text;
                                l3.Click += (sender, e) => Button_Click3(l1.Text, l2.Text, sender, e);

                                obj2.Controls.Add(l1);
                                obj2.Controls.Add(l2);
                                obj2.Controls.Add(l3);
                                box.Controls.Add(obj2);
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



                obj.Controls.Add(box);
                flowLayoutPanel5.Controls.Add(obj);

            }

            guna2Panel43.Visible = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select *  from Appointment 
inner join Member on Member.Member_id=Appointment.member_id
inner join USERS on  Member.email =USERS.email where trainer_id=@id;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel l1 = new Guna2Panel();
                            l1.Size = guna2Panel13.Size;
                            l1.BackColor = guna2Panel13.BackColor;
                            l1.FillColor = guna2Panel13.FillColor;
                            l1.Margin = guna2Panel13.Margin;
                            l1.BorderRadius = guna2Panel13.BorderRadius;


                            Guna2Button b1 = new Guna2Button();
                            b1.Size = guna2Button48.Size;
                            b1.BackColor = guna2Button48.BackColor;
                            b1.Text = reader["firstName"].ToString();
                            b1.Font = guna2Button48.Font;
                            b1.Location = guna2Button48.Location;
                            b1.Margin = guna2Button48.Margin;
                            b1.FillColor = guna2Button48.FillColor;
                            b1.BorderRadius = guna2Button48.BorderRadius;
                            b1.ForeColor = guna2Button48.ForeColor;

                            System.Windows.Forms.Label b2 = new System.Windows.Forms.Label();
                            b2.Size = label41.Size;
                            b2.Font = label41.Font;
                            b2.Text = reader["email"].ToString();
                            b2.Location = label41.Location;
                            b2.Visible = label141.Visible;

                            System.Windows.Forms.Label b3 = new System.Windows.Forms.Label();
                            b3.Size = label41.Size;
                            b3.Font = label41.Font;
                            b3.Text = reader["Date"].ToString();
                            b3.Location = label41.Location;
                            b3.Visible = label141.Visible;

                            System.Windows.Forms.Label b4 = new System.Windows.Forms.Label();
                            b4.Size = label41.Size;
                            b4.Font = label41.Font;
                            b4.Text = reader["appointment_id"].ToString();
                            b4.Location = label41.Location;
                            b4.Visible = label141.Visible;

                            System.Windows.Forms.Label b5 = new System.Windows.Forms.Label();
                            b5.Size = label41.Size;
                            b5.Font = label41.Font;
                            b5.Text = reader["status"].ToString();
                            b5.Location = label41.Location;
                            b5.Visible = label141.Visible;

                            System.Windows.Forms.Label b6 = new System.Windows.Forms.Label();
                            b6.Size = label41.Size;
                            b6.Font = label41.Font;
                            b6.Text = reader["Time"].ToString();
                            b6.Location = label41.Location;
                            b6.Visible = label141.Visible;


                            if (b5.Text == "Waiting")
                            {
                                b1.Click += (sender, e) => Button_Click6(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, sender, e);
                                l1.Controls.Add(b1);
                                l1.Controls.Add(b2);
                                flowLayoutPanel15.Controls.Add(l1);
                            }
                            else if (b5.Text == "Accepted")
                            {
                                b1.Click += (sender, e) => Button_Click7(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, b6.Text, sender, e);
                                l1.Controls.Add(b1);
                                l1.Controls.Add(b2);
                                flowLayoutPanel7.Controls.Add(l1);
                            }



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

                string query = @"select *  from Appointment 
inner join Member on Member.Member_id=Appointment.member_id
inner join USERS on  Member.email =USERS.email where trainer_id=@id;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel l1 = new Guna2Panel();
                            l1.Size = guna2Panel13.Size;
                            l1.BackColor = guna2Panel13.BackColor;
                            l1.FillColor = guna2Panel13.FillColor;
                            l1.Margin = guna2Panel13.Margin;
                            l1.BorderRadius = guna2Panel13.BorderRadius;


                            Guna2Button b1 = new Guna2Button();
                            b1.Size = guna2Button48.Size;
                            b1.BackColor = guna2Button48.BackColor;
                            b1.Text = reader["firstName"].ToString();
                            b1.Font = guna2Button48.Font;
                            b1.Location = guna2Button48.Location;
                            b1.Margin = guna2Button48.Margin;
                            b1.FillColor = guna2Button48.FillColor;
                            b1.BorderRadius = guna2Button48.BorderRadius;
                            b1.ForeColor = guna2Button48.ForeColor;

                            System.Windows.Forms.Label b2 = new System.Windows.Forms.Label();
                            b2.Size = label41.Size;
                            b2.Font = label41.Font;
                            b2.Text = reader["email"].ToString();
                            b2.Location = label41.Location;
                            b2.Visible = label141.Visible;

                            System.Windows.Forms.Label b3 = new System.Windows.Forms.Label();
                            b3.Size = label41.Size;
                            b3.Font = label41.Font;
                            b3.Text = reader["Date"].ToString();
                            b3.Location = label41.Location;
                            b3.Visible = label141.Visible;

                            System.Windows.Forms.Label b4 = new System.Windows.Forms.Label();
                            b4.Size = label41.Size;
                            b4.Font = label41.Font;
                            b4.Text = reader["appointment_id"].ToString();
                            b4.Location = label41.Location;
                            b4.Visible = label141.Visible;

                            System.Windows.Forms.Label b5 = new System.Windows.Forms.Label();
                            b5.Size = label41.Size;
                            b5.Font = label41.Font;
                            b5.Text = reader["status"].ToString();
                            b5.Location = label41.Location;
                            b5.Visible = label141.Visible;

                            System.Windows.Forms.Label b6 = new System.Windows.Forms.Label();
                            b6.Size = label41.Size;
                            b6.Font = label41.Font;
                            b6.Text = reader["Time"].ToString();
                            b6.Location = label41.Location;
                            b6.Visible = label141.Visible;



                            b1.Click += (sender, e) => Button_Click8(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, b6.Text, sender, e);
                            l1.Controls.Add(b1);
                            l1.Controls.Add(b2);
                            flowLayoutPanel9.Controls.Add(l1);




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
                command.Parameters.AddWithValue("@id", trainerid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guna2Panel l1 = new Guna2Panel();
                            l1.Size = guna2Panel16.Size;
                            l1.BackColor = guna2Panel16.BackColor;
                            l1.FillColor = guna2Panel16.FillColor;
                            l1.Margin = guna2Panel16.Margin;
                            l1.BorderRadius = guna2Panel16.BorderRadius;


                            Guna2Button b1 = new Guna2Button();
                            b1.Size = guna2Button49.Size;
                            b1.BackColor = guna2Button49.BackColor;
                            b1.Text = reader["member_firstName"].ToString();
                            b1.Font = guna2Button49.Font;
                            b1.Location = guna2Button49.Location;
                            b1.Margin = guna2Button49.Margin;
                            b1.FillColor = guna2Button49.FillColor;
                            b1.BorderRadius = guna2Button49.BorderRadius;
                            b1.ForeColor = guna2Button49.ForeColor;

                            System.Windows.Forms.Label b2 = new System.Windows.Forms.Label();
                            b2.Size = label52.Size;
                            b2.Font = label52.Font;
                            b2.Text = reader["member_lastName"].ToString();
                            b2.Location = label41.Location;
                            b2.Visible = label141.Visible;

                            System.Windows.Forms.Label b3 = new System.Windows.Forms.Label();
                            b3.Size = label52.Size;
                            b3.Font = label52.Font;
                            b3.Text = reader["member_email"].ToString();
                            b3.Location = label52.Location;
                            b3.Visible = label52.Visible;

                            System.Windows.Forms.Label b4 = new System.Windows.Forms.Label();
                            b4.Size = label52.Size;
                            b4.Font = label52.Font;
                            b4.Text = reader["comment"].ToString();
                            b4.Location = label52.Location;
                            b4.Visible = label52.Visible;

                            System.Windows.Forms.Label b5 = new System.Windows.Forms.Label();
                            b5.Size = label52.Size;
                            b5.Font = label52.Font;
                            b5.Text = reader["rating"].ToString();
                            b5.Location = label52.Location;
                            b5.Visible = label52.Visible;



                            b1.Click += (sender, e) => Button_Click9(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, sender, e);
                            l1.Controls.Add(b1);
                            flowLayoutPanel16.Controls.Add(l1);
                            l1.Controls.Add(b2);




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




            guna2Panel12.Visible = guna2Panel24.Visible = guna2Panel13.Visible = false;
            guna2Panel22.Visible = flowLayoutPanel2.Visible = guna2Button28.Visible = guna2Button38.Visible = false;
            guna2Button75.Visible = false;
            guna2Button76.Visible = guna2Panel16.Visible = false;

        }

        private void Button_Click0(string email, object sender, EventArgs e)
        {
            // Open the form and pass email dynamically
            OpenFormWithEmail(email);
        }
        private void Button_Click1(string name, string id, object sender, EventArgs e)
        {
            label33.Text = id;

        }
        private void Button_Click4(string name, string id, object sender, EventArgs e)
        {
            label35.Text = id;

        }
        private void Button_Click5(string name, string id, object sender, EventArgs e)
        {
            label35.Text = id;

        }
        private void Button_Click6(string name, string email, string date, string id, string status, object sender, EventArgs e)
        {
            label297.Text = "Name: " + name;
            label294.Text = "Email: " + email;
            label43.Text = id;
            label296.Text = date;
            guna2Button75.Visible = true;
            guna2Button76.Visible = true;
            label51.Text = email;
        }

        private void Button_Click7(string name, string email, string date, string id, string status, string time, object sender, EventArgs e)
        {
            label50.Text = "Name: " + name;
            label45.Text = "Email: " + email;
            label49.Text = date;
            label54.Text = "Time: " + time;
        }

        private void Button_Click8(string name, string email, string date, string id, string status, string time, object sender, EventArgs e)
        {
            label57.Text = "Name: " + name;
            label55.Text = "Email: " + email;
            label56.Text = date;
            label44.Text = "Time: " + time;
            label71.Text = "Status: " + status;

        }
        private void Button_Click9(string fname, string lname, string email, string comment, string rating, object sender, EventArgs e)
        {
            label302.Text = "Name: " + fname + " " + lname;
            label300.Text = "Email: " + email;
            label299.Text = "Comment: " + comment;
            label58.Text = "Rating: " + rating + "/5";

        }
        private void Button_Click10(string fname, Guna2Panel obj, object sender, EventArgs e)
        {
            obj.Visible = false;
            int chk = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select count(*) as counting from diet_Member where member_id=@mem_id;";


                SqlCommand command = new SqlCommand(query, connection);
                int memId;
                if (int.TryParse(fname, out memId))
                {
                    command.Parameters.AddWithValue("@mem_id", memId);
                }

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            chk = reader.GetInt32(reader.GetOrdinal("counting"));

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO diet_Member (member_id, Diet_id) VALUES (@mem_id, @id);";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand

                        int memId;
                        if (int.TryParse(fname, out memId))
                        {
                            command.Parameters.AddWithValue("@mem_id", memId);
                        }
                        command.Parameters.AddWithValue("@id", dietplanid);

                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
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
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"Update  diet_Member SET Diet_id=@id WHERE member_id=@mem_id;";



                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand

                        int memId;
                        if (int.TryParse(fname, out memId))
                        {
                            command.Parameters.AddWithValue("@mem_id", memId);
                        }
                        command.Parameters.AddWithValue("@id", dietplanid);

                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
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


        private void Button_Click11(string fname, Guna2Panel obj, object sender, EventArgs e)
        {
            obj.Visible = false;
            int chk = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select count(*) as counting from workout_Member where member_id=@mem_id;";


                SqlCommand command = new SqlCommand(query, connection);
                int memId;
                if (int.TryParse(fname, out memId))
                {
                    command.Parameters.AddWithValue("@mem_id", memId);
                }

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            chk = reader.GetInt32(reader.GetOrdinal("counting"));

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO workout_Member (member_id, plan_id) VALUES (@mem_id, @id);";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand

                        int memId;
                        if (int.TryParse(fname, out memId))
                        {
                            command.Parameters.AddWithValue("@mem_id", memId);
                        }
                        command.Parameters.AddWithValue("@id", workoutplan);

                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
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
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"Update  workout_Member SET plan_id=@id WHERE member_id=@mem_id;";



                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand

                        int memId;
                        if (int.TryParse(fname, out memId))
                        {
                            command.Parameters.AddWithValue("@mem_id", memId);
                        }
                        command.Parameters.AddWithValue("@id", workoutplan);

                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
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

        private void Button_Click3(string meal, string time, object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 7;
            label391.Text = meal;
            label392.Text = time;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT DISTINCT
                            food_name,
                            protien,
                            carbohydrates,
                            calories,
                            fibers,
                            fats

                        FROM 
                            Food f
                        WHERE 
                            food_name = @name";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", meal);
             
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            label393.Text = reader["protien"].ToString();
                            label394.Text = reader["carbohydrates"].ToString();
                            label395.Text = reader["fibers"].ToString();
                            label396.Text = reader["fats"].ToString();
                            //label390.Text = reader["allergen"] != DBNull.Value ? reader["allergen"].ToString() : "";
                            label46.Text = reader["calories"].ToString() ;
                        }
                    }
                    else
                    {

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    // Log the exception or display an error message to the user
                }
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"select*from Potential_Allergens where food_name = @name";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", meal);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            label390.Text = reader["allergen"].ToString();                      
                        }
                    }
                    else
                    {

                        label390.Text = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    label390.Text = "";
                    // Log the exception or display an error message to the user
                }
            }
        }
        private void OpenFormWithEmail(string email)
        {

            Form next = new Trainee_details(email);
            next.Show();

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
            int totalworkoutplans = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to retrieve gym location based on gymId
                string query = @"select count(*) as counting from Workout_Plan;";


                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            totalworkoutplans = reader.GetInt32(reader.GetOrdinal("counting"));

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
            for (int i = 1; i <= totalworkoutplans; i++)
            {
                string fullname = "";
                int week_shd = 0;
                int exp_lvl = 0;


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @" select Workout_Plan.plan_id, USERS.firstName,USERS.lastName,Workout_Plan.weekly_schedule,Workout_Plan.experience_level from Workout_Plan INNER JOIN Trainer on Trainer.Trainer_id = Workout_Plan.trainer_id INNER JOIN USERS on Trainer.email = USERS.email where Workout_Plan.plan_id=@id;
";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", i);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                fullname = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                                string exp = reader["experience_level"].ToString();
                                int.TryParse(exp, out exp_lvl);
                                string week = reader["weekly_schedule"].ToString();
                                int.TryParse(week, out week_shd);
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
                Guna2Panel obj = new Guna2Panel();
                obj.Size = guna2Panel43.Size;
                obj.Margin = guna2Panel43.Margin;
                obj.FillColor = guna2Panel43.FillColor;
                obj.ForeColor = guna2Panel43.ForeColor;
                obj.BackColor = guna2Panel43.BackColor;
                obj.BorderRadius = guna2Panel43.BorderRadius;

                System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                l0.Size = label251.Size;
                l0.Margin = label251.Margin;
                l0.BackColor = label251.BackColor;
                l0.ForeColor = label251.ForeColor;
                l0.Font = label251.Font;
                l0.Text = label251.Text + " " + i.ToString();
                l0.Location = label251.Location;

                Guna2Shapes l1 = new Guna2Shapes();
                l1.Size = guna2Shapes77.Size;
                l1.Shape = guna2Shapes77.Shape;
                l1.BackColor = guna2Shapes77.BackColor;
                l1.ForeColor = guna2Shapes77.ForeColor;
                l1.LineThickness = guna2Shapes77.LineThickness;
                l1.Location = guna2Shapes77.Location;
                l1.Margin = guna2Shapes77.Margin;
                l1.FillColor = guna2Shapes77.FillColor;

                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                l2.Size = label250.Size;
                l2.Margin = label250.Margin;
                l2.BackColor = label250.BackColor;
                l2.ForeColor = label250.ForeColor;
                l2.Font = label250.Font;
                l2.Text = label250.Text + " " + fullname.ToString();
                l2.Location = label250.Location;


                System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                l3.Size = label223.Size;
                l3.Margin = label223.Margin;
                l3.BackColor = label223.BackColor;
                l3.ForeColor = label223.ForeColor;
                l3.Font = label223.Font;
                l3.Text = label223.Text + " " + week_shd.ToString() + "Days a week";
                l3.Location = label223.Location;

                System.Windows.Forms.Label l31 = new System.Windows.Forms.Label();
                l31.Size = label222.Size;
                l31.Margin = label222.Margin;
                l31.BackColor = label222.BackColor;
                l31.ForeColor = label222.ForeColor;
                l31.Font = label222.Font;
                if (exp_lvl == 0)
                {
                    l31.Text = label222.Text + " Beginner";

                }
                else if (exp_lvl == 1)
                {
                    l31.Text = label222.Text + " Intermediate";

                }
                else if (exp_lvl == 2)
                {
                    l31.Text = label222.Text + " Advanced";

                }
                l31.Location = label222.Location;

                System.Windows.Forms.Label l4 = new System.Windows.Forms.Label();
                l4.Size = label224.Size;
                l4.Margin = label224.Margin;
                l4.BackColor = label224.BackColor;
                l4.ForeColor = label224.ForeColor;
                l4.Font = label224.Font;
                l4.Text = label224.Text;
                l4.Location = label224.Location;

                System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                l5.Size = label225.Size;
                l5.Margin = label225.Margin;
                l5.BackColor = label225.BackColor;
                l5.ForeColor = label225.ForeColor;
                l5.Font = label225.Font;
                l5.Text = label225.Text;
                l5.Location = label225.Location;

                System.Windows.Forms.Label l6 = new System.Windows.Forms.Label();
                l6.Size = label220.Size;
                l6.Margin = label220.Margin;
                l6.BackColor = label220.BackColor;
                l6.ForeColor = label220.ForeColor;
                l6.Font = label220.Font;
                l6.Text = label220.Text;
                l6.Location = label220.Location;

                System.Windows.Forms.Label l7 = new System.Windows.Forms.Label();
                l7.Size = label221.Size;
                l7.Margin = label221.Margin;
                l7.BackColor = label221.BackColor;
                l7.ForeColor = label221.ForeColor;
                l7.Font = label221.Font;
                l7.Text = label221.Text;
                l7.Location = label221.Location;


                Guna2Shapes l8 = new Guna2Shapes();
                l8.Size = guna2Shapes74.Size;
                l8.Shape = guna2Shapes74.Shape;
                l8.BackColor = guna2Shapes74.BackColor;
                l8.ForeColor = guna2Shapes74.ForeColor;
                l8.LineThickness = guna2Shapes74.LineThickness;
                l8.Location = guna2Shapes74.Location;
                l8.Margin = guna2Shapes74.Margin;
                l8.FillColor = guna2Shapes74.FillColor;

                Guna2Shapes l9 = new Guna2Shapes();
                l9.Size = guna2Shapes75.Size;
                l9.Shape = guna2Shapes75.Shape;
                l9.BackColor = guna2Shapes75.BackColor;
                l9.ForeColor = guna2Shapes75.ForeColor;
                l9.LineThickness = guna2Shapes75.LineThickness;
                l9.Location = guna2Shapes75.Location;
                l9.Margin = guna2Shapes75.Margin;
                l9.FillColor = guna2Shapes75.FillColor;
                l9.PolygonSides = guna2Shapes75.PolygonSides;


                Guna2Shapes l10 = new Guna2Shapes();
                l10.Size = guna2Shapes70.Size;
                l10.Shape = guna2Shapes70.Shape;
                l10.BackColor = guna2Shapes70.BackColor;
                l10.ForeColor = guna2Shapes70.ForeColor;
                l10.LineThickness = guna2Shapes70.LineThickness;
                l10.Location = guna2Shapes70.Location;
                l10.Margin = guna2Shapes70.Margin;
                l10.FillColor = guna2Shapes70.FillColor;
                l10.PolygonSides = guna2Shapes70.PolygonSides;


                Guna2Shapes l11 = new Guna2Shapes();
                l11.Size = guna2Shapes72.Size;
                l11.Shape = guna2Shapes72.Shape;
                l11.BackColor = guna2Shapes72.BackColor;
                l11.ForeColor = guna2Shapes72.ForeColor;
                l11.LineThickness = guna2Shapes72.LineThickness;
                l11.Location = guna2Shapes72.Location;
                l11.Margin = guna2Shapes72.Margin;
                l11.FillColor = guna2Shapes72.FillColor;
                l11.PolygonSides = guna2Shapes72.PolygonSides;


                Guna2Shapes l12 = new Guna2Shapes();
                l12.Size = guna2Shapes71.Size;
                l12.Shape = guna2Shapes71.Shape;
                l12.BackColor = guna2Shapes71.BackColor;
                l12.ForeColor = guna2Shapes71.ForeColor;
                l12.LineThickness = guna2Shapes71.LineThickness;
                l12.Location = guna2Shapes71.Location;
                l12.Margin = guna2Shapes71.Margin;
                l12.FillColor = guna2Shapes71.FillColor;
                l12.PolygonSides = guna2Shapes71.PolygonSides;

                Guna2Shapes l13 = new Guna2Shapes();
                l13.Size = guna2Shapes73.Size;
                l13.Shape = guna2Shapes73.Shape;
                l13.BackColor = guna2Shapes73.BackColor;
                l13.ForeColor = guna2Shapes73.ForeColor;
                l13.LineThickness = guna2Shapes73.LineThickness;
                l13.Location = guna2Shapes73.Location;
                l13.Margin = guna2Shapes73.Margin;
                l13.FillColor = guna2Shapes73.FillColor;
                l13.PolygonSides = guna2Shapes73.PolygonSides;


                Guna2Shapes l14 = new Guna2Shapes();
                l14.Size = guna2Shapes76.Size;
                l14.Shape = guna2Shapes76.Shape;
                l14.BackColor = guna2Shapes76.BackColor;
                l14.ForeColor = guna2Shapes76.ForeColor;
                l14.LineThickness = guna2Shapes76.LineThickness;
                l14.Location = guna2Shapes76.Location;
                l14.Margin = guna2Shapes76.Margin;
                l14.FillColor = guna2Shapes76.FillColor;
                l14.PolygonSides = guna2Shapes76.PolygonSides;

                FlowLayoutPanel l15 = new FlowLayoutPanel();
                l15.Size = flowLayoutPanel10.Size;
                l15.Location = flowLayoutPanel10.Location;
                l15.Margin = flowLayoutPanel10.Margin;
                l15.BackColor = flowLayoutPanel10.BackColor;
                l15.ForeColor = flowLayoutPanel10.ForeColor;
                l15.Padding = flowLayoutPanel10.Padding;
                l15.FlowDirection = flowLayoutPanel10.FlowDirection;
                l15.AutoSize = flowLayoutPanel10.AutoSize;
                l15.AutoScroll = flowLayoutPanel10.AutoScroll;


                obj.Controls.Add(l31);
                obj.Controls.Add(l14);
                obj.Controls.Add(l13);
                obj.Controls.Add(l12);
                obj.Controls.Add(l11);
                obj.Controls.Add(l10);
                obj.Controls.Add(l9);
                obj.Controls.Add(l8);
                obj.Controls.Add(l7);
                obj.Controls.Add(l6);
                obj.Controls.Add(l5);
                obj.Controls.Add(l4);
                obj.Controls.Add(l3);
                obj.Controls.Add(l2);
                obj.Controls.Add(l1);
                obj.Controls.Add(l0);
                obj.Controls.Add(l15);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @"SELECT 
    steps.plan_id,
    steps.session_id,
    steps.step,
    steps.exercise_name AS step_exercise_name,
    e.difficulty,
    e.num_reps,
    Machine.Machine_name,
    Muscle.Muscle_name
FROM 
    steps
INNER JOIN 
    exercise e ON e.exercise_name = steps.exercise_name
INNER JOIN 
    Machine ON e.exercise_name = Machine.exercise_name
INNER JOIN 
    Muscle ON e.exercise_name = Muscle.exercise_name
where plan_id=@id";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", i);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                Guna2Panel a1 = new Guna2Panel();
                                a1.Size = guna2Panel44.Size;
                                a1.FillColor = guna2Panel44.FillColor;
                                a1.Font = guna2Panel44.Font;
                                a1.Margin = guna2Panel44.Margin;
                                a1.BackColor = guna2Panel44.BackColor;
                                a1.BorderRadius = guna2Panel44.BorderRadius;

                                System.Windows.Forms.Label a2 = new System.Windows.Forms.Label();
                                a2.Size = label229.Size;
                                a2.Margin = label229.Margin;
                                a2.BackColor = label229.BackColor;
                                a2.ForeColor = label229.ForeColor;
                                a2.Font = label229.Font;
                                a2.Text = reader["step_exercise_name"].ToString();
                                a2.Location = label229.Location;

                                System.Windows.Forms.Label a3 = new System.Windows.Forms.Label();
                                a3.Size = label228.Size;
                                a3.Margin = label228.Margin;
                                a3.BackColor = label228.BackColor;
                                a3.ForeColor = label228.ForeColor;
                                a3.Font = label228.Font;
                                a3.Text = reader["num_reps"].ToString();
                                a3.Location = label228.Location;


                                System.Windows.Forms.Label a4 = new System.Windows.Forms.Label();
                                a4.Size = label227.Size;
                                a4.Margin = label227.Margin;
                                a4.BackColor = label227.BackColor;
                                a4.ForeColor = label227.ForeColor;
                                a4.Font = label227.Font;
                                a4.Text = reader["Machine_name"].ToString();
                                a4.Location = label227.Location;


                                System.Windows.Forms.Label a5 = new System.Windows.Forms.Label();
                                a5.Size = label226.Size;
                                a5.Margin = label226.Margin;
                                a5.BackColor = label226.BackColor;
                                a5.ForeColor = label226.ForeColor;
                                a5.Font = label226.Font;
                                a5.Text = reader["Muscle_name"].ToString();
                                a5.Location = label226.Location;


                                System.Windows.Forms.Label a6 = new System.Windows.Forms.Label();
                                a6.Size = label72.Size;
                                a6.Margin = label72.Margin;
                                a6.BackColor = label72.BackColor;
                                a6.ForeColor = label72.ForeColor;
                                a6.Font = label72.Font;
                                a6.Text = reader["difficulty"].ToString();
                                a6.Location = label72.Location;



                                System.Windows.Forms.Label a7 = new System.Windows.Forms.Label();
                                a7.Size = label76.Size;
                                a7.Margin = label76.Margin;
                                a7.BackColor = label76.BackColor;
                                a7.ForeColor = label76.ForeColor;
                                a7.Font = label76.Font;
                                a7.Text = "Step: " + reader["step"].ToString();
                                a7.Location = label76.Location;
                                //Guna2Button a6 = new Guna2Button();
                                //a6.Size = guna2Button123.Size;
                                //a6.Location = guna2Button123.Location;
                                //a6.BackColor = guna2Button123.BackColor;
                                //a6.FillColor = guna2Button123.FillColor;
                                //a6.ForeColor = guna2Button123.ForeColor;
                                //a6.Font = guna2Button123.Font;
                                //a6.BorderRadius = guna2Button123.BorderRadius;
                                //a6.Text = guna2Button123.Text;
                                //a6.Click += (sender, e) => Button_Click5(a6.Text, a6.Text, sender, e);

                                a1.Controls.Add(a7);
                                a1.Controls.Add(a6);
                                a1.Controls.Add(a5);
                                a1.Controls.Add(a4);
                                a1.Controls.Add(a3);
                                a1.Controls.Add(a2);
                                l15.Controls.Add(a1);


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


                obj.Controls.Add(l15);
                flowLayoutPanel8.Controls.Add(obj);

            }

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


        }

        private void guna2Button40_Click(object sender, EventArgs e)
        {

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
        private void label3_Click_1(object sender, EventArgs e)
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


                }
                catch (Exception ex)
                {

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


                }
                catch (Exception ex)
                {
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
                    string query = "UPDATE USERS SET street = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {

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
                    string query = "UPDATE USERS SET city = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {

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
                    string query = "UPDATE USERS SET country = @NewFirstName WHERE email = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@Username", userEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {

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


                    }
                    catch (Exception ex)
                    {

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
            guna2Button29.Visible = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                string query = @"INSERT INTO Workout_session (plan_id, total_exercises, weekly_schedule, day_of_the_week)
VALUES    (@member_id, 0, 0, NULL);";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@member_id", workoutplan);

                    try
                    {

                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select count(*) as counting from Workout_session;";


                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            session_id = reader.GetInt32(reader.GetOrdinal("counting"));

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

        private void guna2TextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text != "")
            {
                flowLayoutPanel13.Visible = true;
                guna2Button43.Visible = true;
                guna2Button22.Visible = true;
                guna2Button27.Visible = false;
                flowLayoutPanel1.Visible = false;
                obj_diet = new FlowLayoutPanel();
                obj_diet.Margin = flowLayoutPanel1.Margin;
                obj_diet.Visible = true;
                obj_diet.Location = flowLayoutPanel1.Location;
                obj_diet.Size = flowLayoutPanel1.Size;
                obj_diet.TabIndex = flowLayoutPanel1.TabIndex;
                obj_diet.ForeColor = flowLayoutPanel1.ForeColor;
                obj_diet.BackColor = flowLayoutPanel1.BackColor;
                guna2Panel11.Controls.Add(obj_diet);
                flowLayoutPanel1.Controls.Clear();



                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO Diet_plan (trainer_id, num_meals) VALUES (@trainer_id, 0);";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@trainer_id", trainerid);


                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"select count(*) as counting from Diet_plan;";


                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dietplanid = reader.GetInt32(reader.GetOrdinal("counting"));

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

                    string query = @"INSERT INTO diet_plan_objectives (Diet_id, objective) VALUES (@trainer_id, @member_id);";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@trainer_id", dietplanid);
                        command.Parameters.AddWithValue("@member_id", richTextBox3.Text);






                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
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







                //flowLayoutPanel20.Visible = false;
                richTextBox3.Visible = false;
                label59.Visible = false;
                flowLayoutPanel1.Visible = true;
                guna2Button27.Visible = false;
                //guna2Panel11.Visible=false;
                guna2Button22.Visible = true;
                guna2Button43.Visible = true;
            }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            flowLayoutPanel13.Visible = false;
            richTextBox3.Visible = true;
            label59.Visible = true;
            //guna2Button22.Visible = false;
            //label33.Text = "";
            //label15.Text = "Selected Client :";
            //guna2TextBox6.Text = "";
            //guna2Button27.Visible = true;
            //flowLayoutPanel20.Visible = true;
            //guna2Panel11.Visible = true;
            //flowLayoutPanel1.Visible = false;
            //guna2Button43.Visible = false;
            guna2Button43.Visible = false;
            guna2Button27.Visible = true;
            guna2Button22.Visible = false;
            flowLayoutPanel1.Visible = false;
            obj_diet.Visible = false;
            object obj_diet2 = null;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button42_Click(object sender, EventArgs e)
        {
            if (label122.Text != "Experience level: " && label38.Text != "Days of Week: ")
            {
                flowLayoutPanel11.Visible = true;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO Workout_Plan (trainer_id, total_exercises, weekly_schedule, experience_level)
VALUES (@trainer_id, 0,@days , @level);";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@trainer_id", trainerid);



                        if (int.TryParse(label37.Text, out int level))
                        {
                            command.Parameters.AddWithValue("@level", level);
                        }
                        if (int.TryParse(label39.Text, out int days))
                        {

                            command.Parameters.AddWithValue("@days", days);
                        }
                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @"select count(*) as counting from Workout_Plan;";


                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                workoutplan = reader.GetInt32(reader.GetOrdinal("counting"));


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
                flowLayoutPanel21.Visible = false;
                flowLayoutPanel12.Visible = false;
                guna2Button38.Visible = true;
                guna2Button42.Visible = false;
                flowLayoutPanel2.Visible = true;


                flowLayoutPanel2.Visible = true;
                guna2Button28.Visible = true;
            }
        }

        private void guna2Button98_Click(object sender, EventArgs e)
        {
            label37.Text = "0";
            label122.Text = "Experience level: " + " Beginner";
        }

        private void guna2Button99_Click(object sender, EventArgs e)
        {
            label37.Text = "1";
            label122.Text = "Experience level: " + " Intermediate";
        }

        private void guna2Button100_Click(object sender, EventArgs e)
        {
            label37.Text = "2";
            label122.Text = "Experience level: " + " Experienced";
        }

        private void guna2Button101_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 1 day";
            label39.Text = "1";
        }

        private void guna2Button102_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 2 day";
            label39.Text = "2";
        }

        private void guna2Button103_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 3 day";
            label39.Text = "3";
        }

        private void guna2Button104_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 4 day";
            label39.Text = "4";
        }

        private void guna2Button105_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 5 day";
            label39.Text = "5";
        }

        private void guna2Button106_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 6 day";
            label39.Text = "6";
        }

        private void guna2Button107_Click(object sender, EventArgs e)
        {
            label38.Text = "Days of Week: 7 day";
            label39.Text = "7";
        }

        private void guna2Button115_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Monday";
            days = "Monday";

        }

        private void guna2Button116_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Tuesday";
            days = "Tuesday";
        }

        private void guna2Button117_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Wednesday";
            days = "Wednesday";
        }

        private void guna2Button118_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Thursday";
            days = "Thursday";
        }

        private void guna2Button119_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Friday";
            days = "Friday";
        }

        private void guna2Button120_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Saturday";
            days = "Saturday";
        }

        private void guna2Button121_Click(object sender, EventArgs e)
        {
            label346.Text = "Workout Name: Sunday";
            days = "Sunday";
        }

        private void guna2Button39_Click_1(object sender, EventArgs e)
        {
            label123.Text = "Experience Level: Beginner";
            experience_level = "Beginner";
        }

        private void guna2Button40_Click_1(object sender, EventArgs e)
        {
            label123.Text = "Experience Level: Intermediate";
            experience_level = "Intermediate";
        }

        private void guna2Button111_Click(object sender, EventArgs e)
        {
            label123.Text = "Experience Level: Advanced";
            experience_level = "Advanced";
        }

        private void guna2Button41_Click_1(object sender, EventArgs e)
        {
            if (label346.Text != "Workout Name:" && label347.Text != "Weekly schedule: ")
            {
                guna2Button29.Visible = true;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE Workout_session 
SET weekly_schedule = @week, day_of_the_week = @days' 
WHERE session_id = @id;";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@week", Convert.ToInt32(weeklyschedule));
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(session_id));
                        command.Parameters.AddWithValue("@days", days);


                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
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

                flowLayoutPanel22.Visible = false;
                flowLayoutPanel17.Visible = true;

                flowLayoutPanel23.Visible = false;
                guna2Button41.Visible = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO Workout_session (plan_id, member_id, total_exercises, weekly_schedule, day_of_the_week)
VALUES (@id, @member_id, 0, @weekday, @day);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@weekday", weeklyschedule);
                        command.Parameters.AddWithValue("@day", days.ToString());
                        command.Parameters.AddWithValue("@id", workoutplan);

                        if (int.TryParse(label35.Text, out int memberId))
                        {
                            command.Parameters.AddWithValue("@member_id", memberId);
                        }


                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @"select count(*) as counting from Workout_session;";


                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                session_id = reader.GetInt32(reader.GetOrdinal("counting"));


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
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {





            flowLayoutPanel22.Visible = true;
            flowLayoutPanel17.Visible = false;

            flowLayoutPanel23.Visible = true;
            guna2Button41.Visible = true;
            Guna2Panel obj = new Guna2Panel();
            obj.Size = guna2Panel18.Size;
            obj.ForeColor = guna2Panel18.ForeColor;
            obj.BackColor = guna2Panel18.BackColor;
            obj.FillColor = guna2Panel18.FillColor;
            obj.Margin = guna2Panel18.Margin;
            obj.BorderRadius = guna2Panel18.BorderRadius;

            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
            l0.Text = label40.Text + " " + session_id.ToString();
            l0.Location = label40.Location;
            l0.Font = label40.Font;
            l0.ForeColor = label40.ForeColor;
            l0.BackColor = label40.BackColor;
            l0.Size = label40.Size;


            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
            l1.Text = label131.Text + " " + weeklyschedule.ToString();
            l1.Location = label131.Location;
            l1.Font = label131.Font;
            l1.ForeColor = label131.ForeColor;
            l1.BackColor = label131.BackColor;
            l1.Margin = label131.Margin;
            l1.Size = label131.Size;


            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
            l2.Text = label130.Text + " " + step;
            l2.Location = label130.Location;
            l2.Font = label130.Font;
            l2.ForeColor = label130.ForeColor;
            l2.BackColor = label130.BackColor;
            l2.Margin = label130.Margin;
            l2.Size = label130.Size;


            obj.Controls.Add(l0);
            obj.Controls.Add(l1);
            obj.Controls.Add(l2);
            flowLayoutPanel2.Controls.Add(obj);

            guna2TabControl3.SelectedIndex = 2;
        }

        private void guna2Button60_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button76_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to insert a new row into the Diet_plan table
                string query = @"Update Appointment set status='Accepted'  where  appointment_id=@id;";

                // Create a new SqlCommand object with the query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    int.TryParse(label43.Text, out numofreps);
                    command.Parameters.AddWithValue("@id", numofreps);
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
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

        private void guna2Button75_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to insert a new row into the Diet_plan table
                string query = @"Update Appointment set status='Accepted'  where  appointment_id=@id;";

                // Create a new SqlCommand object with the query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    int.TryParse(label43.Text, out numofreps);
                    command.Parameters.AddWithValue("@id", numofreps);
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
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
            int id_search = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "select Member.Member_id from Member inner join USERS on USERS.email=Member.email where Member.email=@Email;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", label51.Text);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            int.TryParse(reader["Member_id"].ToString(), out id_search);

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
                // SQL command to insert a new row into the Diet_plan table
                string query = @"insert into member_trainer_log(trainer_id, Member_id) values(@id1,@id2);";

                // Create a new SqlCommand object with the query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id1", trainerid);

                    command.Parameters.AddWithValue("@id2", id_search);
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
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

        private void guna2Button48_Click(object sender, EventArgs e)
        {

        }

        private void label303_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            label336.Text = "Type/Time: Breakfast";
            label33.Text = "Breakfast";
        }

        private void guna2Button50_Click(object sender, EventArgs e)
        {
            label336.Text = "Type/Time: Lunch";
            label33.Text = "Lunch";
        }

        private void guna2Button51_Click(object sender, EventArgs e)
        {
            label336.Text = "Type/Time: Dinner";
            label33.Text = "Dinner";
        }

        private void guna2Button52_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel43_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button109_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 2 days";
            weeklyschedule = 2;

        }

        private void label222_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            if (experience_level != "" && guna2TextBox19.Text != "" && guna2TextBox20.Text != "" && guna2TextBox21.Text != "" && richTextBox2.Text != "")
            {


                step = step + 1;
                int.TryParse(guna2TextBox20.Text, out numofreps);
                machinename = guna2TextBox21.Text;
                muscle_info = richTextBox2.Text;
                exercisename = guna2TextBox19.Text;
                Guna2Panel obj = new Guna2Panel();
                obj.Size = guna2Panel76.Size;
                obj.FillColor = guna2Panel76.FillColor;
                obj.BackColor = guna2Panel76.BackColor;
                obj.ForeColor = guna2Panel76.ForeColor;
                obj.BorderColor = guna2Panel76.BorderColor;
                obj.BorderRadius = guna2Panel76.BorderRadius;
                obj.Margin = guna2Panel76.Margin;

                System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                l0.Text = "Step : " + step.ToString(); ;
                l0.Location = label344.Location;
                l0.Font = label344.Font;
                l0.ForeColor = label344.ForeColor;
                l0.BackColor = label344.BackColor;
                l0.Size = label344.Size;


                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                l1.Text = label345.Text + " " + guna2TextBox20.Text;
                l1.Location = label345.Location;
                l1.Font = label345.Font;
                l1.ForeColor = label345.ForeColor;
                l1.BackColor = label345.BackColor;
                l1.Margin = label345.Margin;
                l1.Size = label345.Size;


                System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                l2.Text = label349.Text + " " + machinename;
                l2.Location = label349.Location;
                l2.Font = label349.Font;
                l2.ForeColor = label349.ForeColor;
                l2.BackColor = label349.BackColor;
                l2.Margin = label349.Margin;
                l2.Size = label349.Size;

                System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
                l3.Text = label350.Text + " " + experience_level;
                l3.Location = label350.Location;
                l3.Font = label350.Font;
                l3.ForeColor = label350.ForeColor;
                l3.BackColor = label350.BackColor;
                l3.Margin = label350.Margin;
                l3.Size = label350.Size;

                System.Windows.Forms.Label l4 = new System.Windows.Forms.Label();
                l4.Text = label351.Text;
                l4.Location = label351.Location;
                l4.Font = label351.Font;
                l4.ForeColor = label351.ForeColor;
                l4.BackColor = label351.BackColor;
                l4.Margin = label351.Margin;
                l4.Size = label351.Size;

                System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
                l5.Text = muscle_info;
                l5.Location = label352.Location;
                l5.Font = label352.Font;
                l5.ForeColor = label352.ForeColor;
                l5.BackColor = label352.BackColor;
                l5.Margin = label352.Margin;
                l5.Size = label352.Size;

                obj.Controls.Add(l0);
                obj.Controls.Add(l1);
                obj.Controls.Add(l2);
                obj.Controls.Add(l3);
                obj.Controls.Add(l4);
                obj.Controls.Add(l5);
                flowLayoutPanel17.Controls.Add(obj);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO exercise (exercise_name, difficulty, num_reps) VALUES (@weekday, @day, @id);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@weekday", exercisename);
                        command.Parameters.AddWithValue("@day", experience_level);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(numofreps));
                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO steps (plan_id, session_id, step, exercise_name) VALUES (@planid, @id, @day,@weekday);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@planid", Convert.ToInt32(workoutplan));
                        command.Parameters.AddWithValue("@weekday", exercisename);
                        command.Parameters.AddWithValue("@day", step);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(session_id));
                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO Muscle (Muscle_name, exercise_name)VALUES (@day, @weekday)";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@weekday", exercisename);
                        command.Parameters.AddWithValue("@day", muscle_info);

                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO Machine (Machine_name, exercise_name)VALUES (@day, @weekday);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@weekday", exercisename);
                        command.Parameters.AddWithValue("@day", machinename);

                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE Workout_session
SET total_exercises = total_exercises + 1
WHERE session_id = @id";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@id", session_id);

                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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

        private void guna2Button110_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 3 days";
            weeklyschedule = 3;
        }

        private void guna2Button112_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 4 days";
            weeklyschedule = 4;
        }

        private void guna2Button113_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 5 days";
            weeklyschedule = 5;
        }

        private void guna2Button114_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 6 days";
            weeklyschedule = 6;
        }

        private void guna2Button122_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 7 days";
            weeklyschedule = 7;
        }

        private void guna2Button108_Click(object sender, EventArgs e)
        {
            label347.Text = "Weekly schedule: 1 day";
            weeklyschedule = 1;
        }

        private void guna2Button38_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel11.Visible = false;
            flowLayoutPanel21.Visible = true;
            guna2Button42.Visible = true;
            guna2Button38.Visible = false;
            label38.Text = "Days of Week: ";
            label122.Text = "Experience level: ";
            flowLayoutPanel12.Visible = true;
            flowLayoutPanel2.Visible = false;
            guna2Button28.Visible = false;
        }

        private void flowLayoutPanel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            if (label33.Text != "" && guna2TextBox6.Text != "" && guna2TextBox12.Text != "" && guna2TextBox13.Text != "" && guna2TextBox14.Text != "" && guna2TextBox18.Text != "" && guna2TextBox17.Text != "" && richTextBox1.Text != "")
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO Food (food_name, protien, carbohydrates, fibers, fats,calories) VALUES (@mealname, @protein, @cabohydrates, @fibers, @fats,@cals);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@mealname", guna2TextBox12.Text);
                        command.Parameters.AddWithValue("@protein", guna2TextBox13.Text);
                        command.Parameters.AddWithValue("@cabohydrates", guna2TextBox14.Text);
                        command.Parameters.AddWithValue("@fibers", guna2TextBox18.Text);
                        command.Parameters.AddWithValue("@fats", guna2TextBox17.Text);
                        float calories;
                        float.TryParse(guna2TextBox6.Text, out calories);
                        command.Parameters.AddWithValue("@cals", calories);
                        try
                        {

                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {

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


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "";
                    // SQL command to insert a new row into the Diet_plan table
                    if (label33.Text == "Breakfast")
                    {
                        query = @"Update Diet_plan SET B=@food_name where Diet_id=@Diet_id";

                    }
                    else if (label33.Text == "Lunch")
                    {
                        query = @"Update Diet_plan SET L=@food_name where Diet_id=@Diet_id";

                    }
                    else if (label33.Text == "Dinner")
                    {
                        query = @"Update Diet_plan SET D=@food_name where Diet_id=@Diet_id";

                    }

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@Diet_id", dietplanid);
                        command.Parameters.AddWithValue("@food_name", guna2TextBox12.Text);
                        try
                        {

                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to insert a new row into the Diet_plan table
                    string query = @"INSERT INTO Potential_Allergens (food_name,allergen) Values (@food_name,@allergen);";

                    // Create a new SqlCommand object with the query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@food_name", guna2TextBox12.Text);
                        command.Parameters.AddWithValue("@allergen", richTextBox1.Text);

                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
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


                Guna2Panel obj = new Guna2Panel();
                obj.Size = guna2Panel22.Size;
                obj.FillColor = guna2Panel22.FillColor;
                obj.BackColor = guna2Panel22.BackColor;
                obj.ForeColor = guna2Panel22.ForeColor;
                obj.BorderRadius = guna2Panel22.BorderRadius;

                System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                l0.Text = label33.Text;
                l0.Font = label89.Font;
                l0.ForeColor = label89.ForeColor;
                l0.BackColor = label89.BackColor;
                l0.Location = label89.Location;
                l0.Size = label89.Size;


                System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                l1.Text = guna2TextBox12.Text;
                l1.Font = label90.Font;
                l1.ForeColor = label90.ForeColor;
                l1.BackColor = label90.BackColor;
                l1.Location = label90.Location;

                Guna2Shapes l2 = new Guna2Shapes();
                l2.Shape = guna2Shapes22.Shape;
                l2.Size = guna2Shapes22.Size;
                l2.FillColor = guna2Shapes22.FillColor;
                l2.BackColor = guna2Shapes22.BackColor;
                l2.LineThickness = guna2Shapes22.LineThickness;
                l2.Location = guna2Shapes22.Location;

                obj.Controls.Add(l2);
                obj.Controls.Add(l1);
                obj.Controls.Add(l0);

                flowLayoutPanel1.Controls.Add(obj);


                guna2TabControl3.SelectedIndex = 1;
                guna2Shapes42.Visible = false;
                guna2Shapes43.Visible = true;
                guna2Shapes44.Visible = false;
            }
        }

        private void label62_Click_1(object sender, EventArgs e)
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