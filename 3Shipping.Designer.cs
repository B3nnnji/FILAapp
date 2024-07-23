namespace FILAapp
{
    partial class Wysyłka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wysyłka));
            dataGridView1 = new DataGridView();
            packageNumber = new DataGridViewTextBoxColumn();
            client = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            kompletowanieToolStripMenuItem = new ToolStripMenuItem();
            wysyłkaToolStripMenuItem = new ToolStripMenuItem();
            wyszukiwarkaToolStripMenuItem = new ToolStripMenuItem();
            klienciToolStripMenuItem = new ToolStripMenuItem();
            Admin = new ToolStripMenuItem();
            labelUserInfo = new Label();
            btnSave = new Button();
            panel2 = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { packageNumber, client });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(75, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(930, 490);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // packageNumber
            // 
            packageNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            packageNumber.HeaderText = "Numer paczki";
            packageNumber.Name = "packageNumber";
            packageNumber.Width = 166;
            // 
            // client
            // 
            client.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            client.HeaderText = "Klient";
            client.Name = "client";
            client.Width = 90;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { kompletowanieToolStripMenuItem, wysyłkaToolStripMenuItem, wyszukiwarkaToolStripMenuItem, klienciToolStripMenuItem, Admin });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 38);
            menuStrip1.TabIndex = 1;
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
            Admin.Click += administracjaToolStripMenuItem_Click;
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelUserInfo.Location = new Point(12, 890);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(65, 22);
            labelUserInfo.TabIndex = 3;
            labelUserInfo.Text = "label2";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ScrollBar;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(75, 550);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(184, 69);
            btnSave.TabIndex = 6;
            btnSave.Text = "ZAPISZ ZMIANY";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(0, 150);
            panel2.Name = "panel2";
            panel2.Size = new Size(1100, 623);
            panel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(372, 10);
            label2.Name = "label2";
            label2.Size = new Size(293, 41);
            label2.TabIndex = 8;
            label2.Text = "WYŚLIJ PACZKĘ";
            // 
            // Wysyłka
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1264, 921);
            Controls.Add(panel2);
            Controls.Add(labelUserInfo);
            Controls.Add(menuStrip1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Wysyłka";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wysyłka";
            Load += Wysyłka_Load;
            Resize += Wysyłka_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private Label labelUserInfo;
        private Button btnSave;
        private ToolStripMenuItem kompletowanieToolStripMenuItem;
        private ToolStripMenuItem wysyłkaToolStripMenuItem;
        private ToolStripMenuItem wyszukiwarkaToolStripMenuItem;
        private ToolStripMenuItem klienciToolStripMenuItem;
        private ToolStripMenuItem Admin;
        private Panel panel2;
        private Label label2;
        private DataGridViewTextBoxColumn packageNumber;
        private DataGridViewTextBoxColumn client;
    }
}
