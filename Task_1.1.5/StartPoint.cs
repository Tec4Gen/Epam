﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._5
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");


            if (int.TryParse(Console.ReadLine(), out var Number))
            {
                Console.WriteLine($"Result: {Sum(Number)}");;
            }
            else
            {
                Console.WriteLine("Not valid value");
            }

            Console.ReadLine();
        }
        static int Sum(int number) 
        {
            int sumresult = 0;

            for (int i = 3; i < number; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumresult += i;
                }
            }
            return sumresult;
        }
    }
}
