using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTodo.Models
{
    public class Entity
    {
        public int Id { get; set; }

        [Display(Name = "Created on")]
        public DateTime DateCreated { get; set; }

        public Entity()
        {
            DateCreated = DateTime.Now;
        }
    }
}