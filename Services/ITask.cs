using DotnetTask.Model;
using DotnetTask.ViewModel;
using System.Runtime.InteropServices;

namespace DotnetTask.Services
{
    public interface ITask
    {
        MyTask CreateTask(MyTask task);
        List<MyTask> GetAlltasks();

        MyTask GetTask(int id);
        MyTask UpdateTask(MyTask task);
        string DeleteTask(int id);
    }
}
