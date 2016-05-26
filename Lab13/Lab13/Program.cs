using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lower bound : ");
            int lower = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Upper bound : ");
            int upper = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = lower; i <= upper; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Deck deck = new Deck();
            List<Card> hand = new List<Card>();
            deck.Shuffle();
            for (int i = 0; i < 5; i++)
                {
                    hand.Add(deck.TakeTopCard());
                }
            for (int i = 0; i < hand.Count; i++)
            {
                hand[i].FlipOver();
            }
            foreach (Card card in hand)
            {
                card.Print();
            }
            Console.WriteLine();
        }
    }
}
