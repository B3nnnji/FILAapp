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

namespace FILAapp
{
    public partial class Klienci : Form
    {
        string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";
        private string loggedInUserName;
        private string loggedInUserSurname;
        private int userId;
        private string userType;

        public Klienci(int userId, string loggedInUserName, string loggedInUserSurname, string userType)
        {
            InitializeComponent();
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;
            this.userId = userId;
            this.userType = userType;
            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }

        private bool IsUserAdmin = false;
        private void Klienci_Load_1(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;

            WyswietlDaneKlientow();
            PrzesunNaSrodek(panel1);
            UstawNaDolnymLewymRogu(labelUserInfo);
        }

        private void Klienci_Resize(object sender, EventArgs e)
        {
            PrzesunNaSrodek(panel1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            DialogResult = MessageBox.Show("Czy napewno chcesz usunąć zaznaczonych klientów z bazy danych?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if (row.Selected)
                    {
                        string nip = row.Cells["NIP"].Value?.ToString() ?? string.Empty;
                        UsunZBazyDanych(nip);
                        
                        dataGridView1.Rows.Remove(row);
                    }
                }
                dataGridView1.Refresh();
            }
        }

        private void UsunZBazyDanych(string nip)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM clients WHERE NIP = @nip";
                using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@nip", nip);
                    deleteCommand.ExecuteNonQuery();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ZapiszDoBazyDanych();
        }

        private void ZapiszDoBazyDanych()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string nip = row.Cells["NIP"].Value?.ToString() ?? string.Empty;
                    string nazwaFirmy = row.Cells["name"].Value?.ToString() ?? string.Empty;

                    string checkExistingQuery = "SELECT COUNT(*) FROM clients WHERE NIP = @nip";
                    using (var checkCommand = new MySqlCommand(checkExistingQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@nip", nip);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingCount == 0)
                        {
                            string insertQuery = "INSERT INTO clients (NIP, Name) VALUES (@nip, @nazwaFirmy)";
                            using (var insertCommand = new MySqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@nip", nip);
                                insertCommand.Parameters.AddWithValue("@nazwaFirmy", string.IsNullOrEmpty(nazwaFirmy) ? DBNull.Value : (object)nazwaFirmy);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Dane zapisane do bazy danych.");
            }
        }

        private void WyswietlDaneKlientow()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NIP, Name FROM clients";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nip = reader["NIP"]?.ToString() ?? string.Empty;
                                string name = reader["Name"]?.ToString() ?? string.Empty;
                                dataGridView1.Rows.Add(nip, name);
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
            this.Hide();
        }
    }
}
