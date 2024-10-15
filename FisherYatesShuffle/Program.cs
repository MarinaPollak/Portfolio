using System;
using System.Collections.Generic;
using System.Linq;




namespace FisherYatesShuffle
{
    public class CardGame
    {
        //make deck of card to pass in a Shuffle function as a string array
        protected static string[] _deck = new string[]
        {
            "Ace of Spades", "2 of Spades", "3 of Spades", "4 of Spades",
            "5 of Spades", "6 of Spades", "7 of Spades", "8 of Spades",
            "9 of Spades", "10 of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
            // ... include other suits
        };

        public static void Main()
        {
            Initialize();
        }

        private static void Initialize()
        {
            //shuffle the deck of cards
            FisherYatesShuffle.Shuffle(_deck);

            //print each card in the deck
            foreach (var card in _deck)
            {
                Console.WriteLine(card);
            }
        }
    }
}
