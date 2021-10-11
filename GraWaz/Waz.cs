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
        int wydluzenie = 0; // o ile ma byc wydluzony ( przy wydluzeniu to wyczyscimy )
        List<Punkt> czlonkiWeza = new();

        Punkt gumka = new();

        Nagroda nagroda;

        
        public Waz(int startx, int starty)
        {
            czlonkiWeza.Add(new(startx, starty));
            wydluzenie = 5;
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
                    nowypunkt.x = glowa.x;
                    nowypunkt.y = glowa.y - 1;
                    break;
                case Kierunek.dol:
                    nowypunkt.x = glowa.x;
                    nowypunkt.y = glowa.y + 1;
                    break;
                case Kierunek.lewo:
                    nowypunkt.x = glowa.x - 1;
                    nowypunkt.y = glowa.y;
                    break;

                case Kierunek.prawo:
                    nowypunkt.x = glowa.x + 1;
                    nowypunkt.y = glowa.y;
                    break;
            }
            if (CzyJestNaWezu(nowypunkt))
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
                wydluzenie--;
            }
            else
            {
                gumka = czlonkiWeza[0];
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
            Console.BackgroundColor = ConsoleColor.Cyan;
            foreach(Punkt czlonek in czlonkiWeza)
            {
                Console.SetCursorPosition(czlonek.x, czlonek.y);
                Console.Write(" ");
            }
            
            Console.ResetColor();

            Console.SetCursorPosition(gumka.x, gumka.y);
            Console.Write(" ");
           
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
