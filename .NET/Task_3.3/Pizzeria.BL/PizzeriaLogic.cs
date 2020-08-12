using Pizzeria.BL.Interface;
using Pizzeria.Entities;
using System;

namespace Pizzeria.BL
{
    public class PizzeriaLogic : IPizzeriaLogic
    {
        public event Action OnOrder = delegate { };


        public PizzeriaPoint Pizzeria { get; set; }

        public PizzeriaLogic(PizzeriaPoint pizzeria)
        {
            if (pizzeria == null)
                throw new ArgumentNullException();
            Pizzeria = pizzeria;
        }

        public void Execution() 
        {
            if (Pizzeria.ListOrder == null)
                throw new ArgumentNullException();
            if (Pizzeria.ListOrder.Count == 0)
                throw new ArgumentException();

            for (int i = 0; i < Pizzeria.ListOrder.Count; i++)
            {
                Notification.Subscribe(Pizzeria.ListOrder[i], this);
                OrderExecution();

                Notification.UnSubscribe(this);
            }
                
        }
        private void OrderExecution()
        {
            OnOrder();
        }

    }
}
