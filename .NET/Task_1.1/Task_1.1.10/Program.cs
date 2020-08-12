using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._10
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            int[,] Array;
            int Summ;
            Console.WriteLine("Enter Row, Column: ");

            if (uint.TryParse(Console.ReadLine(), out var Row) &&
                uint.TryParse(Console.ReadLine(), out var Column))
            {
                Array = new int[Row, Column];
                CreateArray(Array);
                Show(Array);
                Summ = Sum(Array);

                Console.WriteLine($"Summ: {Summ}");
            }
            else
            {
                Console.WriteLine("Not valid value");
            }

            Console.ReadLine();
        }
        #endregion

        #region Sum
        static int Sum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i + j % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }
        #endregion

        #region CreateArray
        static void CreateArray(int[,] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-100, 101);
                }

            }
        }
        #endregion

        #region Show
        static void Show(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }
}
