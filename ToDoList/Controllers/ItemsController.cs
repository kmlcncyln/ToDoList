using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ToDoListDbContext _context;

        public ItemsController(ToDoListDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            // Yeni bir görev ekleyin ve başarı durumunu döndürün.
            _context.Items.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            // Belirli bir görevi ID'ye göre getirin ve döndürün.
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item item)
        {
            // Belirli bir görevi güncelleyin ve başarı durumunu döndürün.
            var existingItem = _context.Items.Find(id);
            if (existingItem == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.DueDate = item.DueDate;
            existingItem.Status = item.Status;
            existingItem.Category = item.Category;

            _context.SaveChanges();

            return Ok(existingItem);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            // Belirli bir görevi silin ve başarı durumunu döndürün.
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound("Görev bulunamadı.");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

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
