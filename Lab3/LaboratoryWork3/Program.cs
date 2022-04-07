using System;

namespace LaboratoryWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите команды. \n" +
                              "Возможные команды: \n" +
                              "{0} - Добавить фигуру (круг - радиус, эллипс - a и b, прямоугольник - a и b, квадрат - сторона (Каждому можно назначить толщину рамки)), \n" +
                              "{1} (Сортирует фигуры по площади), \n" +
                              "{2} (Вывести все фигуры и их площади), \n" +
                              "{3} (Вывести типы первых четырех фигур), \n " +
                              "{4} (Рисует последние три фигуры), \n" + 
                              "{5} - Создать Json файл с данными, после команды написать имя файла, \n" + 
                              "{6} - Извлечь данные из Json файла, после команды написать имя файла",
                InputCommands.AddFigure, InputCommands.Sort, InputCommands.PrintAll, InputCommands.PrintFirstFourTypes,
                InputCommands.Draw, InputCommands.Serialize, InputCommands.DeSerialize);
            Console.WriteLine();

            var figures = new Figures();

            var input = Console.ReadLine();
            while(input != "")
            {
                FiguresInputManager.ProcessInput(figures, input);
                input = Console.ReadLine();
            }
        }
    }
}
