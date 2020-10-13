using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ForestFireModel.ForestModel;

namespace ForestFireModel
{
    class Program
    {
        static Timer timer;
        private Encoding ascii = Encoding.ASCII;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);


            float f = 0.7f;
            float p = 0.8f;
            int height = 20;
            int width = 25;

            long interval = 2000; //3 секунды

            ForestModel model;
            var createResult = ForestModel.Create(f, p, height, width);
            if (!createResult.Succeeded)
            {
                Console.WriteLine(string.Join(Environment.NewLine, createResult.Errors));
            }
            else
            {
                model = createResult.Value;
                timer = new Timer(new TimerCallback(Drawing), model, 0, interval);
            }

            Console.ReadLine();
        }

        public static void Drawing(Object model)
        {
            ForestModel forest = (ForestModel)model;
            Console.Clear();
            
            for (int y = 0; y < forest.HeightMap; y++)
            {
                Console.WriteLine("");
                for (int x = 0; x < forest.WidthMap; x++)
                {
                    switch (forest.GetState()[y, x])
                    {
                        //Пустое поле
                        case State.Empty:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"•  ");
                            break;

                        //Поле с деревом
                        case State.Tree:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"¥  ");
                            break;

                        //Поле с горящим деревом
                        case State.Fire:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Ï  ");
                            break;
                    }
                }
            }

            forest.Step();
            
        }
    }

    public class ForestModel
    {
        public enum State : byte
        {
            Empty = 0,
            Tree = 1,
            Fire = 2
        }

        private State[,] _matrix;

        public State[,] GetState()
        {
            return _matrix;
        }

        private static readonly Random rand = new Random();

        private float _woodFireRisk { get; set; }

        private float _probabilityFillingWithWood { get; set; }

        public int HeightMap { get; set; }

        public int WidthMap { get; set; }

        protected ForestModel(float f, float p, int height, int width)
        {
            _woodFireRisk = f;
            _probabilityFillingWithWood = p;
            HeightMap = height;
            WidthMap = width;

            Initialize();
        }

        public static Result<ForestModel> Create(float f, float p, int height, int width)
        {
            var errors = new List<string>();

            if (!(0 <= f && f <= 1)) errors.Add("Вероятность возгорания дерева только [0,1]");
            if (!(0 <= p && p <= 1)) errors.Add("Вероятность заполнением дерева только [0,1]");
            if (height < 1) errors.Add("Высота не может быть меньше единицы");
            if (width < 1) errors.Add("Ширина не может быть меньше единицы");

            if (errors.Any())
            {
                return Result<ForestModel>.Fail(errors);
            }

            return Result<ForestModel>.Success(new ForestModel(f, p, height, width));
        }

        private void Initialize()
        {
            _matrix = new State[HeightMap, WidthMap];
            _matrix.Initialize();
        }

        public State[,] Step()
        {
            var newState = (State[,])_matrix.Clone();

            int numRows = _matrix.GetLength(0);
            int numCols = _matrix.GetLength(1);

            for (int r = 1; r < numRows - 1; r++)
            {
                for (int c = 1; c < numCols - 1; c++)
                {
                    switch (_matrix[r, c])
                    {
                        case State.Empty:
                            if (rand.NextDouble() < _probabilityFillingWithWood)
                                newState[r, c] = State.Tree;
                            break;

                        case State.Tree:
                            if (NeighborHasState(_matrix, r, c, State.Fire) || rand.NextDouble() < _woodFireRisk)
                                newState[r, c] = State.Fire;
                            break;

                        case State.Fire:
                            newState[r, c] = State.Empty;
                            break;
                    }
                }
            }

            _matrix = newState;
            return newState;
        }

        private bool NeighborHasState(State[,] state, int x, int y, State value)
        {
            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (r == 0 && c == 0)
                        continue;

                    if (state[x + r, y + c] == value)
                        return true;
                }
            }

            return false;
        }
    }
}
