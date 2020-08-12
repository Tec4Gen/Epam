using Backupper.BLL.Interface;
using Backupper.Common.TypeMessage;
using Backupper.DAL.Interface;
using Backupper.PLConsole;
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
            var source = _folderPath.GetDirectory();
            if (source == null)
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
            return source;
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            try
            {
                return _folderPath.GetFiles();
            }
            catch
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
        }
    }
}
