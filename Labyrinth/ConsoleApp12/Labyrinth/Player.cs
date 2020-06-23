using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth
{
    class Player
    {
        public int posX, posY;        

        public Player(int x, int y)
        {           

            posX = x;
            posY = y;
        }

        public void Draw(Graphics gr)
        {
            Image _img = Image.FromFile("../Textures/Hero_Moving.png");
            gr.DrawImage(_img, posY * Form1.squareSize, posX * Form1.squareSize, Form1.squareSize, Form1.squareSize);
        }

        public void Annihilation(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(Color.White), posY * Form1.squareSize, posX * Form1.squareSize, Form1.squareSize, Form1.squareSize);
        }
        public void Move(KeyEventArgs e, Graphics gr, int[,] pos)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (pos[posY + 1, posX] != 1)
                    {
                        Annihilation(gr);
                        posY += 1;                        
                        Draw(gr);                        
                    }
                    break;
                case Keys.A:
                    if (pos[posY - 1, posX] != 1)
                    {
                        Annihilation(gr);
                        posY -= 1;                       
                        Draw(gr);
                    }
                    break;
                case Keys.W:
                    if (pos[posY, posX - 1] != 1)
                    {
                        Annihilation(gr);
                        posX -= 1;                        
                        Draw(gr);
                    }
                    break;
                case Keys.S:
                    if (pos[posY, posX + 1] != 1)
                    {
                        Annihilation(gr);
                        posX += 1;                        
                        Draw(gr);
                    }
                    break;
                default:
                    break;
            }
            if (pos[posY, posX] == 2)
            {
                MessageBox.Show("ПОБЕДА!");
                Application.Restart();
            }
        }
    }
}
