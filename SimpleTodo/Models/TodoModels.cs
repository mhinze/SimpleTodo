using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace SimpleTodo.Models
{
    public class TodoList : Entity
    {
        [Display(Name = "Note Title")]
        public string Title { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Note Body")]
        public string List { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        public TodoList()
        {
            Title = "New Note";
            Date= DateTime.Now;
        }
    }
}