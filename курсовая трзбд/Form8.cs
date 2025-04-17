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

namespace курсовая_трзбд
{
    public partial class Form8 : Form
    {
        string connectionString = @"Data Source= ADCLG1; Initial catalog=!!!ShevelevaPr; Integrated Security=True";
        public Form8()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
            
            string query = "SELECT * FROM clients ";

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
            string query = "INSERT INTO clients (client_id, name, phone)" +
            "VALUES (@client_id, @name, @phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("client_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@phone", textBox3.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE clients SET name  = @name, phone = @phone  WHERE client_id = @client_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("client_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@phone", textBox3.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "DELETE FROM clients WHERE client_id = @client_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(textBox1.Text));

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
            Form3 form = new Form3();
            form.Show();
            this.Hide();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9();
            form.Show();
            this.Hide();
        }
    }
}
