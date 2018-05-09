using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = "";
            var country = "";
            var population = 0;
            var cityCountry = new Dictionary<string, string>();
            var cityPopulation = new Dictionary<string, int>();
            var countryPopulation = new Dictionary<string, long>();
            do
            {
                var inputString = Console.ReadLine().Split('|');
                city = inputString[0];
                if (city == "report") break;
                country = inputString[1];
                population = int.Parse(inputString[2]);
                cityCountry.Add(city, country);
                cityPopulation.Add(city, population);
                if (!countryPopulation.ContainsKey(country))
                {
                    countryPopulation[country] = 0;
                }
                countryPopulation[country] += population;
            } while (city != "report");
            var countryPopulationSorted = countryPopulation.OrderByDescending(x => x.Value);
            //var cityPopulationSorted = cityPopulation.OrderByDescending(x => x.Value);

            //foreach (var item in cityCountry) Console.WriteLine($"{item.Key} -> {item.Value}");
            //foreach (var item in cityPopulation) Console.WriteLine($"{item.Key} -> {item.Value}");
            //foreach (var item in countryPopulationSorted) Console.WriteLine($"{item.Key} -> {item.Value}");

            foreach (var item in countryPopulationSorted)
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value})");

                var writePopCity = new SortedDictionary<int, string>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
                foreach (var kvp in cityCountry)
                    {
                        if (kvp.Value == item.Key)
                        {
                        writePopCity.Add(cityPopulation[kvp.Key], kvp.Key);
                        }
                    }
                foreach (var part in writePopCity)
                {
                Console.WriteLine($"=>{part.Value}: {part.Key}");
                //Console.WriteLine($"=> {kvp.Key}: {cityPopulation[kvp.Key]}");
                }
            }
        }
    }
}
