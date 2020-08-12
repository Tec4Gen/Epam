using Backupper.BLL;
using Backupper.BLL.BackupLog;
using Backupper.BLL.Interface;
using Backupper.BLL.Watcher.Interface;
using Backupper.BLL.WatcherEvent;
using Backupper.DAL;
using Backupper.DAL.Interface;
using BackUpper.BLL.WatcherEvent;

namespace Backupper.Common.Dependencies
{
    public static class DependenciesResolver
    {
        private static IFilesDao _filesDao { get; set; } = new FilesDao();

        public static IFilesLogic FilesLogic { get; set; } = new FilesLogic(_filesDao);

        private static IBackupDao _backupDao { get; set; } = new BackupDao();

        public static IBackupLogic BackupLogic { get; set; } = new BackupLogic(_backupDao);

        public static IHandlerEvent HandlerEvent { get; set; } = new HandlerEvent();

    }

}
/*
private static IFilesDao _filesDao;
public static IFilesDao FilesDao => _filesDao ?? (_filesDao = new FilesDao());

private static IFilesLogic _filesLogic;
public static IFilesLogic FilesLogic => _filesLogic ?? (_filesLogic = new FilesLogic(_filesDao));


private static IBackupDao _backupDao;
public static IBackupDao BackupDao => _backupDao ?? (_backupDao = new BackupDao());

private static IBackupLogic _backupLogic;
public static IBackupLogic BackupLogic => _backupLogic ?? (_backupLogic = new BackupLogic(_backupDao));
*/

