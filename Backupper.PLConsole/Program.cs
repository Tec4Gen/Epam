using Backupper.BLL;
using Backupper.BLL.Watcher;
using Backupper.BLL.WatcherEvent;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Backupper.PLConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            var fileslogic = DependenciesResolver.FilesLogic;
            var Backuplogic = DependenciesResolver.BackupLogic;
            var a = fileslogic.GetDirectory();

            var ListLog = new List<string>();

            IHandlerEvent MyE = new HandlerEvent();
            WatcherLogic runner;


            Console.WriteLine("1 or 2");
            int.TryParse(Console.ReadLine(), out int x);



            switch (x)
            {
                case 1:
                    runner = new WatcherLogic(a, MyE, ListLog);
                    runner.Run();
                    Console.WriteLine("Enter exitt 1");

                    if (int.TryParse(Console.ReadLine(), out int y))
                    {
                        MyE.StartEvent();
                    }
                Console.Read();
                    break;
                case 2:
                    Backuplogic.RestoreVersion("BackUp 01_August_2020 22_34_55.zip");
                    break;
            }

            
        }
    }
}
