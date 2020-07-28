using Backupper.BLL.WatcherEvent;

namespace Backupper.BLL.Watcher.Interface
{
    public interface IRunWatcherLogic
    {
        void Run(HandlerEvent handler);
    }
}
