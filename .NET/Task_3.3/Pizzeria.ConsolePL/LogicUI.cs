using Pizzeria.BL;
using System;
using Pizzeria.Entities;
using System.Collections.Generic;
using Pizzeria.Product;
using System.Threading;
using System.CodeDom.Compiler;

namespace Pizzeria.ConsolePL
{
    public static class LogicUI
    {
        public static object ListOrder { get; private set; }

        public static void Run() 
        {
            int number;
            Random ran = new Random();
            while (true) 
            {
                Console.WriteLine("Enter couts Client");
                if (int.TryParse(Console.ReadLine(), out number)) 
                {
                    break;
                }
                
            }

            var pizzeriaPoint = new PizzeriaPoint
            {
                ListOrder = new List<Order>()
            };

           
            var temp = new List<Pizza>();
            int count;

            for (int i = 0; i < number; i++)
            {
                count = ran.Next(1, 6);
                for (int j = 1; j <= count; j++)
                {
                    temp.Add((Pizza)j);
                }

                var order = new Order
                {
                    Ticket = new ClientTicket()
                    {
                        IdTicket = i,
                        Pizza = new List<Pizza>(temp),
                    }
                };

                pizzeriaPoint.ListOrder.Add(order);
                temp.Clear();
               
            }
            PizzeriaLogic pizzeriaLogic = new PizzeriaLogic(pizzeriaPoint);

            pizzeriaLogic.Execution();
        }
    }
}
