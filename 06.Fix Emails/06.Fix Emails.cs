using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var inputList = new List<string>();
            var resultList = new Dictionary<string, string>();
            while (input != "stop")
            {
                input = Console.ReadLine();
                inputList.Add(input);
            }
            for (int i = 0; i < inputList.Count - 1; i += 2)
            {
                if (!inputList[i+1].Contains(".us".ToLower()) && !inputList[i + 1].Contains(".uk".ToLower()))
                {
                    resultList[inputList[i]] = inputList[i + 1];
                }
            }
            foreach (var resource in resultList.Keys)
            {
                Console.WriteLine($"{resource} -> {resultList[resource]}");
            }
        }
    }
}
