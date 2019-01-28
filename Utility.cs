//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used for writing the common logic 
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Decks this instance.
        /// </summary>
        /// <returns>returns the deck of cards array</returns>
        public string[] Deck()
        {
            ////creating the string array for suit
            string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
            ////creating the string array for storing the ranks
            string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int numberOfCards = suit.Length * rank.Length;
            string[] deck = new string[numberOfCards];
            ////this loop is used for storing cards in to deck array
            for (int i = 0; i < rank.Length; i++)
            {
                for (int j = 0; j < suit.Length; j++)
                {
                    deck[(suit.Length * i) + j] = rank[i] + " is " + suit[j];
                }
            }

            return deck;
        }

        /// <summary>
        /// Shuffles the specified deck.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <returns>returns the deck of cards array</returns>
        public string[] Shuffle(string[] deck)
        {
            try
            {
                ////creating the object of random class
                Random random = new Random();
                ////this loop is used for shuffling the cards
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
