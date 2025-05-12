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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-R1A6GLE\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from UTable1";
            SqlDataAdapter sad = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sad);
            var ds = new DataSet();
            sad.Fill(ds);

            UserDGV.DataSource = ds.Tables[0];

            Con.Close();

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            UnameTb.Text = "";
            PassTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UTable1 where UId=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
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

        private void button2_Click(object sender, EventArgs e)

        {

            if (UnameTb.Text == " " || PhoneTb.Text == " " || AddTb.Text == " " || PassTb.Text == " ")

            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Updated UTable1 set Uname= '" + UnameTb.Text + " ',+UPhone=' " + PhoneTb.Text + " ',UAdd=" + AddTb.Text + ",UPass =" + PassTb.Text + "where UId=" + Key + ";";
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

         private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Book1 Obj = new Book1();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == " " || AddTb.Text == " " || PassTb.Text == " " || PhoneTb.Text == "  " )
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = " insert into UTable1 values( '   " + UnameTb.Text + "  ' , '  " + PhoneTb.Text + "  ' , '  " + AddTb.Text + "  ',' " + PassTb.Text + " ')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved Successfully");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            Annulable1.Text = Login.Annu;
        }
        int Key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            PhoneTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
           
            AddTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            PassTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (UnameTb.Text == "  ")
            {

                Key = 0;

            }

            else

            {
                Key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void Annutable_Click(object sender, EventArgs e)
        {

        }
    }
}
