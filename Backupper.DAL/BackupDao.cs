using Backupper.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.DAL
{
    public class BackupDao : IBackupDao
    {
        private string _backupDirectory = ConfigurationManager.AppSettings.Get("BackupDirectory"); //["SourceDirectory"];
        private string _sourceDirectory = ConfigurationManager.AppSettings.Get("SourceDirectory"); //["SourceDirectory"];
        public DirectoryInfo GetBbackUpDirectory()
        {
            try
            {
                return new DirectoryInfo(_backupDirectory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<FileInfo> GetAllArchive()
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

        public void CreateArchive(IEnumerable<string> logList) 
        {
            string ZipArchiveName = Path.Combine(_backupDirectory, $"BackUp {DateTime.Now.ToString("dd_MMMM_yyyy HH_mm_ss")}.zip");
           
            ZipFile.CreateFromDirectory(_sourceDirectory, Path.Combine(_backupDirectory, ZipArchiveName), CompressionLevel.Optimal, true, Encoding.UTF8);

            using (FileStream zipToOpen = new FileStream(ZipArchiveName, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry("Log.txt");
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.Write("Logging." +
                            Environment.NewLine +
                            new String('=',40) +
                            Environment.NewLine);

                        foreach (var item in logList)
                        {
                            writer.WriteLine(item);
                        }
                        writer.Write(new String('=', 40));
                    }
                }
            }
        }
    }
}
