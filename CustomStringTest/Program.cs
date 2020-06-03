using CustomString;
using System;
namespace CustomStringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StringUp str = new StringUp("Тест");
            StringUp str1 = null;
            str.Equals(str1);
            Console.WriteLine();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
