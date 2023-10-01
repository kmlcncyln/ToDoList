using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ToDoListDbContext _context;
        private readonly IConfiguration _configuration;

        public ItemsController(ToDoListDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // JWT Token Oluşturma
        private string GenerateJwtToken(string userId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userId),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            // Yeni bir görev ekleyin ve başarı durumunu döndürün.
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            // Belirli bir görevi ID'ye göre getirin ve döndürün.
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, Item item)
        {
            // Belirli bir görevi güncelleyin ve başarı durumunu döndürün.
            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.DueDate = item.DueDate;
            existingItem.Status = item.Status;
            existingItem.Category = item.Category;

            await _context.SaveChangesAsync();

            return Ok(existingItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            // Belirli bir görevi silin ve başarı durumunu döndürün.
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Görev başarıyla silindi.");
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            // Tüm görevleri listele ve döndür.
            var items = _context.Items.ToList();
            return Ok(items);
        }
    }
}
