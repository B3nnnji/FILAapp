using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using MySql.Data.MySqlClient;
using ZXing.QrCode;
using Org.BouncyCastle.Bcpg;
using System.Collections;
using Microsoft.VisualBasic;
using ZXing.Windows.Compatibility;
using Microsoft.VisualBasic.Logging;

namespace FILAapp
{
    public partial class Kompletowanie : Form
    {
        private MySqlConnection connection;
        private string connectionString = "Server=10.0.5.3;Database=sql_app;Uid=root;Pwd=root;";
        private string loggedInUserName;
        private string loggedInUserSurname;
        private int userId;
        private string userType;
        private bool isDataInsertionSuccessful = false;
        public Kompletowanie(int userId, string userName, string userSurname, string userType)
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            this.userId = userId;
            loggedInUserName = userName;
            loggedInUserSurname = userSurname;
            this.userType = userType;
            labelUserInfo.Text = $"Zalogowano jako: {loggedInUserName} {loggedInUserSurname}";
        }

        private bool IsUserAdmin = false;
        private void Kompletowanie_Load(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                IsUserAdmin = true;
            }
            menuStrip1.Items["Admin"].Enabled = IsUserAdmin;
            LoadDataToComboBox();
            PrzesunNaSrodek(panel2);
            UstawNaDolnymLewymRogu(labelUserInfo);
        }

        private void Kompletowanie_Resize(object sender, EventArgs e)
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

        private void LoadDataToComboBox()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT DISTINCT WatermeterName FROM wmnames";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["WatermeterName"].ToString());
            }

            connection.Close();
        }

        private int GetLastPackageNumberFromDatabase()
        {
            int lastPackageNumber = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PackageNumber FROM packages ORDER BY PackageNumber DESC LIMIT 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastPackageNumber = Convert.ToInt32(result);
                    }
                }
            }
            return lastPackageNumber;
        }

        private int GetLastWatermeterIdFromDatabase()
        {
            int lastWatermeterId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id FROM watermeters ORDER BY Id DESC LIMIT 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastWatermeterId = Convert.ToInt32(result);
                    }
                }
            }
            return lastWatermeterId;
        }

        private void InsertDataIntoDatabase(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    int lastPackageNumber = GetLastPackageNumberFromDatabase();
                    lastPackageNumber++;

                    int tmplastWatermeterId = GetLastWatermeterIdFromDatabase();

                    try
                    {
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            tmplastWatermeterId++;

                            if (IsRowFull(row))
                            {
                                string name = row.Cells["nazwa"]?.Value.ToString() ?? string.Empty;
                                string serialNumber = row.Cells["numer_seryjny"]?.Value.ToString() ?? string.Empty;
                                int employeeId = Convert.ToInt32(row.Cells["idpracownika"].Value);
                                int productId = Convert.ToInt32(row.Cells["idproduktu"].Value);
                                string klient = row.Cells["Client"]?.Value.ToString() ?? string.Empty;

                                if (CheckForDuplicate(serialNumber))
                                {
                                    DialogResult result = MessageBox.Show($"Numer seryjny {serialNumber} już istnieje w bazie danych. Czy chcesz kontynuować i zastąpić istniejące dane?", "Duplikat znaleziony", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (result == DialogResult.No)
                                    {
                                        transaction.Rollback();
                                        isDataInsertionSuccessful = false;
                                        return;
                                    }
                                    else
                                    {
                                        RemoveDuplicate(serialNumber, connection, transaction);
                                    }
                                }

                                string insertWatermeterQuery = "INSERT INTO watermeters (Name, SerialNumber, Worker, IdInPackage) VALUES (@Name, @SerialNumber, @EmployeeId, @ProductId)";
                                using (MySqlCommand watermeterCommand = new MySqlCommand(insertWatermeterQuery, connection, transaction))
                                {
                                    watermeterCommand.Parameters.AddWithValue("@Name", name);
                                    watermeterCommand.Parameters.AddWithValue("@SerialNumber", serialNumber);
                                    watermeterCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                                    watermeterCommand.Parameters.AddWithValue("@ProductId", productId);
                                    watermeterCommand.ExecuteNonQuery();
                                }

                                string insertPackageQuery = "INSERT INTO packages (PackageNumber, IdWatermeter, Client, CreationDate) VALUES (@PackageNumber, @IdWatermeter, @Klient, NOW())";
                                using (MySqlCommand packageCommand = new MySqlCommand(insertPackageQuery, connection, transaction))
                                {
                                    packageCommand.Parameters.AddWithValue("@PackageNumber", lastPackageNumber);
                                    packageCommand.Parameters.AddWithValue("@IdWatermeter", tmplastWatermeterId);
                                    packageCommand.Parameters.AddWithValue("@Klient", klient);
                                    packageCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        isDataInsertionSuccessful = true;
                        MessageBox.Show("Dane zostały pomyślnie przesłane do bazy danych.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        isDataInsertionSuccessful = false;
                        MessageBox.Show($"Wystąpił błąd podczas przesyłania danych do bazy danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak danych do przesłania do bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RemoveDuplicate(string serialNumber, MySqlConnection connection, MySqlTransaction transaction)
        {
            string deletePackageQuery = "DELETE FROM packages WHERE IdWatermeter IN (SELECT Id FROM watermeters WHERE SerialNumber = @SerialNumber)";
            using (MySqlCommand deletePackageCommand = new MySqlCommand(deletePackageQuery, connection, transaction))
            {
                deletePackageCommand.Parameters.AddWithValue("@SerialNumber", serialNumber);
                deletePackageCommand.ExecuteNonQuery();
            }

            string deleteWatermeterQuery = "DELETE FROM watermeters WHERE SerialNumber = @SerialNumber";
            using (MySqlCommand deleteWatermeterCommand = new MySqlCommand(deleteWatermeterQuery, connection, transaction))
            {
                deleteWatermeterCommand.Parameters.AddWithValue("@SerialNumber", serialNumber);
                deleteWatermeterCommand.ExecuteNonQuery();
            }
        }


        private bool CheckForDuplicate(string serialNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM watermeters WHERE SerialNumber = @SerialNumber";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private bool IsRowFull(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
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
                                    if (!dataGridView1.Rows[i].IsNewRow)
                                    {
                                        dataGridView1.Rows[i].Cells["Client"].Value = klient;
                                    }
                                    else
                                    {
                                        break;
                                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć ostatni wiersz?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].IsNewRow)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    }
                }
            }
            else
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!isDataInsertionSuccessful)
            {
                MessageBox.Show("Dane nie zostały zapisane do bazy danych. Najpierw zapisz dane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isDataGridViewFilled = true;

            if (dataGridView1 != null)
            {
                int rowCount = dataGridView1.Rows.Count;
                for (int i = 0; i < rowCount - 1; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isDataGridViewFilled = false;
                            break;
                        }
                    }

                    if (!isDataGridViewFilled)
                        break;
                }
            }

            if (!isDataGridViewFilled)
            {
                MessageBox.Show("Uzupełnij brakujące pola!.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Czy na pewno chcesz wydrukować naklejkę?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string nazwa = dataGridView1?.Rows[0]?.Cells["Nazwa"]?.Value.ToString() ?? string.Empty;

                int tmpLastPackageNumber = GetLastPackageNumberFromDatabase();
                tmpLastPackageNumber++;

                string combinedData = $"{tmpLastPackageNumber - 1}";
                BarcodeWriter writer1 = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
                Bitmap qrCodeBitmap = writer1.Write(combinedData);

                string stickerLoggedInUserName = loggedInUserName;
                string stickerLoggedInUserSurname = loggedInUserSurname;

                Naklejka form4 = new Naklejka(stickerLoggedInUserName, stickerLoggedInUserSurname, nazwa, tmpLastPackageNumber, qrCodeBitmap);
                form4.Show();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz wyczyścić wszystkie wiersze?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem?.ToString() ?? string.Empty;
            DateTime currentDate = DateTime.Today;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                if (dataGridView1.Rows[row].IsNewRow)
                    break;

                dataGridView1.Rows[row].Cells["nazwa"].Value = selectedValue;
                dataGridView1.Rows[row].Cells["idproduktu"].Value = row + 1;
                dataGridView1.Rows[row].Cells["idpracownika"].Value = userId;
                dataGridView1.Rows[row].Cells["packing_date"].Value = currentDate.ToString("yyyy-MM-dd");
            }
        }

        private void btnEnd_Click_1(object sender, EventArgs e)
        {
            bool isDataGridViewFilled = true;

            if (dataGridView1 != null)
            {
                int rowCount = dataGridView1.Rows.Count;
                for (int i = 0; i < rowCount - 1; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isDataGridViewFilled = false;
                            break;
                        }
                    }

                    if (!isDataGridViewFilled)
                        break;
                }

                if (isDataGridViewFilled)
                {
                    DialogResult result = MessageBox.Show("Czy na pewno chcesz przesłać dane do bazy danych?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            InsertDataIntoDatabase(dataGridView1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anulowano zapis danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Uzupełnij brakujące pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono kontrolki DataGridView!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void kompletowanieToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
