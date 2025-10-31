using BelanjaYuk_BE.Data;
using BelanjaYuk_BE.Models;
using BelanjaYuk_BE.Models.Requests;
using BelanjaYuk_BE.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BelanjaYuk_BE.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IConfiguration _cfg;

        public AuthController(AppDbContext appDbContext, IPasswordHasher<User> hasher, IConfiguration cfg)
        {
            _context = appDbContext;
            _hasher = hasher;
            _cfg = cfg;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Field Must be Filled." });

            var id = loginRequest.EmailOrPhone.Trim();

            var user = await _context.Users.AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == id || u.PhoneNumber ==id);

            var pass = await _context.UserPasswords.AsNoTracking()
                .SingleOrDefaultAsync(p => p.IdUser ==  user.IdUser && p.IsActive == true);

            if (pass is null || string.IsNullOrWhiteSpace(pass.PasswordHashed))
                return Unauthorized(new { message = "Wrong Password" });

            var result = _hasher.VerifyHashedPassword(user, pass.PasswordHashed, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Wrong Password" });

            var minutesCfg = int.TryParse(_cfg["JwtConfig:TokenValidityMin"], out var m) ? m : 30;
            var lifetime = loginRequest.RememberMe ? TimeSpan.FromDays(7) : TimeSpan.FromMinutes(minutesCfg);

            var token = CreateJwt(user, lifetime, out var expiresAt);
            return Ok(new LoginResponse
            {
                AccessToken = token,
                ExpiresIn = (int)(expiresAt - DateTimeOffset.UtcNow).TotalSeconds,
                IdUser = user.IdUser
            });
        }

        private string CreateJwt(User user, TimeSpan lifetime, out DateTimeOffset expiresAt)
        {
            var issuer = _cfg["JwtConfig:Issuer"]!;
            var audience = _cfg["JwtConfig:Audience"];
            var key = _cfg["JwtConfig:Key"]!;

            var now = DateTimeOffset.UtcNow;
            expiresAt = now.Add(lifetime);

            var creds = new SigningCredentials(
              new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
              SecurityAlgorithms.HmacSha256);

            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, user.IdUser),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim("uname", user.UserName ?? string.Empty),
            };

            var jwt = new JwtSecurityToken(
             issuer: issuer,
             audience: audience,
             claims: claims,
             notBefore: now.UtcDateTime,
             expires: expiresAt.UtcDateTime,
             signingCredentials: creds
         );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
    }
}
