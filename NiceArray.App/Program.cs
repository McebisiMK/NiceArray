using NiceArray_Library;
using System;
using System.Collections.Generic;

namespace NiceArray_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminator = "Y";
            while (terminator.ToUpper() == "Y")
            {
                var list = LoadList();
                var niceArray = new NiceArray();
                try
                {
                    var results = niceArray.IsNice(list);
                    Console.WriteLine(results);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Press 'Y' to continue checking other possibilities else any key to exit");
                terminator = Console.ReadLine();
            }
            Console.ReadKey();
        }

        private static List<string> LoadList()
        {
            var list = new List<string>();
            var input = string.Empty;
            Console.WriteLine("Populate the list with number and press 'C' when done!");
            input = Console.ReadLine();

            while (input.ToUpper() != "C")
            {
                list.Add(input);
                input = Console.ReadLine();
            }

            return list;
        }
    }
}
