using Backupper.BLL;
using Backupper.BLL.Watcher;
using Backupper.BLL.WatcherEvent;
using Backupper.Common.Dependencies;
using System;

namespace Backupper.PLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {

                var fileslogic = DependenciesResolver.FilesLogic;

                var a = fileslogic.GetDirectory();

                RunWatcherLogic runner = new RunWatcherLogic(a);

                HandlerEvent MyE = new HandlerEvent();

                runner.Run(MyE);

                if (int.TryParse(Console.ReadLine(), out int x))
                {
                    MyE.StartEvent();
                }
                Console.ReadLine();
            }
           
        }
    }
}
