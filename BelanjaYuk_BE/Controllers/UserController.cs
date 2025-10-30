using BelanjaYuk_BE.Data;
using BelanjaYuk_BE.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BelanjaYuk_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        private async Task<string> GenerateIdUserAsync()
        {
            var last = await _context.Users
                .Where(u => u.IdUser.StartsWith("USR"))
                .OrderByDescending(u => u.IdUser)
                .Select(u => u.IdUser)
                .FirstOrDefaultAsync();

            var nextNumber = 1;
            if (!string.IsNullOrEmpty(last) && last.Length > 3 && int.TryParse(last.Substring(3), out var n))
                nextNumber = n + 1;

            return $"USR{nextNumber:000}";   
        }

        private async Task<string> GenerateIdUserPasswordAsync()
        {
            var last = await _context.UserPasswords
                .Where(p => p.IdUserPassword.StartsWith("PASS"))
                .OrderByDescending(p => p.IdUserPassword)
                .Select(p => p.IdUserPassword)
                .FirstOrDefaultAsync();

            var nextNumber = 1;
            if (!string.IsNullOrEmpty(last) && last.Length > 4 && int.TryParse(last.Substring(4), out var n))
                nextNumber = n + 1;

            return $"PASS{nextNumber:000}";
        }

        private async Task<string> GenerateIdHomeAddressAsync()
        {
            var last = await _context.HomeAddresses
                .Where(p => p.IdHomeAddress.StartsWith("HADDR"))
                .OrderByDescending(p => p.IdHomeAddress)
                .Select(p => p.IdHomeAddress)
                .FirstOrDefaultAsync();

            var nextNumber = 1;
            if (!string.IsNullOrEmpty(last) && last.Length > 5 && int.TryParse(last.Substring(5), out var n))
                nextNumber = n + 1;

            return $"HADDR{nextNumber:000}";
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateUserRequest createUserRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userNameExistsCheck = _context.Users.Where(x => createUserRequest.UserName == x.UserName).Any();
            if (userNameExistsCheck)
                return Conflict("Username already exists");
            
            var emailExistsCheck = _context.Users.Where(x => createUserRequest.Email == x.Email).Any();
            if (emailExistsCheck)
                return Conflict("Email already exists");

            if (string.IsNullOrWhiteSpace(createUserRequest.IdGender))
                return BadRequest("Gender is required.");

            var user = new Models.User
            {
                IdUser = await GenerateIdUserAsync(),
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                UserName = createUserRequest.UserName,
                Email = createUserRequest.Email,
                PhoneNumber = createUserRequest.PhoneNumber,
                DOB = createUserRequest.DOB,
                IdGender = createUserRequest.IdGender,
                IsActive = true,
                DateIn = DateTime.UtcNow

            };
            _context.Users.Add(user);

            _context.UserPasswords.Add(new Models.UserPassword
            {
                IdUserPassword = await GenerateIdUserPasswordAsync(),
                IdUser = user.IdUser,
                PasswordHashed = $"hashed_{createUserRequest.UserName}",
                IsActive = true,
                DateIn = DateTime.UtcNow
            });

            if (!string.IsNullOrWhiteSpace(createUserRequest.HomeAddressDesc))
            {
                _context.HomeAddresses.Add(new Models.HomeAddress
                {
                    IdHomeAddress = await GenerateIdHomeAddressAsync(),
                    IdUser = user.IdUser,  
                    Provinsi = createUserRequest.Provinsi,
                    KotaKabupaten = createUserRequest.KotaKabupaten,
                    Kecamatan = createUserRequest.Kecamatan,    
                    KodePos = createUserRequest.KodePos,
                    HomeAddressDesc = createUserRequest.HomeAddressDesc,
                    IsPrimaryAddress = true,
                    IsActive = true,
                    DateIn = DateTime.UtcNow

                });
            }
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
