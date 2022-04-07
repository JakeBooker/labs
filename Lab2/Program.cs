using System;

namespace LaboratoryWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите команды. Все взаимодействия вы проводите с двумя множествами, под номерами 1 и 2. \n" +
                              "Возможные команды: \n" +
                              "{0} (Номер множества и число которое нужно добавить),\n" +
                              "{1} (Номер множества и число которое нужно убрать), \n" +
                              "{2} - Сравнивает два множества), \n" +
                              "{3} (Сначала номер уменьшаемого множества, потом вычитаемого), \n " +
                              "{4} - Выводит оба множества",
                InputCommands.Add, InputCommands.Remove, InputCommands.Compare, InputCommands.Subtract, InputCommands.Print); 
            Console.WriteLine();

            var set1 = new IntegersSet();
            var set2 = new IntegersSet();

            var input = Console.ReadLine();
            while(input != "")
            {
                IntegersSetInputManager.ProcessInput(set1, set2, input);
                input = Console.ReadLine();
            }
        }
    }
}
