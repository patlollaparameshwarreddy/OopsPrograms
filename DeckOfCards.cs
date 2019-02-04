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
            ////declaring and assigning the return value of card distribute method to player card array
            string[,] playercard = Utility.CardDistribute();
            ////printing on console
            Console.WriteLine("Player1 \t Player2 \t Player3 \t Player4");
            Console.WriteLine();
            int x = 0;
            int y = 0;
            ////this nested loop is uesed for printing the cards with the players
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(playercard[x, y] + " \t ");
                    y++;
                    if (y == 9)
                    {
                        y = 0;
                        x++;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}