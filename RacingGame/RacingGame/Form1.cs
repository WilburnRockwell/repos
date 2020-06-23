using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();            
        }

        Label[] road = new Label[16];
        PictureBox[] enemy = new PictureBox[4];
        Random r = new Random();
        int Count = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            road[0] = label1;
            road[1] = label2;
            road[2] = label3;
            road[3] = label4;
            road[4] = label5;
            road[5] = label6;
            road[6] = label7;
            road[7] = label8;
            road[8] = label9;
            road[9] = label10;
            road[10] = label11;
            road[11] = label12;
            road[12] = label13;
            road[13] = label14;
            road[14] = label15;
            road[15] = label16;

            enemy[0] = pictureBox13;
            enemy[1] = pictureBox14;
            enemy[2] = pictureBox15;
            enemy[3] = pictureBox16;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                return;
            score.Text = "Счет: " + Count;
            Score();

            for (int i = 0; i < road.Length; i++)
            {
                road[i].Top += 2;
                if (road[i].Top > Height)
                    road[i].Top = - road[i].Height;                
            }

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].Top += r.Next(1,10);
                if (enemy[i].Top > Height)
                {
                    enemy[i].Top = -enemy[i].Height;
                    enemy[i].Left = r.Next(0, Width - enemy[i].Width);
                    Count++;
                }
            }

            for (int i = 0; i < enemy.Length; i++)
            {
                if (Player.Bounds.IntersectsWith(enemy[i].Bounds))
                    GameOver();
            }                  
        }   
        
        private void Score()
        {
            if (Count == 35)
            {
                timer1.Stop();
                MessageBox.Show("Вы победили.");
                Application.Restart();
            }
        }

        private void GameOver()
        {            
               timer1.Stop();
               MessageBox.Show("Потрачено");
               Application.Restart();           
        }    
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.A)
         {   
                if(Player.Left>0)
            Player.Left += -15;
         }

        if(e.KeyData == Keys.D)
         {           
                if(Player.Left<480)
           Player.Left += 15;
         }       
}             

        
    }
}
