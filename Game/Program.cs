using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Render mainView = new Render();
            mainView.height = 57;
            mainView.width = 200;
            mainView.background = ' ';
            mainView.border = '~';
            mainView.addBorder = true;

            Character cursor = new Character();
            cursor.x = 6;
            cursor.y = 9;
            cursor.xs = 5;
            cursor.ys = 8;
            cursor.xf = 199;
            cursor.yf = 54;

            Menu mainSprawl = new Menu();
            string[,] mainSprawlOptions = { { "File", "file" }, { "Edit", "edit" }, { "Tools", "tools" }, { "About", "about" } };
            mainSprawl.options = mainSprawlOptions;

            //dropdowns:
            Menu fileDrop = new Menu();
            string[,] fileDropOptions = { { "New", "new" }, { "Open", "open" }, { "Save", "save" }, { "Save As", "saveas" } };
            fileDrop.options = fileDropOptions;

            Menu editDrop = new Menu();
            string[,] editDropOptions = { { "Format", "format" }, { "Transform", "transform" } };
            editDrop.options = editDropOptions;

            Menu toolsDrop = new Menu();
            string[,] toolsDropOptions = { { "Point Single", "single" }, { "Perpendicular Line", "perpline" }, { "Box", "box" }, { "Sprite", "sprite" } };
            toolsDrop.options = toolsDropOptions;

            Menu aboutDrop = new Menu();
            string[,] aboutDropOptions = { { "About", "about" }, { "Help", "help" } };
            aboutDrop.options = aboutDropOptions;

            char[,] workspace = new char[45, 193];

            for (int i = 0; i < 45; i++)
            {
                for (int j = 0; j < 193; j++)
                {
                    workspace[i, j] = '$';
                }
            }

        Top:
            Console.Clear();
            char[,] viewport = mainView.Default();

            //Top menu bar
            Draw.PerpendicularLine(viewport, mainView.border, 2, 1, 2, 199);
            Draw.Sentence(viewport, "ASCII DRAW 1.0", 1, 2);
            Draw.PerpendicularLine(viewport, mainView.border, 1, 17, 1, 199);

            //Top sprawl menu
            mainSprawl.Sprawl(viewport, '|', 3, 2);
            Draw.PerpendicularLine(viewport, mainView.border, 4, 1, 4, 199);

            //Bottom bar
            Draw.PerpendicularLine(viewport, mainView.border, 54, 1, 54, 199);

            //Number guides
            Draw.PerpendicularLine(viewport, mainView.border, 8, 5, 8, 199);
            Draw.PerpendicularLine(viewport, mainView.border, 9, 5, 53, 5);
            for (int i = 0; i < 45; i++)
            {
                string input = Convert.ToString(i);
                Draw.Sentence(viewport, input, i + 9, 2);

                if (i == cursor.y - 9)
                {
                    Draw.Sentence(viewport, "--", i + 9, 2);
                }
            }

            for (int i = 0; i < 193; i++)
            {
                string input = Convert.ToString(i);

                if (i == cursor.x - 6)
                {
                    input = "||";
                }

                char[] digits = input.ToCharArray();

                for (int j = 0; j < digits.Length; j++)
                {
                    Draw.Single(viewport, digits[j], 7 - j, i + 6);
                }
            }

            //Coordinate indicator
            Draw.Sentence(viewport, $"x: {cursor.x - 6}, y: {cursor.y - 9}", 55, 2);

            //Workspace for editing
            Draw.Sprite(viewport, workspace, 9, 6);

            //Draw cursor
            cursor.Initialize(viewport);

            //Dropdown menus
            //tools
            fileDrop.Dropdown(viewport, '#', 4, 2, 20);
            editDrop.Dropdown(viewport, '#', 4, 12, 20);
            toolsDrop.Dropdown(viewport, '#', 4, 22, 20);
            aboutDrop.Dropdown(viewport, '#', 4, 33, 20);

            mainView.Display(viewport);

            if (fileDrop.isOpen == true)
            {
                switch (fileDrop.GetInput())
                {
                    case "new":
                        break;
                    case "open":
                        break;
                    case "save":
                        break;
                    case "saveas":
                        break;
                }
            }
            else if (editDrop.isOpen == true)
            {
                switch (editDrop.GetInput())
                {
                    case "format":
                        break;
                    case "transform":
                        break;
                }
            }
            else if (toolsDrop.isOpen == true)
            {
                switch (toolsDrop.GetInput())
                {
                    case "single":
                        break;
                }
            }
            else if (aboutDrop.isOpen == true)
            {
                switch (aboutDrop.GetInput())
                {
                    case "about":
                        break;
                    case "help":
                        break;
                }
            }
            else
            {
                switch (mainSprawl.GetInput())
                {
                    case "file":
                        fileDrop.isOpen = true;
                        break;
                    case "edit":
                        editDrop.isOpen = true;
                        break;
                    case "tools":
                        toolsDrop.isOpen = true;
                        break;
                    case "about":
                        aboutDrop.isOpen = true;
                        break;
                }
            }
            goto Top;
        }
    }
}