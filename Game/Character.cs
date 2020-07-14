using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Character
    {
        public int x = 0;
        public int y = 0;
        public char look = '#';

        public int xs = 0;
        public int xf = 5;
        public int ys = 0;
        public int yf = 5;

        public char[,] Initialize(char[,] viewport)
        {
            viewport = Draw.Single(viewport, look, y, x);
            return viewport;
        }

        public void Move()
        {
            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case 'w':
                    y--;
                    break;
                case 's':
                    y++;
                    break;
                case 'a':
                    x--;
                    break;
                case 'd':
                    x++;
                    break;
                case 'j':
                    Console.WriteLine("Where would you like to jump to?");
                    Console.WriteLine($"y: {ys + 1}:{yf - 1}");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"x: {xs + 1}:{xf - 1}");
                    x = Convert.ToInt32(Console.ReadLine());
                    break;
            }

            Validate();
        }

        public void Validate()
        {
            if (x == xs)
            {
                x++;
            }
            else if (x == xf)
            {
                x--;
            }
            else if (y == ys)
            {
                y++;
            }
            else if (y == yf)
            {
                y--;
            }
        }
    }
}
