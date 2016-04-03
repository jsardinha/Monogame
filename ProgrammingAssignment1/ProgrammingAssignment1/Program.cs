using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// Calculates both distance and angle between two points
    /// </summary>
    class Program
    {
        /// <summary>
        /// Calculates both distance and angle between two points
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // welcome message
            Console.WriteLine();
            Console.WriteLine("Welcome.\n\n" +
                              "This program will calculate both distance\n" +
                              "and angle between to points of your choosing.\n\n");

            // enter coordinates
            Console.WriteLine("Point 1:");
            Console.WriteLine("========");
            Console.Write("Enter X coordinate: ");
            double point1X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate: ");
            double point1Y = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Point 2: ");
            Console.WriteLine("========");
            Console.Write("Enter X coordinate: ");
            double point2X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate: ");
            double point2Y = double.Parse(Console.ReadLine());
            Console.WriteLine();

            // calcultate delta
            double deltaX = point2X - point1X;
            double deltaY = point2Y - point1Y;

            // calculate distance using Pythagorean Theorem
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            // calculate angle in degrees
            double angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);

            // print results
            Console.WriteLine("The distance between the two points is: " + Math.Round(distance, 3));
            Console.WriteLine();
            Console.WriteLine("The angle between the two points is " + Math.Round(angle, 3) + " degrees.");
            Console.WriteLine();
        }
    }
}
