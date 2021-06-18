using System;

namespace ImageProcessing
{
    public class Run
    {
        public static class Program
        {
            public static void Main(string[] args)
            { Menu menu = new Menu();
                menu.LoadMenu();
            }

        }
        public class Menu
        {
            public void LoadMenu()
            {
                Console.WriteLine(@"Choose an image resizing benchmarks:

1. Resize
2. Blur
3. Greyscale
");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        try
                        {
                            Resize resize = new Resize();
                            resize.ResizeImageSharpChoose();
                            Menu menu = new Menu();
                            menu.LoadMenu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        break;
                    case ConsoleKey.D2:
                        try
                        {
                            BlurSave blurSave = new BlurSave();
                            blurSave.ImageSharpBlurChoose();
                            Menu menu = new Menu();
                            menu.LoadMenu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        break;
                    case ConsoleKey.D3:
                        try
                        {
                            Greyscale greyscale = new Greyscale();
                            greyscale.ImageGrayscaleChoose();
                            Menu menu = new Menu();
                            menu.LoadMenu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("Unrecognized command.");
                        break;
                }
            }
        }
    }
}