using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ForestFireModel.ForestModel;

namespace ForestFireModel
{
    class Program
    {
        public static float f;
        public static float p;
        public static int height;
        public static int width;

        private static Timer timer;
        private Encoding ascii = Encoding.ASCII;
        static void Main(string[] args)
        {
            var parser = ParserValue();
            if (!parser.Succeeded)
            {
                Console.WriteLine(String.Join(Environment.NewLine, parser.Errors));
                Console.ReadLine();
                return;
            }           

            long interval = 2000;

            ForestModel model;
            var createResult = ForestModel.Create(f, p, height, width);
            if (!createResult.Succeeded)
            {
                Console.WriteLine(string.Join(Environment.NewLine, createResult.Errors));
            }
            else
            {
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
                model = createResult.Value;
                timer = new Timer(new TimerCallback(Drawing), model, 0, interval);
            }

            Console.ReadLine();
        }

        #region Parser
        public static Result<bool> ParserValue()
        {
            var errors = new List<string>();

            if (!IsDigitsOnlyAndPoint(ConfigurationManager.AppSettings["WoodFireRisk"])) { errors.Add("Поле WoodFireRisk не удалось преобразовать в float"); }
            if (!IsDigitsOnlyAndPoint(ConfigurationManager.AppSettings["FillingWithWood"])) { errors.Add("Поле FillingWithWood  не удалось преобразовать в float"); }
            if (!IsDigitsOnly(ConfigurationManager.AppSettings["HeightMap"])) { errors.Add("Поле HeightMap не удалось преобразовать в int"); }
            if (!IsDigitsOnly(ConfigurationManager.AppSettings["WidthMap"])) { errors.Add("Поле WidthMap не удалось преобразовать в int"); }

            if (errors.Any())
            {
                return Result<bool>.Fail(errors);
            }

            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            f = float.Parse(ConfigurationManager.AppSettings["WoodFireRisk"], NumberStyles.Any, ci);
            p = float.Parse(ConfigurationManager.AppSettings["FillingWithWood"], NumberStyles.Any, ci);
            height = int.Parse(ConfigurationManager.AppSettings["HeightMap"]);
            width = int.Parse(ConfigurationManager.AppSettings["WidthMap"]);

            return Result<bool>.Success(true);
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private static bool IsDigitsOnlyAndPoint(string str)
        {
            if (str.Where(c => c == '.').Count() > 1) return false;
            else
                str = str.Replace(".", "");

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        #endregion

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
}
