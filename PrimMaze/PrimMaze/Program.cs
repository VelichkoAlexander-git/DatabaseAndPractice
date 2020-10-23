using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public static int height;
        public static int width;
        public static int interval;

        static Timer timer;
        static void Main(string[] args)
        {
            var parser = ParserValue();
            if (!parser.Succeeded)
            {
                Console.WriteLine(String.Join(Environment.NewLine, parser.Errors));
                Console.ReadLine();
                return;
            }

            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

            string path = @"G:\";
            Maze maze = new Maze(width, height);

            maze.Prims(true);
            timer = new Timer(new TimerCallback(Drawing), maze, 0, interval);

            SaveArrayInFile(Сonversion(maze), path + "maze.txt");
            SaveArrayInPNG(Сonversion(maze), path + "maze.png");
            Console.ReadLine();
        }

        #region Parser
        public static Result<bool> ParserValue()
        {
            var errors = new List<string>();

            if (!int.TryParse(ConfigurationManager.AppSettings["HeightMap"], out height)) { errors.Add("Поле HeightMap не удалось преобразовать в int"); }
            if (!int.TryParse(ConfigurationManager.AppSettings["WidthMap"], out width)) { errors.Add("Поле WidthMap не удалось преобразовать в int"); }
            if (!int.TryParse(ConfigurationManager.AppSettings["Interval"], out interval)) { errors.Add("Поле Interval не удалось преобразовать в int"); }

            if (errors.Any())
            {
                return Result<bool>.Fail(errors);
            }

            return Result<bool>.Success(true);
        }
        #endregion

        public static void Drawing(Object maze)
        {
            var mazes = (Maze)maze;
            Console.Clear();

            var charZame = Сonversion(mazes);

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

            mazes.Prims(false);
        }

        public static int[,] Сonversion(Maze maze)
        {
            int[,] matrix = new int[(maze.GetHeight() << 1) + 1, (maze.GetWidth() << 1) + 1];

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

            Bitmap bmp = new Bitmap(matrix.GetLength(1) * increase, matrix.GetLength(0) * increase, PixelFormat.Format32bppArgb);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (matrix[y / increase, x / increase] == 1)
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
