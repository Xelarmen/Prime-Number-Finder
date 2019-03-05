using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asalsayılar_ödev
{


    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

        }
        //



        //
        int Mov;
        int mx;
        int my;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Mov = 1;
            mx = e.X;
            my = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = 0;
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "Başlangıç Değeri")
            {
                bunifuMetroTextbox1.Text = "";
            }
        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "Bitiş değeri")
            {
                bunifuMetroTextbox2.Text = "";
            }
        }

        private void bunifuMetroTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "")
            {
                bunifuMetroTextbox1.Text = "Başlangıç Değeri";
            }
        }

        private void bunifuMetroTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "")
            {
                bunifuMetroTextbox2.Text = "Bitiş değeri";
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            int s1 = Convert.ToInt32(bunifuMetroTextbox1.Text);
            int s2 = Convert.ToInt32(bunifuMetroTextbox2.Text);
            Console.WriteLine();
            for (int sayi = s1; sayi <= s2; sayi++)
            {
                int kontrol = 0;

                for (int i = 2; i < sayi; i++)
                {
                    if (sayi % i == 0)
                    {
                        kontrol = 1;
                        break;
                    }
                }
                if (kontrol != 1)
                {
                    listBox1.Items.Add(sayi);
                    sayac++;
                }
                
            }
        }

        private void bunifuMetroTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuMetroTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
