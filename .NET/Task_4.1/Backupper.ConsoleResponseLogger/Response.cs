using Backupper.Common.TypeMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.PLConsole
{
    public static class Response
    {
        public static void Result(TypeMessage type)
        {
           
            switch (type)
            {  
                case TypeMessage.None:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The action is not selected");
                    break;
                case TypeMessage.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Path not found" + 
                                    Environment.NewLine + 
                                    "Check paths and try again");
                    break;
                case TypeMessage.DataError:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The backup is damaged, recovery is not possible");
                    break;
                case TypeMessage.BackupСreated:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Backup created");
                    Console.WriteLine("The operation is performed");                 
                    break;
                case TypeMessage.NoBackupСreated:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("There were no changes, Backup no created");
                    Console.WriteLine("The operation is performed");
                    break;
                case TypeMessage.Successful:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The operation is performed");
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }
    }
}
