using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseControl
{
    public partial class Form1 : Form
    {       
        Graphics g;
        int mx, my;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }
        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + "; " + e.Y.ToString();
        }
        
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mx = e.X / (pictureBox1.Width / 8);
            my = e.Y / (pictureBox1.Height / 8);

            if (e.Button == MouseButtons.Left)
                g.FillRectangle(new SolidBrush(Color.Green), (mx) * (pictureBox1.Width / 8), (my) * (pictureBox1.Height / 8), pictureBox1.Width / 8, pictureBox1.Height / 8);

            if (e.Button == MouseButtons.Right)
                g.FillRectangle(new SolidBrush(Color.Red), (mx) * (pictureBox1.Width / 8), (my) * (pictureBox1.Height / 8), pictureBox1.Width / 8, pictureBox1.Height / 8);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Здравствуйте! \n Чтобы очистить поле и начать заново, нажмите запуск");
            Pen blackpen = new Pen(Color.Black, 2);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.FillRectangle(new SolidBrush(Color.White), i * (pictureBox1.Width / 8), j * (pictureBox1.Height / 8), pictureBox1.Width / 8, pictureBox1.Height / 8);
                    g.DrawRectangle(blackpen, i * (pictureBox1.Width / 8), j * (pictureBox1.Height / 8), pictureBox1.Width / 8, pictureBox1.Height / 8);
                }
            }

        }

        
        
    }
}
