using Backupper.BLL.Interface;
using Backupper.BLL.Watcher.Interface;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backupper.BLL.Watcher
{
    public class WatcherLogic : IWatcherLogic
    {
        #region Fields
        private static DirectoryInfo _rootFolder { get; set; }
        private static List<string> _logList { get; set; }
        public static string _logMessage { get; set; }

        private IHandlerEvent _eventUI { get; set; }

        private IBackupLogic _backupLogic;
        private bool Flag { get; set; } = true;


      
        #endregion

        #region constructor
        public WatcherLogic(DirectoryInfo path, IHandlerEvent handler, List<string> listlog)
        {
            if (path == null)
                // TODO:
                throw new ArgumentNullException();
            _eventUI = handler;

            _rootFolder = path;

            _logList = listlog;

            _backupLogic = DependenciesResolver.BackupLogic;
        }

        #endregion

        #region main Non-Static Methods
        public async void Run()
        {
            _eventUI.OnEvent += Cancel;
             await Task.Run(() => Watcher());
        }

        private void Cancel()
        {
            Flag = false;
            _eventUI.OnEvent -= Cancel;
        }

        private void Watcher()
        {

            using (FileSystemWatcher watcher = new FileSystemWatcher(_rootFolder.FullName))
            {
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

                watcher.Filter = @"*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                Console.WriteLine("Press 'q' to quit the sample.");

                while (Flag) ;

                _backupLogic.CreateBackup(_logList);
                
                Console.WriteLine("Я умер");

            }
        }

        #endregion

        #region Static Methods
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            _logMessage = PathFormatting(new Uri(e.FullPath), new Uri(_rootFolder.FullName));

            _logList.Add($"File: {_logMessage} => {e.ChangeType}");

            Console.WriteLine(_logList.Last());

        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            _logMessage = PathFormatting(new Uri(e.FullPath), new Uri(_rootFolder.FullName));

            _logList.Add($"File: {_logMessage} => {e.ChangeType}");

            Console.WriteLine(_logList.Last());
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            _logMessage = PathFormatting(new Uri(e.FullPath), new Uri(_rootFolder.FullName));

            _logList.Add($"File: {_logMessage} => {e.ChangeType}");

            Console.WriteLine(_logList.Last());
        }

        private static string PathFormatting(Uri fileUri, Uri rootUri)
        {
            return Uri.UnescapeDataString(rootUri.MakeRelativeUri(fileUri).ToString());
        }
        #endregion

    }
}

