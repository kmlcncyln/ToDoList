using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
