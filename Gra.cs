using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GraWaz
{
    class Gra
    {
        Waz waz;
        Nagroda nagroda;

        Waz.Kierunek nowykierunek = Waz.Kierunek.prawo;

        public void RozpocznijZbieraniePrzyciskow() // nwm jak to zrobic :(
        {
            Thread watekKlawiatury = new Thread(() =>
            {
                while (true)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            nowykierunek = Waz.Kierunek.lewo;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            nowykierunek = Waz.Kierunek.prawo;
                            break;
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            nowykierunek = Waz.Kierunek.gora;
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            nowykierunek = Waz.Kierunek.dol;
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.CursorVisible=true;
                            Environment.Exit(0);
                            break;
                    }
                }

            });

            watekKlawiatury.IsBackground = true;
            watekKlawiatury.Start();
        }


        public void NowaGra()
        {
            Console.Clear();

            waz = new(2,2);
            Plansza.NarysujRamke();
       
            RozpocznijZbieraniePrzyciskow();
            Console.CursorVisible = false;
            bool kontynuujGre = true; 
            while(kontynuujGre)
            {
                kontynuujGre = PetlaGry();
            }
        }

        public bool PetlaGry()
        {
            waz.UstawKierunek(nowykierunek);
            waz.RuszSie();
            waz.Narysuj();


            Thread.Sleep(70);
            return true;
        }
    }
}
