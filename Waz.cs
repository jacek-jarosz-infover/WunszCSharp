using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWaz
{
    class Waz
    {
        public enum Kierunek
        {
            gora,
            prawo,
            dol,
            lewo
        }
        
        Kierunek kierunek = Kierunek.prawo;
        int  wydluzenie = 0;                     // o ile ma byc wydluzony ( przy wydluzeniu to wyczyscimy )
        bool wydluzany;

        List<Punkt> czlonkiWeza = new();

        Punkt gumka; 

        Nagroda nagroda;

        
        public Waz(int startx, int starty)
        {
            czlonkiWeza.Add(new(startx, starty));
            //wydluzenie = 5;
            wydluzenie = 9999;
        }
        public Waz() : this(1, 1)
        { }

        bool dodajElement()
        {
            Punkt nowypunkt = new();
            Punkt glowa = czlonkiWeza[czlonkiWeza.Count - 1];
            switch (kierunek)
            {
                case Kierunek.gora:
                    nowypunkt.X = glowa.X;
                    nowypunkt.Y = glowa.Y - 1;
                    break;
                case Kierunek.dol:
                    nowypunkt.X = glowa.X;
                    nowypunkt.Y = glowa.Y + 1;
                    break;
                case Kierunek.lewo:
                    nowypunkt.X = glowa.X - 1;
                    nowypunkt.Y = glowa.Y;
                    break;

                case Kierunek.prawo:
                    nowypunkt.X = glowa.X + 1;
                    nowypunkt.Y = glowa.Y;
                    break;
            }
            if (
            CzyJestNaWezu(nowypunkt)
            || nowypunkt.X == 0
            || nowypunkt.X == Console.WindowWidth - 1
            || nowypunkt.Y == 0
            || nowypunkt.Y == Console.WindowHeight - 1
            )
            {
                return false; // zderzenie 
            }
            else
            {
                czlonkiWeza.Add(nowypunkt);
                return true;
            }
        }

        public bool RuszSie()
        {
            if (!dodajElement()) return false; 
            if (wydluzenie > 0)
            {
                wydluzany = true;
                wydluzenie--;
            }
            else
            {
                gumka = czlonkiWeza[0];
                wydluzany = false;
                Console.SetCursorPosition(0,0);
                czlonkiWeza.RemoveAt(0);
            }
            return true;         
        }

        public bool CzyJestNaWezu(Punkt punkt)
        {
            return czlonkiWeza.Exists(p1 => p1.Equals(punkt));
        }
        


        public void Narysuj()
        {
            if(!wydluzany)
            { 
                Console.SetCursorPosition(gumka.X, gumka.Y);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Cyan;
            foreach(Punkt czlonek in czlonkiWeza)
            {
                Console.SetCursorPosition(czlonek.X, czlonek.Y);
                Console.Write(" ");
            }
            Console.ResetColor();
        }

        public void UstawKierunek(Kierunek k)
        {
            switch(k)
            {
                case Kierunek.lewo:
                    if (kierunek != Kierunek.prawo && kierunek != Kierunek.lewo)
                    {
                        kierunek = k;
                    }
                    break;

                case Kierunek.prawo:
                    if (kierunek != Kierunek.prawo && kierunek != Kierunek.lewo)
                    {
                        kierunek = k;
                    }
                    break;

                case Kierunek.gora:
                    if (kierunek != Kierunek.gora && kierunek != Kierunek.dol)
                    {
                        kierunek = k;
                    }

                    break;
                case Kierunek.dol:
                    if (kierunek != Kierunek.gora && kierunek != Kierunek.dol)
                    {
                        kierunek = k;
                    }
                    break;
                default:
                    kierunek = Kierunek.prawo;
                    break;
            }

        }



        /* public void Obroc(bool obracajZgodnieZKierunkiemZegara)
        {
            if (obracajZgodnieZKierunkiemZegara) kierunek = (Kierunek)(((int)kierunek+1) % 4);
            else kierunek = (Kierunek)(((int)kierunek - 1) % 4); 
        } 
        DZIEŁO SZATANA
        */
    }
}
