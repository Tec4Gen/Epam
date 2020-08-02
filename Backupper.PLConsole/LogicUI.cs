using Backupper.BLL.Interface;
using Backupper.BLL.Watcher;
using Backupper.BLL.Watcher.Interface;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Backupper.PLConsole
{
    public class LogicUI
    {
        private IFilesLogic _filesLogic;
        private IBackupLogic _backupLogic;
        private IHandlerEvent _handlerEvent;

        private IWatcherLogic _watcherLogic;
        private List<string> _listLog;

        public LogicUI()
        {
            _filesLogic = DependenciesResolver.FilesLogic;
            _backupLogic = DependenciesResolver.BackupLogic;
            _handlerEvent = DependenciesResolver.HandlerEvent;

            _listLog = new List<string>();
        }

        public void Run()
        {
            bool flag = true;
            int choose;

            while (flag)
            {

                Console.Write(Environment.NewLine +
                              "1) Tracking mode" +
                              Environment.NewLine +
                              "2) Recovery mode" +
                              Environment.NewLine +
                              "3) Exit" +
                              Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Select mode: =>");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            var pathDirectory = _filesLogic.GetDirectory();
                            if (pathDirectory == null)
                            {
                                break;
                            }

                            _watcherLogic = new WatcherLogic(pathDirectory, _handlerEvent, _listLog);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Traking mode run" +
                                Environment.NewLine +
                                "Enter STOP to get out of the mode");
                            Console.ResetColor();

                            _watcherLogic.Run();
                            while (true)
                            {
                                if (Console.ReadLine() == "STOP")
                                {
                                    _handlerEvent.StartEvent();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Is not STOP, try again ");
                                    Console.ResetColor();
                                }
                            }

                            Thread.Sleep(100);

                            break;
                        case 2:
                            var backUp = _backupLogic.GetAllArchive();

                            if (backUp == null)
                            {
                                break;
                            }

                            var backUpList = backUp.ToList();
                            for (int i = 0; i < backUpList.Count(); i++)
                            {
                                Console.Write($"{i}){backUpList[i].Name}{Environment.NewLine}");
                            }
                            Console.WriteLine();
                            Console.Write("Select version =>");

                            if (int.TryParse(Console.ReadLine(), out choose))
                            {
                                if (choose >= 0 && choose < backUpList.Count())
                                {

                                    _backupLogic.RestoreVersion(backUpList[choose].Name);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choose from what is! Try again");
                                    Console.ResetColor();
                                }
                            }

                            break;
                        case 3:
                            Console.Write("Darkness covers my eyes P.S Arthas");
                            Thread.Sleep(2000);
                            return;

                        default:
                            Console.WriteLine("TryAgain");
                            break;
                    }
                }
            }
        }
    }
}
