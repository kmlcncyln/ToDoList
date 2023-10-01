using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Data;
using ToDoList.Models;

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
        public IActionResult Register(User user)
        {
            // Kullanıcıyı veritabanına kaydetme işlemi
            // Örnek olarak kullanıcı adı ve parolayı veritabanına kaydedebilirsiniz
            // Parolayı güvenli bir şekilde saklamak için uygun bir yöntem kullanmalısınız
            // Örneğin, şifreleri tuzlama (salting) ve karma (hashing) işlemleri ile saklamak güvenli bir yaklaşım olabilir

            // Kullanıcıyı kaydettikten sonra JWT token oluşturabilirsiniz
            var token = GenerateJwtToken(user.Username, "User");

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            // Kullanıcının kimlik doğrulama işlemi
            // Kullanıcı adı ve parola doğrulamasını gerçekleştirin
            // Eğer kullanıcı doğru bilgileri verirse, JWT token oluşturabilirsiniz
            // Eğer kullanıcı adı ve parola eşleşmezse hata mesajı döndürün

            if (UserIsValid(user.Username, user.Password))
            {
                var token = GenerateJwtToken(user.Username, "User");
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(new { Message = "Kullanıcı adı veya parola hatalı." });
            }
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

        private bool UserIsValid(string username, string password)
        {
            // Kullanıcı doğrulama işlemi
            // Kullanıcı adı ve parola doğru ise true, değilse false döndürün
            // Kullanıcı parolalarını güvenli bir şekilde sakladığınızdan emin olun

            // Örnek olarak kullanıcı adı ve parolayı veritabanından sorgulayabilirsiniz
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
