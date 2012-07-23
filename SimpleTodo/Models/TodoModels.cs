using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace SimpleTodo.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoList> Lists { get; set; }
    }

    public class TodoList
    {
        public string Title { get; set; }

    }
}