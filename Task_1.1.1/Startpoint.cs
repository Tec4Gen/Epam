using System;

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
                    Console.WriteLine("One of the sides is equal to zero");
                }
            }

            Console.ReadLine();
        }
    }
}
