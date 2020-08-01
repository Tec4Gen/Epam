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

namespace Backupper.PLConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
             //string _backupDirectory = ConfigurationManager.AppSettings.Get("BackupDirectory");
             //string _sourceDirectory = ConfigurationManager.AppSettings.Get("SourceDirectory");
            while (true) 
            {

                var fileslogic = DependenciesResolver.FilesLogic;
                var Backuplogic = DependenciesResolver.BackupLogic;
                var a = fileslogic.GetDirectory();

                var ListLog = new List<string>();

                IHandlerEvent MyE = new HandlerEvent();
                WatcherLogic runner = new WatcherLogic(a, MyE, ListLog);

                runner.Run();


                if (int.TryParse(Console.ReadLine(), out int x))
                {
                    MyE.StartEvent();
                }

                Backuplogic.RestoreVersion("BackUp 01_August_2020 11_25_55.zip");
                Console.ReadLine();

                //using (var zip = ZipFile.Open(Path.Combine(_backupDirectory, "BackUp 01_August_2020 11_25_55.zip"), ZipArchiveMode.Read))
                //{
                //    foreach (ZipArchiveEntry file in zip.Entries)
                //    {
                //        //пропущено тело цикла
                //        //ignoredFilenames - массив игнорируемых файлов
                //        file.ExtractToFile(_sourceDirectory, true);
                //    }
                //}
            }
           
        }
    }
}
