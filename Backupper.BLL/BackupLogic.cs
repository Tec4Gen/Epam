using System.Collections.Generic;
using System.IO;
using Backupper.BLL.Interface;
using Backupper.DAL;
using Backupper.DAL.Interface;

namespace Backupper.BLL.BackupLog
{
    public class BackupLogic: IBackupLogic
    {
        private IBackupDao _backuoDao;
        public BackupLogic(IBackupDao backuoDao)
        {
            _backuoDao = backuoDao;
        }

        public DirectoryInfo GetBbackUpDirectory()
        {
            return _backuoDao.GetBbackUpDirectory();
        }

        public IEnumerable<FileInfo> GetAllArchive()
        {
            return _backuoDao.GetAllArchive();
        }

        public void CreateBackup(IEnumerable<string> loglist)
        {
            _backuoDao.CreateArchive(loglist);
        }

        public bool RestoreVersion(string versionName)
        {
            return _backuoDao.RestoreVersion(versionName);
        }
    }
}
