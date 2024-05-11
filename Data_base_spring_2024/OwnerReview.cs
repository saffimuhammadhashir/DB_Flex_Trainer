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

namespace Data_base_spring_2024
{
    public partial class OwnerReview : Form
    {
        private string userEmail;
        private int myid,chk=0,count=0;
        private string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";

        public OwnerReview(string email,int id)
        {
            InitializeComponent();
            userEmail = email;
            myid = id;
            label2.Text ="Email: "+ userEmail;






            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select count(*)as counting from Gym where GymOwner_id=@id;";


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
                            count = Convert.ToInt32(reader["counting"]);
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

            label5.Text ="Count: "+ count.ToString();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"select * from Gym inner join Gym_location on Gym.Gym_id=Gym_location.Gym_id  where Gym.GymOwner_id=@id;";


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

                            Guna2Panel obj =new  Guna2Panel();
                            obj.Size = guna2Panel3.Size;
                            obj.FillColor = guna2Panel3.FillColor;
                            obj.BackColor = guna2Panel3.BackColor;
                            obj.BorderRadius = guna2Panel3.BorderRadius;
                            obj.Margin = guna2Panel3.Margin;

                            System.Windows.Forms.Label l0 = new System.Windows.Forms.Label();
                            l0.Size = label9.Size;
                            l0.Font= label9.Font;
                            l0.ForeColor = label9.ForeColor;
                            l0.Text = "Name:  "+reader["gym_name"].ToString();
                            l0.Location=label9.Location;

                            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
                            l1.Size = label10.Size;
                            l1.Font = label10.Font;
                            l1.ForeColor = label10.ForeColor;
                            l1.Text =  "Location " + reader["gym_location"].ToString();
                            l1.Location = label10.Location;

                            Guna2CircleProgressBar l2 = CloneProgressBar(guna2CircleProgressBar1);
                            l2.Value = (Convert.ToInt32(reader["rating"].ToString()) * 100) / 5;

                            obj.Controls.Add(l0);
                            obj.Controls.Add(l1);
                            obj.Controls.Add(l2);
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



            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"Select USERS.* from GymOwner inner join USERS on USERS.email=GymOwner.email where GymOwner.GymOwner_id=@id;
";


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
                            chk = Convert.ToInt32(reader["is_active"]);
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
                guna2Panel5.Visible = true;
                guna2Panel4.Visible = false;
            }
        }
        public Guna2CircleProgressBar CloneProgressBar(Guna2CircleProgressBar original)
        {
            Guna2CircleProgressBar clone = new Guna2CircleProgressBar();
            clone.AccessibleDescription = original.AccessibleDescription;
            clone.AccessibleName = original.AccessibleName;
            clone.AccessibleRole = original.AccessibleRole;
            clone.AllowDrop = original.AllowDrop;

            clone.Anchor = original.Anchor;
            clone.AnimationSpeed = original.AnimationSpeed;
            clone.AutoScaleMode = original.AutoScaleMode;
            clone.AutoSize = original.AutoSize;
            clone.AutoValidate = original.AutoValidate;
            clone.BackColor = original.BackColor;
            clone.BackgroundImage = original.BackgroundImage;
            clone.BackgroundImageLayout = original.BackgroundImageLayout;
            clone.ContextMenuStrip = original.ContextMenuStrip;
            clone.Cursor = original.Cursor;
            clone.Dock = original.Dock;
            clone.Enabled = original.Enabled;
            clone.FillColor = original.FillColor;
            clone.Font = original.Font;
            clone.ForeColor = original.ForeColor;
            clone.ImageSize = original.ImageSize;
            clone.Location = original.Location;
            clone.Margin = original.Margin;
            clone.Maximum = original.Maximum;
            clone.Minimum = original.Minimum;
            clone.Name = original.Name;
            clone.Padding = original.Padding;
            clone.Parent = original.Parent;
            clone.ProgressColor = original.ProgressColor;
            clone.ProgressColor2 = original.ProgressColor2;
            clone.ProgressEndCap = original.ProgressEndCap;
            clone.ProgressOffset = original.ProgressOffset;
            clone.ProgressThickness = original.ProgressThickness;
            clone.ShowText = original.ShowText;
            clone.Size = original.Size;
            clone.TabIndex = original.TabIndex;
            clone.TabStop = original.TabStop;
            clone.Tag = original.Tag;
            clone.Text = original.Text;
            clone.UseTransparentBackground = original.UseTransparentBackground;
            clone.UseWaitCursor = original.UseWaitCursor;
            clone.Value = original.Value;
            clone.Visible = true;

            return clone;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"Update  Users SET is_active=0 WHERE email=@mem_id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@mem_id", userEmail);


                    try
                    {

                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            guna2Panel5.Visible = true;
                            guna2Panel4.Visible = false;
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
}
