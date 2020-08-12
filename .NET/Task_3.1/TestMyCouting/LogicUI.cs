using ProgramDieOrDie.IOStream;
using ProgramDieOrDie.Logic;
using System.Configuration;

namespace TestMyCouting
{
    public static class LogicUI
    {
        public static void Go(int number) 
        {
            var connection = ConfigurationManager.ConnectionStrings["PersonData"].ConnectionString;

            var Collection = ReaderPerson.Read(connection);

            var Obj = new GameDieOrDie(Collection);

            Obj.Play(number);
        }
    }
}
