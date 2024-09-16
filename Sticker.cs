using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILAapp
{
    public partial class Naklejka : Form
    {
        public static int margines = 0;
        private Bitmap _qrCodeBitmap;
        private int packageNumber;
        private string nazwa;
        private int userId;
        public Naklejka(int stickerLoggedInUser, string nazwa, int tmpLastPackageNumber, Bitmap qrCodeBitmap)
        {
            InitializeComponent();
            _qrCodeBitmap = qrCodeBitmap;
            packageNumber = tmpLastPackageNumber - 1;
            this.nazwa = nazwa;
            userId = stickerLoggedInUser;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap picImage = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(picImage, new Rectangle(0, 0, panel1.Width, panel1.Height));
            Bitmap image = new Bitmap(picImage);
            float quotient = 1;
            float margin = 20;
            float page_w = e.PageBounds.Width - (2 * margin);
            float page_h = e.PageBounds.Height - (2 * margin);

            if (image.Width >= image.Height)
            {
                quotient = page_w / image.Width;
            }
            if (image.Width < image.Height)
            {
                quotient = image.Height / page_h;
            }
            float w = page_w;
            float h = image.Height * quotient;
            e.Graphics.DrawImage(image, margin - 7, margin - margin - margines, w + 30, h + 10);
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            pbQRCode.Image = _qrCodeBitmap;
            lbDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbPackageNumber.Text = $"{packageNumber}";
            lbPackingWorker.Text = $"ID Pracownika: {userId}";
            PrintDialog printDialog = new PrintDialog();
            printDocument1.PrinterSettings.PrinterName = "Polonia";
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            printDocument1.Print();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Naklejka_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
