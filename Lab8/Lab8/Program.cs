using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Demonstrates string processing
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates string processing
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Enter pyramid slot number, block letter, and if it should be lit or not.\n(int,char,(true/false)) ");
            string answer = Console.ReadLine();
            Console.WriteLine();
            int indexOfComma = answer.IndexOf(',');
            int slotNumber = int.Parse(answer.Substring(0, indexOfComma));
            Console.WriteLine("The slot number is: " + slotNumber);
            string cutAnswer = answer.Substring(indexOfComma + 1);
            indexOfComma = cutAnswer.IndexOf(',');
            char blockLetter = cutAnswer.Substring(0, indexOfComma)[0];
            Console.WriteLine("The block letter is: " + blockLetter);
            bool lit = bool.Parse(cutAnswer.Substring(indexOfComma + 1));
            Console.Write("The block is ");
            if (!lit)
            {
                Console.Write("not ");
            }
            Console.WriteLine("lit.");
            Console.WriteLine();
        }
    }
}
