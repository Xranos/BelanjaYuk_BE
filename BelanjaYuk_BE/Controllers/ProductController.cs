using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BelanjaYuk_BE.Data;
using BelanjaYuk_BE.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelanjaYuk_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            var items = await _context.Products.ToListAsync();
            return items;
        }
    }
}
