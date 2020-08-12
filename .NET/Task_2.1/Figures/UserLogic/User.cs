using Figures.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Figures.UserLogic
{
    public class User : IUser
    {
        private List<AbstractFigure> _listFigure;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstname, string lastname)
        {
            if (firstname == null || lastname == null) 
            {
                throw new ArgumentNullException(); 
            }
            FirstName = firstname;
            LastName = lastname;

           _listFigure = new List<AbstractFigure>();

        }


        public void ClearList()
        {
            if (_listFigure == null) 
            {
                throw new ArgumentNullException();
            }
            _listFigure.Clear();
        }

        public void Create(AbstractFigure item)
        {
            if (item == null) 
            {
                throw new ArgumentNullException();
            }
            _listFigure.Add(item);
        }

        public void ShowAll()
        {
            foreach (var item in _listFigure)
            {
                Console.Write($"{item.GetType()}");
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} CountFigure: {_listFigure.Count()}";
        }
    }
}

