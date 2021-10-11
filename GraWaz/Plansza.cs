using System;

namespace GraWaz
{
    class Plansza
    {
        static public void NarysujRamke()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            for (int x = 0; x < Console.WindowWidth; x++)
            { 
                for(int y = 0; y < Console.WindowHeight; y++)
                {
                    if (x == 0 || x == Console.WindowWidth - 1 || y == 0 || y == Console.WindowHeight - 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(" ");
                    }
                }
            }
            Console.ResetColor();
        }
    }
}
