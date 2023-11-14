using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlagodarniStoreAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        MeatStoreContext _context;

        public AuthRepository(MeatStoreContext context)
        {
            _context = context;
        }

        public User? ValidUser(string email, string password)
        {
            var user = _context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email);
            if (user is not null)
            {
                if (user.Password == RegistrationTools.GetPasswordSha256(password, user.PasswordSalt))
                {
                    return user;
                }
                return null;
            }
            else
                return null;
        }

        public User? Register(User user) 
        {
            Random rnd = new Random();
            string salt = RegistrationTools.GetRandomKey(rnd.Next(128, 256));
            string pass = RegistrationTools.GetPasswordSha256(user.Password, salt);
            var newUser = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Lastname = user.Lastname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = 3,
                Password = pass,
                PasswordSalt = salt,
                Address = user.Address,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }
    }
}
