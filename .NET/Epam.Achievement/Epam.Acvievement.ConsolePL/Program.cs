using Epam.Achievement.Entities;
using Epam.Achievement.Ioc;
using System;


namespace Epam.Acvievement.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = DependenciesResolver.ClientLogic;
            var b = DependenciesResolver.AwardLogic;
            var c = DependenciesResolver.ClientWaradLogic;

            a.Add(new Client
            {
                Id = 0 ,
                Name = "Ivan",
                Age = 21,
                DataOfBirth = new DateTime()
            });

            a.Add(new Client
            {
                Id = 1,
                Name = "Alex",
                Age = 22,
                DataOfBirth = new DateTime()
            });

            a.Add(new Client
            {
                Id = 2,
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
