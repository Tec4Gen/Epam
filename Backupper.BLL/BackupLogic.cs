using System;
using System.Collections.Generic;
using System.IO;
using Backupper.BLL.Interface;
using Backupper.Common.TypeMessage;
using Backupper.DAL;
using Backupper.DAL.Interface;
using Backupper.PLConsole;

namespace Backupper.BLL.BackupLog
{
    public class BackupLogic: IBackupLogic
    {
        private IBackupDao _backuoDao;
        public BackupLogic(IBackupDao backuoDao)
        {
            _backuoDao = backuoDao;
        }

        public DirectoryInfo GetBbackUpDirectory()
        {
            try
            {
                return _backuoDao.GetBbackUpDirectory();
            }
            catch (Exception ex)
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
           
        }

        public IEnumerable<FileInfo> GetAllArchive()
        {
            try
            {
                return _backuoDao.GetAllArchive();
            }
            catch (Exception)
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
           
        }

        public void CreateBackup(IEnumerable<string> loglist)
        {
            try
            {
                _backuoDao.CreateArchive(loglist);
                Response.Result(TypeMessage.Successful);
            }
            catch 
            {
                Response.Result(TypeMessage.Error);
            }
           
        }

        public void RestoreVersion(string versionName)
        {
            try
            {
               _backuoDao.RestoreVersion(versionName);
                Response.Result(TypeMessage.Successful);
            }
            catch
            {
                Response.Result(TypeMessage.Error);
                return;
            }
        }
    }
}
