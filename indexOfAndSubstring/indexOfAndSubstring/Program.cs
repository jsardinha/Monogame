using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexOfAndSubstring
{
    /// <summary>
    /// Demonstrates IndexOf and Substring methods
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates IndexOf and Substrig methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // read in csv string
            Console.Write("Enter name and percentage (name,percentage): ");
            string csvString = Console.ReadLine();

            // find comma index
            int commaLocation = csvString.IndexOf(',');

            // extract name and percent
            string name = csvString.Substring(0, commaLocation);
            float percent = float.Parse(csvString.Substring(commaLocation + 1));

            // print name and percent
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Percent: " + percent);

            Console.WriteLine();
        }
    }
}
