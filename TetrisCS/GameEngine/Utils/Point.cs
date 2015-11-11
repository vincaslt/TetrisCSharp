using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameEngine.Utils
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Translate(Point vector)
        {
            Translate(vector.X, vector.Y);
        }

        public void Translate(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}
