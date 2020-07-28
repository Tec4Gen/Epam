using Backupper.BLL.Watcher.Interface;
using Backupper.BLL.WatcherEvent;
using System.IO;

namespace Backupper.BLL.Watcher
{
    public class RunWatcherLogic : IRunWatcherLogic
    {
        DirectoryInfo _watcherDirectory;

        public RunWatcherLogic(DirectoryInfo watcherDirectory)
        {
            _watcherDirectory = watcherDirectory;
        }
        public void Run(HandlerEvent handler)
        {

            var watcher = new WatcherLogic(_watcherDirectory.FullName, handler);

            watcher.Run();
        }
    }
}

#region Просто Дичайший фейл
/*
public void Run(HandlerEvent handler)
{

    List<WatcherLogic> listWatchers = new List<WatcherLogic>();
    List<Task> listTasks = new List<Task>();

    listWatchers.Add(new WatcherLogic(_watcherDirectory.FullName, handler));

    foreach (var item in _watcherDirectory.GetDirectories())
    {
        listWatchers.Add(new WatcherLogic(item.FullName, handler));
    }

    for (int i = 0; i < listWatchers.Count(); i++)
    {
        listTasks.Add(new Task(listWatchers[i].Run));
        listTasks[i].Start();
    }

    Task tasks = Task.WhenAll(listTasks);

}
*/
#endregion