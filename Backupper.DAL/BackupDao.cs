using Backupper.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.DAL
{
    public class BackupDao : IBackupDao
    {
        private string _sourceDirectory = ConfigurationManager.AppSettings.Get("SourceDirectory"); //["SourceDirectory"];
        public DirectoryInfo GetBbackUpDirectory()
        {
            try
            {
                return new DirectoryInfo(_sourceDirectory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<FileInfo> GetBackUpFolder()
        {
            try
            { 
                return GetBbackUpDirectory().GetFiles("*.rar");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
