using Backupper.BLL.Interface;
using Backupper.BLL.Watcher;
using Backupper.BLL.Watcher.Interface;
using Backupper.BLL.WatcherEvent;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System.Collections.Generic;

namespace Backupper.PLConsole
{
    public class LogicUI
    {
        private IFilesLogic _filesLogic;
        private IBackupLogic _backupLogic;
        private IHandlerEvent _handlerEvent;

        private IWatcherLogic _watcherLogic;
        private List<string> ListLog;

        public LogicUI()
        {
            _filesLogic = DependenciesResolver.FilesLogic;
            _backupLogic = DependenciesResolver.BackupLogic;
            _handlerEvent = DependenciesResolver.HandlerEvent;

            ListLog = new List<string>();
        }
        public void Run() 
        {
            var pathDirectory = _filesLogic.GetDirectory();

            
            _watcherLogic = new WatcherLogic(pathDirectory, _handlerEvent, ListLog);

            while (true)
            {
                switch (switch_on)
                {
                    default:
                }
            }
            
        }
    }
}
