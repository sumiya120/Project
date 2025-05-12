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
    public partial class Book1 : Form
    {
        public Book1()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from BTable1";
            SqlDataAdapter sad = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sad);
            var ds = new DataSet();
            sad.Fill(ds);

           BooKDGV.DataSource = ds.Tables[0];

            Con.Close(); 
        
        }
        private void Filter()
        {
            Con.Open();
            string query = "select * from BTable1 where BCat ='" +CatCbSeachCb.SelectedItem.ToString () +"'";
            SqlDataAdapter sad = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sad);
            var ds = new DataSet();
            sad.Fill(ds);

            BooKDGV.DataSource = ds.Tables[0];

            Con.Close();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == " " || BautTb.Text == " " || QtyTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex== -1)
            {
                MessageBox.Show("Missing Information");

            }
         else
            {   
                try
                {
                    Con.Open();
                    string query = " insert into BTable1 values( '" + BTitleTb.Text + "' , '" + BautTb.Text + "' , '" + BCatCb.SelectedItem.ToString() + "','" + QtyTb.Text + "'," + PriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Saved Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }
                
                
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }




        }

        private void CatCbSeachCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            populate();

           // CatCbSeachCb.SelectedIndex = -1;

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
            CatCbSeachCb.SelectedIndex = -1;
        }
        int Key = 0;
        private void BookDGV_Enter(object sender, EventArgs e)
        {
           

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {


            if (Key ==0)
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = " delet from BTable1 where BID=" + Key + ";"; 
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }


                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (BTitleTb.Text == " " || BautTb.Text == " " || QtyTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex== -1)
            
                {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Updated BTable1 set BTitle = ' " + BTitleTb.Text + " ',+BAuthor=' " + BautTb.Text + " ',BCat=' " + BCatCb.SelectedItem.ToString() + "',BQty= ' " + QtyTb.Text + " ',Bprice = '" + PriceTb.Text+ "',where BId ='" +Key+ " ';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }


                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void BooKDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text= BooKDGV.SelectedRows[0]. Cells[1].Value.ToString();
             BautTb.Text = BooKDGV.SelectedRows[0].Cells[2].Value.ToString();
             BCatCb.SelectedItem = BooKDGV.SelectedRows[0].Cells[3].Value.ToString();
             QtyTb.Text = BooKDGV.SelectedRows[0].Cells[4].Value.ToString();
             PriceTb.Text = BooKDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (BTitleTb.Text == "")
            {

                Key = 0;

            }

             else

            {
                 Key = Convert.ToInt32(BooKDGV.SelectedRows[0].Cells[1].Value.ToString());
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BTitleTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void BautTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Book1_Load(object sender, EventArgs e)
        {
            
        }

        private void UserNamelabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
