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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Data_base_spring_2024
{
    public partial class Trainee_details : Form
    {
        private string userEmail,name,weight, height;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";

        public Trainee_details(string email)
        {
            InitializeComponent();
            userEmail = email;
            int myid =0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to retrieve gym location based on gymId
                string query = @"Select* from Member
                                inner join USERS on Member.email=USERS.email
                                where Member.email=@id";


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
                            name= reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                            weight = "Weight : " + reader["Weight"].ToString();
                            height = "Height : " + reader["height"].ToString();
                            myid= Convert.ToInt32(reader["Member_id"]);
                            int val = Convert.ToInt32(reader["attendance"]);
                            val *= 100;
                            val /= 30;
                            guna2ProgressBar1.Value = Convert.ToInt32(reader["workoutconsistency"]) * 10;
                            guna2ProgressBar2.Value = Convert.ToInt32(reader["dietconsistency"]) * 10;
                            guna2ProgressBar3.Value = val;
                            guna2CircleProgressBar1.Value = (guna2ProgressBar1.Value + guna2ProgressBar2.Value + guna2ProgressBar3.Value) / 3;

                            label16.Text = weight;
                            label36.Text = height;
                            label1.Text = name;
                            label2.Text = userEmail;

                        }

                    }
                    else
                    {



                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }
            int dietid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to retrieve gym location based on gymId
                string query = @"select* from diet_Member where member_id=@id";


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
                            dietid = Convert.ToInt32(reader["Diet_id"]);
                        }

                    }
                    else
                    {

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }













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
    diet_plan_objectives ON diet_plan_objectives.Diet_id = Diet_plan.Diet_id;
    ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", dietid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();



                            breakfast = reader["Breakfast"].ToString();
                            lunch = reader["Lunch"].ToString();
                            dinner = reader["Dinner"].ToString();

                            label34.Text =  "Advisor name:   " + reader["firstName"] + " " + reader["lastName"];
 


                            label17.Text ="Objectives:   " + reader["objective"];

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
                            obj2.Size = guna2Panel7.Size;
                            obj2.FillColor = guna2Panel7.FillColor;
                            obj2.BackColor = guna2Panel7.BackColor;
                            obj2.ForeColor = guna2Panel7.ForeColor;
                            obj2.BorderRadius = guna2Panel7.BorderRadius;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Text = reader["food_name"].ToString();
                            l1.Location = label21.Location;
                            l1.Size = label21.Size;
                            l1.ForeColor = label21.ForeColor;
                            l1.BackColor = label21.BackColor;
                            l1.TextAlign = label21.TextAlign;
                            l1.Margin = label21.Margin;
                            l1.Font = label21.Font;

                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Text = "Breakfast";
                            l2.Location = label20.Location;
                            l2.Size = label20.Size;
                            l2.ForeColor = label20.ForeColor;
                            l2.BackColor = label20.BackColor;
                            l2.TextAlign = label20.TextAlign;
                            l2.Margin = label20.Margin;
                            l2.Font = label20.Font;


                            obj2.Controls.Add(l1);
                            obj2.Controls.Add(l2);

                            flowLayoutPanel1.Controls.Add(obj2);
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
                            obj2.Size = guna2Panel7.Size;
                            obj2.FillColor = guna2Panel7.FillColor;
                            obj2.BackColor = guna2Panel7.BackColor;
                            obj2.ForeColor = guna2Panel7.ForeColor;
                            obj2.BorderRadius = guna2Panel7.BorderRadius;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Text = reader["food_name"].ToString();
                            l1.Location = label21.Location;
                            l1.Size = label21.Size;
                            l1.ForeColor = label21.ForeColor;
                            l1.BackColor = label21.BackColor;
                            l1.TextAlign = label21.TextAlign;
                            l1.Margin = label21.Margin;
                            l1.Font = label21.Font;

                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Text = "Lunch";
                            l2.Location = label20.Location;
                            l2.Size = label20.Size;
                            l2.ForeColor = label20.ForeColor;
                            l2.BackColor = label20.BackColor;
                            l2.TextAlign = label20.TextAlign;
                            l2.Margin = label20.Margin;
                            l2.Font = label20.Font;


                            obj2.Controls.Add(l1);
                            obj2.Controls.Add(l2);

                            flowLayoutPanel1.Controls.Add(obj2);
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
                            obj2.Size = guna2Panel7.Size;
                            obj2.FillColor = guna2Panel7.FillColor;
                            obj2.BackColor = guna2Panel7.BackColor;
                            obj2.ForeColor = guna2Panel7.ForeColor;
                            obj2.BorderRadius = guna2Panel7.BorderRadius;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Text = reader["food_name"].ToString();
                            l1.Location = label21.Location;
                            l1.Size = label21.Size;
                            l1.ForeColor = label21.ForeColor;
                            l1.BackColor = label21.BackColor;
                            l1.TextAlign = label21.TextAlign;
                            l1.Margin = label21.Margin;
                            l1.Font = label21.Font;

                            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
                            l2.Text = "Dinner";
                            l2.Location = label20.Location;
                            l2.Size = label20.Size;
                            l2.ForeColor = label20.ForeColor;
                            l2.BackColor = label20.BackColor;
                            l2.TextAlign = label20.TextAlign;
                            l2.Margin = label20.Margin;
                            l2.Font = label20.Font;



                            obj2.Controls.Add(l1);
                            obj2.Controls.Add(l2);

                            flowLayoutPanel1.Controls.Add(obj2);
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








            int workid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL command to retrieve gym location based on gymId
                string query = @"select* from workout_Member where member_id=@id";


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
                            workid = Convert.ToInt32(reader["plan_id"]);
                        }

                    }
                    else
                    {

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }









                 string fullname = "";
                int week_shd = 0;
                int exp_lvl = 0;


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL command to retrieve gym location based on gymId
                    string query = @" select Workout_Plan.plan_id, USERS.firstName,USERS.lastName,Workout_Plan.weekly_schedule,Workout_Plan.experience_level from Workout_Plan INNER JOIN Trainer on Trainer.Trainer_id = Workout_Plan.trainer_id INNER JOIN USERS on Trainer.email = USERS.email where Workout_Plan.plan_id=@id;
