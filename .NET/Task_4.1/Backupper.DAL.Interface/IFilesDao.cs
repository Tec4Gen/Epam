using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.DAL.Interface
{
    public interface IFilesDao
    {
        DirectoryInfo GetDirectory();

        IEnumerable<FileInfo> GetFiles();
    }
}
