using DotnetTask.Model;
using DotnetTask.ViewModel;
using System.Runtime.InteropServices;

namespace DotnetTask.Services
{
    public interface ITask
    {
        Task<MyTask> CreateTask(MyTask task);
        Task<List<MyTask>> GetAllTasks();

        Task<MyTask> GetTask(int id);
        Task<MyTask> UpdateTask(MyTask task);
        Task<string> DeleteTask(int id);
    }
}
