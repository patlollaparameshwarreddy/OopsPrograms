using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class Utility
    {
        public string[] Deck()
        {
            string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int numberOfCards = suit.Length * rank.Length;
            string[] deck = new string[numberOfCards];
            for (int i = 0; i < rank.Length; i++)
            {
                for (int j = 0; j < suit.Length; j++)
                {
                    deck[suit.Length * i + j] = rank[i] + " is " + suit[j];
                }
            }
            return deck;
        }

        public string[] Shuffle(string[] deck)
        {
            try
            {
                Random random = new Random();
                for (int i = 0; i < 52; i++)
                {
                    int randomIndex = random.Next(0, 52);
                    string temp = deck[i];
                    deck[i] = deck[randomIndex];
                    deck[randomIndex] = temp;
                }
                return deck;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
