using System.Collections.Generic;
using System.IO;

namespace Backupper.DAL.Interface
{
    public interface IBackupDao
    {
        DirectoryInfo GetBbackUpDirectory();

        IEnumerable<FileInfo> GetAllArchive();

        void CreateArchive(IEnumerable<string> logList);

        void RestoreVersion(string versionName); 
    }
}
