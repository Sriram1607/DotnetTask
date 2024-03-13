
using DotnetTask.Context;
using DotnetTask.Model;
using DotnetTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

        public MyTask CreateTask(MyTask task)
        {
            if(task==null)
            {
                throw new Exception();
            }
            ctx.Tasks.Add(task);
            ctx.SaveChanges();
            return task;
        }
        public string DeleteTask(int id)
        {
            if(id==null)
            {
                throw new Exception();
            }
            MyTask task=GetTask(id);
            ctx.Tasks.Remove(task);
            ctx.SaveChanges();
            return "Data Deleted Successfully!!!";
        }

        public List<MyTask> GetAlltasks()
        {
            List<MyTask> AllTasks=ctx.Tasks.ToList();
            return AllTasks;
        }

        public MyTask GetTask(int id)
        {
            MyTask task = ctx.Tasks.Where(val => val.TaskId == id).FirstOrDefault();
            if (task==null)
            {
                throw new Exception();
            }
            return task;
        }

        
        public MyTask UpdateTask(MyTask task)
        {
            if(task==null)
            {
                throw new Exception();
            }
            
            ctx.Tasks.Update(task);
            ctx.SaveChanges();
            return task;
        }
    }
}
