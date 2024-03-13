
using DotnetTask.Context;
using DotnetTask.Model;
using Microsoft.AspNetCore.Mvc;
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
            if(task==null)
            {
                throw new Exception();
            }
            ctx.Tasks.Add(task);
            ctx.SaveChangesAsync();
            return task;
        }

        public async Task<string> DeleteTask(int id)
        {
            if(id==null)
            {
                throw new Exception();
            }
            MyTask task=GetTask(id);
            ctx.Tasks.Remove(task);
            ctx.SaveChangesAsync();
            return "Data Deleted Successfully!!!";
        }

        public List<MyTask> GetAlltasks()
        {
            List<MyTask> AllTasks=ctx.Tasks.ToList();
            return AllTasks;
        }

        public MyTask GetTask(int id)
        {
            MyTask task = ctx.Tasks.Where(val => val.Id == id).FirstOrDefault();
            if (task==null)
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
            MyTask task1=GetTask(task.Id);
            task1.Title=task.Title;
            task1.Description=task.Description; 
            task1.GetStatus=task.GetStatus;
            ctx.Tasks.Update(task1);
            ctx.SaveChangesAsync();
            return task1;
        }
    }
}
