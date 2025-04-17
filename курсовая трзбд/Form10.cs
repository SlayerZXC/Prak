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

    public partial class Form10 : Form
    {
        string connectionString = @"Data Source= ADCLG1; Initial catalog=!!!ShevelevaPr; Integrated Security=True";
        public Form10()
        {
            InitializeComponent();
            LoadData();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
        }

        private void LoadData()
        {
            
            string query = "SELECT * FROM Zakaz ";

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
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Zakaz WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", Int32.Parse(textBox1.Text));

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
        }

    }
}
