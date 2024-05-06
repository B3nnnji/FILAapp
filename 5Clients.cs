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


        public Klienci(int userId, string loggedInUserName, string loggedInUserSurname)
        {
            InitializeComponent();
            this.loggedInUserName = loggedInUserName;
            this.loggedInUserSurname = loggedInUserSurname;
            this.userId = userId;
            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                int rowIndex = row.Index;

                dataGridView1.Rows.RemoveAt(rowIndex);
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
                    string nip = row.Cells["NIP"].Value?.ToString();
                    string nazwaFirmy = row.Cells["name"].Value?.ToString();

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



        private bool IsUserAdmin = false;

        private void Klienci_Load_1(object sender, EventArgs e)
        {
            if (userId == 1 || userId == 2)
            {
                IsUserAdmin = true;
            }

            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;

            WyswietlDaneKlientow();
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
                                string nip = reader["NIP"].ToString();
                                string name = reader["Name"].ToString();
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
    }
}
