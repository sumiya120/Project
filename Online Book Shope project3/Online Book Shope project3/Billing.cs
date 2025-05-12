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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from BTable1";
            SqlDataAdapter sad = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sad);
            var ds = new DataSet();
            sad.Fill(ds);

            BooKDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Billing_Load(object sender, EventArgs e)
        {
            UserNamelabel3 = Login.UserName;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int Key = 0; int stock = 0;
        private void BooKDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BooKDGV.SelectedRows[0].Cells[1].Value.ToString();
            BautTb.Text = BooKDGV.SelectedRows[0].Cells[2].Value.ToString();
            BCatCb.SelectedItem = BooKDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = BooKDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BooKDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (BTitleTb.Text == "")
            {

                Key = 0;
                stock = 0;
            }

            else

            {
                Key = Convert.ToInt32(BooKDGV.SelectedRows[0].Cells[1].Value.ToString());
            }
            stock = Convert.ToInt32(BooKDGV.SelectedRows[0].Cells[4].Value.ToString());

        }
        int n = 0; 
        private  void SaveBtn_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "" || Convert.ToInt32 (QtyTb.Text) > stock)

            {
                MessageBox.Show("No Enough stock");

            }
            else
            {

                 int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BTitleTb.Text;
                newRow.Cells[2].Value = BautTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
                newRow.Cells[4].Value = PriceTb.Text;
                BillDGV.Rows.Add(newRow);
            }
        }
        private void Reset()
        {
            BTitleTb.Text = "";
            BautTb.Text = "";
            BCatCb.SelectedIndex = -1;
            PriceTb.Text = "";
            QtyTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        } 
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UserNamelabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
    
