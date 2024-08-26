namespace FILAapp
{
    partial class Naklejka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Naklejka));
            panel1 = new Panel();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            lbPackingWorker = new Label();
            label2 = new Label();
            lbDate = new Label();
            lbWatermeterName = new Label();
            pbQRCode = new PictureBox();
            pictureBox1 = new PictureBox();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbPackingWorker);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbDate);
            panel1.Controls.Add(lbWatermeterName);
            panel1.Controls.Add(pbQRCode);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(432, 208);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 1.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(296, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(124, 3);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(332, 183);
            label6.Name = "label6";
            label6.Size = new Size(58, 18);
            label6.TabIndex = 11;
            label6.Text = "Podpis";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(296, 120);
            label5.Name = "label5";
            label5.Size = new Size(124, 22);
            label5.TabIndex = 10;
            label5.Text = "Sprawdził/a:";
            // 
            // lbPackingWorker
            // 
            lbPackingWorker.AutoSize = true;
            lbPackingWorker.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPackingWorker.Location = new Point(12, 159);
            lbPackingWorker.Name = "lbPackingWorker";
            lbPackingWorker.Size = new Size(50, 18);
            lbPackingWorker.TabIndex = 9;
            lbPackingWorker.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(111, 22);
            label2.TabIndex = 8;
            label2.Text = "Pakował/a:";
            // 
            // lbDate
            // 
            lbDate.AutoSize = true;
            lbDate.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbDate.Location = new Point(156, 12);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(65, 24);
            lbDate.TabIndex = 7;
            lbDate.Text = "label4";
            // 
            // lbWatermeterName
            // 
            lbWatermeterName.AutoSize = true;
            lbWatermeterName.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbWatermeterName.Location = new Point(12, 89);
            lbWatermeterName.Name = "lbWatermeterName";
            lbWatermeterName.Size = new Size(41, 16);
            lbWatermeterName.TabIndex = 6;
            lbWatermeterName.Text = "label1";
            // 
            // pbQRCode
            // 
            pbQRCode.Location = new Point(342, 3);
            pbQRCode.Name = "pbQRCode";
            pbQRCode.Size = new Size(87, 76);
            pbQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            pbQRCode.TabIndex = 3;
            pbQRCode.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // Naklejka
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 208);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Naklejka";
            Text = "Naklejka";
            Shown += Form3_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PictureBox pbQRCode;
        private Label lbDate;
        private Label lbWatermeterName;
        private Label label6;
        private Label label5;
        private Label lbPackingWorker;
        private Label label2;
        private TextBox textBox1;
    }
}
