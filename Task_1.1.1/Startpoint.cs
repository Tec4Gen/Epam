﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._1
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter side a and b: ");

            if (ulong.TryParse(Console.ReadLine(), out var SideA) && 
                ulong.TryParse(Console.ReadLine(), out var SideB)) 
            {
                try
                {
                    AreaRectangle MyTriangle = new AreaRectangle(SideA, SideB);

                    Console.WriteLine($"Area {MyTriangle.Area()}");
                }
                catch
                {
                    Console.WriteLine("All or One of the sides is equal to zero");
                }
            }

            Console.ReadLine();
        }
    }
}
