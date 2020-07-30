using Backupper.Common.TypeMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.PLConsole
{
    public static class ResponseLogger
    {
        public static void Result(TypeMessage type)
        {
            switch (type)
            {
                case TypeMessage.None:
                    Console.WriteLine("Действие не выбрано");
                    break;
                case TypeMessage.Error:
                    Console.WriteLine("Ошибка");
                    break;
                case TypeMessage.Successful:
                    Console.WriteLine("Резервная копия успешно сделана");
                    break;
                default:
                    break;
            }
        }
    }
}
