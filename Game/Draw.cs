using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    static class Draw
    {
        public static char[,] Single(char[,] workspace, char input, int y, int x)
        {
            workspace[y, x] = input;
            return workspace;
        }
        public static char[,] Sentence(char[,] workspace, string input, int y, int x)
        {
            char[] letters = input.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                workspace = Single(workspace, letters[i], y, x + i);
            }

            return workspace;
        }

        public static char[,] Line(char[,] workspace, char input, int ys, int xs, int yf, int xf)
        {
            decimal ysInt = Convert.ToDecimal(ys);
            decimal xsInt = Convert.ToDecimal(xs);
            decimal yfInt = Convert.ToDecimal(yf);
            decimal xfInt = Convert.ToDecimal(xf);

            for (int i = xs; i <= xf; i++)
            {
                decimal yIntermediate = (yfInt - ysInt) / (xfInt - xsInt) * i;
                int yInt = Convert.ToInt32(Math.Floor(yIntermediate));

                workspace[yInt, i] = input;
            }

            workspace[ys, xs] = input;
            workspace[yf, xf] = input;

            return workspace;
        }

        public static char[,] Rectangle(char[,] workspace, char input, int ys, int xs, int yf, int xf)
        {
            for (int i = ys; i <= yf; i++)
            {
                for (int j = xs; j <= xf; j++)
                {
                    workspace = Single(workspace, input, i, j);
                }
            }

            return workspace;
        }

        public static char[,] Box(char[,] workspace, char input, int ys, int xs, int yf, int xf)
        {
            for (int i = ys; i <= yf; i++)
            {
                if (i == ys || i == yf)
                {
                    for (int j = xs; j <= xf; j++)
                    {
                        workspace = Draw.Single(workspace, input, i, j);
                    }
                }
                else
                {
                    workspace = Draw.Single(workspace, input, i, xs);
                    workspace = Draw.Single(workspace, input, i, xf);
                }
            }

            return workspace;
        }

        public static char[,] PerpendicularLine(char[,] workspace, char input, int ys, int xs, int yf, int xf)
        {
            if (ys != yf)
            {
                for (int i = ys; i <= yf; i++)
                {
                    workspace = Draw.Single(workspace, input, i, xs);
                }
            }
            else
            {
                for (int i = xs; i <= xf; i++)
                {
                    workspace = Draw.Single(workspace, input, ys, i);
                }
            }

            return workspace;
        }

        public static char[,] Sprite(char[,] workspace, char[,] input, int y, int x)
        {
            int spriteRows = input.GetLength(0);
            int spriteCols = input.GetLength(1);

            for (int i = 0; i < spriteRows; i++)
            {
                for (int j = 0; j < spriteCols; j++)
                {
                    workspace[y + i, x + j] = input[i, j];
                }
            }

            return workspace;
        }
    }
}
