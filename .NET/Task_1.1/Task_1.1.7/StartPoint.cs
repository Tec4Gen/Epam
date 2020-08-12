using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._7
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            int[] Array;


            Console.Write("Enter size: ");

            if (uint.TryParse(Console.ReadLine(), out var Size))
            {
                Array = new int[Size];
                CreateArray(Array);
                SortAndFindMinMax(Array, out var Min, out var Max);
                Show(Array);

                Console.WriteLine($"min: {Min} max: {Max}");
            }
            else
            {
                Console.WriteLine("Not valid value");
            }

            Console.ReadLine();
        }
        static void SortAndFindMinMax(int[] array,out int min,out int max)
        {
            SortInsertion(array);

            min = array[0];
            max = array[array.Length - 1];
        }

        static void CreateArray(int[] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101); ;
            }
        }
        static void Show(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        static public void SortInsertion(int[] MyArray)
        {
            int Current;
            int j;
            for (int i = 1; i < MyArray.Length; i++)
            {
                Current = MyArray[i];
                j = i;

                while (j > 0 && Current < MyArray[j - 1])
                {
                    MyArray[j] = MyArray[j - 1];
                    j--;
                }
                MyArray[j] = Current;
            }
        }
    }
}
