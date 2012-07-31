using System;

namespace SimpleTodo.Models
{
    public class TodoItem : Entity
    {
        public string Content { get; set; }

        public string Status { get; private set; }

        public TodoItem()
        {
            Status = "Todo";
        }

        public void Promote()
        {
            if (Status == "Todo")
            {
                Status = "Doing";
            } else if (Status != "Doing")
            {
                throw new Exception("Invalid TodoItem State.");
            }
        }

        public bool IsInProgress()
        {
            return Status == "Doing";
        }
    }


}