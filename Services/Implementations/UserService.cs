﻿using ErrorOr;
using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Models;
using Loren_TPI_Prog3.Services.Interfaces;

namespace Loren_TPI_Prog3.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LorenContext _context;

        public UserService(LorenContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail (string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public bool CheckIfUserExists(string userEmail)
        {
            return _context.Users.Any(u => u.Email == userEmail);
        }

        public BaseResponse ValidateUser (string email, string password)
        {
            BaseResponse response = new();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null) //Si lo encuentra, entra al if (distinto de null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "successful login";
                } else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            } else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

        public ErrorOr<int> CreateUser (User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public ErrorOr<Updated> UpdateUser (User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return Result.Updated;
        }

        public ErrorOr<Deleted> DeleteUser (int userId)
        {
            User userToBeDeleted = _context.Users.SingleOrDefault(u => u.Id == userId); //el usuario a borrar va a existir en la BBDD porque el userId viene del token del usuario que inició sesión. Si inicia sesión, su usuario ya existe.
            userToBeDeleted.State = false; //borrado lógico. El usuario seguirá en la BBDD pero con un state 0 (false)
            _context.Update(userToBeDeleted);
            _context.SaveChanges();
            return Result.Deleted;
        }

        

        public ErrorOr<List<User>> GetUsersByRole(string role)
        {
            return _context.Users.Where(u => u.UserType == role).ToList();
        }
    }
}
