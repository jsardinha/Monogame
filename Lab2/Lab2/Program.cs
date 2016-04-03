using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Lab2
    /// </summary>
    class Program
    {
        /// <summary>
        /// Lab2
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // problem 1 -  declaring and using variables
            int age = 55;

            Console.WriteLine("My age is: " + age);

            Console.WriteLine();

            // problem 2 - declaring and using constants and variables
            const int MaxScore = 100;
            int score = 25;
            float percent = (float)score / MaxScore;

            Console.WriteLine("Percent: " + percent);

            Console.WriteLine();
        }
    }
}
