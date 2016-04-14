using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************");
            Console.WriteLine("Menu:");
            Console.WriteLine();
            Console.WriteLine("N - New Game");
            Console.WriteLine("L - Load Game");
            Console.WriteLine("O - Options");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("**************");
            Console.WriteLine();
            Console.Write("Enter option: ");
            char answer = Console.ReadLine()[0];

            Console.WriteLine();

            if (answer == 'n' || answer == 'N')
            {
                Console.WriteLine("Generating new world...");
            }
            else if (answer == 'l' || answer == 'L')
            {
                Console.WriteLine("Loading game...");
            }
            else if (answer == 'o' || answer == 'O')
            {
                Console.WriteLine("Options menu...");
            }
            else if (answer == 'q' || answer == 'Q')
            {
                Console.WriteLine("Quitting...");
            }
            else
            {
                Console.WriteLine(answer + " is not a valid entry.");
            }

            Console.WriteLine();

            switch (answer)
            {
                case 'n':
                case 'N':
                    Console.WriteLine("Generating new world...");
                    break;
                case 'l':
                case 'L':
                    Console.WriteLine("Loading game...");
                    break;
                case 'o':
                case 'O':
                    Console.WriteLine("Options menu...");
                    break;
                case 'q':
                case 'Q':
                    Console.WriteLine("Quitting...");
                    break;
                default:
                    Console.WriteLine(answer + " is not a valid entry.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
