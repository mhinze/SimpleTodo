using System.Data.Entity;

namespace SimpleTodo.Models
{
    public class Context : DbContext
    {
        public DbSet<LogOnModel> Users { get; set; }
        public DbSet<TodoItem> TodoList { get; set; }
    }
}