using Backupper.BLL.Interface;
using Backupper.DAL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.BLL
{
    public class BackupLogic: IBackupLogic
    {
        private IBackupDao _backupDao;
        
        public BackupLogic(IBackupDao backupDao)
        {
            _backupDao = backupDao;
        }
        public IEnumerable<FileInfo> GetBackUpFolder()
        {
            throw new NotImplementedException();
        }

        public DirectoryInfo GetBbackUpDirectory()
        {
            throw new NotImplementedException();
        }
    }
}
