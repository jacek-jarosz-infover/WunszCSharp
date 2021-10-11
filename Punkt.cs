using System;
namespace GraWaz
{
    class Punkt : IEquatable<Punkt>
    {
        public int x { get; set; }
        public int y { get; set; }

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Punkt()
        {
            x = 0;
            y = 0;
        }

        public bool Equals(Punkt other)
        {
            return x == other.x && y == other.y;
        }
    }
}
