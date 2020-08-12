using BackUpper.BLL.WatcherEvent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper.BLL.WatcherEvent
{
    public class HandlerEvent : IHandlerEvent
    {
        public event Action OnEvent = delegate { };

        public void StartEvent() 
        {
            OnEvent.Invoke();
        }
    }
}
