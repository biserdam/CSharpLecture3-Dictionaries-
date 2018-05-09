using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); //get the number of lines which will be input

            //initialize two dictionaries: 
            var userIPs = new SortedDictionary<string, string>(); //users->IPs(string of all IPs added one after another for same user)
            var userDuration = new Dictionary<string, int>(); //users->total duration(for same user increase the duration with new value from each input line)

            for (int i = 0; i < n; i++)
            {
                var inputString = Console.ReadLine().Split(' ');
                if (!userIPs.ContainsKey(inputString[1]))
                {
                    userIPs[inputString[1]] = "";
                }
                userIPs[inputString[1]] += inputString[0] + " "; //string of all IPs added one after another for same user

                if (!userDuration.ContainsKey(inputString[1]))
                {
                    userDuration[inputString[1]] = 0;
                }
                userDuration[inputString[1]] += int.Parse(inputString[2]); //for same user increase the duration with new value from each input line
            }
            //foreach (var user in userIPs) Console.WriteLine($"{user.Key} -> {user.Value}");
            //foreach (var user in userDuration) Console.WriteLine($"{user.Key} -> {user.Value}");

            //Print the output for each user from the list with users and IPs and refer to the second dictionary with duration for the same user
            foreach (var item in userIPs.Keys)
            {
                var ipList = userIPs[item].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ipList.Sort(); //create, sort and remove duplicate values from a new list of IPs for same user only, then use it for the final print
                var ipListNoDupes = ipList.Distinct().ToList();
                Console.WriteLine($"{item}: {userDuration[item]} [{String.Join(", ", ipListNoDupes)}]");
            }
        }
    }
}
