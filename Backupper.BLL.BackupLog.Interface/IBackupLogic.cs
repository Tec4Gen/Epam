using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.BLL.BackupLog.Interface
{
    public interface IBackupLogic
    {
        DirectoryInfo GetBbackUpDirectory();

        IEnumerable<FileInfo> GetAllArchive();

        void CreateArchive();
    }
}
