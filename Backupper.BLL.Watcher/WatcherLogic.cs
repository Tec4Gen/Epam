using Backupper.BLL.Watcher.Interface;
using Backupper.BLL.WatcherEvent;
using System;
using System.IO;
using System.Threading;

namespace Backupper.BLL.Watcher
{
    sealed class WatcherLogic : IWatcherLogic
    {
        private string _watchedFolder { get; set; }

        public bool Flag { get; set; } = true;
        public HandlerEvent EventUI { get; set; }
        public WatcherLogic(string path, HandlerEvent handler)
        {
            if (path == null)
                // TODO:
                throw new ArgumentNullException();
            EventUI = handler;
            _watchedFolder = path;
        }

        public void Run()
        {
            EventUI.OnEvent += Cancel;
            Watcher();
        }
        private void Cancel()
        {   
            Flag = false;
            EventUI.OnEvent -= Cancel;
        }

        private void Watcher()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(_watchedFolder))
            {
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

                watcher.Filter = @"*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDelete;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;

                Console.WriteLine("Press 'q' to quit the sample.");

                while (Flag)
                {

                }

                Console.WriteLine("Я умер");
            }
        }



        private static void OnChanged(object source, FileSystemEventArgs e) =>
             // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        private static void OnCreated(object source, FileSystemEventArgs e) =>
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        private static void OnDelete(object source, FileSystemEventArgs e) =>
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");


    }
}

