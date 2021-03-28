using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleMenu


{
    static class Graphics
    {
        public static void Frame(int width, int height, int left, int top)
        {

           
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            
            Console.CursorLeft = left;
            Console.CursorTop = top;
            Console.Write("╔");
            for (int i = 1; i < width; i++)
                Console.Write('═');
            Console.WriteLine('╗');
            Console.CursorLeft = left;
            for (int i = 1; i < height; i++)
            {
                Console.Write('║');
                Console.CursorLeft = width + left;
                Console.WriteLine('║');
                Console.CursorLeft = left;
            }
            Console.Write('╚');
            for (int i = 1; i < width; i++)
                Console.Write('═');
            Console.WriteLine('╝');
            Console.CursorLeft = left;
            Console.ResetColor();
        }



        public static void AreaFill(int width, int height, int left, int top, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.CursorVisible = false;
            Console.CursorLeft = left;
            Console.CursorTop = top;

            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.CursorLeft = left;
            }
            Console.ResetColor();

        }
        public static void Text(string text, int left, int top, ConsoleColor bgColor, ConsoleColor fontColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fontColor;

            Console.CursorLeft = left;
            Console.CursorTop = top;

            Console.Write(text);

            Console.CursorLeft = 0;
            Console.CursorTop = Console.WindowHeight;

            Console.ResetColor();
        }

        public static void HorizontalLine(int left, int top, int width, ConsoleColor bgColor, ConsoleColor fontColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fontColor;

            Console.CursorLeft = left;
            Console.CursorTop = top;
            Console.Write('╟');
            for (int i = 0; i < (width - 1); i++)
            {
                Console.Write('─');
            }
            Console.Write('╢');

            Console.CursorLeft = 0;
            Console.CursorTop = Console.WindowHeight;
            Console.ResetColor();
        }

        public static string hint1 = "↑↓, Ent-Run, Esc-Exit";


    }


    public class Menu

    {
        public delegate void Act();
        public class MenuItem
        {
            public string Caption { get; set; }
            public int Top { get; set; }

            public delegate void act();

            internal bool selected;
            
            public Act itemAction;


            public void Draw(int left, int top, int width)
            {
                Graphics.AreaFill(width - 4, 0, left + 2, top, ConsoleColor.DarkBlue);
                Graphics.Text(Caption, (left + width / 2 - Caption.Length / 2), top, ConsoleColor.DarkBlue, ConsoleColor.White);
                selected = false;

            }
            public void Select(int left, int top, int width)
            {
               
                Graphics.AreaFill(width - 4, 0, left + 2, top, ConsoleColor.White);
                Graphics.Text(Caption, (left + width / 2 - Caption.Length / 2), top, ConsoleColor.White, ConsoleColor.DarkBlue);
                selected = true;

            }




        }


        public int Width { get; set; }
        public int Height { get; set; }

        public List<MenuItem> menuItems { get; set; }

        int Left { get; set; }
        int Top { get; set; }



        string Caption { get; set; }


        int selectedItem;
        public int SelectedItem
        {

            set
            {
                selectedItem = value;
                if (selectedItem > (menuItems.Count - 1))
                {
                    selectedItem = 0;
                }
                if (selectedItem < 0)
                {
                    selectedItem = (menuItems.Count - 1);
                }
                
            }
            get
            {
                return selectedItem;
            }
        }

       
        public Act esc; //param to do on Esc button is pressed
    

    public Menu(int width, int height, string caption, int top = 2, int left = 2)
    {

        Width = width;
        if (Width > Console.WindowWidth)
        {
            Width = Console.WindowWidth;
        }
        Height = height;
        if (Height > Console.WindowHeight)
        {
            Height = Console.WindowHeight;
        }
        Caption = caption;

        Top = top;
        Left = Console.WindowWidth / 2 - Width / 2;

        selectedItem = 0;


    }
    public void Show()
    {

        Console.ResetColor();
        Console.Clear();
        Graphics.AreaFill(Width, Height, Left, Top, ConsoleColor.DarkBlue);
        Graphics.Frame(Width, Height, Left, Top);
        Graphics.Text(Caption, (Left + Width / 2 - Caption.Length / 2), (Top + 1), ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);
        Graphics.HorizontalLine(Left, (Top + 2), Width, ConsoleColor.DarkBlue, ConsoleColor.White);
        Graphics.HorizontalLine(Left, (Top + Height - 2), Width, ConsoleColor.DarkBlue, ConsoleColor.White);
        Graphics.Text(Caption, (Left + Width / 2 - Caption.Length / 2), (Top + 1), ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);
        Graphics.Text(Graphics.hint1, (Left + Width / 2 - Graphics.hint1.Length / 2), (Top + Height - 1), ConsoleColor.DarkBlue, ConsoleColor.DarkGray);
        for (int i = 0; i < menuItems.Count; i++)
        {
            menuItems[i].Draw(Left + 1, Top + 3 + i, Width);
        }

        menuItems[SelectedItem].Select(Left + 1, Top + 3 + SelectedItem, Width);
    }

        public void Activate()
        {
            Show();
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        esc.Invoke();
                        continue;
                    case ConsoleKey.UpArrow:
                        SelectedItem -= 1;
                        for (int i = 0; i < menuItems.Count; i++)
                        {
                            menuItems[i].Draw(Left + 1, Top + 3 + i, Width);
                        }
                        menuItems[SelectedItem].Select(Left + 1, Top + 3 + SelectedItem, Width);
                        continue;

                    case ConsoleKey.DownArrow:
                        SelectedItem +=1;
                        for (int i = 0; i < menuItems.Count; i++)
                        {
                            menuItems[i].Draw(Left + 1, Top + 3 + i, Width);
                        }
                        menuItems[SelectedItem].Select(Left + 1, Top + 3 + SelectedItem, Width);
                        continue;

                    case ConsoleKey.Enter:

                        menuItems[SelectedItem].itemAction.Invoke();
                        continue;


                    default:
                        
                        continue;
                }

            }
        }

    }

}
