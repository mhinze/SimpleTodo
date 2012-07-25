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

    public class TodoList : Entity
    {
        [Required]
        [Display(Name = "Note Title")]
        public string Title { get; set; }

        [Display(Name = "Note Body")]
        public string List { get; set; }

        public TodoList()
        {
            Title = "New Note";
        }
    }
}