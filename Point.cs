using System;

namespace TicTacToe
{
    class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override String ToString()
        {
            return "[" + x + "," + y + "]";
        }
    }
}
