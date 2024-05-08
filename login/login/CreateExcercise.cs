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
    public partial class CreateExcercise : Form
    {
        private string connectionString;
        public CreateExcercise(string c)
        {
            InitializeComponent();
            connectionString = c;

        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            string n = guna2TextBox1.Text;
            string r = guna2TextBox2.Text;
            string m = guna2TextBox3.Text;
            string d=guna2TextBox4.Text;
            string mu= guna2TextBox6.Text;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "insert into exercise values ('"+n+"',"+d+","+r+")";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            commandName.ExecuteNonQuery();

            queryName = "insert into muscle values ('" + mu + "','" + n + "')";
            commandName = new SqlCommand(queryName, connection);
            commandName.ExecuteNonQuery();

            queryName = "insert into machine values ('" + m + "','" + n + "')";
            commandName = new SqlCommand(queryName, connection);
            commandName.ExecuteNonQuery();
            connection.Close();
            this.Hide();
        }
    }
}
