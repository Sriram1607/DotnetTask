using DotnetTask.Model;
using Microsoft.EntityFrameworkCore;

namespace DotnetTask.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        public DbSet<MyTask> Tasks { get; set; }
    }
}
