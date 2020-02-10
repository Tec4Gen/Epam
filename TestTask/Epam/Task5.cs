using System;
using System.Collections.Generic;


namespace Epam
{
    public class Task5
    {
        public static bool CheсkString(string str)
        {
            if (str.Length % 2 == 0 && str != "")
            {
                Stack<char> Stack_ = new Stack<char>();

                for (int i = 0; i < str.Length; i++)
                {
                    if (Stack_.Count == 0)
                    {
                        if (str[i] != ')' && str[i] != ']' && str[i] != '}')
                        {
                            Stack_.Push(str[i]);
                        }
                        else
                        {
                            Console.WriteLine("Не правильная последовательность");
                            return false;
                        }

                    }
                    else
                    {
                        //Собираем все открывающие
                        if (str[i] == '(')
                        {
                            Stack_.Push(str[i]);
                        }
                        else if (str[i] == '[')
                        {
                            Stack_.Push(str[i]);
                        }
                        else if (str[i] == '{')
                        {
                            Stack_.Push(str[i]);
                        }
                        else
                        {
                            //если некторой открывающей соответствует закрывающая вытаскиваем из стека
                            if (str[i] != ')' || str[i] != ']' || str[i] != '}')
                            {
                                if (str[i] == ')' && Stack_.Peek()== '(')
                                {
                                    Stack_.Pop();
                                }
                                else if (str[i] == '}' && Stack_.Peek() == '{')
                                {
                                    Stack_.Pop();
                                }
                                else if (str[i] == ']' && Stack_.Peek() == '[')
                                {
                                    Stack_.Pop();
                                }
                            }   
                        }
                    } 
                }
                //Если стек пуст, значит ПСП 
                if (Stack_.Count == 0)
                {
                    Console.WriteLine("Правильная последовательность");
                    return true;
                }
                else
                {
                    Console.WriteLine("Не правильная последовательность");
                    return false;
                }
            }
            else
            {
                if (str == "")
                {
                    Console.WriteLine("Строка пустая");
                    return false;
                }
                else
                {
                    Console.WriteLine("Нечетное кол-во символов в строке не может быть ПСП");
                    return false;
                }
            }

        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            CheсkString(str);
            //Если говорить о цункциях, то какое нибудь сложное регулярное выражение, легко бы заменило весь этот велосипед.
        }
    }
}
