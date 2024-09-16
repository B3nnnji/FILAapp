namespace FILAapp
{
    partial class Logowanie
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logowanie));
            txtUsername = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            btnShowPassword = new CheckBox();
            txtPassword = new MaskedTextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.ScrollBar;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(116, 106);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(325, 39);
            txtUsername.TabIndex = 0;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ControlDarkDark;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.Window;
            btnLogin.Location = new Point(116, 309);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(325, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "ZALOGUJ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(227, 71);
            label1.Name = "label1";
            label1.Size = new Size(98, 32);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(227, 197);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 4;
            label2.Text = "HASŁO";
            // 
            // btnShowPassword
            // 
            btnShowPassword.AutoSize = true;
            btnShowPassword.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowPassword.Location = new Point(447, 252);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(108, 19);
            btnShowPassword.TabIndex = 5;
            btnShowPassword.Text = "POKAŻ HASŁO";
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ScrollBar;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(116, 232);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(325, 39);
            txtPassword.TabIndex = 6;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(btnShowPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtUsername);
            panel1.Location = new Point(261, 181);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 457);
            panel1.TabIndex = 7;
            // 
            // Logowanie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1424, 861);
            Controls.Add(panel1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Logowanie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logowanie";
            FormClosed += Logowanie_FormClosed;
            Load += Logowanie_Load;
            Resize += Logowanie_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsername;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private CheckBox btnShowPassword;
        private MaskedTextBox txtPassword;
        private Panel panel1;
    }
}
