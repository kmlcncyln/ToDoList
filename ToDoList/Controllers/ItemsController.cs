using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Data;
using ToDoList.Models;

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

        return CreatedAtAction(nameof(GetItemById), new { id = item.TaskID }, item);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(string id)
    {
        var item = _context.Items.FirstOrDefault(i => i.TaskID == id);
        if (item == null)
        {
            return NotFound("Görev bulunamadı.");
        }

        // Geçici olarak token doğrulamasını devre dışı bırakmak için true döndürün
        bool tokenValidationDisabled = true;

        if (!tokenValidationDisabled)
        {
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
        else
        {
            // Geçici olarak token doğrulamasını devre dışı bıraktığınızda, doğrudan veriyi dönüştürebilirsiniz.
            return Ok(item);
        }
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(string id, Item item)
    {
        // Belirli bir görevi güncelleyin ve başarı durumunu döndürün.
        var existingItem = _context.Items.FirstOrDefault(i => i.TaskID == id);
        if (existingItem == null)
        {
            return NotFound("Görev bulunamadı.");
        }

        // Geçici olarak token doğrulamasını devre dışı bırakmak için true döndürün
        bool tokenValidationDisabled = true;

        if (!tokenValidationDisabled)
        {
            // Kullanıcıya özgü yetkilendirme
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == UserRole.Admin.ToString() || (userId == existingItem.CreatedBy))
            {
                // Öğenin alanlarını güncelleyin
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
        else
        {
            // Geçici olarak token doğrulamasını devre dışı bıraktığınızda, doğrudan veriyi güncelleyebilirsiniz.
            // Öğenin alanlarını güncelleyin
            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.DueDate = item.DueDate;
            existingItem.Status = item.Status;
            existingItem.Category = item.Category;

            await _context.SaveChangesAsync();

            return Ok(existingItem);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(string id)
    {
        // Belirli bir görevi silin ve başarı durumunu döndürün.
        var item = _context.Items.FirstOrDefault(i => i.TaskID == id);
        if (item == null)
        {
            return NotFound("Görev bulunamadı.");
        }

        // Geçici olarak token doğrulamasını devre dışı bırakmak için true döndürün
        bool tokenValidationDisabled = true;

        if (!tokenValidationDisabled)
        {
            // Kullanıcıya özgü yetkilendirme
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == UserRole.Admin.ToString() || (userId == item.CreatedBy))
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
        else
        {
            // Geçici olarak token doğrulamasını devre dışı bıraktığınızda, görevi silebilirsiniz.
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Görev başarıyla silindi.");
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
