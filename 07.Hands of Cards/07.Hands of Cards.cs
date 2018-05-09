using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collecting all the inputs and putting them for same name collected cards in a new Dictionary
            var name = "";
            var finalDict = new Dictionary<string, string>();
            do
            {
                var inputString = Console.ReadLine().Split(':');
                name = inputString[0];
                if (name == "JOKER") break;
                if (finalDict.ContainsKey(name)) finalDict[name] += "," + inputString[1];
                else finalDict.Add(name, inputString[1]);
            } while (name != "JOKER");

            //each string value from the Dictionary is converted into new list as cards are splitted
            foreach (var person in finalDict.Keys)
            {
                var cardsArrayWithDupes = finalDict[person].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var cardsArray=cardsArrayWithDupes.Distinct().ToList(); //removing the duplicated values from the list for each name

                //calculating the power based on unique cards for each name and printing the result
                int globalPower = 0;

                for (int i = 0; i < cardsArray.Count; i++)
                {
                    int localPower = 0;
                    char[] card = cardsArray[i].ToCharArray();

                    if (card[0] == '1') localPower += 10;
                    else if (card[0] == '2') localPower += 2;
                    else if (card[0] == '3') localPower += 3;
                    else if (card[0] == '4') localPower += 4;
                    else if (card[0] == '5') localPower += 5;
                    else if (card[0] == '6') localPower += 6;
                    else if (card[0] == '7') localPower += 7;
                    else if (card[0] == '8') localPower += 8;
                    else if (card[0] == '9') localPower += 9;
                    else if (card[0] == 'J') localPower += 11;
                    else if (card[0] == 'Q') localPower += 12;
                    else if (card[0] == 'K') localPower += 13;
                    else if (card[0] == 'A') localPower += 14;

                    if (card[card.Length - 1] == 'S') localPower *= 4;
                    else if (card[card.Length - 1] == 'H') localPower *= 3;
                    else if (card[card.Length - 1] == 'D') localPower *= 2;
                    else if (card[card.Length - 1] == 'C') localPower *= 1;

                    globalPower += localPower;
                }
                Console.WriteLine($"{person}: {globalPower}");
            }
        }
    }
}
