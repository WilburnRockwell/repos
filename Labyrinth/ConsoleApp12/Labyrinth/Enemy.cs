using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    class Enemy
    {
        public int posX, posY;        
        int moving;

        public Enemy(int x, int y)
        {
            moving = 0;
            posX = x;
            posY = y;
        }

        public void Draw(Graphics gr)
        {
            Image _img = Image.FromFile("../Textures/Demon_StandingPos.png");
            gr.DrawImage(_img, posY * Form1.squareSize, posX * Form1.squareSize, Form1.squareSize, Form1.squareSize);
        }

        public void Annihilation(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(Color.White), posY * Form1.squareSize, posX * Form1.squareSize, Form1.squareSize, Form1.squareSize);
        }
        public void Move(Graphics gr, int[,] pos)
        {
            if (moving == 0)
            {
                Annihilation(gr);
                posY += 1;                
                Draw(gr);

                if (pos[posY + 1, posX] == 1)
                    moving = 3;
            }
            else if (moving == 1)
            {
                Annihilation(gr);
                posY -= 1;
                
                Draw(gr);

                if (pos[posY - 1, posX] == 1)
                    moving = 2;
            }
            else if (moving == 2)
            {
                Annihilation(gr);
                posX -= 1;               
                Draw(gr);

                if (pos[posY, posX - 1] == 1)
                    moving = 0;
            }
            else if (moving == 3)
            {
                Annihilation(gr);
                posX += 1;               
                Draw(gr);

                if (pos[posY, posX + 1] == 1)
                    moving = 1;
            }
        }    
    }
}
