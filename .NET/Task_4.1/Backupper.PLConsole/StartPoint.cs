using Backupper.BLL;
using Backupper.BLL.Watcher;
using Backupper.BLL.WatcherEvent;
using Backupper.Common.Dependencies;
using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Backupper.PLConsole
{
    class StartPoint
    {

        static void Main(string[] args)
        {



            LogicUI a = new LogicUI();
            a.Run();


        }
    }
}
