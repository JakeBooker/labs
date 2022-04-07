using System;

namespace LaboratoryWork3
{
    public static class GraphicEditor
    {
        private static char _symbol = '*';
        private static double _consoleRatio = Convert.ToDouble(4.0 / 2.0);

        public static double AverageFiguresArea;

        public static void PrintCircle(int radius)
        {
            var a = _consoleRatio * radius;
            var b = radius;

            for (double y = -radius; y <= radius; y++)
            {
                for (double x = -a; x <= a; x++)
                {
                    var d = (x / a) * (x / a) + (y / b) * (y / b);
                    if (d > 0.99 && d < 1.1)
                        Console.Write(_symbol);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public static void PrintEllipse(int r1, int r2)
        {
            var a = _consoleRatio * r2;
            var b = r1;

            for (double y = -r1; y <= r1; y++)
            {
                for (double x = -a; x <= a; x++)
                {
                    var d = (x / a) * (x / a) + (y / b) * (y / b);
                    if (d > 0.9 && d < 1.2)
                        Console.Write(_symbol);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public static void PrintRectangle(int a, int b)
        {
            for (var y = 0; y < a; y++)
            {
                for (var x = 0; x < b; x++)
                {
                    if (y == 0 || y == a - 1)
                        Console.Write(_symbol);
                    else if (x == 0 || x == b - 1)
                        Console.Write(_symbol);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public static void PrintSquare(int a)
        {
            PrintRectangle(a, a);
        }
    }
}