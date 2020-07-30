using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backupper.BLL.BackupLog.Interface;
using Backupper.Common.TypeMessage;
using Backupper.DAL;

namespace Backupper.BLL.BackupLog
{
    public class BackupLogic: IBackupLogic
    {
        private IEnumerable<string> _LogList { get; }

        private BackupDao _backuoDao;
        public BackupLogic(IEnumerable<string> loglist)
        {
            _LogList = new List<string>(loglist);
            _backuoDao = new BackupDao();
        }

        public DirectoryInfo GetBbackUpDirectory()
        {
            return _backuoDao.GetBbackUpDirectory();
        }

        public IEnumerable<FileInfo> GetAllArchive()
        {
            return _backuoDao.GetAllArchive();
        }

        public void CreateArchive()
        {
            _backuoDao.CreateArchive(_LogList);
        }
    }
}
