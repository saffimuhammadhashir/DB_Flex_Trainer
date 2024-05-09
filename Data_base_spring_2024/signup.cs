using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms;

namespace Data_base_spring_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();





            label16.Visible = false;
            guna2Button4.Visible = false;
            guna2Button3.Visible = false;
            guna2Panel3.Visible = false;
            guna2WinProgressIndicator1.Visible = false;
            label13.Visible = false;
        }


        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            //this.Hide();
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton4.Checked)
            {
                guna2CustomRadioButton2.Checked = false;
                guna2CustomRadioButton3.Checked = false;

            }
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton2.Checked)
            {
                guna2CustomRadioButton4.Checked = false;
                guna2CustomRadioButton3.Checked = false;

            }
        }

        private void guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton3.Checked)
            {
                guna2CustomRadioButton4.Checked = false;
                guna2CustomRadioButton2.Checked = false;

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton7.Checked)
            {
                guna2CustomRadioButton6.Checked = false;
                guna2CustomRadioButton5.Checked = false;

            }
        }

        private void guna2CustomRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton6.Checked)
            {
                guna2CustomRadioButton7.Checked = false;
                guna2CustomRadioButton5.Checked = false;

            }
        }

        private void guna2CustomRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton5.Checked)
            {
                guna2CustomRadioButton7.Checked = false;
                guna2CustomRadioButton6.Checked = false;

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Shapes4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }




        static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }

        static string GenerateUsername(string firstName, string lastName, string email)
        {

            string username = firstName.Substring(0, 1) + lastName;


            username = RemoveNonAlphanumeric(username);


            if (email.Contains(username))
            {

                int count = 1;
                while (email.Contains(username + count))
                {
                    count++;
                }
                username += count;
            }

            return username;
        }

        static string RemoveNonAlphanumeric(string input)
        {

            string cleaned = "";
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    cleaned += c;
                }
            }
            return cleaned;
        }


        void SendEmail(string firstname, string lastname, string username, string email, string password)
        {



            try
            {
                string smtpServer = "smtp.office365.com";
                int port = 587;
                string senderEmail = "flextrainersystem@outlook.com";
                string passwordowner = "hashir12";


                string recipientEmail = guna2TextBox2.Text;
                if (!IsValidEmail(recipientEmail))
                {

                    throw new ArgumentException("Invalid recipient email address.");
                }


                string bccRecipientEmail = "flextrainersystem@gmail.com";

                string subject = "Welcome To Flex Trainer";
                string body = "Kindly find your login credentials attached, Username:\'" + username + "\'\n Password: \'" + password;


                SmtpClient client = new SmtpClient(smtpServer, port);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(senderEmail, passwordowner);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(senderEmail);
                message.To.Add(recipientEmail);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;


                message.Bcc.Add(bccRecipientEmail);


                message.Headers.Add("X-Mailer", "Flex Trainer");
                message.Headers.Add("X-Priority", "1");
                message.Headers.Add("X-MSMail-Priority", "High");
                message.Headers.Add("Importance", "High");

                client.Send(message);


                guna2Panel3.Visible = true;
                label14.Text = "Email Sent Successfully!";
                label15.Text = "Your login credentials have been emailed to you.";
                guna2Button4.Visible = true;
                guna2WinProgressIndicator1.Visible = false;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                guna2Panel3.Visible = true;
                label14.Text = "Email Sending Failed!";
                label15.Text = "Failed to send email. Please try again later.";
                guna2Button3.Visible = true;
                guna2WinProgressIndicator1.Visible = false;
                // Log or display the exception message
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }


        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private string GetMembershipStatus()
        {
            if (guna2CustomRadioButton7.Checked)
            {
                return "Gym Owner";
            }
            else if (guna2CustomRadioButton6.Checked)
            {
                return "Trainer";
            }
            else if (guna2CustomRadioButton5.Checked)
            {
                return "Member";
            }
            else
            {

                return "Admin";
            }
        }

        private string GetGender()
        {
            if (guna2CustomRadioButton2.Checked)
            {
                return "Male";
            }
            else if (guna2CustomRadioButton3.Checked)
            {
                return "Female";
            }
            else if (guna2CustomRadioButton4.Checked)
            {
                return "Others";
            }
            else
            {

                return "";
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=SAFFI-MUHAMMAD-;Initial Catalog=FlexTrainer;Integrated Security=True;Encrypt=False";
            string email = guna2TextBox2.Text;
            int count = 0;
            string query = "SELECT COUNT(*) FROM USERS WHERE email=@Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@Email", email);


                    conn.Open();

                    count = (int)cmd.ExecuteScalar();


                }
            }


            if (count <= 0)
            {
                if ((guna2CustomRadioButton7.Checked || guna2CustomRadioButton6.Checked || guna2CustomRadioButton5.Checked || guna2CustomRadioButton13.Checked) && (guna2CustomRadioButton2.Checked || guna2CustomRadioButton3.Checked || guna2CustomRadioButton4.Checked && IsValidEmail(guna2TextBox2.Text) && guna2TextBox1.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "" && guna2TextBox5.Text != "" && guna2TextBox6.Text != ""))
                {
                    guna2WinProgressIndicator1.Visible = true;
                    label16.Visible = false;

                    string firstName = guna2TextBox1.Text;
                    string lastName = guna2TextBox3.Text;
                    string address = guna2TextBox3.Text + "," + guna2TextBox4.Text + "," + guna2TextBox6.Text;
                    string membershipStatus = GetMembershipStatus();
                    string gender = GetGender();
                    string password = GenerateRandomPassword();
                    string username = GenerateUsername(firstName, lastName, email);
                    await Task.Delay(1000);
                    SendEmail(firstName, lastName, username, email, password);



                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        conn.Open();
                        string query2 = "INSERT INTO USERS (email, username, password, firstName, lastName, registration_date, gender, membership_status,streetaddress,cityaddress,countryaddress,DOB) " +
                                       "VALUES (@Email, @Username, @Password, @FirstName, @LastName, @RegistrationDate, @Gender, @MembershipStatus,@street,@city,@country,@dob)";

                        SqlCommand cmd = new SqlCommand(query2, conn);


                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                        //cmd.Parameters.AddWithValue("@Gender", 0);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@dob", guna2DateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@street", guna2TextBox4.Text);
                        cmd.Parameters.AddWithValue("@city", guna2TextBox5.Text);
                        cmd.Parameters.AddWithValue("@country", guna2TextBox6.Text);
                        cmd.Parameters.AddWithValue("@MembershipStatus", membershipStatus);
                        cmd.ExecuteNonQuery();
                    }
                    if (guna2CustomRadioButton6.Checked)
                    {
                        using (SqlConnection conn1 = new SqlConnection(connectionString))
                        {

                            conn1.Open();
                            string query2 = "INSERT INTO Trainer (email) " +
                                           "VALUES (@Email)";

                            SqlCommand cmd = new SqlCommand(query2, conn1);


                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (guna2CustomRadioButton13.Checked)
                    {
                        using (SqlConnection conn2 = new SqlConnection(connectionString))
                        {

                            conn2.Open();
                            string query2 = "INSERT INTO Admin (email) " +
                                           "VALUES (@Email)";

                            SqlCommand cmd = new SqlCommand(query2, conn2);


                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (guna2CustomRadioButton7.Checked)
                    {
                        using (SqlConnection conn2 = new SqlConnection(connectionString))
                        {

                            conn2.Open();
                            string query2 = "INSERT INTO GymOwner (email) " +
                                           "VALUES (@Email)";

                            SqlCommand cmd = new SqlCommand(query2, conn2);


                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (guna2CustomRadioButton5.Checked)
                    {
                        using (SqlConnection conn2 = new SqlConnection(connectionString))
                        {

                            conn2.Open();
                            string query2 = "INSERT INTO Member (email) " +
                                           "VALUES (@Email)";

                            SqlCommand cmd = new SqlCommand(query2, conn2);


                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    await Task.Delay(4000);
                }
                else
                {
                    label16.Visible = true;
                }
            }
            else
            {
                label13.Visible = true;
            }



        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel3.Visible= false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
