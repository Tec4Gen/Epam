using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");


            if (uint.TryParse(Console.ReadLine(), out var Number))
            {
                Console.WriteLine("");
                ShowTriangle(Number);
            }
            else
            {
                Console.WriteLine("Enter a positive number");
            }

            Console.ReadLine();
        }

        static void ShowTriangle(uint number)
        {
            if (number > 0)
            {

                for (var i = 0; i < number; i++)
                {
                    for (uint j = 0, stars = 1, space = number;
                         j <= i;
                         j++, stars += 2, space--)
                    {
                        Console.WriteLine(new String(' ', (int)space) + new String('*', (int)stars));
                    }
                }
            }
            else
            {
                Console.WriteLine("is nothing to draw");
            }
        }
    }
}
