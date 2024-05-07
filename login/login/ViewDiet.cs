using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class ViewDiet : Form
    {
        public ViewDiet()
        {
            InitializeComponent();
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MealDetails obj = new MealDetails();
            obj.Show();
        }
    }
}
