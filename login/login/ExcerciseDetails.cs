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
    public partial class ExcerciseDetails : Form
    {
        private string name;
        private string connectionString;
        public ExcerciseDetails(string t, string c)
        {
            InitializeComponent();
            name = t;
            connectionString = c;
            guna2Button8.Text = t;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //name
            string queryName = "select*from exercise where exercise_name='" + name + "'";
            SqlCommand commandName = new SqlCommand(queryName, connection);
            SqlDataReader readerName = commandName.ExecuteReader();
            if (readerName != null)
            {
                readerName.Read();
                guna2Button7.Text = readerName["num_reps"].ToString()+" Reps";
                guna2Button4.Text = readerName["difficulty"].ToString()+ guna2Button4.Text;
                readerName.Close();
            }

            queryName = "select*from muscle where exercise_name='" + name + "'";
            commandName = new SqlCommand(queryName, connection);
            readerName = commandName.ExecuteReader();
            if (readerName != null)
            {
                readerName.Read();
                guna2Button5.Text = readerName["Muscle_name"].ToString();
                readerName.Close();
            }
            queryName = "select*from machine where exercise_name='" + name + "'";
            commandName = new SqlCommand(queryName, connection);
            readerName = commandName.ExecuteReader();
            if (readerName != null)
            {
                readerName.Read();
                guna2Button1.Text = readerName["Machine_name"].ToString();
                readerName.Close();
            }

            connection.Close();

        }
    }
}
