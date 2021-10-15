using System;
namespace GraWaz
{
    class Punkt : IEquatable<Punkt>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punkt(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Punkt()
        {
            X = 0;
            Y = 0;
        }

        public bool Equals(Punkt other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
