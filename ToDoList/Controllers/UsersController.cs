using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ToDoListDbContext _context;

        public UsersController(ToDoListDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password; 

            _context.SaveChanges();

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok("Kullanıcı başarıyla silindi.");
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
