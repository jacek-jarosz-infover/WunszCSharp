using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWaz
{
   
    class Nagroda
    {
      

        Punkt pozycja;
        public int wartosc  { get; }
        public Nagroda(int x, int y, int wartosc) // nie zrespawnij na wezu
        {
            pozycja.x = x;
            pozycja.y = y;
            this.wartosc = wartosc;
        }
    }
}
