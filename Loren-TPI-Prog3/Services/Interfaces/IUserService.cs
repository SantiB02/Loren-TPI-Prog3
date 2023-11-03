using ErrorOr;
using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Models;

namespace Loren_TPI_Prog3.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByEmail(string email);
        public BaseResponse ValidateUser(string email, string password);
        public ErrorOr<int> CreateUser(User user);
        public ErrorOr<Updated> UpdateUser(User user);
        public ErrorOr<Deleted> DeleteUser(int userId);
    }
}
