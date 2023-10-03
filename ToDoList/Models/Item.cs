using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Item
    {
        [Key]
        [MaxLength(10)]
        public string TaskID { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public TaskCategory Category { get; set; }
        public string CreatedBy { get; set; }
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Completed
    }

    public enum TaskCategory
    {
        Work,
        Home,
        School,
        Entertainment
    }
}
