using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork2
{
    public static class IntegersSetInputManager
    {
        public static void ProcessInput(IntegersSet set1, IntegersSet set2, string input)
        {
            var splitedInput = input.Split(' ');
            switch (splitedInput[0])
            {
                case InputCommands.Add:
                    if (splitedInput.Length != 3)
                    {
                        Console.WriteLine("Неверные аргументы");
                        break;
                    }
                    if (splitedInput[1] == "1")
                    {
                        set1.AddElement(int.Parse(splitedInput[2]));
                    }
                    if (splitedInput[1] == "2")
                    {
                        set2.AddElement(int.Parse(splitedInput[2]));
                    }
                    break;

                case InputCommands.Remove:
                    if (splitedInput.Length != 3)
                    {
                        Console.WriteLine("Неверные аргументы");
                        break;
                    }
                    if (splitedInput[1] == "1")
                    {
                        set1.RemoveElement(int.Parse(splitedInput[2]));
                    }
                    if (splitedInput[1] == "2")
                    {
                        set2.RemoveElement(int.Parse(splitedInput[2]));
                    }
                    break;

                case InputCommands.Compare:
                    if (splitedInput.Length != 1)
                    {
                        Console.WriteLine("Неверные аргументы");
                        break;
                    }
                    Console.WriteLine(set1 == set2 ? "Множества равны" : "Множества неравны");
                    break;

                case InputCommands.Subtract:
                    if (splitedInput.Length != 3)
                    {
                        Console.WriteLine("Неверные аргументы");
                        break;
                    }
                    var newSet = new IntegersSet();
                    if (splitedInput[1] == "1")
                    {
                        newSet = set1 - set2;
                    }
                    else
                    {
                        newSet = set2 - set1;
                    }
                    Console.WriteLine(newSet);
                    break;

                case InputCommands.Print:
                    Console.WriteLine(set1);
                    Console.WriteLine(set2);
                    break;

                default:
                    Console.WriteLine("Неверная команда");
                    break;
            }
        }
    }
}
