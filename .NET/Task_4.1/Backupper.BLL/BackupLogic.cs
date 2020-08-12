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
           
            var backUp = _backuoDao.GetBbackUpDirectory();
            if (backUp == null) 
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
                    

           return backUp;
            
           
        }

        public IEnumerable<FileInfo> GetAllArchive()
        {
            var backUp = _backuoDao.GetAllArchive();
            if (backUp == null)
            {
                Response.Result(TypeMessage.Error);
                return null;
            }
            return backUp;

        }

        public void CreateBackup(IList<string> loglist)
        {
            try
            {
                if (loglist.Count > 0)
                {
                    _backuoDao.CreateArchive(loglist);
                    Response.Result(TypeMessage.BackupСreated);
                }
                else 
                {
                    Response.Result(TypeMessage.NoBackupСreated);
                }
               
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
            catch (InvalidDataException) 
            {
                Response.Result(TypeMessage.DataError);
                return;
            }
            catch
            {
                Response.Result(TypeMessage.Error);
                return;
            }
        }
    }
}
