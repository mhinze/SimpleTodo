using System;
using System.Data.Entity;
using System.Linq;
using SimpleTodo.Migrations;

namespace SimpleTodo.Models
{
    public class Context : DbContext
    {
        
        public DbSet<LogOnModel> Users { get; set; }

        public int SelectedTodo { get; set; }
        public DbSet<TodoItem> List { get; set; }

        public IQueryable<TodoItem> GetTodos()
        {
            return List.Where(c => c.Status == "Todo");
        }

        public TodoItem GetDoing()
        {
            var inprogresscount = List.Count(c => c.Status == "Doing");
            switch (inprogresscount)
            {
                case 0:
                    return null;
                case 1:
                    return List.First(c => c.Status == "Doing");
                default:
                    throw new Exception(String.Format("There are {0} items in progress. Please fix this.", inprogresscount));
            }
        }

        public TodoItem GetSelected()
        {
            return List.Find(SelectedTodo);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}