using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FILAapp
{
    public partial class Admin : Form
    {
        private MySqlConnection connection;
        private string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";
        private string loggedInUserName;
        private string loggedInUserSurname;
        private int userId;
        private string userType;

        public Admin(int userId, string loggedInUserName, string loggedInUserSurname, string userType)
        {
            InitializeComponent();
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;
            this.userId = userId;
            this.userType = userType;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private bool IsUserAdmin = false;
        private void Admin_Load(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Administracja"].Enabled = IsUserAdmin;

            FillDataGridViewWorkers();
            LoadWatermeterNames();
            PrzesunNaSrodek(panel1);
        }

        private void Admin_Resize(object sender, EventArgs e)
        {
            PrzesunNaSrodek(panel1);
        }

        private void PrzesunNaSrodek(Control kontrolka)
        {
            int x = (this.ClientSize.Width - kontrolka.Width) / 2;
            int y = (this.ClientSize.Height - kontrolka.Height) / 2;

            kontrolka.Location = new Point(x, y);
        }

        private void LoadWatermeterNames()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM wmnames";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    dataGridView2.Rows.Clear();

                    while (reader.Read())
                    {
                        int watermeterNumber = reader.GetInt32("Id");
                        string watermeterName = reader.GetString("WatermeterName");
                        dataGridView2.Rows.Add(watermeterNumber, watermeterName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania danych: " + ex.Message);
            }
        }

        private void FillDataGridViewWorkers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, Surname, Login, Password, Type FROM users";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        int workerNumber = reader.GetInt32("Id");
                        string name = reader.GetString("Name");
                        string surname = reader.GetString("Surname");
                        string login = reader.GetString("Login");
                        string password = reader.GetString("Password");
                        string workerType = reader.GetString("Type");

                        dataGridView1.Rows.Add(workerNumber, name, surname, login, password, workerType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania danych: " + ex.Message);
            }
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                bool areNewValuesAdded = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isEmptyRow = true;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isEmptyRow = false;
                            break;
                        }
                    }

                    if (!isEmptyRow)
                    {
                        areNewValuesAdded = true;
                        break;
                    }
                }

                if (areNewValuesAdded)
                {
                    DialogResult result = MessageBox.Show("Czy na pewno chcesz przesłać nowe dane do bazy danych?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            InsertNewDataIntoDatabase(dataGridView1);
                            FillDataGridViewWorkers();
                            MessageBox.Show("Nowe dane zostały pomyślnie przesłane do bazy danych.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anulowano zapis nowych danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono nowych danych do zapisu!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono kontrolki DataGridView!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertNewDataIntoDatabase(DataGridView dataGridView)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    bool isNewRow = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isNewRow = true;
                            break;
                        }
                    }

                    if (isNewRow)
                    {
                        string name = row.Cells["name"].Value.ToString();
                        string surName = row.Cells["surname"].Value.ToString();
                        string login = row.Cells["login"].Value.ToString();
                        string password = row.Cells["password"].Value.ToString();
                        string workerType = row.Cells["workerType"].Value.ToString();

                        if (!IsDataExistInDatabase(connection, name, surName, login, password))
                        {
                            string insertDataQuery = "INSERT INTO users (Login, Password, Name, Surname, Type) VALUES (@Login, @Password, @Name, @Surname, @Type)";
                            using (MySqlCommand command = new MySqlCommand(insertDataQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Login", login);
                                command.Parameters.AddWithValue("@Password", password);
                                command.Parameters.AddWithValue("@Name", name);
                                command.Parameters.AddWithValue("@Surname", surName);
                                command.Parameters.AddWithValue("@Type", workerType);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        private bool IsDataExistInDatabase(MySqlConnection connection, string name, string surName, string login, string password)
        {
            string query = "SELECT COUNT(*) FROM users WHERE Name = @Name AND Surname = @Surname AND Login = @Login AND Password = @Password";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surName);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }


        private void Administracja_Click(object sender, EventArgs e)
        {
            Admin form1 = new Admin(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
            this.Hide();
        }

        private void kompletowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kompletowanie form2 = new Kompletowanie(userId, loggedInUserName, loggedInUserSurname, userType);
            form2.Show();
            this.Hide();
        }

        private void wysyłkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wysyłka form1 = new Wysyłka(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
            this.Hide();
        }

        private void wyszukiwarkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wyszukiwarka form4 = new Wyszukiwarka(userId, loggedInUserName, loggedInUserSurname, userType);
            form4.Show();
            this.Hide();
        }

        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klienci form3 = new Klienci(userId, loggedInUserName, loggedInUserSurname, userType);
            form3.Show();
            this.Hide();
        }

        private void btnSaveName_Click(object sender, EventArgs e)
        {
            if (dataGridView2 != null)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string word = row.Cells[1].Value.ToString().Trim();

                        if (!string.IsNullOrWhiteSpace(word))
                        {
                            if (!CheckIfNameExistsInDatabase(word))
                            {
                                SaveNameToDatabase(word);
                            }
                            else
                            {

                            }
                        }
                    }
                }

                MessageBox.Show("Nazwa(y) zostały zapisane do bazy danych.");
                LoadWatermeterNames();
            }
            else
            {
                MessageBox.Show("Nie znaleziono kontrolki DataGridView!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfNameExistsInDatabase(string word)
        {
            bool nameExists = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string queryCheckExistence = "SELECT COUNT(*) FROM wmnames WHERE WatermeterName = @Word";
                    MySqlCommand commandCheckExistence = new MySqlCommand(queryCheckExistence, connection);
                    commandCheckExistence.Parameters.AddWithValue("@Word", word);
                    int nameCount = Convert.ToInt32(commandCheckExistence.ExecuteScalar());

                    if (nameCount > 0)
                    {
                        nameExists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas sprawdzania istnienia danych w bazie: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nameExists;
        }

        private void SaveNameToDatabase(string word)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string queryInsert = "INSERT INTO wmnames (WatermeterName) VALUES (@Word)";
                    MySqlCommand commandInsert = new MySqlCommand(queryInsert, connection);
                    commandInsert.Parameters.AddWithValue("@Word", word);
                    commandInsert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania danych do bazy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDeleteName_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone wiersze?", "Potwierdzenie Usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        string word = row.Cells["wmname"].Value.ToString();

                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();

                        string query = "DELETE FROM wmnames WHERE WatermeterName = @Word";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Word", word);
                        command.ExecuteNonQuery();

                        connection.Close();

                        dataGridView2.Rows.Remove(row);
                    }
                }

                MessageBox.Show("Zaznaczone wiersze zostały pomyślnie usunięte z bazy danych.");
                FillDataGridViewWorkers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone wiersze?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string name = row.Cells["name"].Value.ToString();
                            string surName = row.Cells["surname"].Value.ToString();
                            string login = row.Cells["login"].Value.ToString();
                            string password = row.Cells["password"].Value.ToString();
                            string workerNumber = row.Cells["workerNumber"].Value.ToString();

                            DeleteDataFromDatabase(name, surName, login, password, workerNumber);
                            dataGridView1.Rows.Remove(row);
                        }

                        MessageBox.Show("Zaznaczone wiersze zostały pomyślnie usunięte z bazy danych.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wystąpił błąd podczas usuwania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnych wierszy do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridViewWorkers();
            }
        }

        private void DeleteDataFromDatabase(string name, string surName, string login, string password, string workerNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string deleteDataQuery = "DELETE FROM users WHERE Name = @Name AND Surname = @Surname AND Login = @Login AND Password = @Password AND Id = @WorkerNumber";
                using (MySqlCommand command = new MySqlCommand(deleteDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surName);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@WorkerNumber", workerNumber);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
