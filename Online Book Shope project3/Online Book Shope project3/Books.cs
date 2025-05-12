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
using System.Diagnostics.Eventing.Reader;

namespace Online_Book_Shope_project3
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=tempdb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == " " || BautTb.Text == " " || QtyTb.Text == "" || PriceTb.Text == ""|| BCatCb.SelectedIndex==-1) 

            {
                MessageBox.Show("Missing Information");


            }

            else
            {
                try
                {
                    Con.Open();
                    String query = " insert into BookTb1 values ('"+BTitleTb.Text  +"','"+ BautTb.Text +"','"+BCatCb.SelectedIndex.ToString() +"','"+QtyTb.Text +"','"+ PriceTb.Text+") "

                       SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    
                    Con.Close();


                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
            
        }

        private void Books_Load(object sender, EventArgs e)
        {

        }

        private void Books_Load_1(object sender, EventArgs e)
        {

        }
    }
}
