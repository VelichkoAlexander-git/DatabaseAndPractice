using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Prim_sAlgorithmMaze
{
    public class Maze_generator
    {
        public const int wall = 0;
        public const int hole = 1;
        public const int solution = 2;

        public const int vertical = 0;
        public const int horizontal = 1;

        public const int north = 0;
        public const int south = 1;
        public const int west = 2;
        public const int east = 3;

        List<List<int>> area;

        int height;
        int width;

        public Maze_generator(int height, int width)
        {            
            area = new List<List<int>>();
            if (!(height % 2 == 0) || !(width % 2 == 0))
            {
                throw new ArgumentException("Height and width must be odd numbers!");
            }

            this.height = height;
            this.width = width;

            area.Resize(height);
            for (int y = 0; y < height; y++)
            {
                area[y].Resize(width);
                for (int x = 0; x < width; x++)
                {
                    area[y][x] = wall;
                }
            }
        }

        public void set_cell(int y, int x, int value)
        {
            if ((area.Count() <= y) || (area[y].Count() <= x))
            {
                throw new Exception("Out of boundary!");
            }
            else if ((wall != value) && (hole != value))
            {
                throw new Exception("The input can only contain 0 or 1.");
            }
            else
            {
                area[y][x] = value;
            }
        }

        public int get_cell(int y, int x)
        {
            return area[y][x];
        }

        public List<List<int>> get_maze()
        {
            return area;
        }

        void set_maze(List<List<int>> vect)
        {
            if ((vect.Count() != area.Count()) || (vect[0].Count() != area[0].Count()))
            {
                throw new Exception("Wrong size!");
            }
            else
            {
                for (int y = 0; y < vect.Count(); y++)
                {
                    for (int x = 0; x < vect[y].Count(); x++)
                    {
                        if ((wall != vect[y][x]) && (hole != vect[y][x]))
                        {
                            throw new Exception("The input can only contain 0 or 1.");
                        }
                        else
                        {
                            area[y][x] = vect[y][x];
                        }
                    }
                }
            }
        }

        void reshape(int new_height, int new_width)
        {
            /* Make sure, that the dimensions are odd numbers, otherwise the maze would look strange. */
            if ((!(height % 2 == 0)) || (!(width % 2 == 0)))
            {
                throw new Exception("Height and width must be odd numbers!");
            }

            /* Resize. */
            area.Resize(height);
            for (int y = 0; y < height; y++)
            {
                area[y].Resize(width);
            }
        }

        public int get_height()
        {
            return area.Count();
        }

        public int get_width()
        {
            return area[0].Count;
        }
    }

    public static class ListExtra
    {
        public static void Resize<T>(this List<T> list, int sz, T c)
        {
            int cur = list.Count();
            if (sz < cur)
                list.RemoveRange(sz, cur - sz);
            else if (sz > cur)
            {
                if (sz > list.Capacity)//this bit is purely an optimisation, to avoid multiple automatic capacity changes.
                    list.Capacity = sz;
                list.AddRange(Enumerable.Repeat(c, sz - cur));
            }
        }
        public static void Resize<T>(this List<T> list, int sz) where T : new()
        {
            Resize(list, sz, new T());
        }
    }
}
