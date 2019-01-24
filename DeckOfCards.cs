using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class DeckOfCards
    {
        public void Distribution()
        {
            Utility utility = new Utility();
            Constants constants = new Constants();
            string[] deck = utility.Deck();
            string[] shuffledDeck = utility.Shuffle(deck);
            string[,] playerCards = new string[constants.players, constants.cards];
            int indexOfShuffledDeck = 0;
            for (int i = 0; i < constants.players; i++ )
            {
                for (int j = 0; j < constants.cards; j++)
                {
                    playerCards[i, j] = shuffledDeck[indexOfShuffledDeck];
                    indexOfShuffledDeck++;
                }
            }
            for (int i = 0; i < constants.players; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(playerCards[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
        
       
    }
}
