using System;

class Program
{
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
        Console.WriteLine();
    }

    //ищем бинарным поиском, отсортированная же)
    static public int BinaryFind(int[]MyArray,int Required)
    {
        int Left, Right, Middle;
        Left = 0;
        Right = MyArray.Length-1;
        while (Left <= Right)
        {
            Middle = (Left + Right) / 2;
            if (Required < MyArray[Middle])
            {
                Right = Middle - 1;
            }
            else if (Required > MyArray[Middle])
            {
                Left = Middle + 1;
            }
            else
            {
                return Middle;
            }
               
        }
        return -1;
    }
    static void Main(string[] args)
    {
        Random rdn = new Random();

        Console.Write("Length: ");
        uint.TryParse(Console.ReadLine(), out uint n);

        int[] MyArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            MyArray[i] = rdn.Next(-100, 101);//Так проще 
        }

        ShowArray(MyArray);
        SortInsertion(MyArray);
        ShowArray(MyArray);

        Console.Write("Введите искомый элемент: ");
        int.TryParse(Console.ReadLine(), out int Number);

        int RequiredIndex = BinaryFind(MyArray, Number);
        
        if (RequiredIndex != -1)
        {
            Console.WriteLine($"Искомый индекс элемента MyArray[{RequiredIndex}] = {MyArray[RequiredIndex]}");
        }
        else
        {
            Console.WriteLine($"Такого элемента нет!");
        }
    }
}


