    using System.ComponentModel.DataAnnotations;

namespace SimpleTodo.Models
{
    public class TodoItem : Entity
    {
        public string Content { get; set; }

        public string Status { get; private set; }

        public TodoItem()
        {
            Status = "Pending";
        }

        public void Promote()
        {
            if (Status == "Pending")
            {
                Status = "Doing";
            } else if (Status == "Doing")
            {
                Status = "Done";
            }
        }
    }


}