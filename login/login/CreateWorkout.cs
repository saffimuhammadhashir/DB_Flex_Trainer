using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace login
{
    public partial class CreateWorkout : Form
    {
        private string memberid;
        private string connectionString;


        public CreateWorkout(string mid, string con)
        {
            InitializeComponent();
            memberid = mid;
            connectionString = con;

            load_exercises();
        }

        private void load_exercises()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "select*from exercise";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            while (readerName.Read())
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Size = guna2Panel2.Size;
                panel.FillColor = guna2Panel2.FillColor;
                panel.ForeColor = guna2Panel2.ForeColor;
                panel.BackColor = guna2Panel2.BackColor;
                panel.Margin = guna2Panel2.Margin;
                panel.BorderRadius = guna2Panel2.BorderRadius;

                Guna2Button button = new Guna2Button();
                button.BorderRadius = guna2Button5.BorderRadius;
                button.Size = guna2Button5.Size;
                button.BackColor = guna2Button5.BackColor;
                button.ForeColor = guna2Button5.ForeColor;
                button.FillColor = guna2Button5.FillColor;
                button.Text = readerName["exercise_name"].ToString();
                button.Font = guna2Button5.Font;
                button.Margin = guna2Button5.Margin;
                button.Location = guna2Button5.Location;

                button.Click -= guna2Button5_Click;
                button.Click += new EventHandler((sender, e) => ExerciseButton_Click(sender, e, button.Text));




                panel.Controls.Add(button);
                flowLayoutPanel5.Controls.Add(panel);
            }
            guna2Panel2.Hide();
            readerName.Close();
            connection.Close();
        }

        private void ExerciseButton_Click(object sender, EventArgs e, string buttonText)
        {
            ExcerciseDetails obj = new ExcerciseDetails(buttonText, connectionString);
            obj.Show();
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ExcerciseDetails obj = new ExcerciseDetails(" ", connectionString);
            obj.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateExcercise obj = new CreateExcercise(connectionString);
            obj.Show();
        }

        private void label152_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            string n = guna2TextBox1.Text;
            string ex = guna2TextBox23.Text;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "insert into Workout_Plan (member_id,total_exercises,experience_level,Wname) values ("
                + memberid + ",9," + ex + ",'" + n + "')";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            commandName.ExecuteNonQuery();

            queryName = "select max(plan_id) as PlanID from Workout_Plan";
            commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            string planid = " ";
            if (readerName.HasRows)
            {
                readerName.Read();
                planid = readerName["PlanID"].ToString();
                readerName.Close();
            }

            if (guna2TextBox16.Text != "")
            {
                string d = guna2TextBox16.Text;
                queryName = "insert into Workout_session (plan_id,member_id,total_exercises,day_of_the_week) values ("
                + planid + "," + memberid + ",3,'" + d + "')";
                commandName = new SqlCommand(queryName, connection);
                commandName.ExecuteNonQuery();

                queryName = "select max(session_id) as SessionID from Workout_session";
                commandName = new SqlCommand(queryName, connection);
                readerName = commandName.ExecuteReader();
                string sessionid = " ";
                if (readerName.HasRows)
                {
                    readerName.Read();
                    sessionid = readerName["SessionID"].ToString();
                    readerName.Close();
                }
                if (guna2TextBox15.Text != "")
                {
                    string en = guna2TextBox15.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",1,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox13.Text != "")
                {
                    string en = guna2TextBox13.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",2,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox3.Text != "")
                {
                    string en = guna2TextBox3.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",3,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
            }

            if (guna2TextBox22.Text != "")
            {
                string d = guna2TextBox22.Text;
                queryName = "insert into Workout_session (plan_id,member_id,total_exercises,day_of_the_week) values ("
                + planid + "," + memberid + ",3,'" + d + "')";
                commandName = new SqlCommand(queryName, connection);
                commandName.ExecuteNonQuery();

                queryName = "select max(session_id) as SessionID from Workout_session";
                commandName = new SqlCommand(queryName, connection);
                readerName = commandName.ExecuteReader();
                string sessionid = " ";
                if (readerName.HasRows)
                {
                    readerName.Read();
                    sessionid = readerName["SessionID"].ToString();
                    readerName.Close();
                }
                if (guna2TextBox21.Text != "")
                {
                    string en = guna2TextBox21.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",1,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox19.Text != "")
                {
                    string en = guna2TextBox19.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",2,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox17.Text != "")
                {
                    string en = guna2TextBox17.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",3,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
            }

            if (guna2TextBox10.Text != "")
            {
                string d = guna2TextBox10.Text;
                queryName = "insert into Workout_session (plan_id,member_id,total_exercises,day_of_the_week) values ("
                + planid + "," + memberid + ",3,'" + d + "')";
                commandName = new SqlCommand(queryName, connection);
                commandName.ExecuteNonQuery();

                queryName = "select max(session_id) as SessionID from Workout_session";
                commandName = new SqlCommand(queryName, connection);
                readerName = commandName.ExecuteReader();
                string sessionid = " ";
                if (readerName.HasRows)
                {
                    readerName.Read();
                    sessionid = readerName["SessionID"].ToString();
                    readerName.Close();
                }
                if (guna2TextBox9.Text != "")
                {
                    string en = guna2TextBox9.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",1,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox7.Text != "")
                {
                    string en = guna2TextBox7.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",2,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
                if (guna2TextBox5.Text != "")
                {
                    string en = guna2TextBox5.Text;
                    queryName = "insert into steps (plan_id,session_id,step,excersice_name) values ("
                        + planid + "," + sessionid + ",3,'" + en + "')";
                    commandName = new SqlCommand(queryName, connection);
                    commandName.ExecuteNonQuery();
                }
            }
            this.Hide();
        }
    }
}
