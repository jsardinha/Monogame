using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            List<int> list = new List<int>();

            while (input != -1)
            {
                Console.Write("Enter a positive integer (0 included) or -1 to stop : ");
                input = int.Parse(Console.ReadLine());
                if (input >= 0)
                {
                    list.Add(input);
                }                
            }
            int max = 0;
            foreach (int number in list)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The max number is : " + max);
            Console.WriteLine();
            double average = 0.0;
            foreach (int number in list)
            {
                average += number;
            }
            average /= (list.Count * 1.0);
            Console.WriteLine("The average is : " + average);
            Console.WriteLine();

        }
    }
}
