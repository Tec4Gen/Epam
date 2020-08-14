using System;
using System.Collections.Generic;
class Program
{
    static public void MySplit(string str, List<string> MyArray)
    {
        string Word;
        int IndexInarray = 0;
        int Count = 0;
        int Current;
        if (str != "")
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    Current = i;
                    //Выделяем слова и складываем в список
                    while (i != str.Length && str[i] != ' ')
                    {
                        i++;
                        Count++;
                    }
                    Word = str.Substring(Current, Count);
                    Count = 0;

                    MyArray.Add(Word);
                    IndexInarray++;
                }
            }
        }
        else
        {
            Console.WriteLine("Строка пустая");
        }
    }
    static public void FindAllSingle(List<string>MyArray)
    {
        int CountSingleWords = 0;
        int count;
        if (MyArray.Count > 1)
        {
            foreach (string First in MyArray)
            {
                count = 0;
                foreach (string Second in MyArray)
                {
                    if (count > 1)
                    {
                        break;
                    }
                    if (First == Second)
                    {
                        count++;
                    }
                }
                if (count == 1)
                {
                    CountSingleWords++;
                    Console.Write($"{First} ");
                }
            }
            if (CountSingleWords==0)
            {
                Console.WriteLine("Одиночный слов нет");
            }
        }
        else
        {
            if (MyArray.Count == 1)
            {
                Console.Write($"{MyArray[0]} ");
            }
            else
            {
                Console.Write($"В этом списке слов нет!");
            }

        }
        
    }
    //То,что это предложение и в нем содержаться зпятые, и прочие знаки припинания - не сказано
    //По этому в качестве разделителя только пробел.

    //А вообще если без этих велосипедов, то .Split потом .Join потом через Linq отсеиваем, Ps/можно еще Regex в качестве отсеивания прилепить.
    static void Main(string[] args)
    {
        string str = Console.ReadLine();

        List<string> ArrayWords = new List<string>();
        MySplit(str,ArrayWords);//Самописный сплит

        FindAllSingle(ArrayWords);//Ищем все "одинокие" слова 
    }
}
