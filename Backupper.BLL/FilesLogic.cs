using Backupper.BLL.Interface;
using Backupper.DAL.Interface;
using System.Collections.Generic;
using System.IO;

namespace Backupper.BLL
{
    public class FilesLogic : IFilesLogic
    {
        private IFilesDao _folderPath;

        public FilesLogic(IFilesDao folderPath)
        {
            _folderPath = folderPath;
        }

        public DirectoryInfo GetDirectory()
        {
            return _folderPath.GetDirectory();
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            return _folderPath.GetFiles();
        }
    }
}
