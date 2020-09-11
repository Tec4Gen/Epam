using Epam.Achievement.Entities;
using Epam.Achievement.FakeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Acvievement.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ClientDao();
            var b = new AwardDao();
            var c = new ClientAwardDao();

            a.Add(new Client
            {
                Name = "Ivan",
                Age = 21,
                DataOfBirth = new DateTime()
            });

            a.Add(new Client
            {
                Name = "Alex",
                Age = 22,
                DataOfBirth = new DateTime()
            });


            b.Add(new Award 
            {
                Title = "This is DarkSolus",
            });

            b.Add(new Award
            {
                Title = "Praise the sun",
            });

            c.Add(1,1);

            c.Add(0,1);
        }
    }
}
