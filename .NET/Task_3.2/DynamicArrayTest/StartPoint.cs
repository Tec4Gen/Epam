using MyDynamicArray;
using System;
using System.Collections.Generic;

namespace DynamicArrayTest
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            CycledDynamicArray<int> item = new CycledDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            DynamicArray<int> c = new DynamicArray<int>(100);
            DynamicArray<int> item2 = new DynamicArray<int>() { 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
            DynamicArray<int> a = new DynamicArray<int> (20);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.AddRange(item2);
            item2.Capacity = 100;

            var g = item2.ToArray();
            //Console.WriteLine(a.IsInsert(3, 99999));
            //Console.WriteLine(a.IsInsert(1, 10000));
            // c = (DynamicArray <int>)a.Clone();

            foreach (var item1 in c)
            {

                Console.Write($"{item1} ");
            }
            Console.ReadLine();
        }
    }
}
