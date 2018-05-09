using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var phonebook = new SortedDictionary<string, string>();

            while (input != "END")
            {
                var inputString = Console.ReadLine().Split();
                input = inputString[0];
                if (input == "A")
                {
                    phonebook[inputString[1]] = inputString[2];
                }
                else if (input == "S")
                {
                    if (phonebook.ContainsKey(inputString[1]))
                    {
                        Console.WriteLine($"{inputString[1]} -> {phonebook[inputString[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {inputString[1]} does not exist.");
                    }
                }
                else if (input=="ListAll")
                {
                    foreach (var name in phonebook.Keys)
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                }
            }
        }
    }
}
