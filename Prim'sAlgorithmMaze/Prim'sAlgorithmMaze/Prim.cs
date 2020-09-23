using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troschuetz;
using Troschuetz.Random.Generators;

namespace Prim_sAlgorithmMaze
{
    public class Prim
    {

        List<frontier_location> frontiers;

        List<List<int>> area;

        private int frontier = 2;

        public Prim(List<List<int>> area)
        {
            frontiers = new List<frontier_location>();
            this.area = area;
        }
        struct frontier_location
        {
            public int x;
            public int y;

            public frontier_location(int x, int y) : this()
            {
                this.y = y;
                this.x = x;
            }
        }
        public void generate()
        {
            /* Random starting point. */
            IEnumerable<int> random_start_y = Enumerable.Range(1, area.Count() - 2);
            IEnumerable<int> random_start_x = Enumerable.Range(1, area[0].Count() - 2);
            /* Random direction. */
            IEnumerable<int> random_dir = Enumerable.Range(Maze_generator.north, Maze_generator.east);

            /* Make sure, that the two random numbers are odd. */
            mark(random_start_y.RandomElement() / 2 * 2 + 1,
                 random_start_x.RandomElement() / 2 * 2 + 1);

            /* Loop until there are no frontiers left. */
            while (!frontiers.Any())
            {
                bool possible_to_crave = false;

                /* Randomly select a frontier from the list.*/
                IEnumerable<int> random_frontier = Enumerable.Range(0, frontiers.Count() - 1);
                int next_frontier = random_frontier.RandomElement();
                int y = frontiers[next_frontier].y;
                int x = frontiers[next_frontier].x;
                /* Remove frontier from the list. */
                frontiers.RemoveAt(next_frontier);

                /* Try to move to one direction (loop until we find a possible way to go). */
                while (!possible_to_crave)
                {
                    int direction = random_dir.RandomElement();
                    if (Maze_generator.north == direction)
                    {
                        /* If it is possible to go north, then crave a hole and stop the loop. */
                        if ((y > 2u) && (Maze_generator.hole == area[y - 2][x]))
                        {
                            possible_to_crave = true;
                            area[y - 1][x] = Maze_generator.hole;
                        }
                    }
                    else if (Maze_generator.south == direction)
                    {
                        /* If it is possible to go south, then crave a hole and stop the loop. */
                        if (((y + 2u) < (area.Count() - 1u)) && (Maze_generator.hole == area[y + 2][x]))
                        {
                            possible_to_crave = true;
                            area[y + 1][x] = Maze_generator.hole;
                        }
                    }
                    else if (Maze_generator.west == direction)
                    {
                        /* If it is possible to go west, then crave a hole and stop the loop. */
                        if ((x > 2u) && (Maze_generator.hole == area[y][x - 2]))
                        {
                            possible_to_crave = true;
                            area[y][x - 1] = Maze_generator.hole;
                        }
                    }
                    else if (Maze_generator.east == direction)
                    {
                        /* If it is possible to go east, then crave a hole and stop the loop. */
                        if (((x + 2u) < (area[0].Count() - 1u)) && (Maze_generator.hole == area[y][x + 2]))
                        {
                            possible_to_crave = true;
                            area[y][x + 1] = Maze_generator.hole;
                        }
                    }
                }

                /* Create new frontiers. */
                mark(y, x);

            }
        }

        void mark(int y, int x)
        {
            /* Mark as a hole. */
            area[y][x] = Maze_generator.hole;
            /* Save the cell at north as a frontier (if it isn't out of boundary). */
            if ((y >= 3u) && (Maze_generator.wall == area[y - 2][x]))
            {
                area[y - 2][x] = frontier;
                frontiers.Add(new frontier_location(y - 2, x));
            }
            /* Save the cell at south as a frontier (if it isn't out of boundary). */
            if (((y + 2u) <= area.Count() - 2u) && (Maze_generator.wall == area[y + 2][x]))
            {
                area[y + 2][x] = frontier;
                frontiers.Add(new frontier_location(y + 2, x));
            }
            /* Save the cell at west as a frontier (if it isn't out of boundary). */
            if ((x >= 3u) && (Maze_generator.wall == area[y][x - 2]))
            {
                area[y][x - 2] = frontier;
                frontiers.Add(new frontier_location(y, x - 2));
            }
            /* Save the cell at east as a frontier (if it isn't out of boundary). */
            if (((x + 2u) <= area[0].Count() - 2u) && (Maze_generator.wall == area[y][x + 2]))
            {
                area[y][x + 2] = frontier;
                frontiers.Add(new frontier_location(y, x + 2));
            }
        }
    }
}
