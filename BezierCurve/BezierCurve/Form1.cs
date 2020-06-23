using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierCurve
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point[][] points;        
        
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }        

        private void DrawBezierPoints(Point[] points)
        {
            Pen redpen = new Pen(Color.Red, 2);
            Pen blackpen = new Pen(Color.Black, 2);
            for (int i = 1; i < points.Length; i++)
            {                
                g.DrawLine(blackpen, points[i - 1], points[i]);
            }

            g.DrawBezier(redpen, points[0], points[1], points[2], points[3]);
           
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            points = new Point[4][];
            points[0] = new Point[]
            {
              new Point(170,280),
              new Point(345,125),
              new Point(510,280),
              new Point(510,280)
            };

            points[1] = new Point[]
            {
                new Point(230, 150),
                new Point(200, 80),
                new Point(500, 80),
                new Point(470, 150)
            };

            points[2] = new Point[]
            {
                new Point(500, 50),
                new Point(250, 150),
                new Point(600, 250),
                new Point(300, 350)
            };

            points[3] = new Point[]
            {
                new Point(300, 60),
                new Point(560, 160),
                new Point(260, 160),
                new Point(510, 60)
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawBezierPoints(points[0]);     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawBezierPoints(points[1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawBezierPoints(points[2]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawBezierPoints(points[3]);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + "; " + e.Y.ToString();
        }
    }
}
