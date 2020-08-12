using Pizzeria.Entities;
using System;

namespace Pizzeria.BL.Interface
{
    public interface IPizzeriaLogic
    {
        event Action OnOrder;
        void Execution();
    } 
}
