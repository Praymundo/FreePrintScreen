using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreePrintScreen
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = FreePrintScreen.Properties.Resources.screenshot_16;
            this.trayIcon.Icon = FreePrintScreen.Properties.Resources.screenshot_16;
            this.trayIcon.Visible = true;
        }

        private void Mostrar()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Focus();
        }

        private void Ocultar()
        {
            this.Hide();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Ocultar();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                }

                Clipboard.SetImage(bmpScreenCapture);
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                this.Mostrar();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.trayIcon.ContextMenuStrip.Show(Cursor.Position);
            }
        }
    }
}
