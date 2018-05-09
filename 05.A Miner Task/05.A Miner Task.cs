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
            var resultList = new Dictionary<string, uint>();
            while (input!="stop")
            {
                input = Console.ReadLine();
                inputList.Add(input);
            }
            for (int i = 0; i < inputList.Count-1; i+=2)
            {
                if (!resultList.ContainsKey(inputList[i]))
                {
                resultList[inputList[i]] = uint.Parse(inputList[i + 1]);
                }
                else
                {
                resultList[inputList[i]] += uint.Parse(inputList[i + 1]);
                }
            }
            foreach (var resource in resultList.Keys)
            {
                Console.WriteLine($"{resource} -> {resultList[resource]}");
            }
        }
    }
}
