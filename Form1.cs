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
using Sql.Connection;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();

            conn = DBUtils.GetDBConnection();
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                label2.Text = "Connected";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from adress", conn);
                DataSet data = new DataSet();
                adapter.Fill(data, "adress");
                dataGridView1.DataSource = data.Tables["adress"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand($"insert into adress(region,city,street) values('{textBox1.Text}','{textBox2.Text}', '{textBox3.Text}');", conn);
            query.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand($"update adress set region = '{textBox6.Text}', city = '{textBox5.Text}', street = '{textBox4.Text}' where adress_id = {textBox7.Text};", conn);
            query.ExecuteNonQuery();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand($"delete from adress where adress_id = {textBox8.Text};", conn);
            query.ExecuteNonQuery();
            textBox8.Clear();
        }
    }
}
