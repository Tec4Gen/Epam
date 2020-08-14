using System;

class Program
{
    //юзаем сортировку вставкой
    static public void SortInsertion(int[] MyArray)
    {
        //Array.Sort(MyArray);//Так проще :3 

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
    static public void ShowArray(int[] MyArray)
    {
        foreach (int item in MyArray)
        {
            Console.Write($"{item} ");
        }
    }

    static void Main(string[] args)
    {
        //Random rdn = new Random();

        Console.Write("Length: ");
        uint.TryParse(Console.ReadLine(), out uint n);

        int[] MyArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            //MyArray[i] = rdn.Next(-99999, 99999);//Так проще
            int.TryParse(Console.ReadLine(), out MyArray[i]);
        }

        if (MyArray.Length > 1)//возможно лишние, но за то норм 
        {
            Console.Write("Не сортированный массив" + Environment.NewLine);
            ShowArray(MyArray);

            SortInsertion(MyArray);//<------

            Console.Write(Environment.NewLine +
                          Environment.NewLine +
                          "Отсортированный массив" +
                          Environment.NewLine);
            ShowArray(MyArray);
        }
        else
        {
            if (MyArray.Length == 1)
            {
                Console.Write("Массив содержит 1 элемент" +
                               Environment.NewLine +
                               "Array" +
                               Environment.NewLine);
                ShowArray(MyArray);
            }
            else
            {
                Console.Write("Массив пуст");
            }
        }
    }
}