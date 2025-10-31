using BelanjaYuk_BE.Data;
using BelanjaYuk_BE.Models;
using BelanjaYuk_BE.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using System.Security.Claims;

namespace BelanjaYuk_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSellerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserSellerController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        private async Task<string> GenerateIdUserSellerAsync()
        {
            var last = await _context.UserSellers
                .Where(u => u.IdUserSeller.StartsWith("SEL"))
                .OrderByDescending(u => u.IdUserSeller)
                .Select(u => u.IdUserSeller)
                .FirstOrDefaultAsync();

            var nextNumber = 1;
            if (!string.IsNullOrEmpty(last) && last.Length > 3 && int.TryParse(last.Substring(3), out var n))
                nextNumber = n + 1;

            return $"SEL{nextNumber:000}";
        }

        [HttpPost("RegisterSeller")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserSellerRequest createUserSellerRequest)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            if (!createUserSellerRequest.agreement)
                return BadRequest(new { message = "Need Agreement First" });

            var name = createUserSellerRequest.StoreName.Trim();
            if (name.Length < 3 || name.Length > 40)
                return BadRequest(new { message ="Store name must be 3 - 40 characters"});
            if (!Regex.IsMatch(name, @"^[A-Za-z0-9 \-]+$"))
                return BadRequest(new { message = "Store name only accepts Numbers, Space, Letter, and '-' " });

            //var url = createUserSellerRequest.StoreUrl.Trim();
            //if (!Regex.IsMatch(url, @"^[a-z0-9]([a-z0-9\-]{1,58})[a-z0-9]$"))
            //    return BadRequest(new { message = "URL only accepts lower case letter, number, '-', and not end or starts with '-'" });

            //var exists = await _context.UserSellers.AnyAsync(s => s.StoreUrl == url);
            //if (exists)
            //    return Conflict(new { message = "Store URL already used" });

            var desc = createUserSellerRequest.SellerDesc.Trim();
            if (desc.Length < 30 || desc.Length > 2000)
                return BadRequest(new { message = "Atleast 30 Or Max 2000 characters" });

            var addr = createUserSellerRequest.Address.Trim();
            if (addr.Length < 10)
                return BadRequest(new {message = "Alamat minimal 10 karakter." });

            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (string .IsNullOrEmpty(userId)) 
                return Unauthorized();

            var seller = new UserSeller
            {
                IdUserSeller = await GenerateIdUserSellerAsync() ,
                IdUser = userId,
                StoreName = name,
                //StoreUrl = url,         
                PhoneNumber = createUserSellerRequest.PhoneNumber,
                SellerDesc = desc,
                Address = addr,
                IsActive = true,
                DateIn = DateTime.UtcNow
            };

            _context.UserSellers.Add(seller);
            await _context.SaveChangesAsync();

            return Ok();
        }

        




    }
}
