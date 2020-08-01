using Backupper.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Backupper.DAL
{
    public class FilesDao : IFilesDao
    {
        private string _sourceDirectory = ConfigurationManager.AppSettings.Get("SourceDirectory"); //["SourceDirectory"];

        public DirectoryInfo GetDirectory()
        {
            try
            {
                return new DirectoryInfo(_sourceDirectory);
            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<FileInfo> GetFiles()
        {

            try
            {
                return GetDirectory().GetFiles("*.txt");

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
