using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Guna.UI2.WinForms;

namespace login
{
    public partial class MemberD : Form
    {
        private string loggedInEmail;
        private string connectionString;
        private string memberid;
        public MemberD(string email, string c)
        {
            InitializeComponent();
            this.loggedInEmail = email;
            this.connectionString = c;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryName = "select * from member where email = '" + loggedInEmail + "'";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            readerName.Read();
            memberid = readerName["Member_id"].ToString();

            connection.Close();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 1;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 2; // Select the first tab
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "select*from Workout_Plan where member_id=" + memberid;
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            string planid = "";
            int c = 0;
            while (readerName.Read())
            {
                c++;
                planid = readerName["plan_id"].ToString();
                Guna2Panel panel = new Guna2Panel();
                panel.Size = guna2Panel45.Size;
                panel.FillColor = guna2Panel45.FillColor;
                panel.ForeColor = guna2Panel45.ForeColor;
                panel.BackColor = guna2Panel45.BackColor;
                panel.Margin = guna2Panel45.Margin;
                panel.BorderRadius = guna2Panel45.BorderRadius;

                Label L = new Label();
                L.Location=label83.Location;
                L.Font=label83.Font;
                L.Size=label83.Size;
                L.Text = readerName["Wname"].ToString() +" #"+ readerName["plan_id"].ToString();

                Guna2Button button = new Guna2Button();
                button.BorderRadius = guna2Button15.BorderRadius;
                button.Size = guna2Button15.Size;
                button.BackColor = guna2Button15.BackColor;
                button.ForeColor = guna2Button15.ForeColor;
                button.FillColor = guna2Button15.FillColor;
                button.Text = guna2Button15.Text;
                button.Font = guna2Button15.Font;
                button.Margin = guna2Button15.Margin;
                button.Location = guna2Button15.Location;
                string planId = readerName["plan_id"].ToString();
                button.Click -= guna2Button15_Click;
                button.Click += new EventHandler((sender, e) => ViewWButton_Click(sender, e, L.Text,planId));

                panel.Controls.Add(button);
                panel.Controls.Add(L);
                flowLayoutPanel1.Controls.Add(panel);

                queryName = "select*from Workout_session where plan_id=" + planid;
                SqlCommand commandName1 = new SqlCommand(queryName, connection);
                SqlDataReader readerName1 = commandName1.ExecuteReader();
                int ww = 21;
                while (readerName1.Read())
                {
                    Guna2Button button1 = new Guna2Button();
                    button1.BorderRadius = guna2Button20.BorderRadius;
                    button1.Size = guna2Button20.Size;
                    button1.BackColor = guna2Button20.BackColor;
                    button1.ForeColor = guna2Button20.ForeColor;
                    button1.FillColor = guna2Button20.FillColor;
                    button1.Text = readerName1["day_of_the_week"].ToString();
                    button1.Font = guna2Button20.Font;
                    button1.Margin = guna2Button20.Margin;
                    button1.Location = new Point(ww, guna2Button20.Location.Y);
                    ww += 101;
                    panel.Controls.Add(button1);
                }
                readerName1.Close();
            }
            guna2Panel45.Hide();

            readerName.Close();
            queryName = "select*from Workout_Plan where member_id=" + memberid;
            commandName = new SqlCommand(queryName, connection);
            readerName = commandName.ExecuteReader();
            planid = "";
            c = 0;
            while (readerName.Read())
            {
                c++;
                planid = readerName["plan_id"].ToString();
                Guna2Panel panel = new Guna2Panel();
                panel.Size = guna2Panel31.Size;
                panel.FillColor = guna2Panel31.FillColor;
                panel.ForeColor = guna2Panel31.ForeColor;
                panel.BackColor = guna2Panel31.BackColor;
                panel.Margin = guna2Panel31.Margin;
                panel.BorderRadius = guna2Panel31.BorderRadius;

                Label L = new Label();
                L.Location = label63.Location;
                L.Font = label63.Font;
                L.Size = label63.Size;
                L.Text = readerName["Wname"].ToString() + " #" + readerName["plan_id"].ToString();

                Guna2Button button = new Guna2Button();
                button.BorderRadius = guna2Button23.BorderRadius;
                button.Size = guna2Button23.Size;
                button.BackColor = guna2Button23.BackColor;
                button.ForeColor = guna2Button23.ForeColor;
                button.FillColor = guna2Button23.FillColor;
                button.Text = guna2Button23.Text;
                button.Font = guna2Button23.Font;
                button.Margin = guna2Button23.Margin;
                button.Location = guna2Button23.Location;
                string planId = readerName["plan_id"].ToString();
                button.Click += new EventHandler((sender, e) => ViewWButton_Click(sender, e, L.Text, planId));


                Guna2Button button1 = new Guna2Button();
                button1.BorderRadius = guna2Button93.BorderRadius;
                button1.Size = guna2Button93.Size;
                button1.BackColor = guna2Button93.BackColor;
                button1.ForeColor = guna2Button93.ForeColor;
                button1.FillColor = guna2Button93.FillColor;
                button1.Text = "Trainer #"+readerName["trainer_id"].ToString();
                button1.Font = guna2Button93.Font;
                button1.Margin = guna2Button93.Margin;
                button1.Location = guna2Button93.Location;


                panel.Controls.Add(button);
                panel.Controls.Add(button1);
                panel.Controls.Add(L);
                flowLayoutPanel2.Controls.Add(panel);
            }
            readerName.Close();
            connection.Close();
            guna2Panel31.Hide();

        }
        private void ViewWButton_Click(object sender, EventArgs e, string buttonText, string pid)
        {
            ViewWorkout obj = new ViewWorkout(buttonText,pid, connectionString);
            obj.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 1;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 0; // Select the first tab
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 1;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 1; // Select the first tab
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Login EL = new Login();
            label32.Text = loggedInEmail;

            //name
            string queryName = "select * from USERS where email = '" + loggedInEmail + "'";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            //L21
            if (readerName.HasRows)
            {
                readerName.Read(); // Move to the first (and only) row

                // Assuming "firstName" and "lastName" are columns in your USERS table
                string firstName = readerName["firstName"].ToString();
                string lastName = readerName["lastName"].ToString();

                label21.Text = firstName + " " + lastName;
                label33.Text += readerName["registration_date"].ToString();
                label30.Text = readerName["membership_status"].ToString();
                label27.Text = readerName["gender"].ToString() + label27.Text;
            }


            readerName.Close();

            queryName = "select * from member where email = '" + loggedInEmail + "'";
            commandName = new SqlCommand(queryName, connection);
            readerName = commandName.ExecuteReader();
            if (readerName.HasRows)
            {
                readerName.Read();
                string mt = readerName["memnbership_type"].ToString();
                label27.Text += mt;
                string me = readerName["membership_expiry"].ToString();
                label28.Text += me;
            }

            readerName.Close();
            connection.Close();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 1;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 3; // Select the first tab
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 0;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 1;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 4; // Select the first tab
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            guna2Button1.BorderThickness = 0;
            guna2Button2.BorderThickness = 1;
            guna2Button3.BorderThickness = 0;
            guna2Button4.BorderThickness = 0;
            guna2Button5.BorderThickness = 0;
            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedIndex = 1; // Select the first tab
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel10_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            MemberReviewTrainer obj = new MemberReviewTrainer();
            obj.Show();
        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            guna2Button49.Text = "✓";
        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            ViewDiet obj = new ViewDiet();
            obj.Show();
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            ViewDiet obj = new ViewDiet();
            obj.Show();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            ViewWorkout obj = new ViewWorkout("","","");
            obj.Show();
        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {
            CreateDiet obj = new CreateDiet();
            obj.Show();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            CreateWorkout obj = new CreateWorkout(memberid, connectionString);
            obj.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            OwnerD obj = new OwnerD();
            obj.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
