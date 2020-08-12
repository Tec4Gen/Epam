using System;

namespace Task_1._1._8
{
    class StartPoin
    {
        #region Main
        static void Main(string[] args)
        {
            int[,,] Array;
            Console.WriteLine("Enter Row, Column, List: ");

            if (uint.TryParse(Console.ReadLine(), out var Row) &&
                uint.TryParse(Console.ReadLine(), out var Column) &&
                uint.TryParse(Console.ReadLine(), out var List))
            {
                Array = new int[Row, Column, List];
                CreateArray(Array);
                Show(Array);
                Console.WriteLine(new String('*', 20));
                ReplaceToZero(Array);
                Show(Array);
            }
            else
            {
                Console.WriteLine("Not valid value");
            }

            Console.ReadLine();
        }
        #endregion

        #region ReplaceToZero
        static void ReplaceToZero(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }

                    }
                }
            }
        }
        #endregion

        #region CreateArray
        static void CreateArray(int[,,] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rnd.Next(-100, 101);
                    }
                }

            }
        }
        #endregion

        #region Show
        static void Show(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine($"Page {i}");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write($"{array[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion

    }
}
