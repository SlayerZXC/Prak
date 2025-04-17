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
    public partial class Form5 : Form
    {
        string connectionString = @"Data Source= ADCLG1; Initial catalog=!!!ShevelevaPr; Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM OrderTable1 ";

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
            string query = "INSERT INTO OrderTable1 (order_id, employee_id, service_id, description, created_at, client_id)" +
            "VALUES (@order_id, @employee_id, @service_id, @description, @created_at, @client_id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("order_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@employee_id", Int32.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@service_id", Int32.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@description", textBox4.Text);
                    command.Parameters.AddWithValue("@created_at", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(textBox5.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE OrderTable1 SET employee_id  = @employee_id, service_id = @service_id, description = @description, created_at = @created_at, client_id = @client_id WHERE order_id = @order_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("order_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@employee_id", Int32.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@service_id", Int32.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@description", textBox4.Text);
                    command.Parameters.AddWithValue("@created_at", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(textBox5.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "DELETE FROM OrderTable1 WHERE order_id = @order_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@order_id", Int32.Parse(textBox1.Text));

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

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
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
