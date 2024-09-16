namespace FILAapp
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            menuStrip1 = new MenuStrip();
            kompletowanieToolStripMenuItem = new ToolStripMenuItem();
            wysyłkaToolStripMenuItem = new ToolStripMenuItem();
            wyszukiwarkaToolStripMenuItem = new ToolStripMenuItem();
            klienciToolStripMenuItem = new ToolStripMenuItem();
            Administracja = new ToolStripMenuItem();
            btnAdd = new Button();
            btnSave = new Button();
            dataGridView1 = new DataGridView();
            workerNumber = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            surname = new DataGridViewTextBoxColumn();
            login = new DataGridViewTextBoxColumn();
            password = new DataGridViewTextBoxColumn();
            workerType = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnSaveName = new Button();
            btnDeleteName = new Button();
            dataGridView2 = new DataGridView();
            number = new DataGridViewTextBoxColumn();
            wmName = new DataGridViewTextBoxColumn();
            label2 = new Label();
            btnDel = new Button();
            button1 = new Button();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { kompletowanieToolStripMenuItem, wysyłkaToolStripMenuItem, wyszukiwarkaToolStripMenuItem, klienciToolStripMenuItem, Administracja });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 38);
            menuStrip1.TabIndex = 0;
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
            // Administracja
            // 
            Administracja.Name = "Administracja";
            Administracja.Size = new Size(151, 34);
            Administracja.Text = "Administracja";
            Administracja.Click += Administracja_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ScrollBar;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(295, 571);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(162, 55);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "DODAJ WIERSZ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ScrollBar;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(565, 571);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(162, 57);
            btnSave.TabIndex = 2;
            btnSave.Text = "ZAPISZ PRACOWNIKA";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { workerNumber, name, surname, login, password, workerType });
            dataGridView1.Location = new Point(26, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(701, 519);
            dataGridView1.TabIndex = 4;
            // 
            // workerNumber
            // 
            workerNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            workerNumber.HeaderText = "Numer pracownika";
            workerNumber.Name = "workerNumber";
            workerNumber.Width = 124;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.HeaderText = "Imię";
            name.Name = "name";
            name.Width = 56;
            // 
            // surname
            // 
            surname.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            surname.HeaderText = "Nazwisko";
            surname.Name = "surname";
            surname.Width = 85;
            // 
            // login
            // 
            login.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            login.HeaderText = "Login";
            login.Name = "login";
            login.Width = 63;
            // 
            // password
            // 
            password.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            password.HeaderText = "Hasło";
            password.Name = "password";
            password.Width = 65;
            // 
            // workerType
            // 
            workerType.HeaderText = "Typ";
            workerType.Name = "workerType";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(785, 11);
            label1.Name = "label1";
            label1.Size = new Size(414, 32);
            label1.TabIndex = 5;
            label1.Text = "DODAJ NAZWĘ WODOMIERZA\r\n";
            // 
            // btnSaveName
            // 
            btnSaveName.BackColor = SystemColors.ScrollBar;
            btnSaveName.FlatStyle = FlatStyle.Popup;
            btnSaveName.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveName.Location = new Point(1067, 571);
            btnSaveName.Name = "btnSaveName";
            btnSaveName.Size = new Size(162, 57);
            btnSaveName.TabIndex = 7;
            btnSaveName.Text = "ZAPISZ";
            btnSaveName.UseVisualStyleBackColor = false;
            btnSaveName.Click += btnSaveName_Click;
            // 
            // btnDeleteName
            // 
            btnDeleteName.BackColor = SystemColors.ScrollBar;
            btnDeleteName.FlatStyle = FlatStyle.Popup;
            btnDeleteName.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteName.Location = new Point(1544, 773);
            btnDeleteName.Name = "btnDeleteName";
            btnDeleteName.Size = new Size(184, 69);
            btnDeleteName.TabIndex = 8;
            btnDeleteName.Text = "USUŃ";
            btnDeleteName.UseVisualStyleBackColor = false;
            btnDeleteName.Click += btnDeleteName_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { number, wmName });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.Location = new Point(759, 46);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(470, 519);
            dataGridView2.TabIndex = 9;
            // 
            // number
            // 
            number.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            number.HeaderText = "Numer";
            number.Name = "number";
            number.Width = 70;
            // 
            // wmName
            // 
            wmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            wmName.HeaderText = "Nazwa Wodomierza";
            wmName.Name = "wmName";
            wmName.Width = 141;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(204, 11);
            label2.Name = "label2";
            label2.Size = new Size(307, 32);
            label2.TabIndex = 10;
            label2.Text = "DODAJ PRACOWNIKA";
            // 
            // btnDel
            // 
            btnDel.BackColor = SystemColors.ScrollBar;
            btnDel.FlatStyle = FlatStyle.Popup;
            btnDel.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDel.Location = new Point(26, 570);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(162, 56);
            btnDel.TabIndex = 11;
            btnDel.Text = "USUŃ PRACOWNIKA";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(759, 571);
            button1.Name = "button1";
            button1.Size = new Size(162, 57);
            button1.TabIndex = 12;
            button1.Text = "DODAJ WIERSZ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(btnSaveName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnAdd);
            panel1.Location = new Point(5, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(1259, 641);
            panel1.TabIndex = 13;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1264, 921);
            Controls.Add(panel1);
            Controls.Add(btnDeleteName);
            Controls.Add(menuStrip1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administracja";
            FormClosed += Admin_FormClosed;
            Load += Admin_Load;
            Resize += Admin_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Button btnAdd;
        private Button btnSave;
        private DataGridView dataGridView1;
        private ToolStripMenuItem kompletowanieToolStripMenuItem;
        private ToolStripMenuItem wysyłkaToolStripMenuItem;
        private ToolStripMenuItem wyszukiwarkaToolStripMenuItem;
        private ToolStripMenuItem klienciToolStripMenuItem;
        private ToolStripMenuItem Administracja;
        private Label label1;
        private Button btnSaveName;
        private Button btnDeleteName;
        private DataGridView dataGridView2;
        private Label label2;
        private Button btnDel;
        private Button button1;
        private DataGridViewTextBoxColumn number;
        private DataGridViewTextBoxColumn wmName;
        private Panel panel1;
        private DataGridViewTextBoxColumn workerNumber;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn surname;
        private DataGridViewTextBoxColumn login;
        private DataGridViewTextBoxColumn password;
        private DataGridViewTextBoxColumn workerType;
    }
}
