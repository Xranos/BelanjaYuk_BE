//using BelanjaYuk_BE.Data;
//using BelanjaYuk_BE.Models.Responses;

//namespace BelanjaYuk_BE.Services
//{

//    public class JwtService
//    {

//        private readonly AppDbContext _context;
//        private readonly IConfiguration _configuration;
//        public JwtService(AppDbContext appDbContext, IConfiguration configuration)
//        {
//            _context = appDbContext;
//            _configuration = configuration;
//        }

//        public async Task<LoginResponse> Authenticate(LoginRequest loginRequest)
//        {
//            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
//                return null;
//        }
//    }
//}
