using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace Prim_sAlgorithmMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 10;
            int height = 10;

            List<List<int>> maze;

            Maze_generator m_maze = new Maze_generator(height, width);
            m_maze.set_cell(0, 1, Maze_generator.hole);
            m_maze.set_cell(height - 1, width - 2, Maze_generator.hole);
            Prim prim = new Prim(m_maze.get_maze());
            prim.generate();
            maze = m_maze.get_maze();

        }
    }
    static class IEnumerableRandom
    {
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return RandomElementUsing<T>(enumerable, new Random());
        }

        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
    }
}
