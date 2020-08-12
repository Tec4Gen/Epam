using ProgramDieOrDie.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramDieOrDie.Logic
{
    public class GameDieOrDie : IGameDiOrDie
    {
        public List<Person> ListPlayer { get; private set; }

        public GameDieOrDie(List<Person> listPlayer)
        {
            if (listPlayer == null)
                throw new ArgumentNullException();

            if (listPlayer.Count == 0)
                throw new ArgumentException();

            ListPlayer = new List<Person>(listPlayer.Count());

            foreach (var item in listPlayer)
            {
                ListPlayer.Add((Person)item.Clone());
            }

           
        }
        public void Show() 
        {
            if (ListPlayer.Count() == 0) 
            {
                Console.WriteLine("List is empty");
                return;
            }

            foreach (var item in ListPlayer)
            {
                Console.Write(item + Environment.NewLine);
            }
        }
        public void Play(int number) 
        {
            if (number > ListPlayer.Count())
                throw new ArgumentException("Argument - number", "The number is greater than the number of players");

            if (number <= 1) 
            {
                //??? exeption?
                Console.WriteLine("You can't start the game");
                return;
            }


            bool play = true;
            int count = 1;

            int countRaunds = 1;

            while (play)
            {
                for (int i = 0; i < ListPlayer.Count(); i++)
                {
                    if (number > ListPlayer.Count()) 
                    {
                        play = false;
                        Console.Write(new String('*', 20) + Environment.NewLine);    
                        Console.Write("Game over, winners: " + Environment.NewLine);
                        Console.Write(new String('*', 20) + Environment.NewLine);

                        Show();

                        break;
                    }
                    if (count % number == 0) 
                    {

                        Console.WriteLine($"Raund: {countRaunds++} leave: {ListPlayer[i]}| игроков осталось {ListPlayer.Count()}"+ Environment.NewLine);
                        ListPlayer.RemoveAt(i);
                        i--;
                    }
                    count++;
                }
            }
        }
    }
}
