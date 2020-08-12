using Backupper.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace Backupper.DAL
{
    public class BackupDao : IBackupDao
    {
        private string _backupDirectory = ConfigurationManager.AppSettings.Get("BackupDirectory");
        private string _sourceDirectory = ConfigurationManager.AppSettings.Get("SourceDirectory");
        public DirectoryInfo GetBbackUpDirectory()
        {
            if (Directory.Exists(_backupDirectory))
            {
                return new DirectoryInfo(_backupDirectory);
            }
            return null;
        }

        public IEnumerable<FileInfo> GetAllArchive()
        {
            var backup = GetBbackUpDirectory();

            if (backup==null) 
            {
                return null;
            }
            return GetBbackUpDirectory().GetFiles("*.zip");
        
            
        }

        public void CreateArchive(IEnumerable<string> logList)
        {
            string time = $"{DateTime.Now.ToString("dd_MMMM_yyyy HH_mm_ss")}";

            string ZipArchiveName = Path.Combine(_backupDirectory, $"BackUp {time}.zip");
            try
            {
                ZipFile.CreateFromDirectory(_sourceDirectory,
                                            Path.Combine(_backupDirectory, ZipArchiveName), 
                                            CompressionLevel.Optimal, 
                                            true, 
                                            Encoding.UTF8);

                using (FileStream zipToOpen = new FileStream(ZipArchiveName, FileMode.Open))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                    {
                        ZipArchiveEntry readmeEntry = archive.CreateEntry($"Log_{time}.txt");
                        using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                        {
                            writer.Write("Logging." +
                                Environment.NewLine +
                                new String('=', 40) +
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
            catch
            {
                throw new DirectoryNotFoundException("Path Not Found");
            }
            
        }
        public void RestoreVersion(string versionName)
        {
            using (var zip = ZipFile.Open(Path.Combine(_backupDirectory, versionName), ZipArchiveMode.Update))
            {
                try
                {
                    var sourceFolder = new DirectoryInfo(_sourceDirectory);
                    string nameFolder = sourceFolder.Name;
                    string root = $"{_sourceDirectory.Replace(nameFolder, "")}";
                    Directory.Delete(sourceFolder.FullName, true);

                    zip.ExtractToDirectory(root);

                    File.Delete(Path.Combine(root, zip.Entries.LastOrDefault().Name));
                }
                catch (InvalidDataException) 
                {
                    throw;
                }
                catch
                {
                    throw new DirectoryNotFoundException("Path Not Found");
                }
            }
        }
    }
}