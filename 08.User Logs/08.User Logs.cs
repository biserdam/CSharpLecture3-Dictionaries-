using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collecting all the inputs and putting them for same username collected messages in a new Dictionary
            var username = "";
            var finalDict = new SortedDictionary<string, string>();
            do
            {
                var inputString = Console.ReadLine().Split(new char[] { ' ', '=' });
                username = inputString[inputString.Length-1];
                if (username == "end") break;
                if (finalDict.ContainsKey(username)) finalDict[username] += ";" + inputString[1];
                else finalDict.Add(username, inputString[1]);
            } while (username != "end");
            
            //put the finalDict values into list of IPs only
            foreach (var name in finalDict.Keys)
            {
                var ipList = finalDict[name].Split(';').ToList();

                //each IP from ipList is put in ipDict as key and value equal to number of time the IP exists inipList
                var ipDict = new Dictionary<string, int>();
                foreach (var IP in ipList)
                {
                    if (!ipDict.ContainsKey(IP)) ipDict[IP] = 0;
                    ipDict[IP]++;
                }

                Console.WriteLine($"{name}: ");
                //create a list for final strings to be printed for each IP from the ipDict
                var writeList = new List<string>();
                foreach (var kvp in ipDict)
                {
                    writeList.Add($"{kvp.Key} => {kvp.Value}");
                }
                //Print the last list with final strings ready
                Console.Write(String.Join(", ", writeList));
                Console.WriteLine(".");
            }
        }
    }
}
