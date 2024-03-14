
using DotnetTask.Context;
using DotnetTask.Model;
using DotnetTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Xml.Linq;

namespace DotnetTask.Services
{
    public class TaskService : ITask
    {
        private MyDbContext ctx;
        public TaskService(MyDbContext ctx) 
        {
            this.ctx = ctx;
        }

        public async Task<MyTask> CreateTask(MyTask task)
        {
            if (task == null)
            {
                throw new Exception();
            }

            ctx.Tasks.Add(task);
            await ctx.SaveChangesAsync();

            return task;
        }
        public async Task<string> DeleteTask(int id)
        {
            if(id==null)
            {
                throw new Exception();
            }
            MyTask task=await GetTask(id);
            ctx.Tasks.Remove(task);
            ctx.SaveChangesAsync();
            return "Data Deleted Successfully!!!";
        }
        
        private List<MyTask> allTasks;

        public async Task<List<MyTask>> GetAllTasks()
        {
            await Task.Run(() =>
            {
                allTasks = ctx.Tasks.ToList();
            });
            return allTasks;

        }

        public async Task<MyTask> GetTask(int id)
        {
            MyTask task = await ctx.Tasks.FirstOrDefaultAsync(val => val.TaskId == id);
            if (task == null)
            {
                throw new Exception();
            }
            return task;
        }


        public async Task<MyTask> UpdateTask(MyTask task)
        {
            if(task==null)
            {
                throw new Exception();
            }
            
            ctx.Tasks.Update(task);
            await ctx.SaveChangesAsync();
            return task;
        }

      
    }
}
