using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Fahrenheit to Celsius converter and back
    /// </summary>
    class Program
    {
        /// <summary>
        /// Fahrenheit to Celsius converter and back
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // declare variables
            double originalFahrenheit;
            double celsius;
            double celsiusToFahrenheit;

            // enter Fahrenheit value
            Console.Write("Enter temperature (Fahrenheit): ");
            originalFahrenheit = double.Parse(Console.ReadLine());

            // convert Fahrenheit to Celsius
            celsius = ((originalFahrenheit - 32) / 9) * 5;

            // Convert Celsius to Fahrenheit
            celsiusToFahrenheit = ((celsius * 9) / 5) + 32;

            // print results
            Console.WriteLine();
            Console.WriteLine(originalFahrenheit + " degrees Fahrenheit is " +
                celsius + " degrees Celsius");
            Console.WriteLine();
            Console.WriteLine(celsius + " degrees Celsius is " +
                celsiusToFahrenheit + " degrees Fahrenheit");
            Console.WriteLine();
             
        }
    }
}
