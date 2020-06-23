using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Player player;
        Enemy[] enemies;

        public const int squareSize = 30;
        int[,] position = {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 2, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },

        };

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void IsDead(Player player, Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].posX == player.posX && enemies[i].posY == player.posY)
                {
                    timer1.Stop();
                    MessageBox.Show("ПОТРАЧЕНО");                   
                    Application.Restart();
                }
            }
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            player.Move(e, gr, position);
            IsDead(player, enemies);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
        }       
        private void timer1_Tick(object sender, EventArgs e)
        {
            enemies[0].Move(gr, position);
            enemies[1].Move(gr, position);
            enemies[2].Move(gr, position);
            IsDead(player, enemies);           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);            
            timer1.Interval = 600;
            timer1.Enabled = true;
            Map.DrawLabyrinth(gr, position);

            player = new Player(1, 1);
            player.Draw(gr);
            enemies = new Enemy[3];
            enemies[0] = new Enemy(3, 3);
            enemies[0].Draw(gr);
            enemies[1] = new Enemy(3, 12);
            enemies[1].Draw(gr);
            enemies[2] = new Enemy(1, 8);
            enemies[2].Draw(gr);
        }

       
    }
}
