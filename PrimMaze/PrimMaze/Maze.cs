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
        private int LENGTH;
        private Cell[,] maze;
        private Cell start;

        private Dictionary<Cell, List<int>> wallMap = new Dictionary<Cell, List<int>>();
        private Random rand = new Random();
        private List<Cell> keyList = new List<Cell>();

        #region BASIC MAZE CONSTRUCTION
        public Maze(int width, int length)
        {
            this.WIDTH = width;
            this.LENGTH = length;
            maze = new Cell[WIDTH, LENGTH];

            Random rand = new Random();
            start = new Cell(rand.Next(0, WIDTH - 1), rand.Next(0, LENGTH - 1));
            generateMaze();

            //prims(start);
        }

        public Cell[,] getMaze()
        {
            return maze;
        }

        public int GetWidth()
        {
            return WIDTH;
        }

        public int GetLength()
        {
            return LENGTH;
        }

        public void generateMaze()
        {
            for (int i = 0; i < WIDTH; ++i)
            {
                for (int j = 0; j < LENGTH; ++j)
                {
                    maze[i, j] = new Cell(i, j);
                }
            }
        }
        #endregion

        #region PRIMS ALGORITHM
        private void prims(Cell root)
        {            
            List<int> foundWalls = findWalls(root);
            
            if (foundWalls.Count() > 0)
            {
                wallMap[root] = foundWalls;
            }
            foreach (Cell key in wallMap.Keys)
            {
                keyList.Add(key);
            }
            
            int index = rand.Next(keyList.Count());
            Cell current = keyList[index];


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
                        break;
                    }
                }
                index = rand.Next(keyList.Count());
                current = keyList[index];
            }
        }

        private List<int> findWalls(Cell curr)
        {
            List<int> walls = new List<int>();
            if (curr != null)
            {
                Cell[] n = findPrimsNeighbors(curr.getX(), curr.getY()); 

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
                return maze[curr.getX() - 1, curr.getY()].getVisited();
            }
            else if (location == 1)
            {
                return maze[curr.getX(), curr.getY() - 1].getVisited();
            }
            else if (location == 2)
            {
                return maze[curr.getX() + 1, curr.getY()].getVisited();
            }
            else if (location == 3)
            {
                return maze[curr.getX(), curr.getY() + 1].getVisited();
            }
            return true;
        }

        private Cell[] findPrimsNeighbors(int x, int y)
        {
            Cell[] neighbors = new Cell[4];
            if (!((x - 1) < 1) && !maze[x - 1, y].getVisited())
            {
                neighbors[0] = maze[x - 1, y];
            }
            if (!((y - 1) < 1) && !maze[x, y - 1].getVisited())
            {
                neighbors[1] = maze[x, y - 1];
            }
            if (!((x + 1) > (WIDTH - 1)) && !maze[x + 1, y].getVisited())
            {
                neighbors[2] = maze[x + 1, y];
            }
            if (!((y + 1) > (LENGTH - 1)) && !maze[x, y + 1].getVisited())
            {
                neighbors[3] = maze[x, y + 1];
            }
            return neighbors;
        }

        private Cell primsWallBuster(Cell curr, int location)
        {
            if (curr != null)
            {
                //Returns the cell the pointer is going into
                //Or the neighboring cell
                if (location == 0)
                { //Bust Left
                    curr.setLeft(false);
                    maze[curr.getX() - 1, curr.getY()].setRight(false);
                    return maze[curr.getX() - 1, curr.getY()];
                }
                else if (location == 1)
                { //Bust Bottom
                    curr.setTop(false);
                    maze[curr.getX(), curr.getY() - 1].setBottom(false);
                    return maze[curr.getX(), curr.getY() - 1];
                }
                else if (location == 2)
                { //Bust Right
                    curr.setRight(false);
                    maze[curr.getX() + 1, curr.getY()].setLeft(false);
                    return maze[curr.getX() + 1, curr.getY()];
                }
                else if (location == 3)
                { //Bust Top
                    curr.setBottom(false);
                    maze[curr.getX(), curr.getY() + 1].setTop(false);
                    return maze[curr.getX(), curr.getY() + 1];
                }
                curr.setVisited(true);
            }
            return null;
        }
        #endregion
    }
}
