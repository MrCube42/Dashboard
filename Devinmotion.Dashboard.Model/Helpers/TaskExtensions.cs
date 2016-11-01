using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Devinmotion.Dashboard.Model.Helpers
{
    public static class TaskExtensions
    {
        public static Task ContinueIn<T>(this Task<T> task, Action<Task<T>> continuationAction, Dispatcher dispatcher)
        {
            return task.ContinueWith(t => dispatcher.Invoke(() => continuationAction(task)));
        }
    }
}
