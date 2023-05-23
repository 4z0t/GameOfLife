using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Vector2d
    {
        public double x;
        public double y;

        public Vector2d(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2d operator +(Vector2d left, Vector2d right)
        {
            return new Vector2d(left.x + right.x, left.y + right.y);
        }

        public static Vector2d operator -(Vector2d left, Vector2d right)
        {
            return new Vector2d(left.x - right.x, left.y - right.y);
        }
    }
}
