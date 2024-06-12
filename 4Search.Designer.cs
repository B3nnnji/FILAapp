namespace FILAapp
{
    partial class Wyszukiwarka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wyszukiwarka));
            button1 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            packageNumber = new DataGridViewTextBoxColumn();
            serialNumber = new DataGridViewTextBoxColumn();
            client = new DataGridViewTextBoxColumn();
            clientName = new DataGridViewTextBoxColumn();
            CreationDate = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            checkedListBox1 = new CheckedListBox();
            menuStrip1 = new MenuStrip();
            kompletowanieToolStripMenuItem = new ToolStripMenuItem();
            wysyłkaToolStripMenuItem = new ToolStripMenuItem();
            wyszukiwarkaToolStripMenuItem = new ToolStripMenuItem();
            klienciToolStripMenuItem = new ToolStripMenuItem();
            Admin = new ToolStripMenuItem();
            label2 = new Label();
            labelUserInfo = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            panel2 = new Panel();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(95, 508);
            button1.Name = "button1";
            button1.Size = new Size(125, 44);
            button1.TabIndex = 0;
            button1.Text = "SZUKAJ\r\n";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(599, 54);
            label1.Name = "label1";
            label1.Size = new Size(402, 37);
            label1.TabIndex = 2;
            label1.Text = "WYSZUKIWANIE PACZEK\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { packageNumber, serialNumber, client, clientName, CreationDate });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(348, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(864, 620);
            dataGridView1.TabIndex = 4;
            // 
            // packageNumber
            // 
            packageNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            packageNumber.HeaderText = "Numer paczki";
            packageNumber.Name = "packageNumber";
            packageNumber.Width = 131;
            // 
            // serialNumber
            // 
            serialNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            serialNumber.HeaderText = "Numer seryjny";
            serialNumber.Name = "serialNumber";
            serialNumber.Width = 138;
            // 
            // client
            // 
            client.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            client.HeaderText = "Numer NIP";
            client.Name = "client";
            client.Width = 113;
            // 
            // clientName
            // 
            clientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clientName.HeaderText = "Nazwa Klienta";
            clientName.Name = "clientName";
            clientName.Width = 133;
            // 
            // CreationDate
            // 
            CreationDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CreationDate.HeaderText = "Data pakowania";
            CreationDate.Name = "CreationDate";
            CreationDate.Width = 146;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(14, 215);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(291, 33);
            txtSearch.TabIndex = 8;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.Window;
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Wyszukaj po numerze paczki", "Wyszukaj po numerze seryjnym", "Wyszukaj po numerze NIP", "Wyszukaj po dacie" });
            checkedListBox1.Location = new Point(14, 97);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(291, 98);
            checkedListBox1.TabIndex = 9;
            checkedListBox1.ThreeDCheckBoxes = true;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Window;
            menuStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { kompletowanieToolStripMenuItem, wysyłkaToolStripMenuItem, wyszukiwarkaToolStripMenuItem, klienciToolStripMenuItem, Admin });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 38);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // kompletowanieToolStripMenuItem
            // 
            kompletowanieToolStripMenuItem.Name = "kompletowanieToolStripMenuItem";
            kompletowanieToolStripMenuItem.Size = new Size(167, 34);
            kompletowanieToolStripMenuItem.Text = "Kompletowanie";
            kompletowanieToolStripMenuItem.Click += kompletowanieToolStripMenuItem_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(32, 15);
            label2.Name = "label2";
            label2.Size = new Size(257, 66);
            label2.TabIndex = 11;
            label2.Text = "WYBIERZ SPOSÓB \r\nWYSZUKIWANIA I \r\nWPISZ WARTOŚĆ PONIŻEJ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelUserInfo.Location = new Point(12, 890);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(65, 22);
            labelUserInfo.TabIndex = 12;
            labelUserInfo.Text = "label3";
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(6, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 620);
            panel1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(14, 446);
            label5.Name = "label5";
            label5.Size = new Size(28, 16);
            label5.TabIndex = 16;
            label5.Text = "Do:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(14, 381);
            label4.Name = "label4";
            label4.Size = new Size(29, 16);
            label4.TabIndex = 15;
            label4.Text = "Od:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(14, 282);
            label3.Name = "label3";
            label3.Size = new Size(299, 66);
            label3.TabIndex = 14;
            label3.Text = "W PRZYPADKU WYSZUKIWANIA\r\nPO DACIE WYBIERZ \r\nODPOWIEDNI ZAKRES";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Location = new Point(14, 465);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(291, 26);
            dateTimePicker2.TabIndex = 13;
            dateTimePicker2.Value = new DateTime(2024, 6, 12, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(14, 400);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(291, 26);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.Value = new DateTime(2024, 6, 12, 0, 0, 0, 0);
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(15, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(1215, 659);
            panel2.TabIndex = 14;
            panel2.Resize += panel2_Resize;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // Wyszukiwarka
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1264, 921);
            Controls.Add(panel2);
            Controls.Add(labelUserInfo);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Wyszukiwarka";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wyszukiwarka paczek";
            Load += Wyszukiwarka_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private CheckedListBox checkedListBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem kompletowanieToolStripMenuItem;
        private ToolStripMenuItem wysyłkaToolStripMenuItem;
        private ToolStripMenuItem wyszukiwarkaToolStripMenuItem;
        private ToolStripMenuItem klienciToolStripMenuItem;
        private ToolStripMenuItem Admin;
        private Label label2;
        private Label labelUserInfo;
        private DataGridViewTextBoxColumn packageNumber;
        private DataGridViewTextBoxColumn serialNumber;
        private DataGridViewTextBoxColumn client;
        private DataGridViewTextBoxColumn clientName;
        private DataGridViewTextBoxColumn CreationDate;
        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Label label4;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
    }
}
