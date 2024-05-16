using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace FILAapp
{
    public partial class Logowanie : Form
    {
        private MySqlConnection connection;
        private string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";

        private int userId;
        private string userName = "";
        private string userSurname = "";
        private string userType = "";

        public Logowanie()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(login, password))
            {
                GetUserInformation(login, out userId, out userName, out userSurname, out userType);

                Kompletowanie form2 = new Kompletowanie(userId, userName, userSurname, userType);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło.");
            }
        }

        private bool AuthenticateUser(string login, string password)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE Login=@Login AND Password=@Password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetUserInformation(string login, out int userId, out string userName, out string userSurname, out string userType)
        {
            string query = "SELECT Id, Name, Surname, Type FROM users WHERE Login=@Login";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Login", login);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(0);
                        userName = reader.GetString(1);
                        userSurname = reader.GetString(2);
                        userType = reader.GetString(3);
                    }
                    else
                    {
                        userId = -1;
                        userName = string.Empty;
                        userSurname = string.Empty;
                        userType = string.Empty;
                    }
                }
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string login = txtUsername.Text;
                string password = txtPassword.Text;

                if (AuthenticateUser(login, password))
                {
                    GetUserInformation(login, out userId, out userName, out userSurname, out userType);
                    Kompletowanie form2 = new Kompletowanie(userId, userName, userSurname, userType);
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowy login lub hasło.");
                }
            }
        }

        private void PrzesunNaSrodek(Control kontrolka)
        {
            int x = (this.ClientSize.Width - kontrolka.Width) / 2;
            int y = (this.ClientSize.Height - kontrolka.Height) / 2;

            kontrolka.Location = new Point(x, y);
        }

        private void Logowanie_Load(object sender, EventArgs e)
        {
            PrzesunNaSrodek(panel1);
        }

        private void Logowanie_Resize(object sender, EventArgs e)
        {
            PrzesunNaSrodek(panel1);
        }
    }
}
