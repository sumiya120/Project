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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Book1 Obj = new Book1();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True");

        private void Dashboard_Load(object sender, EventArgs e)

        {
            Con.Open();
            
            SqlDataAdapter sad = new SqlDataAdapter("select sum(BQty) from BTable1", Con);

            DataTable dt = new DataTable();

            sad.Fill(dt);

            BStockL1.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sad1 = new SqlDataAdapter("select sum(Amount) from BillTable1 ", Con);

            DataTable dt1 = new DataTable();

            sad1.Fill(dt1);

            AstockL2.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sad2 = new SqlDataAdapter("select Count(*) from UTable1 ", Con);

            DataTable dt2 = new DataTable();
           
            sad2.Fill(dt2);
           UstockL3.Text = dt2.Rows[0][0].ToString();
            Con.Close();

        }

        private void UstockL3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
            
        
