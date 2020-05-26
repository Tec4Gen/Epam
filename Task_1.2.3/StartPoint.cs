using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._3
{
    class StartPoint
    {
        #region Main
        static void Main(string[] args)
        {
            double Count = 0;
            Console.Write("Enter string: ");

            string Str = Console.ReadLine();

            var ArrayWord = Str.Split(new char[] { ' ','.', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ArrayWord.Length; i++)
            {
                if (Char.IsLower(ArrayWord[i][0]))
                {
                    Count++;
                }
            }
            Console.WriteLine($"Count {Count}");
            Console.ReadLine();
        }
        #endregion
    }
}
