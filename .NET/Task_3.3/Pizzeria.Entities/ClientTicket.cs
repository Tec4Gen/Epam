using Pizzeria.Product;
using System.Collections.Generic;

namespace Pizzeria.Entities
{
    public struct ClientTicket
    {
        public int IdTicket { get; set; }

        public List<Pizza> Pizza { get; set; }
    }
}
