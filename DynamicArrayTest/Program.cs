using MyDynamicArray;
using System;
using System.Collections.Generic;

namespace DynamicArrayTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> item = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            DynamicArray<int> a = new DynamicArray<int> (20);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.AddRange(item);
            //Console.WriteLine(a.IsInsert(3, 99999));
            //Console.WriteLine(a.IsInsert(1, 10000));
           // c = (DynamicArray <int>)a.Clone();

            foreach (var item1 in a)
            {

                Console.Write($"{item1} ");
            }
            Console.ReadLine();
        }
    }
}
