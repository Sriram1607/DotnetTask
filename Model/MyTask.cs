﻿namespace DotnetTask.Model
{
    public enum Status
    {  
            Pending,
            Completed 
    }

    public class MyTask
    {
        public int Id { get; set; } 
        public string Title {  get; set; }
        public string Description { get; set; }
        public Status GetStatus { get; set; }
    }
}
