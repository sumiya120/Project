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

namespace Online_Book_Shope_project3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True");
        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UTable1  where UName = '" + UnameTb.Text + "'and UPass='" + UPassTb.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                UserName = UnameTb.Text;
                Billing obj =  new Billing  ();
               obj .Show();
                this.Hide();
                Con.Close();
            }

            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
       Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }
    }
}
