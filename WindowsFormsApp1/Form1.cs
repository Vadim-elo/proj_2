using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    
public partial class Form1 : Form
    {

        static public class Keep
            {
                static public string name;
                static public int age;
                static public string sex;
                static public int mark;
            }
    public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LAPTOP-3TK8E4LL\SQLEXPRESS;Initial Catalog=Basetp;Integrated Security=True";
            string sql = "SELECT * FROM Students";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

        }
       
    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=LAPTOP-3TK8E4LL\SQLEXPRESS;Initial Catalog=Basetp;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            string sInsSql = "Insert into Students(Name,Age,Sex,Mark) Values('{0}','{1}','{2}','{3}') ";
            // int id= Convert.ToInt32(textBox5.Text);
            string name = textBox1.Text;
            int age = Convert.ToInt32(textBox2.Text);
            string sex = textBox3.Text;
            int mark = Convert.ToInt32(textBox4.Text);
            string sInStud = string.Format(sInsSql, name, age, sex, mark);
            SqlCommand cmdIns = new SqlCommand(sInStud, Conn);
            cmdIns.ExecuteNonQuery();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=LAPTOP-3TK8E4LL\SQLEXPRESS;Initial Catalog=Basetp;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            int id = Convert.ToInt32(textBox5.Text);
            string sql = string.Format("Delete from Students where id = '{0}'", id);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Keep.name= textBox1.Text;
            Keep.age = Convert.ToInt32(textBox2.Text);
            Keep.sex = textBox3.Text;
            Keep.mark= Convert.ToInt32(textBox4.Text);
            int id = Convert.ToInt32(textBox5.Text);
            string strConn = @"Data Source=LAPTOP-3TK8E4LL\SQLEXPRESS;Initial Catalog=Basetp;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            string sql = string.Format("Update Students set Name = '{0}',Age='{1}',Sex='{2}',Mark='{3}' where id = '{4}'", Keep.name, Keep.age,Keep.sex,Keep.mark, id);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.ExecuteNonQuery();
        }










        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name like '{0}%'",textBox6.Text);
        }

        private string showMale()
        {
            return "select id from Students where Sex = 'male' ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
