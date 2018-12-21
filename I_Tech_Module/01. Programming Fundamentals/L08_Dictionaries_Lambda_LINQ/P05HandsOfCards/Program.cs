using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> playerCards = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(':').ToArray();
            string name = input[0];

            while (name != "JOKER")
            {
                List<string> cards = input[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!playerCards.ContainsKey(name))
                {
                    playerCards.Add(name, new List<string>(cards));					
                }
                else if (playerCards.ContainsKey(name))
                {
                    playerCards[name].AddRange(cards);
                }
                playerCards[name] = playerCards[name].Distinct().ToList();
                input = Console.ReadLine().Split(':').ToArray();
                name = input[0];
            }
            foreach (var player in playerCards)
            {
                Console.WriteLine("{0}: {1}", player.Key, GetCardsSum(player.Value));
            }
        }

        static int GetCardsSum(List<string> cardsPowerAndType)
        {
            Dictionary<string, int> allCardsValue = new Dictionary<string, int>()
            {
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
                {"10", 10},
                {"J", 11},
                {"Q", 12},
                {"K", 13},
                {"A", 14},
                {"S", 4},
                {"H", 3},
                {"D", 2},
                {"C", 1}
            };
            int cardsSum = 0;
            foreach (var card in cardsPowerAndType)
            {
                string cardType = card.Substring(card.Length - 1);
                string cardPower = card.Remove(card.Length - 1);
                cardsSum += allCardsValue[cardPower] * allCardsValue[cardType];
            }
            return cardsSum;
        }
    }
}
