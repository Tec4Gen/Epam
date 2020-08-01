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
                    Console.WriteLine("The action is not selected");
                    break;
                case TypeMessage.Error:
                    Console.WriteLine("Path not found");
                    break;
                case TypeMessage.Successful:
                    Console.WriteLine("The operation is performed");
                    break;
                default:
                    break;
            }
        }
    }
}
