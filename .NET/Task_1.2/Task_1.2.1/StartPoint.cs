using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._1
{
    //Дробное число 
    class StartPoint
    {
        #region Main
        static void Main(string[] args)
        {
            double Middle = 0;
            Console.Write("Enter string: ");

            string Str = Console.ReadLine();

            var ArrayWord = Str.Split(new char[] { ' ',',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
           
            foreach (var item in ArrayWord)
            {
                Middle += item.Length;
            }
            Console.WriteLine($"Meddle length: {Math.Round(Middle/ArrayWord.Length,3)}");
            Console.ReadLine();
        }
        #endregion

    }
}
