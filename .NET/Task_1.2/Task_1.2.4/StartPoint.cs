using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._4
{
    class StartPoint
    {
        #region Main
        static void Main(string[] args)
        {
            double Count = 0;
            Console.Write("Enter string: ");

            StringBuilder Str = new StringBuilder(Console.ReadLine());
           
            for (int i = 0; i < Str.Length; i++)
            {
                if (Str[i].ToString() != Str[i].ToString().ToUpper())
                {
                    Str.Replace(Str[i].ToString(), Str[i].ToString().ToUpper(),i,1);
                }
                while (true) 
                {
                    if (Str[i].ToString() == "." ||
                        Str[i].ToString() == "?" ||
                        Str[i].ToString() == "!")
                    {
                        i += 1;
                        break;
                    }
                    i++;
                }

            }
            Console.WriteLine(Str);
            Console.ReadLine();
        }
        #endregion
    }
}
