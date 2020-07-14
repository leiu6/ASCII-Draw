using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Render
    {
        public int width = 30;
        public int height = 30;
        public char background = ' ';
        public char border = '#';
        public bool addBorder = false;

        public Render()
        {
            Default();
        }
        public char[,] Default()
        {
            char[,] viewport = new char[height, width];

            //fill with background

            viewport = Draw.Rectangle(viewport, background, 0, 0, height - 1, width - 1);

            //add border
            if (addBorder == true)
            {
                viewport = Draw.Box(viewport, border, 0, 0, height - 1, width - 1);
                return viewport;
            }
            else
            {
                return viewport;
            }
        }

        public void Display(char[,] viewport)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(viewport[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
