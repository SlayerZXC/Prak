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
    public partial class Form7 : Form
    {
        string connectionString = @"Data Source= ADCLG1; Initial catalog=!!!ShevelevaPr; Integrated Security=True";
        public Form7()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
                        string query = "SELECT * FROM employees";

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
            string query = "INSERT INTO employees (employee_id, name, position)" +
            "VALUES (@employee_id, @name, @position)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("employee_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@position", textBox3.Text);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE employees SET name  = @name, position = @position WHERE employee_id = @employee_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("employee_id", Int32.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@position", textBox3.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "DELETE FROM employees WHERE employee_id = @employee_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employee_id", Int32.Parse(textBox1.Text));

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

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }


    }
}
