using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FILAapp
{
    public partial class Wyszukiwarka : Form
    {
        private string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";
        private string loggedInUserName;
        private string loggedInUserSurname;
        private int userId;
        private string userType;

        public Wyszukiwarka(int userId, string loggedInUserName, string loggedInUserSurname, string userType)
        {
            InitializeComponent();
            this.userId = userId;
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;
            this.userType = userType;
            checkedListBox1.ItemCheck += new ItemCheckEventHandler(checkedListBox1_ItemCheck);

            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }

        private bool IsUserAdmin = false;
        private void Wyszukiwarka_Load_1(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;

            PrzesunNaSrodek(panel2);
            UstawNaDolnymLewymRogu(labelUserInfo);
        }

        private void panel2_Resize(object sender, EventArgs e)
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

        public class PackageInfo
        {
            public string PackageNumber { get; set; }
            public string DataNadania { get; set; }
            public string Status { get; set; }
            public int IdWatermeter { get; set; }
            public string ClientName { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string numery = txtSearch.Text.Trim();
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                startDate = dateTimePicker1.Value;
                endDate = dateTimePicker2.Value;
            }

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Wybierz typ wyszukiwania!");
                return;
            }

            string wybranyTyp = checkedListBox1.CheckedItems[0]?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(numery) && wybranyTyp != "Wyszukaj po dacie")
            {
                MessageBox.Show("Wprowadź numery do wyszukiwania.");
                return;
            }

            string[] numeryArray = numery.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(s => s.Trim())
                                          .ToArray();

            switch (wybranyTyp)
            {
                case "Wyszukaj po dacie":
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        WyszukajPoDacie(startDate.Value, endDate.Value);
                    }
                    else
                    {
                        MessageBox.Show("Podaj zakres dat.");
                    }
                    break;
                case "Wyszukaj po numerze paczki":
                    foreach (string numer in numeryArray)
                    {
                        WyszukajPaczke(numer);
                    }
                    break;
                case "Wyszukaj po numerze NIP":
                    foreach (string numer in numeryArray)
                    {
                        WyszukajPoNIP(numer);
                    }
                    break;
                case "Wyszukaj po numerze fabrycznym":
                    foreach (string numer in numeryArray)
                    {
                        WyszukajWodomierz(numer);
                    }
                    break;
                case "Wyszukaj po numerze NIP w zakresie dat":
                    foreach (string numer in numeryArray)
                    {
                        WyszukajPoNIP(numer, startDate, endDate);
                    }
                    break;
                default:
                    MessageBox.Show("Nieznany typ wyszukiwania!");
                    break;
            }
        }


        private void WyszukajPoDacie(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.PackageNumber, p.CreationDate, p.Client, p.IdWatermeter, c.Name AS CompanyName " +
                                   "FROM packages p " +
                                   "INNER JOIN clients c ON p.Client = c.NIP " +
                                   "WHERE DATE(p.CreationDate) BETWEEN @StartDate AND @EndDate";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Brak paczek w wybranym zakresie dat.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string packageNumber = reader["PackageNumber"]?.ToString() ?? string.Empty;
                                string dataNadania = ((DateTime)reader["CreationDate"]).ToString("yyyy-MM-dd");
                                string status = reader["Client"]?.ToString() ?? string.Empty;
                                int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);
                                string companyName = reader["CompanyName"]?.ToString() ?? string.Empty;

                                string serialNumber = PobierzNumerSeryjnyWodomierza(idWatermeter);

                                dataGridView1.Rows.Add(packageNumber, serialNumber, status, companyName, dataNadania);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void WyszukajPaczke(string numer, DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT p.PackageNumber, p.CreationDate, p.Client, p.IdWatermeter, c.Name AS ClientName " +
                               $"FROM packages p " +
                               $"INNER JOIN clients c ON p.Client = c.NIP " +
                               $"WHERE p.PackageNumber = @numer";

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND DATE(p.CreationDate) BETWEEN @StartDate AND @EndDate";
                }

                var packageData = new List<PackageInfo>();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numer", numer);
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EndDate", endDate.Value.ToString("yyyy-MM-dd"));
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dataNadania = ((DateTime)reader["CreationDate"]).ToString("yyyy-MM-dd");
                            string status = reader["Client"]?.ToString() ?? string.Empty;
                            int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);
                            string clientName = reader["ClientName"]?.ToString() ?? string.Empty;

                            packageData.Add(new PackageInfo
                            {
                                DataNadania = dataNadania,
                                Status = status,
                                IdWatermeter = idWatermeter,
                                ClientName = clientName
                            });
                        }
                    }
                }
                if (packageData.Count > 0)
                {
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
                                        dataGridView1.Rows.Add(numer, serialNumber, package.Status, package.ClientName, package.DataNadania);
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
                else
                {
                    MessageBox.Show("Nie znaleziono paczki o podanym numerze w podanym zakresie dat.");
                }
            }
        }

        private void WyszukajPoNIP(string nip, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT p.PackageNumber, p.CreationDate, p.Client, p.IdWatermeter, c.Name AS CompanyName " +
                                   "FROM packages p " +
                                   "INNER JOIN clients c ON p.Client = c.NIP " +
                                   "WHERE p.Client = @nip";

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        query += " AND DATE(p.CreationDate) BETWEEN @StartDate AND @EndDate";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nip", nip);
                        if (startDate.HasValue && endDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@StartDate", startDate.Value.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@EndDate", endDate.Value.ToString("yyyy-MM-dd"));
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Brak paczek dla podanego klienta.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string packageNumber = reader["PackageNumber"]?.ToString() ?? string.Empty;
                                string dataNadania = ((DateTime)reader["CreationDate"]).ToString("yyyy-MM-dd");
                                string status = reader["Client"]?.ToString() ?? string.Empty;
                                int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);
                                string companyName = reader["CompanyName"]?.ToString() ?? string.Empty;

                                string serialNumber = PobierzNumerSeryjnyWodomierza(idWatermeter);

                                dataGridView1.Rows.Add(packageNumber, serialNumber, status, companyName, dataNadania);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void WyszukajWodomierz(string numerSeryjny)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string getIdQuery = $"SELECT Id FROM watermeters WHERE SerialNumber = '{numerSeryjny}'";
                int idWodomierza = 0;

                using (var getIdCommand = new MySqlCommand(getIdQuery, connection))
                {
                    var result = getIdCommand.ExecuteScalar();
                    if (result != null)
                    {
                        idWodomierza = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono wodomierza o podanym numerze seryjnym.");
                        return;
                    }
                }

                string getPaczkaQuery = $"SELECT p.PackageNumber, p.CreationDate, p.Client, c.Name AS CompanyName " +
                                        $"FROM packages p " +
                                        $"INNER JOIN clients c ON p.Client = c.NIP " +
                                        $"WHERE p.IdWatermeter = {idWodomierza}";

                using (var getPaczkaCommand = new MySqlCommand(getPaczkaQuery, connection))
                {
                    using (var paczkaReader = getPaczkaCommand.ExecuteReader())
                    {
                        while (paczkaReader.Read())
                        {
                            string numerPaczki = paczkaReader["PackageNumber"]?.ToString() ?? string.Empty;
                            string dataNadania = ((DateTime)paczkaReader["CreationDate"]).ToString("yyyy-MM-dd");
                            string status = paczkaReader["Client"]?.ToString() ?? string.Empty;
                            string companyName = paczkaReader["CompanyName"]?.ToString() ?? string.Empty;
                            dataGridView1.Rows.Add(numerPaczki, numerSeryjny, status, companyName, dataNadania);
                        }
                    }
                }
            }
        }


        private string PobierzNumerSeryjnyWodomierza(int idWatermeter)
        {
            using (var innerConnection = new MySqlConnection(connectionString))
            {
                innerConnection.Open();
                string watermeterQuery = "SELECT SerialNumber FROM watermeters WHERE Id = @idWatermeter";

                using (var watermeterCommand = new MySqlCommand(watermeterQuery, innerConnection))
                {
                    watermeterCommand.Parameters.AddWithValue("@idWatermeter", idWatermeter);

                    using (var watermeterReader = watermeterCommand.ExecuteReader())
                    {
                        if (watermeterReader.Read())
                        {
                            return watermeterReader["SerialNumber"]?.ToString() ?? string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono wodomierza o podanym numerze.");
                            return string.Empty;
                        }
                    }
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
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

        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klienci form3 = new Klienci(userId, loggedInUserName, loggedInUserSurname, userType);
            form3.Show();
            this.Hide();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin form1 = new Admin(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
            this.Hide();
        }

        private void wysyłkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wysyłka form1 = new Wysyłka(userId, loggedInUserName, loggedInUserSurname, userType);
            form1.Show();
        }

        private void Wyszukiwarka_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
