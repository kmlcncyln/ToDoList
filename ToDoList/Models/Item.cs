namespace ToDoList.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Title { get; set; }
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
