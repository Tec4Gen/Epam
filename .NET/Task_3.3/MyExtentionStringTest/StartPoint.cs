using MyExtentionString;
using System;
namespace MyExtentionStringTest
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            string str1 = "ЯЯЯЯ";
            string str2 = "AAAA";
            string str3 = "AAA2";
            string str4 = "ЯЯЯЯ3";
            string str5 = "3333";

            Console.WriteLine(str1.GetLanguage());
            Console.WriteLine(str2.GetLanguage());
            Console.WriteLine(str3.GetLanguage());
            Console.WriteLine(str4.GetLanguage());
            Console.WriteLine(str5.GetLanguage());

        }
    }
}
