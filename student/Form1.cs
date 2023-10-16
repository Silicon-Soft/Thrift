using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace student
{
    public partial class Form1 : Form
    {
         static string constr = "SERVER=localhost; DATABASE=school; USERNAME=root; PASSWORD='';";
        MySqlConnection conn = new MySqlConnection(constr);
        int rollno = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }
      
        public void DisplayData()
        {
            conn.Open();
            string query = "SELECT * FROM student";
            MySqlDataAdapter adr = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource=dt;
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rollno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string name= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string address = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text=rollno.ToString();
            textBox3.Text=name;
            textBox2.Text=address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                
                conn.Open();
                int rollno=int.Parse(textBox1.Text);
                string name = textBox3.Text;
                string address=textBox2.Text;
                string query = "Insert INTO student VALUES("+rollno+",'"+name+"','"+address+"')";
                MySqlCommand cmd= new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Insert Successful");
                else
                    MessageBox.Show("Error in Insertion");
                conn.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("data is not filled");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                conn.Open();
                string name = textBox3.Text;
                string address = textBox2.Text;
                string query = "UPDATE student SET name ='"+name+"', address='"+address+"' WHERE rollno="+rollno+"";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows=cmd.ExecuteNonQuery();
                if (rows>0)
                    MessageBox.Show("update Successful");
                else
                    MessageBox.Show("Erros int UPdate");
                conn.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Data not fill");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(rollno!=0)
            {
                conn.Open();
                string query = "DELETE FROM student WHERE rollno ="+rollno+"";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows=cmd.ExecuteNonQuery();
                if (rows>0)
                    MessageBox.Show("Delete Successful");
                else
                    MessageBox.Show("Erros in  delete");
                conn.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Data not fill");
            }

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
