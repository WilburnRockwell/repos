using System;
using System.Drawing;

namespace Labyrinth
{
    class Map
    {       
        public static void DrawLabyrinth(Graphics gr, int[,] position)
        {             
            for (int i = 0; i < position.GetLength(0); i++)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    if (position[i,j] == 1)
                    {
                        Image img = Image.FromFile("../Textures/Wall.png");
                        gr.DrawImage(img, i * Form1.squareSize, j * Form1.squareSize, Form1.squareSize, Form1.squareSize);
                    }   
                   else if (position[i, j] == 2)
                    {
                        Image img = Image.FromFile("../Textures/Finish.png");
                        gr.DrawImage(img, i * Form1.squareSize, j * Form1.squareSize, Form1.squareSize, Form1.squareSize);
                    }
                }
            }
        }
    }
}
