using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformation
{
    public partial class Form1 : Form
    {
        PointF[] points;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            g = pictureBox1.CreateGraphics();
        }

        private void DrawTriangle(Color color)
        {
            Pen redpen = new Pen(color, 3);
            g.DrawCurve(redpen,points, 0);                        
        }

        private void Scale(KeyEventArgs e)
        {
            float dg = 1f;
                if (e.KeyCode == Keys.Q)
              dg = dg * 1.25f;
            else if(e.KeyCode == Keys.E)
              dg = dg * 0.75f;

            DrawTriangle(Color.White);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X *= dg;
                points[i].Y *= dg;
            }
            DrawTriangle(Color.Red);
        }

        private void Rotate(KeyEventArgs e)
        {
            float angle = 0.6f;
            DrawTriangle(Color.White);

            for (int i = 0; i < points.Length; i++)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        points[i].X = (points[i].X - points[0].X) * (float)Math.Cos(angle) - (points[i].Y - points[0].Y) * (float)Math.Sin(angle) + points[0].X;
                        points[i].Y = (points[i].X - points[0].X) * (float)Math.Sin(angle) + (points[i].Y - points[0].Y) * (float)Math.Cos(angle) + points[0].Y;
                        break;

                    case Keys.X:
                        points[i].X = (points[i].X - points[0].X) * (float)Math.Cos(angle) + (points[i].Y - points[0].Y) * (float)Math.Sin(angle) + points[0].X;
                        points[i].Y = -(points[i].X - points[0].X) * (float)Math.Sin(angle) + (points[i].Y - points[0].Y) * (float)Math.Cos(angle) + points[0].Y;
                        break;
                }
            }
            DrawTriangle(Color.Red);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawTriangle(Color.Red);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            points = new PointF[]
              {
                new PointF(181, 107),
                new PointF(369, 170),
                new PointF(140, 220),
                new PointF(182, 107),
              };
        }

        private void Move(KeyEventArgs e)
        {
            DrawTriangle(Color.White);

            for (int i = 0; i < points.Length; i++)
            {
                if (e.KeyCode == Keys.W)
                    points[i].Y -= 3f;
                if (e.KeyCode == Keys.A)
                    points[i].X -= 5.5f;
                if (e.KeyCode == Keys.S)
                    points[i].Y += 3f;
                if (e.KeyCode == Keys.D)
                    points[i].X += 5.5f;
            }
            DrawTriangle(Color.Red);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + "; " + e.Y.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                Move(e);
            }

            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.E)
            {
                Scale(e);
            }

            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.X)
            {
                Rotate(e);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawTriangle(Color.Red);
        }        
    }
}

