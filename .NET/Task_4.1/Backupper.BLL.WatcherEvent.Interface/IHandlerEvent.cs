using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpper.BLL.WatcherEvent
{
    public interface IHandlerEvent
    {
        event Action OnEvent;

        void StartEvent();
    }
}
