using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.DAL.Interface
{
    public interface IBackupDao
    {
        DirectoryInfo GetBbackUpDirectory();

        IEnumerable<FileInfo> GetBackUpFolder();
    }
}
