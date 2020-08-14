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
            if (Directory.Exists(_sourceDirectory)) 
            {
                return new DirectoryInfo(_sourceDirectory);
            }
            return null;    
        }

        public IEnumerable<FileInfo> GetFiles()
        {

            try
            {
                return GetDirectory().GetFiles("*.txt");

            }
            catch
            {
                throw new DirectoryNotFoundException("Path Not Found");
            }

        }
    }
}
