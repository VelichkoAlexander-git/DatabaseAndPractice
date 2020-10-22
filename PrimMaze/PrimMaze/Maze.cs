using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimMaze
{
    public class Maze
    {
        private int WIDTH;
        private int HEIGHT;
        private Cell[,] maze;
        private Cell current;

        private Dictionary<Cell, List<int>> wallMap;
        private Random rand;
        private List<Cell> keyList;

        #region BASIC MAZE CONSTRUCTION
        public Maze(int width, int height)
        {
            this.WIDTH = width;
            this.HEIGHT = height;
            maze = new Cell[HEIGHT, WIDTH];

            Restart_Prim();
        }

        public Cell[,] getMaze()
        {
            return maze;
        }

        public int GetWidth()
        {
            return WIDTH;
        }

        public int GetHeight()
        {
            return HEIGHT;
        }

        public void generateMaze()
        {
            for (int i = 0; i < HEIGHT; ++i)
            {
                for (int j = 0; j < WIDTH; ++j)
                {
                    maze[i, j] = new Cell(i, j);
                }
            }
        }
        #endregion

        public void Restart_Prim()
        {
            wallMap = new Dictionary<Cell, List<int>>();
            rand = new Random();
            keyList = new List<Cell>();
            generateMaze();
            current = maze[rand.Next(HEIGHT - 1), rand.Next(WIDTH - 1)];

            List<int> foundWalls = findWalls(current);
            if (foundWalls.Count() > 0)
            {
                wallMap[current] = findWalls(current);
                keyList.Add(current);
            }
        }

        #region PRIMS ALGORITHM
        public void Prims(bool flag)
        {
            while (wallMap.Any())
            {
                current.setVisited(true);

                List<int> walls = wallMap[current];
                int location = walls[rand.Next(walls.Count())];

                if (!neighborVisited(current, location))
                {
                    Cell nextCell = primsWallBuster(current, location);
                    nextCell.setVisited(true);
                    List<int> w = findWalls(nextCell);
                    if (w.Count() > 0 && !keyList.Contains(nextCell))
                    {
                        keyList.Add(nextCell);
                        wallMap[nextCell] = w;
                    }

                }

                walls.Remove((int)location);
                if (walls.Count() == 0)
                {
                    wallMap.Remove(current);
                    keyList.Remove(current);

                    if (keyList.Count() == 0)
                    {
                        return;
                    }
                }

                int index = rand.Next(keyList.Count());
                current = keyList[index];

                if (!flag) break;
            } 
        }

        private List<int> findWalls(Cell curr)
        {
            List<int> walls = new List<int>();
            if (curr != null)
            {
                Cell[] n = findPrimsNeighbors(curr.getY(), curr.getX());

                if (n[0] != null)
                {
                    walls.Add(0); //Left wall
                }
                if (n[1] != null)
                {
                    walls.Add(1); //Bottom wall
                }
                if (n[2] != null)
                {
                    walls.Add(2); //Right wall
                }
                if (n[3] != null)
                {
                    walls.Add(3); //Top wall
                }
            }
            return walls;
        }

        private bool neighborVisited(Cell curr, int location)
        {
            if (location == 0)
            {
                return maze[curr.getY(), curr.getX() - 1].getVisited();
            }
            else if (location == 1)
            {
                return maze[curr.getY() + 1, curr.getX()].getVisited();
            }
            else if (location == 2)
            {
                return maze[curr.getY(), curr.getX() + 1].getVisited();
            }
            else if (location == 3)
            {
                return maze[curr.getY() - 1, curr.getX()].getVisited();
            }
            return true;
        }

        private Cell[] findPrimsNeighbors(int y, int x)
        {
            Cell[] neighbors = new Cell[4];
            if ((y - 1 >= 0) && !maze[y - 1, x].getVisited())
            {
                neighbors[3] = maze[y - 1, x]; //Top wall
            }
            if ((x - 1 >= 0) && !maze[y, x - 1].getVisited())
            {
                neighbors[0] = maze[y, x - 1]; //Left wall +
            }
            if ((y + 1 < HEIGHT) && !maze[y + 1, x].getVisited())
            {
                neighbors[1] = maze[y + 1, x]; //Bottom wall +
            }
            if ((x + 1 < WIDTH) && !maze[y, x + 1].getVisited())
            {
                neighbors[2] = maze[y, x + 1]; //Right wall
            }
            return neighbors;
        }

        private Cell primsWallBuster(Cell curr, int location)
        {
            if (curr != null)
            {
                if (location == 0)
                { //Bust Left
                    curr.setLeft(false);
                    maze[curr.getY(), curr.getX()].setLeft(false);
                    maze[curr.getY(), curr.getX() - 1].setRight(false);
                    return maze[curr.getY(), curr.getX() - 1];
                }
                else if (location == 1)
                { //Bust Bottom
                    curr.setBottom(false);
                    maze[curr.getY(), curr.getX()].setBottom(false);
                    maze[curr.getY() + 1, curr.getX()].setTop(false);
                    return maze[curr.getY() + 1, curr.getX()];
                }
                else if (location == 2)
                { //Bust Right
                    curr.setRight(false);
                    maze[curr.getY(), curr.getX()].setRight(false);
                    maze[curr.getY(), curr.getX() + 1].setLeft(false);
                    return maze[curr.getY(), curr.getX() + 1];
                }
                else if (location == 3)
                { //Bust Top
                    curr.setTop(false);
                    maze[curr.getY(), curr.getX()].setTop(false);
                    maze[curr.getY() - 1, curr.getX()].setBottom(false);
                    return maze[curr.getY() - 1, curr.getX()];
                }
                curr.setVisited(true);
            }
            return null;
        }
        #endregion
    }
}