";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", workid);

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
   







            label250.Text = label250.Text + " " + fullname.ToString();
         



            label223.Text = label223.Text + " " + week_shd.ToString() + "Days a week";
 
                if (exp_lvl == 0)
                {
                label222.Text = label222.Text + " Beginner";

                }
                else if (exp_lvl == 1)
                {
                label222.Text = label222.Text + " Intermediate";

                }
                else if (exp_lvl == 2)
                {
                label222.Text = label222.Text + " Advanced";

                }



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
                command.Parameters.AddWithValue("@id", workid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Guna2Panel a1 = new Guna2Panel();
                            a1.Size = guna2Panel2.Size;
                            a1.FillColor = guna2Panel2.FillColor;
                            a1.Font = guna2Panel2.Font;
                            a1.Margin = guna2Panel2.Margin;
                            a1.BackColor = guna2Panel2.BackColor;
                            a1.BorderRadius = guna2Panel2.BorderRadius;

                            System.Windows.Forms.Label a2 = new System.Windows.Forms.Label();
                            a2.Size = label10.Size;
                            a2.Margin = label10.Margin;
                            a2.BackColor = label10.BackColor;
                            a2.ForeColor = label10.ForeColor;
                            a2.Font = label10.Font;
                            a2.Text = reader["step_exercise_name"].ToString();
                            a2.Location = label10.Location;

                            System.Windows.Forms.Label a3 = new System.Windows.Forms.Label();
                            a3.Size = label9.Size;
                            a3.Margin = label9.Margin;
                            a3.BackColor = label9.BackColor;
                            a3.ForeColor = label9.ForeColor;
                            a3.Font = label9.Font;
                            a3.Text = reader["num_reps"].ToString();
                            a3.Location = label9.Location;


                            System.Windows.Forms.Label a4 = new System.Windows.Forms.Label();
                            a4.Size = label8.Size;
                            a4.Margin = label8.Margin;
                            a4.BackColor = label8.BackColor;
                            a4.ForeColor = label8.ForeColor;
                            a4.Font = label8.Font;
                            a4.Text = reader["Machine_name"].ToString();
                            a4.Location = label8.Location;


                            System.Windows.Forms.Label a5 = new System.Windows.Forms.Label();
                            a5.Size = label7.Size;
                            a5.Margin = label7.Margin;
                            a5.BackColor = label7.BackColor;
                            a5.ForeColor = label7.ForeColor;
                            a5.Font = label7.Font;
                            a5.Text = reader["Muscle_name"].ToString();
                            a5.Location = label7.Location;


                            System.Windows.Forms.Label a6 = new System.Windows.Forms.Label();
                            a6.Size = label3.Size;
                            a6.Margin = label3.Margin;
                            a6.BackColor = label3.BackColor;
                            a6.ForeColor = label3.ForeColor;
                            a6.Font = label3.Font;
                            a6.Text = reader["difficulty"].ToString();
                            a6.Location = label3.Location;



                            System.Windows.Forms.Label a7 = new System.Windows.Forms.Label();
                            a7.Size = label4.Size;
                            a7.Margin = label4.Margin;
                            a7.BackColor = label4.BackColor;
                            a7.ForeColor = label4.ForeColor;
                            a7.Font = label4.Font;
                            a7.Text = "Step: " + reader["step"].ToString();
                            a7.Location = label4.Location;


                            a1.Controls.Add(a7);
                            a1.Controls.Add(a6);
                            a1.Controls.Add(a5);
                            a1.Controls.Add(a4);
                            a1.Controls.Add(a3);
                            a1.Controls.Add(a2);

                            flowLayoutPanel10.Controls.Add(a1);

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

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Trainee_details_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
