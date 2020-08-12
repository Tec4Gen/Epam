using Pizzeria.Entities;
using Pizzeria.Product;
using System;
using System.Threading;

namespace Pizzeria.BL
{
    public static class Notification
    {
        static public Order _order { get; set; }
        static public void Subscribe(Order order, PizzeriaLogic pizzeriaLogic)
        {
            _order = order;
            pizzeriaLogic.OnOrder += GetReady;
        }

        static public void UnSubscribe(PizzeriaLogic pizzeriaLogic)
        {
            pizzeriaLogic.OnOrder -= GetReady;
        }


        static private void СompletionMessage()
        {
            Console.WriteLine($"{Environment.NewLine}!!!Order ready!!!: {_order.Ticket.IdTicket}" +
                Environment.NewLine +
                "Pizza");
            Console.WriteLine(new String('*', 20));

            foreach (var item in _order.Ticket.Pizza)
            {
                Console.Write(item + Environment.NewLine);
            }
            Console.WriteLine(new String('*', 20) + Environment.NewLine);
        }

        static private void GetReady()
        {
            Console.WriteLine($"{new String('=', 20)} {Environment.NewLine}Order get ready: {_order.Ticket.IdTicket}:");
        
            СompletionMessage();
        }
    }
}
