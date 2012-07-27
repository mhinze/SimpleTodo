using System.ComponentModel.DataAnnotations;

namespace SimpleTodo.Models
{
    public class TodoItem : Entity
    {
        public string Content { get; set; }

        public bool IsChecked { get; set; }

        public TodoItem()
        {
            Content = "New Todo";
        }
    }
}