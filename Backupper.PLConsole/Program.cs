using Backupper.BLL;
using Backupper.BLL.Watcher;
using Backupper.BLL.WatcherEvent;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;

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

                var ListLog = new List<string>();

                IHandlerEvent MyE = new HandlerEvent();
                WatcherLogic runner = new WatcherLogic(a, MyE, ListLog);

                runner.Run();

                if (int.TryParse(Console.ReadLine(), out int x))
                {
                    MyE.StartEvent();
                }


                Console.ReadLine();
            }
           
        }
    }
}
