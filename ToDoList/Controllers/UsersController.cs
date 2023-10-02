using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using ToDoList.Data;
using ToDoList.Models;
using Microsoft.AspNetCore.Identity;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ToDoListDbContext _context;

        public UserController(IConfiguration configuration, ToDoListDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(User userRegistration)
        {
            // Kullanıcı adının benzersiz olduğunu kontrol edin
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == userRegistration.Username);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Bu kullanıcı adı zaten kullanılıyor." });
            }

            // Parolayı güvenli bir şekilde tuzlama ve karma işlemi uygula
            string hashedPassword = HashPassword(userRegistration.Password);

            // Yeni bir User nesnesi oluştur ve veritabanına eklemek için DbContext kullan
            var newUser = new User
            {
                Username = userRegistration.Username,
                Password = hashedPassword,
                Role = UserRole.User // Kullanıcı rolünü ayarlayın
            };

            // Veritabanına kullanıcıyı ekleyin
            _context.Users.Add(newUser);
            _context.SaveChanges();

            // Kullanıcıyı kaydettikten sonra JWT token oluşturabilirsiniz
            var token = GenerateJwtToken(newUser.Username, newUser.Role.ToString());

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public IActionResult Login(User userLogin)
        {
            // Kullanıcının kimlik doğrulama işlemi
            // Kullanıcı adı ve parola doğrulamasını gerçekleştirin
            // Eğer kullanıcı adı ve parola eşleşmezse hata mesajı döndürün

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == userLogin.Username);
            if (existingUser == null || !VerifyPassword(existingUser.Password, userLogin.Password))
            {
                return Unauthorized(new { Message = "Kullanıcı adı veya parola hatalı." });
            }

            var token = GenerateJwtToken(existingUser.Username, existingUser.Role.ToString());
            return Ok(new { Token = token });
        }

        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>(); 
            string hashedPassword = passwordHasher.HashPassword(null, password);
            return hashedPassword;
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<User>(); 
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        private string GenerateJwtToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token süresini ayarlayabilirsiniz
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
