using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    /// <summary>
    /// Implements Lab 4 functionality
    /// </summary>
    class Program
    {
        /// <summary>
        /// Implements Lab 4 functionality
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // create a new deck and print the contents of the deck
            Deck deck = new Deck();
            deck.Print();
            Console.WriteLine();

            // shuffle the deck and print the contents of the deck
            deck.Shuffle();
            deck.Print();
            Console.WriteLine();

            // take the top card from the deck and print the card rank and suit
            Card card0 = deck.TakeTopCard();
            Console.WriteLine("Card0 rank: " + card0.Rank + ", Card0 suit: " + card0.Suit);

            // take the top card from the deck and print the card rank and suit
            Card card1 = deck.TakeTopCard();
            Console.WriteLine("Card1 rank: " + card1.Rank + ", Card1 suit: " + card1.Suit);

        }
    }
}
