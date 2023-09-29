using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)] 
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        User,
        Admin
    }

}

