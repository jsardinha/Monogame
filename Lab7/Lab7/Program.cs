using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    /// <summary>
    /// Birthday fun
    /// </summary>
    class Program
    {
        /// <summary>
        /// Birthday fun
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // ask for and get in date of birth
            Console.Write("In what month were you born? ");
            string month = Console.ReadLine();
            Console.Write("On what day were you born? ");
            int day = int.Parse(Console.ReadLine());

            // print birthday
            Console.WriteLine();
            Console.WriteLine("Your birthday is " + month + " " + day);
            Console.WriteLine("You'll receive an email reminder on " + month + " " + (day - 1));
            Console.WriteLine();
        }
    }
}
