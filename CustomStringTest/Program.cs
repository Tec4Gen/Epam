using CustomString;
using System;
using System.Linq;

namespace CustomStringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StringUp str = new StringUp("abaaba");
            var a = StringUp.ZFunction("abaaba");
            foreach (var item in a)
            {
                Console.Write(item);
            }

            

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
