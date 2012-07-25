using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace SimpleTodo.Models
{
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