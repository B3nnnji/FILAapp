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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FILAapp
{
    public partial class Wyszukiwarka : Form
    {
        private string connectionString = "Server=192.168.1.1;Database=sql_app;Uid=root;Pwd=root;";
        private string loggedInUserName;
        private string loggedInUserSurname;
        private int userId;
        private Kompletowanie mainForm;


        public Wyszukiwarka(int userId, string loggedInUserName, string loggedInUserSurname)
        {
            InitializeComponent();
            this.userId = userId;
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;

            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string numery = txtSearch.Text;

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Wybierz typ wyszukiwania!");
                return;
            }

            string wybranyTyp = checkedListBox1.CheckedItems[0].ToString();

            string[] numeryArray = numery.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(s => s.Trim())
                                          .ToArray();

            foreach (string numer in numeryArray)
            {
                switch (wybranyTyp)
                {
                    case "Wyszukaj po numerze paczki":
                        WyszukajPaczke(numer);
                        break;
                    case "Wyszukaj po numerze seryjnym":
                        WyszukajWodomierz(numer);
                        break;
                    case "Wyszukaj po numerze NIP":
                        WyszukajPoNIP(numer);
                        break;
                    default:
                        MessageBox.Show("Nieznany typ wyszukiwania!");
                        break;
                }
            }
        }

        private void WyszukajPaczke(string numer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT p.PackageNumber, p.CreationDate, p.Client, p.IdWatermeter, c.Name AS ClientName " +
                               $"FROM packages p " +
                               $"INNER JOIN clients c ON p.Client = c.NIP " +
                               $"WHERE p.PackageNumber = '{numer}'";

                var packageData = new List<PackageInfo>();

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dataNadania = reader["CreationDate"].ToString();
                            string status = reader["Client"].ToString();
                            int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);
                            string clientName = reader["ClientName"].ToString();

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
                                    string serialNumber = watermeterReader["SerialNumber"].ToString();
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
        }

        class PackageInfo
        {
            public string DataNadania { get; set; }
            public string Status { get; set; }
            public int IdWatermeter { get; set; }
            public string ClientName { get; set; }
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
                            string numerPaczki = paczkaReader["PackageNumber"].ToString();
                            string dataNadania = paczkaReader["CreationDate"].ToString();
                            string status = paczkaReader["Client"].ToString();
                            string companyName = paczkaReader["CompanyName"].ToString();
                            dataGridView1.Rows.Add(numerPaczki, numerSeryjny, status, companyName, dataNadania);
                        }
                    }
                }
            }
        }

        private void WyszukajPoNIP(string nip)
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

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nip", nip);

                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Brak paczek dla podanego klienta.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string packageNumber = reader["PackageNumber"].ToString();
                                string dataNadania = reader["CreationDate"].ToString();
                                string status = reader["Client"].ToString();
                                int idWatermeter = Convert.ToInt32(reader["IdWatermeter"]);
                                string companyName = reader["CompanyName"].ToString();

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
                            return watermeterReader["SerialNumber"].ToString();
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

        private void kompletowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kompletowanie form2 = new Kompletowanie(userId, loggedInUserName, loggedInUserSurname);
            form2.Show();
            this.Hide();
        }

        private void wyszukiwarkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wyszukiwarka form4 = new Wyszukiwarka(userId, loggedInUserName, loggedInUserSurname);
            form4.Show();
            this.Hide();
        }

        private bool IsUserAdmin = false;

        private void Wyszukiwarka_Load_1(object sender, EventArgs e)
        {
            if (loggedInUserName == "Jakub" && loggedInUserSurname == "Kopek")
            {
                IsUserAdmin = true;
            }
            else if (loggedInUserName == "Bartłomiej" && loggedInUserSurname == "Banaszak")
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;
        }

        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klienci form3 = new Klienci(userId, loggedInUserName, loggedInUserSurname);
            form3.Show();
            this.Hide();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin form1 = new Admin(userId, loggedInUserName, loggedInUserSurname);
            form1.Show();
            this.Hide();
        }

        private void wysyłkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wysyłka form1 = new Wysyłka(userId, loggedInUserName, loggedInUserSurname);
            form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
