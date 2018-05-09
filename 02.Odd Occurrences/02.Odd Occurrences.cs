using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToLower().Split(' ');
            var resultArray = new Dictionary<string, int>();
            var finalArray = new List<string>();

            foreach (var word in words)
            {
                if (!resultArray.ContainsKey(word))
                {
                    resultArray[word] = 0;
                }
                resultArray[word]++;
            }
            foreach (var item in resultArray.Keys)
            {
                if (resultArray[item]%2!=0)
                {
                    finalArray.Add(item);
                }
            }
            Console.WriteLine(string.Join(", ", finalArray));
        }
    }
}
