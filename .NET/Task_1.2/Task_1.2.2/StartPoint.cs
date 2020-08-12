using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._2
{
    class StartPoint
    {
        #region Main
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            StringBuilder Str = new StringBuilder(Console.ReadLine());

            Console.Write("Enter Two: ");
            string StrTwo = Console.ReadLine();
            Console.WriteLine();

            var DistStrTwo = StrTwo.Distinct().ToArray();

            for (int i = 0; i < DistStrTwo.Count(); i++)
            {
                for (int j = 0; j < Str.Length; j++)
                {
                    if (DistStrTwo[i] == Str[j]) 
                    {
                        Str.Insert(j, DistStrTwo[i].ToString(), 1);
                        j +=2;
                    }
                }
            }

            Console.Write(Str);
            Console.ReadLine();
        }
        #endregion
    }
}
