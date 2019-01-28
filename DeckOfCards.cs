//-----------------------------------------------------------------------
// <copyright file="DeckOfCards.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used for deck of cards
    /// </summary>
    public class DeckOfCards
    {
        /// <summary>
        /// Distributions this instance.
        /// </summary>
        public void Distribution()
        {
            ////cresating the object of utility class
            Utility utility = new Utility();
            ////creating the object of constant class
            Constants constants = new Constants();
            ////crating the string array for deck of cards
            string[] deck = utility.Deck();
            ////string array for shuffledDeck cards
            string[] shuffledDeck = utility.Shuffle(deck);
            ////creating 2D array for storing players cards
            string[,] playerCards = new string[constants.Players, constants.Cards];
            int indexOfShuffledDeck = 0;
            ////this nested for loop is used for shuffleing cards
            for (int i = 0; i < constants.Players; i++)
            {
                for (int j = 0; j < constants.Cards; j++)
                {
                    playerCards[i, j] = shuffledDeck[indexOfShuffledDeck];
                    indexOfShuffledDeck++;
                }
            }

            int player = 1;
            ////this nested for loop is used for distribution of cards for players
            for (int i = 0; i < constants.Players; i++)
            {               
                Console.WriteLine("player " + player + " cards");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(playerCards[i, j] + "\t");
                }

                player++;
                Console.WriteLine();
            }
        }              
    }
}
