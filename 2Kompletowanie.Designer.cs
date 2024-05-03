namespace FILAapp
{
    partial class Kompletowanie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kompletowanie));
            labelUserInfo = new Label();
            comboBox1 = new ComboBox();
            btnEnd = new Button();
            dataGridView1 = new DataGridView();
            nazwa = new DataGridViewTextBoxColumn();
            numer_seryjny = new DataGridViewTextBoxColumn();
            idproduktu = new DataGridViewTextBoxColumn();
            idpracownika = new DataGridViewTextBoxColumn();
            packing_date = new DataGridViewTextBoxColumn();
            client = new DataGridViewTextBoxColumn();
            label1 = new Label();
            button1 = new Button();
            btnClear = new Button();
            btnPrint = new Button();
            button2 = new Button();
            panel1 = new Panel();
            kompletowanieToolStripMenuItem = new ToolStripMenuItem();
            wysyłkaToolStripMenuItem = new ToolStripMenuItem();
            wyszukiwarkaToolStripMenuItem = new ToolStripMenuItem();
            klienciToolStripMenuItem = new ToolStripMenuItem();
            Admin = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelUserInfo.Location = new Point(12, 981);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(65, 22);
            labelUserInfo.TabIndex = 8;
            labelUserInfo.Text = "label2";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(720, 765);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(481, 40);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Wybierz nazwę wodomierza...";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnEnd
            // 
            btnEnd.BackColor = SystemColors.ScrollBar;
            btnEnd.FlatStyle = FlatStyle.Popup;
            btnEnd.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEnd.Location = new Point(1097, 671);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(184, 69);
            btnEnd.TabIndex = 2;
            btnEnd.Text = "ZAPISZ PACZKĘ";
            btnEnd.UseVisualStyleBackColor = false;
            btnEnd.Click += btnEnd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ScrollBar;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nazwa, numer_seryjny, idproduktu, idpracownika, packing_date, client });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = SystemColors.InfoText;
            dataGridView1.Location = new Point(400, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(1120, 550);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // nazwa
            // 
            nazwa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nazwa.DataPropertyName = "nazwa";
            nazwa.HeaderText = "Nazwa wodomierza";
            nazwa.Name = "nazwa";
            nazwa.Resizable = DataGridViewTriState.True;
            nazwa.Width = 185;
            // 
            // numer_seryjny
            // 
            numer_seryjny.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            numer_seryjny.HeaderText = "Numer fabryczny";
            numer_seryjny.Name = "numer_seryjny";
            numer_seryjny.Width = 165;
            // 
            // idproduktu
            // 
            idproduktu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idproduktu.HeaderText = "Numer w paczce";
            idproduktu.Name = "idproduktu";
            idproduktu.Width = 161;
            // 
            // idpracownika
            // 
            idpracownika.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idpracownika.HeaderText = "Numer pracownika";
            idpracownika.Name = "idpracownika";
            idpracownika.Width = 179;
            // 
            // packing_date
            // 
            packing_date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            packing_date.HeaderText = "Data pakowania";
            packing_date.Name = "packing_date";
            packing_date.Width = 157;
            // 
            // client
            // 
            client.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            client.HeaderText = "Klient";
            client.Name = "client";
            client.Width = 85;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(817, 50);
            label1.Name = "label1";
            label1.Size = new Size(286, 41);
            label1.TabIndex = 6;
            label1.Text = "TWOJA PACZKA";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(400, 671);
            button1.Name = "button1";
            button1.Size = new Size(184, 69);
            button1.TabIndex = 9;
            button1.Text = "DODAJ NOWY WIERSZ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ScrollBar;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(867, 671);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(184, 69);
            btnClear.TabIndex = 10;
            btnClear.Text = "WYCZYŚĆ TABELĘ";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = SystemColors.ScrollBar;
            btnPrint.FlatStyle = FlatStyle.Popup;
            btnPrint.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrint.Location = new Point(1336, 671);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(184, 69);
            btnPrint.TabIndex = 11;
            btnPrint.Text = "DRUKUJ NAKLEJKĘ";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ScrollBar;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(630, 671);
            button2.Name = "button2";
            button2.Size = new Size(184, 69);
            button2.TabIndex = 12;
            button2.Text = "USUŃ OSTATNI WIERSZ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnPrint);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btnEnd);
            panel1.Location = new Point(0, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 827);
            panel1.TabIndex = 14;
            // 
            // kompletowanieToolStripMenuItem
            // 
            kompletowanieToolStripMenuItem.Name = "kompletowanieToolStripMenuItem";
            kompletowanieToolStripMenuItem.Size = new Size(167, 34);
            kompletowanieToolStripMenuItem.Text = "Kompletowanie";
            kompletowanieToolStripMenuItem.Click += kompletowanieToolStripMenuItem_Click_1;
            // 
            // wysyłkaToolStripMenuItem
            // 
            wysyłkaToolStripMenuItem.Name = "wysyłkaToolStripMenuItem";
            wysyłkaToolStripMenuItem.Size = new Size(101, 34);
            wysyłkaToolStripMenuItem.Text = "Wysyłka";
            wysyłkaToolStripMenuItem.Click += wysyłkaToolStripMenuItem_Click;
            // 
            // wyszukiwarkaToolStripMenuItem
            // 
            wyszukiwarkaToolStripMenuItem.Name = "wyszukiwarkaToolStripMenuItem";
            wyszukiwarkaToolStripMenuItem.Size = new Size(155, 34);
            wyszukiwarkaToolStripMenuItem.Text = "Wyszukiwarka";
            wyszukiwarkaToolStripMenuItem.Click += wyszukiwarkaToolStripMenuItem_Click;
            // 
            // klienciToolStripMenuItem
            // 
            klienciToolStripMenuItem.Name = "klienciToolStripMenuItem";
            klienciToolStripMenuItem.Size = new Size(85, 34);
            klienciToolStripMenuItem.Text = "Klienci";
            klienciToolStripMenuItem.Click += klienciToolStripMenuItem_Click;
            // 
            // Admin
            // 
            Admin.Name = "Admin";
            Admin.Size = new Size(151, 34);
            Admin.Text = "Administracja";
            Admin.Click += Admin_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Window;
            menuStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { kompletowanieToolStripMenuItem, wysyłkaToolStripMenuItem, wyszukiwarkaToolStripMenuItem, klienciToolStripMenuItem, Admin });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 38);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // Kompletowanie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Controls.Add(labelUserInfo);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Kompletowanie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paczka";
            WindowState = FormWindowState.Maximized;
            Load += Kompletowanie_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelUserInfo;
        private ComboBox comboBox1;
        private Button btnEnd;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button btnClear;
        private Button btnPrint;
        private Button button2;
        private Panel panel1;
        private ToolStripMenuItem kompletowanieToolStripMenuItem;
        private ToolStripMenuItem wysyłkaToolStripMenuItem;
        private ToolStripMenuItem wyszukiwarkaToolStripMenuItem;
        private ToolStripMenuItem klienciToolStripMenuItem;
        private ToolStripMenuItem Admin;
        private MenuStrip menuStrip1;
        private DataGridViewTextBoxColumn nazwa;
        private DataGridViewTextBoxColumn numer_seryjny;
        private DataGridViewTextBoxColumn idproduktu;
        private DataGridViewTextBoxColumn idpracownika;
        private DataGridViewTextBoxColumn packing_date;
        private DataGridViewTextBoxColumn client;
    }
}