using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace курсовая_трзбд
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=ADCLG1; Initial Catalog=!!!ShevelevaPr; Integrated Security=True";

        public bool IsLoggedIn { get; private set; }
        public bool IsClientDataLoaded { get; private set; }
        public bool IsErrorMessageShown { get; private set; }

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // или FormBorderStyle.Fixed3D;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;

            // Устанавливаем свойство UseSystemPasswordChar для textBox2 после инициализации компонентов
            textBox2.UseSystemPasswordChar = true;
        }

        public void Login(string login, string password)
        {
            IsLoggedIn = false;
            IsClientDataLoaded = false;
            IsErrorMessageShown = false;

            if (!string.IsNullOrEmpty(login))
            {
                string query = "SELECT Name, Role FROM Paroli WHERE login = @Login AND password = @Password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string userName = reader["Name"].ToString();
                        string userRole = reader["Role"].ToString();
                        if (userRole == "admin" || userRole == "user" || userRole == "sotr")
                        {
                            IsLoggedIn = true;
                            if (userRole == "user")
                            {
                                IsClientDataLoaded = true;
                            }
                        }
                        else
                        {
                            IsErrorMessageShown = true;
                        }
                    }
                    else
                    {
                        IsErrorMessageShown = true;
                    }

                    connection.Close();
                }
            }
            else
            {
                IsErrorMessageShown = true;
            }
        }

        public void Register(string login, string password)
        {
            IsErrorMessageShown = false;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                string role = "user"; // Предполагая, что регистрируемый пользователь по умолчанию имеет роль "user"
                string query = "INSERT INTO Users (login, password, role) VALUES (@Login, @Password, @Role)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Пользователь успешно зарегистрирован
                    }
                    else
                    {
                        IsErrorMessageShown = true;
                    }

                    connection.Close();
                }
            }
            else
            {
                IsErrorMessageShown = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            Login(login, password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            Register(login, password);
        }
    }
}
