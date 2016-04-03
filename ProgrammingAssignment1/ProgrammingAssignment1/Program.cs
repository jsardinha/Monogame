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
                              "and angle between two points of your choosing.\n\n");

            // enter coordinates
            Console.WriteLine("Point 1:");
            Console.WriteLine("========");
            Console.Write("Enter X coordinate: ");
            float point1X = float.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate: ");
            float point1Y = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Point 2: ");
            Console.WriteLine("========");
            Console.Write("Enter X coordinate: ");
            float point2X = float.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate: ");
            float point2Y = float.Parse(Console.ReadLine());
            Console.WriteLine();

            // calcultate delta
            float deltaX = point2X - point1X;
            float deltaY = point2Y - point1Y;

            // calculate distance using Pythagorean Theorem
            float distance = (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            // calculate angle in degrees
            float angle = (float)(Math.Atan2(deltaY, deltaX) * (180 / Math.PI));

            // print results
            Console.WriteLine();
            Console.WriteLine("Distance between points: " + distance.ToString("F3"));
            Console.WriteLine();
            Console.WriteLine("Angle between points: " + angle.ToString("F3") + " degrees.");
            Console.WriteLine();
        }
    }
}
