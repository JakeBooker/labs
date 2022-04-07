using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork3
{
    public static class FiguresInputManager
    {
        public static void ProcessInput(Figures figures, string input)
        {
            var splitedInput = input.Split(' ');
            switch (splitedInput[0])
            {
                case InputCommands.AddFigure:
                    switch (splitedInput[1])
                    {
                        case "круг":
                            figures.AddFigure(new Circle(int.Parse(splitedInput[2])));
                            Console.WriteLine("Успешно");
                            break;

                        case "эллипс":
                            figures.AddFigure(new Ellipse(int.Parse(splitedInput[2]), int.Parse(splitedInput[3])));
                            Console.WriteLine("Успешно");
                            break;

                        case "прямоугольник":
                            figures.AddFigure(new Rectangle(int.Parse(splitedInput[2]), int.Parse(splitedInput[3])));
                            Console.WriteLine("Успешно");
                            break;

                        case "квадрат":
                            figures.AddFigure(new Square(int.Parse(splitedInput[2])));
                            Console.WriteLine("Успешно");
                            break;

                        default:
                            Console.WriteLine("Неверный тип фигуры");
                            break;
                    }
                    break;

                case InputCommands.Sort:
                    figures.SortByArea();
                    Console.WriteLine("Успешно");
                    break;

                case InputCommands.PrintAll:
                    Console.WriteLine(figures);
                    break;

                case InputCommands.PrintFirstFourTypes:
                    figures.PrintFourFiguresTypes();
                    break;

                case InputCommands.Draw:
                    figures.DrawLastThreeFigures();
                    break;

                case InputCommands.Serialize:
                    figures.ToJson(splitedInput[1]);
                    Console.WriteLine("Успешно");
                    break;

                case InputCommands.DeSerialize:
                    figures = Figures.FromJson(splitedInput[1]);
                    Console.WriteLine("Успешно");
                    break;

                default:
                    Console.WriteLine("Неверная команда");
                    break;
            }
        }
    }
}
