using System.Collections.Generic;
using System.IO;

namespace Backupper.BLL.Interface
{
    public interface IBackupLogic
    {
        DirectoryInfo GetBbackUpDirectory();

        IEnumerable<FileInfo> GetAllArchive();

        void CreateBackup(IEnumerable<string>  loglist);
        bool RestoreVersion(string versionName);
    }
}
