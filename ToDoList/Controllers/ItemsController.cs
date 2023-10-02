using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Authorize]
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
                Expires = DateTime.UtcNow.AddDays(7), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            // TaskID'yi otomatik olarak oluştur
            item.TaskID = GenerateUniqueTaskID();

            // Yeni bir görev ekleyin ve döndür
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = item.TaskID }, item);
        }

        private static readonly Random _random = new Random();
        private const int TaskIdLength = 10; // TaskID uzunluğu

        private static string GenerateUniqueTaskID()
        {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Span<char> id = stackalloc char[TaskIdLength];

        for (int i = 0; i < TaskIdLength; i++)
        {
            id[i] = chars[_random.Next(chars.Length)];
        }

        return id.ToString();
        }


        [HttpGet("{id}")]
        //[Authorize]
            public async Task<IActionResult> GetItemById(string id)
        {
            var item = _context.Items.FirstOrDefault(i => i.TaskID == id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            // Kullanıcıya özgü yetkilendirme
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // UserController tarafından üretilen token ile kimlik doğrulaması yapılabilir
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Token'ın doğru olup olmadığını kontrol edin
            if (ValidateToken(token, userId, userRole))
            {
                return Ok(item);
            }
            else
            {
                return Forbid(); // Yetkilendirme reddedildi
            }
        }


        [HttpPut("{id}")]
            //[Authorize]
            public async Task<IActionResult> UpdateItem(string id, Item item)
        {
            // Belirli bir görevi güncelleme işlemine başlayın.
            var existingItem = _context.Items.FirstOrDefault(i => i.TaskID == id);
            if (existingItem == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            // Kullanıcıya özgü yetkilendirme
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // UserController tarafından üretilen token ile kimlik doğrulaması yapılabilir
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Token'ın doğru olup olmadığını kontrol edin
            if (ValidateToken(token, userId, userRole))
            {
                // taskID'yi güncelleme işlemi sırasında dikkate almayın
                item.TaskID = existingItem.TaskID;

                existingItem.Title = item.Title;
                existingItem.Description = item.Description;
                existingItem.DueDate = item.DueDate;
                existingItem.Status = item.Status;
                existingItem.Category = item.Category;

                await _context.SaveChangesAsync();

                return Ok(existingItem);
            }
            else
            {
                return Forbid(); // Yetkilendirme reddedildi
            }
        }

        [HttpDelete("{id}")]
            //[Authorize]
            public async Task<IActionResult> DeleteItem(string id)
        {
            // Belirli bir görevi silin ve başarı durumunu döndürün.
            var item = _context.Items.FirstOrDefault(i => i.TaskID == id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            // Kullanıcıya özgü yetkilendirme
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // UserController tarafından üretilen token ile kimlik doğrulaması yapılabilir
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Token'ın doğru olup olmadığını kontrol edin
            if (ValidateToken(token, userId, userRole))
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                return Ok("Görev başarıyla silindi.");
            }
            else
            {
                return Forbid(); // Yetkilendirme reddedildi
            }
        }


        private bool ValidateToken(string token, string userId, string userRole)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                // Token'ı doğrula
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Token içindeki kullanıcı adı ve rolü kontrol et
                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims;

                var usernameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                return usernameClaim == userId && roleClaim == userRole;
            }
            catch
            {
                return false;
            }
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


