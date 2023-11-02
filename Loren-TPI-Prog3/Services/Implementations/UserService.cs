using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Data.Models;

namespace Loren_TPI_Prog3.Services.Implementations
{
    public class UserService
    {
        private readonly LorenContext _context;

        public UserService(LorenContext context)
        {
            _context = context;
        }

        public BaseResponse ValidateUser (string email, string password)
        {
            BaseResponse response = new();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
