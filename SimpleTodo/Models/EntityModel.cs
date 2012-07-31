using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;

namespace SimpleTodo.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Created on")]
        public DateTime DateCreated { get; set; }

        public Entity()
        {
            DateCreated = DateTime.Now;
        }

        public Type GetUnproxiedType()
        {
            return ObjectContext.GetObjectType(GetType());
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", GetUnproxiedType().Name, Id);
        }
    }
}