using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace курсовая_трзбд
{
    public partial class Form4 : Form
    {
        string connectionString = @"Data Source=ADCLG1; Initial Catalog=!!!ShevelevaPr; Integrated Security=True";

        public bool IsClientAdded { get; private set; }
        public bool IsClientUpdated { get; private set; }
        public bool IsClientDeleted { get; private set; }
        public bool IsErrorMessageShown { get; private set; }

        public Form4()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM clients";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }

        public void AddClient(string clientId, string name, string phone)
        {
            IsClientAdded = false;
            IsErrorMessageShown = false;

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                IsErrorMessageShown = true;
                return;
            }

            string query = "INSERT INTO clients (client_id, name, phone) VALUES (@client_id, @name, @phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(clientId));
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@phone", phone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            IsClientAdded = true;
            LoadData();
        }

        public void UpdateClient(string clientId, string name, string phone)
        {
            IsClientUpdated = false;
            IsErrorMessageShown = false;

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                IsErrorMessageShown = true;
                return;
            }

            string query = "UPDATE clients SET name = @name, phone = @phone WHERE client_id = @client_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(clientId));
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@phone", phone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            IsClientUpdated = true;
            LoadData();
        }

        public void DeleteClient(string clientId)
        {
            IsClientDeleted = false;
            IsErrorMessageShown = false;

            if (string.IsNullOrWhiteSpace(clientId))
            {
                IsErrorMessageShown = true;
                return;
            }

            string query = "DELETE FROM clients WHERE client_id = @client_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@client_id", Int32.Parse(clientId));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            IsClientDeleted = true;
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateClient(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteClient(textBox1.Text);
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

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
            this.Hide();
        }
    }
}
