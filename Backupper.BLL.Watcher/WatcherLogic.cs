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
        private static IList<string> _logList { get; set; }
        public static string _logMessage { get; set; }

        private IHandlerEvent _handlerEvent { get; set; }

        private IBackupLogic _backupLogic;
        private bool Flag { get; set; } = true;

        #endregion

        #region constructor
        public WatcherLogic(DirectoryInfo path, IHandlerEvent handler, List<string> listlog)
        {
            if (path == null || listlog == null)
                throw new ArgumentNullException("Argumet cannot null");
            if (listlog.Count() > 0)
                throw new ArgumentException("Cannot be greater than zero");
            
            _handlerEvent = handler;

            _rootFolder = path;

            _logList = listlog;

            _backupLogic = DependenciesResolver.BackupLogic;
        }

        #endregion

        #region main Non-Static Methods
        public async void Run()
        {
            _handlerEvent.OnEvent += Cancel;
             await Task.Run(() => Watcher());
        }

        private void Cancel()
        {
            Flag = false;
            _handlerEvent.OnEvent -= Cancel;
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

