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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\p106\source\repos\WindowsFormsApp3\WindowsFormsApp3\Data\ForCalss.mdf;Integrated Security=True";
            var _connect = new SqlConnection(_connectionString);
            _connect.Open();
            var tName = textBox1.Text;
            var _insertQuery = "insert into Teacher(Name) values('" + tName + "')";
            var _command = new SqlCommand(_insertQuery, _connect);
            _command.ExecuteNonQuery();
            _connect.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\p106\source\repos\WindowsFormsApp3\WindowsFormsApp3\Data\ForCalss.mdf;Integrated Security=True";
            var _connect = new SqlConnection(_connectionString);
            _connect.Open();
            var _insertQuery = "select * from Teacher";
            var da = new SqlDataAdapter(_insertQuery, _connect);
            var ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                textBox5.Text += item["Id"] + ". " + item["Name"] + "\r\n";
                comboBox1.Items.Add(item["Name"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\p106\source\repos\WindowsFormsApp3\WindowsFormsApp3\Data\ForCalss.mdf;Integrated Security=True";
            var connect = new SqlConnection(connectString);
            connect.Open();
            var cName = textBox3.Text;
            var select = comboBox1.SelectedItem;
            var tCount = Convert.ToInt32(textBox2.Text);
            var insertQuery = "insert into Classes(Name, TeacherId, StudentCount) values('" + cName + "',(select Id from Teacher where Name='" + select + "'),'"+tCount+"')";
            var command = new SqlCommand(insertQuery, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\p106\source\repos\WindowsFormsApp3\WindowsFormsApp3\Data\ForCalss.mdf;Integrated Security=True";
            var connect = new SqlConnection(connectString);
            connect.Open();
            var insertquery = "select * from Classes";
            var da = new SqlDataAdapter(insertquery, connect);
            var ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                textBox4.Text += item["Name"] + ". " + item["TeacherId"] + " / " + item["StudentCount"] + "\r\n";
            }
            connect.Close();
        }
    }
}
