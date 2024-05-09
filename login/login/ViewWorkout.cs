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

namespace login
{
    public partial class ViewWorkout : Form
    {
        private string planid;
        private string connectionString;
        public ViewWorkout(string b, string p, string c)
        {
            InitializeComponent();
            planid = p;
            connectionString = c;
            label109.Text = b;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "select*from Workout_session where plan_id=" + planid;
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();

            while (readerName.Read())
            {
                string session = readerName["day_of_the_week"].ToString();
                Guna2CustomGradientPanel panel = new Guna2CustomGradientPanel();
                panel.Size = guna2CustomGradientPanel2.Size;
                panel.FillColor = guna2CustomGradientPanel2.FillColor;
                panel.ForeColor = guna2CustomGradientPanel2.ForeColor;
                panel.BackColor = guna2CustomGradientPanel2.BackColor;
                panel.Margin = guna2CustomGradientPanel2.Margin;
                panel.BorderRadius = guna2CustomGradientPanel2.BorderRadius;

                Guna2Button button = new Guna2Button();
                button.BorderRadius = guna2Button8.BorderRadius;
                button.Size = guna2Button8.Size;
                button.BackColor = guna2Button8.BackColor;
                button.ForeColor = guna2Button8.ForeColor;
                button.FillColor = guna2Button8.FillColor;
                button.Text = session;
                button.Font = guna2Button8.Font;
                button.Margin = guna2Button8.Margin;
                button.Location = guna2Button8.Location;

                FlowLayoutPanel FL=new FlowLayoutPanel();
                FL.Size = flowLayoutPanel1.Size;
                FL.Location= flowLayoutPanel1.Location;



                string sID = readerName["session_id"].ToString();
                string queryName1 = "select*from steps where session_id=" + sID;
                SqlCommand commandName1 = new SqlCommand(queryName1, connection);
                SqlDataReader readerName1 = commandName1.ExecuteReader();
                while (readerName1.Read())
                {
                    Guna2Panel panel2 = new Guna2Panel();
                    panel2.Size = guna2Panel2.Size;
                    panel2.FillColor = guna2Panel2.FillColor;
                    panel2.ForeColor = guna2Panel2.ForeColor;
                    panel2.BackColor = guna2Panel2.BackColor;
                    panel2.Margin = guna2Panel2.Margin;
                    panel2.BorderRadius = guna2Panel2.BorderRadius;

                    Guna2Button button1 = new Guna2Button();
                    button1.BorderRadius = guna2Button1.BorderRadius;
                    button1.Size = guna2Button1.Size;
                    button1.BackColor = guna2Button1.BackColor;
                    button1.ForeColor = guna2Button1.ForeColor;
                    button1.FillColor = guna2Button1.FillColor;
                    button1.Text = readerName1["excersice_name"].ToString();
                    button1.Font = guna2Button1.Font;
                    button1.Margin = guna2Button1.Margin;
                    button1.Location = guna2Button1.Location;
                    button1.Click += new EventHandler((sender, e) => ExerciseButton_Click(sender, e, button1.Text));
                    panel2.Controls.Add(button1);
                    FL.Controls.Add(panel2);
                }

                

                panel.Controls.Add(button);
                panel.Controls.Add(FL);
                flowLayoutPanel3.Controls.Add(panel);
                
            }
            guna2CustomGradientPanel2.Hide();
        }

        private void ExerciseButton_Click(object sender, EventArgs e, string buttonText)
        {
            ExcerciseDetails obj = new ExcerciseDetails(buttonText, connectionString);
            obj.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ExcerciseDetails obj = new ExcerciseDetails(" ", " ");
            obj.Show();
        }
    }
}
