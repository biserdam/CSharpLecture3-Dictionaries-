using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryFlag = "";
            var keyMaterialsDictionary = new Dictionary<string, int>();
            var junkDictionary = new SortedDictionary<string, int>();
            keyMaterialsDictionary.Add("shards", 0);
            keyMaterialsDictionary.Add("fragments", 0);
            keyMaterialsDictionary.Add("motes", 0);
            do
            {
                var inputString = Console.ReadLine().ToLower().Split(' ');
                for (int i = 0; i < inputString.Length; i += 2)
                {
                    if (inputString[i + 1] == "shards" || inputString[i + 1] == "fragments" || inputString[i + 1] == "motes")
                    {
                        keyMaterialsDictionary[inputString[i + 1]] += int.Parse(inputString[i]);
                        if (keyMaterialsDictionary[inputString[i + 1]] >= 250)
                        {
                            legendaryFlag = inputString[i + 1];
                            keyMaterialsDictionary[inputString[i + 1]] -= 250;
                                break;
                        }
                    }
                    else
                    {
                        if (!junkDictionary.ContainsKey(inputString[i + 1]))
                        {
                            junkDictionary[inputString[i + 1]] = 0;
                        }
                        junkDictionary[inputString[i + 1]] += int.Parse(inputString[i]);
                    }
                }

            } while (legendaryFlag == "");

            var legendaryItem = "";
            if (legendaryFlag == "shards") legendaryItem = "Shadowmourne";
            if (legendaryFlag == "fragments") legendaryItem = "Valanyr";
            if (legendaryFlag == "motes") legendaryItem = "Dragonwrath";
            Console.WriteLine($"{legendaryItem} obtained!");

            var keyMaterialsDictionarySorted = keyMaterialsDictionary.OrderByDescending(x => x.Value).ThenBy(x=>x.Key);
            foreach (var item in keyMaterialsDictionarySorted) Console.WriteLine($"{item.Key}: {item.Value}");

            foreach (var item in junkDictionary) Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
