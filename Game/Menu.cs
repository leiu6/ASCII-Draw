using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Menu
    {
        public string[,] options;
        public bool isOpen = false;
        public void Sprawl(char[,] viewport, char divider, int y, int x)
        {
            string sprawlMenu = "";

            for (int i = 0; i < options.Length / 2; i++)
            {
                string option = "";

                option = options[i, 0];
                int current = i + 1;

                if (i == options.Length / 2 - 1)
                {
                    sprawlMenu += current + ". " + option;
                }
                else
                {
                    sprawlMenu += current + ". " + option + " " + divider + " ";
                }
            }

            Draw.Sentence(viewport, sprawlMenu, y, x);
        }
        public void Dropdown(char[,] viewport, char border, int y, int x, int width)
        {
            if (isOpen == true)
            {
                Draw.Box(viewport, border, y, x, y + options.Length, x + width);

                for (int i = 0; i < options.Length / 2; i++)
                {
                    string option = "";

                    option = options[i, 0];
                    int current = i + 1;
                    string display = Convert.ToString(current) + ". " + option;

                    Draw.Sentence(viewport, display, 2 * i + (y + 1), x + 1);
                }
            }
        }

        public void Dialog(char[,] viewport, char border, string title, int ys, int xs, int yf, int xf)
        {
            if (isOpen == true)
            {
                Draw.Box(viewport, border, ys, xs, yf, xf);
                Draw.PerpendicularLine(viewport, border, ys + 2, xs, ys + 2, xf);
                Draw.Sentence(viewport, title, ys + 1, xs + 2);

                char[,] content = new char[yf - 6, xf - 4];
                content = Draw.Rectangle(content, '$', 0, 0, yf - 7, xf - 5);
                Draw.Sprite(viewport, content, ys + 3, xs + 1);
            }
        }
        public string GetInput()
        {
            int input = Convert.ToInt32(Console.ReadKey().KeyChar);
            input -= 48;

            if (input == 72)
            {
                isOpen = false;
                return null;
            }

            for (int i = 0; i < options.Length / 2; i++)
            {
                string option = "";

                option = options[i, 1];
                int current = i + 1;

                if (input == current)
                {
                    isOpen = false;
                    return option;
                }
            }

            return null;
        }
    }
}
