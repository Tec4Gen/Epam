using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.BLL.Interface
{
    public interface IFilesLogic
    {
        DirectoryInfo GetDirectory();

        IEnumerable<FileInfo> GetFiles();
    }
}
