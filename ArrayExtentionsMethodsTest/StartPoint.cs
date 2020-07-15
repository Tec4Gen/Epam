using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ArrayExtentionMethod;
namespace ArrayExtentionsMethodsTest
{
    class StartPoint
    {
        static void Main(string[] args)
        {

            int[] a = new int[] { 1, 2};

            char[] b = new char[] { 'a', 'b', 'c','c' };

            Console.WriteLine(b.CommonElement() );

            var bm = a.ArrayModifi(x=>x*x);


            Console.WriteLine(a.Average());

        }
    }
}
