using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._2
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");

            
            if (ulong.TryParse(Console.ReadLine(), out var Number)) 
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

        static void ShowTriangle(ulong number) 
        {
            if (number != 0)
            {
                for (ulong i = 1; i < number; i++)
                {
                    Console.WriteLine(new String('*', (int)i));
                }
            }
            else 
            {
                Console.WriteLine("is nothing to draw");
            }     
        }
    }
}
