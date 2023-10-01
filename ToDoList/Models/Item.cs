using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Item
    {
        [Key]
        public string TaskID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public TaskCategory Category { get; set; }

        [Required]
        [MaxLength(50)]
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
