using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    TaskID = "q1j9rEh2Xw",
                    Title = "Buy Groceries",
                    Description = "Buy groceries for the week",
                    DueDate = DateTime.Parse("2023-09-15 10:00"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Home,
                    CreatedBy = "john_doe"
                },
                new Item
                {
                    TaskID = "s2kDfPz8Tm",
                    Title = "Finish Project Report",
                    Description = "Finish the project report for the presentation",
                    DueDate = DateTime.Parse("2023-09-16 14:30"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "jane_smith"
                },
                new Item
                {
                    TaskID = "t3mHxVz7Yn",
                    Title = "Attend Team Meeting",
                    Description = "Attend the weekly team meeting",
                    DueDate = DateTime.Parse("2023-09-17 12:00"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Work,
                    CreatedBy = "alice_jones"
                },
                new Item
                {
                    TaskID = "w4oPqRv5Au",
                    Title = "Plan Weekend Getaway",
                    Description = "Plan a weekend getaway with friends",
                    DueDate = DateTime.Parse("2023-09-18 09:45"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Entertainment,
                    CreatedBy = "bob_smith"
                },
                new Item
                {
                    TaskID = "y5uJwQb4Bv",
                    Title = "Prepare for Exam",
                    Description = "Study and prepare for the upcoming exam",
                    DueDate = DateTime.Parse("2023-09-19 17:15"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.School,
                    CreatedBy = "sarah_davis"
                },
                new Item
                {
                    TaskID = "z6vKxUc3Cx",
                    Title = "Workout at the Gym",
                    Description = "Hit the gym for a workout session",
                    DueDate = DateTime.Parse("2023-09-20 08:30"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Home,
                    CreatedBy = "mike_adams"
                },
                new Item
                {
                    TaskID = "x7tLrNm9Dz",
                    Title = "Review Quarterly Report",
                    Description = "Review the quarterly financial report",
                    DueDate = DateTime.Parse("2023-09-21 11:30"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Work,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "p8qOsXe1Lf",
                    Title = "Submit Expense Reports",
                    Description = "Submit expense reports for reimbursement",
                    DueDate = DateTime.Parse("2023-09-22 13:45"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "k9vZpMt0Ki",
                    Title = "Plan Company Retreat",
                    Description = "Plan a company retreat for team building",
                    DueDate = DateTime.Parse("2023-09-23 15:00"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Work,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "a1bCdEf2Gh",
                    Title = "Complete Project Proposal",
                    Description = "Finalize and submit the project proposal",
                    DueDate = DateTime.Parse("2023-09-24 09:30"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Work,
                    CreatedBy = "emily_wilson"
                },
                new Item
                {
                    TaskID = "b2CkLmN3Op",
                    Title = "Call Mom",
                    Description = "Give Mom a call and catch up",
                    DueDate = DateTime.Parse("2023-09-25 14:15"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Home,
                    CreatedBy = "john_doe"
                },
                new Item
                {
                    TaskID = "c3DnOpQ4Rs",
                    Title = "Pay Utility Bills",
                    Description = "Pay the electricity and water bills",
                    DueDate = DateTime.Parse("2023-09-26 16:00"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Home,
                    CreatedBy = "jane_smith"
                },
                new Item
                {
                    TaskID = "d4EpQrS5Tu",
                    Title = "Update Resume",
                    Description = "Update the resume with recent achievements",
                    DueDate = DateTime.Parse("2023-09-27 10:45"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "alice_jones"
                },
                new Item
                {
                    TaskID = "e5FqRsT6Vw",
                    Title = "Attend Webinar on AI",
                    Description = "Attend the online webinar on artificial intelligence",
                    DueDate = DateTime.Parse("2023-09-28 13:30"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.School,
                    CreatedBy = "bob_smith"
                },
                new Item
                {
                    TaskID = "f6GsTuV7Wx",
                    Title = "Write Blog Post",
                    Description = "Write a blog post about the latest tech trends",
                    DueDate = DateTime.Parse("2023-09-29 15:45"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Work,
                    CreatedBy = "sarah_davis"
                },
                new Item
                {
                    TaskID = "g7HtUvW8Xy",
                    Title = "Review Code for Project",
                    Description = "Review and provide feedback on the project code",
                    DueDate = DateTime.Parse("2023-09-30 12:15"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "mike_adams"
                },
                new Item
                {
                    TaskID = "h8IuWxY9Zz",
                    Title = "Plan Anniversary Celebration",
                    Description = "Plan a surprise anniversary celebration",
                    DueDate = DateTime.Parse("2023-10-01 10:00"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Entertainment,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "i9JvXyZ1Aa",
                    Title = "Schedule Dentist Appointment",
                    Description = "Schedule a dental checkup appointment",
                    DueDate = DateTime.Parse("2023-10-02 09:30"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Home,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "j0KwYz1BbC",
                    Title = "Research Vacation Destinations",
                    Description = "Research potential vacation destinations",
                    DueDate = DateTime.Parse("2023-10-03 14:45"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Entertainment,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "k1LxZ2CcDd",
                    Title = "Create Presentation for Meeting",
                    Description = "Prepare a presentation for an upcoming meeting",
                    DueDate = DateTime.Parse("2023-10-04 11:00"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Work,
                    CreatedBy = "emily_wilson"
                },
                new Item
                {
                    TaskID = "m2NyZ3OdPe",
                    Title = "Grocery Shopping",
                    Description = "Buy groceries for the family",
                    DueDate = DateTime.Parse("2023-10-05 16:30"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Home,
                    CreatedBy = "john_doe"
                },
                new Item
                {
                    TaskID = "o3PzA4QeRf",
                    Title = "Pay Credit Card Bill",
                    Description = "Make a payment for the credit card bill",
                    DueDate = DateTime.Parse("2023-10-06 14:00"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Home,
                    CreatedBy = "jane_smith"
                },
                new Item
                {
                    TaskID = "q4RsT5UfSg",
                    Title = "Write Report on Market Trends",
                    Description = "Prepare a report on current market trends",
                    DueDate = DateTime.Parse("2023-10-07 12:30"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "alice_jones"
                },
                new Item
                {
                    TaskID = "s5TuV6WgXh",
                    Title = "Walk the Dog",
                    Description = "Take the dog for a walk in the park",
                    DueDate = DateTime.Parse("2023-10-08 17:00"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Home,
                    CreatedBy = "bob_smith"
                },
                new Item
                {
                    TaskID = "u6VwXyZiAj",
                    Title = "Book Flight Tickets",
                    Description = "Book flight tickets for the upcoming vacation",
                    DueDate = DateTime.Parse("2023-10-09 08:45"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Entertainment,
                    CreatedBy = "sarah_davis"
                },
                new Item
                {
                    TaskID = "w7XyZ1AkBl",
                    Title = "Attend Coding Bootcamp",
                    Description = "Attend the coding bootcamp workshop",
                    DueDate = DateTime.Parse("2023-10-10 13:15"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.School,
                    CreatedBy = "mike_adams"
                },
                new Item
                {
                    TaskID = "z8Z1AaBmCn",
                    Title = "Plan Anniversary Celebration",
                    Description = "Plan a surprise anniversary celebration",
                    DueDate = DateTime.Parse("2023-10-11 11:45"),
                    Status = ToDoList.Models.TaskStatus.Completed,
                    Category = TaskCategory.Entertainment,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "A9bBmCnDoE",
                    Title = "Pay Rent",
                    Description = "Pay the monthly rent for the apartment",
                    DueDate = DateTime.Parse("2023-10-12 09:00"),
                    Status = ToDoList.Models.TaskStatus.New,
                    Category = TaskCategory.Home,
                    CreatedBy = "admin_user"
                },
                new Item
                {
                    TaskID = "B0cDnEoFpG",
                    Title = "Research New Tech Gadgets",
                    Description = "Research and compare new tech gadgets",
                    DueDate = DateTime.Parse("2023-10-13 14:30"),
                    Status = ToDoList.Models.TaskStatus.InProgress,
                    Category = TaskCategory.Work,
                    CreatedBy = "admin_user"
                }
                
            );

        }

    }
}
