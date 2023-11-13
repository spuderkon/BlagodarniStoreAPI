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
    }
}
