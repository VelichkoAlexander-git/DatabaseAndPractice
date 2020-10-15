using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimMaze
{
    public class Cell
    {
        private bool left;
        private bool top;
        private bool right;
        private bool bottom;
        private bool visited;

        private int x;
        private int y;

        public Cell(int x, int y)
        {
            left = true;
            top = true;
            right = true;
            bottom = true;
            visited = false;
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setTop(bool b)
        {
            top = b;
        }

        public void setBottom(bool b)
        {
            bottom = b;
        }

        public void setLeft(bool b)
        {
            left = b;
        }

        public void setRight(bool b)
        {
            right = b;
        }

        public bool getTop()
        {
            return top;
        }

        public bool getBottom()
        {
            return bottom;
        }

        public bool getRight()
        {
            return right;
        }

        public bool getLeft()
        {
            return left;
        }

        public bool getVisited()
        {
            return visited;
        }

        public void setVisited(bool b)
        {
            visited = b;
        }

        public String toString()
        {
            return ("Cell (" + x + "," + y + ")");
        }

        public bool equals(Cell cell)
        {
            return (this.x == cell.getX() && this.y == cell.getY());
        }
    }
}
