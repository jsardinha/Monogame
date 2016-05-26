using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            // create deck
            Deck deck = new Deck();

            // create 5 cards array
            Card[] fivecard = new Card[5];

            // shuffle deck
            deck.Shuffle();

            fivecard[0] = deck.TakeTopCard();
            fivecard[0].FlipOver();
            fivecard[0].Print();
            fivecard[1] = deck.TakeTopCard();
            fivecard[1].FlipOver();
            fivecard[0].Print();
            fivecard[1].Print();
            

        }
    }
}
