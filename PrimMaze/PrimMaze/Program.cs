﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimMaze
{
    class Program
    {
        static Timer timer;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

            int interval = 2000;

            string path = @"G:\";
            Maze maze = new Maze(10, 10);
            SaveArrayInFile(Сonversion(maze), path + "maze.txt");
            SaveArrayInPNG(Сonversion(maze), path + "maze.png");
            timer = new Timer(new TimerCallback(Drawing), maze, 0, interval);

            Console.ReadLine();
        }

        public static void Drawing(Object maze)
        {
            Maze maze_t = (Maze)maze;
            Console.Clear();

            var charZame = Сonversion(maze_t);

            for (int i = 0; i < charZame.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < charZame.GetLength(1); j++)
                {
                    if (charZame[i, j] == 1)
                        Console.Write($"{(char)12} ");
                    else
                        Console.Write($"  ");
                }
            }

            //step...
        }

        public static int[,] Сonversion(Maze maze)
        {
            int[,] matrix = new int[(maze.GetWidth() << 1) + 1, (maze.GetLength() << 1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i = i + 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j = j + 2)
                {
                    matrix[i, j] = 1;
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i = i + 2)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j = j + 2)
                {
                    var i_temp = i / 2;
                    var j_temp = j / 2;
                    if (maze.getMaze()[i_temp, j_temp] != null && maze.getMaze()[i_temp, j_temp].getTop())
                    {
                        matrix[i, j + 1] = 1;
                    }
                    if (maze.getMaze()[i_temp, j_temp] != null && maze.getMaze()[i_temp, j_temp].getBottom())
                    {
                        matrix[i + 2, j + 1] = 1;
                    }
                    if (maze.getMaze()[i_temp, j_temp] != null && maze.getMaze()[i_temp, j_temp].getLeft())
                    {
                        matrix[i + 1, j] = 1;
                    }
                    if (maze.getMaze()[i_temp, j_temp] != null && maze.getMaze()[i_temp, j_temp].getRight())
                    {
                        matrix[i + 1, j + 2] = 1;
                    }
                }
            }

            return matrix;
        }

        public static void SaveArrayInFile(int[,] matrix, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            using (StreamWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (i != 0)
                        sr.Write("\n");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        sr.Write(matrix[i, j]);
                    }
                }
            }
        }

        public static void SaveArrayInPNG(int[,] matrix, string path)
        {
            int increase = 20;

            Bitmap bmp = new Bitmap(matrix.GetLength(0) * increase, matrix.GetLength(1) * increase, PixelFormat.Format32bppArgb);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (matrix[x / increase, y / increase] == 1)
                        bmp.SetPixel(x, y, Color.Black);
                    else
                        bmp.SetPixel(x, y, Color.White);
                }
            }

            bmp.Save(path, ImageFormat.Png);
            bmp.Dispose();
        }
    }
}