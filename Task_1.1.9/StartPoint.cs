using System;

namespace Task_1._1._9
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            int[] Array;


            Console.Write("Enter size: ");

            if (uint.TryParse(Console.ReadLine(), out var Size))
            {
                Array = new int[Size];
                CreateArray(Array);   
                Show(Array);
                var Sum = NonNegativeSum(Array);

                Console.WriteLine($"Sum NonNegative: {Sum}");
            }
            else
            {
                Console.WriteLine("Not valid value");
            }

            Console.ReadLine();
        }
        #endregion

        #region CreateArray
        static void CreateArray(int[] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 100); ;
            }
        }
        #endregion

        #region Show
        static void Show(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        #endregion

        #region NonNegativeSum
        static public int NonNegativeSum(int[] MyArray)
        {
            int sum = 0;
            for (int i = 1; i < MyArray.Length; i++)
            {
                if (MyArray[i] > 0)
                {
                    sum += MyArray[i];

                }

            }
            return sum;
        }
        #endregion
    }
}
