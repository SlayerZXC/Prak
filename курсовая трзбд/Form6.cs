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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace курсовая_трзбд
{
    public partial class Form6 : Form
    {
        string connectionString = @"Data Source= ADCLG1; Initial catalog=!!!ShevelevaPr; Integrated Security=True";
        public Form6()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
            
            string query = "SELECT * FROM goods ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO goods (good_id, order_id, name)" +
            "VALUES (@good_id, @order_id, @name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("good_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@order_id", Int32.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@name", textBox3.Text);
          

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE goods SET order_id  = @order_id, name = @name WHERE good_id = @good_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("good_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@order_id", Int32.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@name", textBox3.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "DELETE FROM goods WHERE good_id = @good_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@good_id", Int32.Parse(textBox1.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
            this.Hide();
        }
    }
}
