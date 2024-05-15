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
    public partial class Wysyłka : Form
    {
        private string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";
        private int userId;
        private string loggedInUserName;
        private string loggedInUserSurname;
        private string userType;

        public Wysyłka(int userId, string loggedInUserName, string loggedInUserSurname, string userType)
        {
            InitializeComponent();
            this.userId = userId;
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;
            this.userType = userType;
            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numery = txtSearch.Text;
            string[] numeryArray = numery.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(s => s.Trim())
                                          .ToArray();

            foreach (string numer in numeryArray)
            {
                WyszukajPaczke(numer);
            }
        }

        private void WyszukajPaczke(string numer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT PackageNumber, CreationDate, Client, IdWatermeter FROM packages WHERE PackageNumber = '{numer}'";

                var packageData = new List<PackageInfo>();

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dataNadania = reader["CreationDate"]?.ToString() ?? string.Empty;
                            string status = reader["Client"]?.ToString() ?? string.Empty;
                            int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);

                            packageData.Add(new PackageInfo
                            {
                                DataNadania = dataNadania,
                                Status = status,
                                IdWatermeter = idWatermeter
                            });
                        }
                    }
                }

                foreach (var package in packageData)
                {
                    using (var innerConnection = new MySqlConnection(connectionString))
                    {
                        innerConnection.Open();
                        string watermeterQuery = $"SELECT SerialNumber FROM watermeters WHERE Id = {package.IdWatermeter}";

                        using (var watermeterCommand = new MySqlCommand(watermeterQuery, innerConnection))
                        {
                            using (var watermeterReader = watermeterCommand.ExecuteReader())
                            {
                                if (watermeterReader.Read())
                                {
                                    string serialNumber = watermeterReader["SerialNumber"]?.ToString() ?? string.Empty;
                                    dataGridView1.Rows.Add(numer, serialNumber, package.DataNadania, package.Status);
                                }
                                else
                                {
                                    MessageBox.Show("Nie znaleziono wodomierza o podanym numerze.");
                                }
                            }
                        }
                    }
                }
            }
        }


        class PackageInfo
        {
            public string DataNadania { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public int IdWatermeter { get; set; }
        }

        private bool IsUserAdmin = false;

        private void Wysyłka_Load(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;

            PrzesunNaSrodek(panel2);
            UstawNaDolnymLewymRogu(labelUserInfo);
        }

        private void Wysyłka_Resize(object sender, EventArgs e)
        {
            PrzesunNaSrodek(panel2);
            UstawNaDolnymLewymRogu(labelUserInfo);
        }

        private void PrzesunNaSrodek(Control kontrolka)
        {
            int x = (this.ClientSize.Width - kontrolka.Width) / 2;
            int y = (this.ClientSize.Height - kontrolka.Height) / 2;

            kontrolka.Location = new Point(x, y);
        }

        private void UstawNaDolnymLewymRogu(Control kontrolka)
        {
            int x = 12;
            int y = this.ClientSize.Height - kontrolka.Height;

            kontrolka.Location = new Point(x, y);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Client"].Index)
            {
                string klient = dataGridView1.Rows[e.RowIndex].Cells["Client"]?.Value.ToString() ?? string.Empty;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = $"SELECT COUNT(*) FROM clients WHERE NIP = @NIP";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NIP", klient);
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0 || klient.ToLower() == "magazyn")
                            {
                                for (int i = e.RowIndex + 1; i < dataGridView1.Rows.Count; i++)
                                {
                                    dataGridView1.Rows[i].Cells["Client"].Value = klient;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Podany NIP nie istnieje w bazie danych. Wprowadź poprawny NIP.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zaktualizować dane w bazie danych", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ZapiszDaneDoBazy();
            }
            else
            {
            }
        }

        private void ZapiszDaneDoBazy()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string packageNumber = row.Cells["packageNumber"]?.Value.ToString() ?? string.Empty;
                        string nipValue = row.Cells["client"]?.Value.ToString() ?? string.Empty;

                        string updateQuery = $"UPDATE packages SET Client = '{nipValue}' WHERE PackageNumber = '{packageNumber}'";
                        using (var command = new MySqlCommand(updateQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Dane zaktualizowane w bazie danych!");
            }
        }


        private void wysyłkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wysyłka form1 = new Wysyłka(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
            this.Hide();
        }

        private void kompletowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kompletowanie form2 = new Kompletowanie(userId, loggedInUserName, loggedInUserSurname, userType);
            form2.Show();
            this.Hide();
        }

        private void wyszukiwarkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wyszukiwarka form4 = new Wyszukiwarka(userId, loggedInUserName, loggedInUserSurname, userType);
            form4.Show();
            this.Hide();
        }

        private void administracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin form1 = new Admin(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
            this.Hide();
        }

        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klienci form3 = new Klienci(userId, loggedInUserName, loggedInUserSurname, userType);
            form3.Show();
            this.Hide();
        }
    }
}
