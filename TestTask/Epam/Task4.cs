using System;

class Program
{
    static public ulong Fact(int n)
    {
        if (n < 0)
        {
            Console.WriteLine("n < 0 :*(");
        }
        if(n==0 || n==1)
        {
            return 1;
        }

        ulong Factorial = 1;
        //чекаем на переполнение
        checked
        {
            try
            {
                for (int i = 2; i <= n; i++)
                {
                    Factorial *= (ulong)i;
                }
                return Factorial;
            }
            catch
            {
                Console.WriteLine("n >= 21 :*(");
                return 0;
            }
        }
    } 
    static void Main(string[] args)
    {
        int.TryParse(Console.ReadLine(), out int Number);

        Console.Write($"Факториал {Number} = {Fact(Number)}");
    }
}

