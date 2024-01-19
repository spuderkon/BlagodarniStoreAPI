using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.ModelsDTO.POST;
using BlagodarniStoreAPI.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;

namespace BlagodarniStoreAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        Random _random;
        private readonly MeatStoreContext _context;
        private readonly IUserRepository _iUserRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IConfiguration _iConfiguration;

        public AuthRepository(MeatStoreContext context, IUserRepository iUserRepository, IUserAddressRepository userAddressRepository, IConfiguration iConfiguration)
        {
            _context = context;
            _random = new Random();
            _iUserRepository = iUserRepository;
            _userAddressRepository = userAddressRepository;
            _iConfiguration = iConfiguration;
        }

        public string? Authorize(string phoneNumber, string password)
        {
            var user = ValidUser(phoneNumber, password);
            if (user is not null)
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim("id",user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.Name),
                        new Claim("phoneNumber", user.PhoneNumber),
                });
                
            return JwtTools.GenerateJwtToken(identity, _iConfiguration["JwtSettings:Key"]!, _iConfiguration["JwtSettings:Issuer"]!, _iConfiguration["JwtSettings:Audience"]!);
            }
            return null;

        }

        public User? ValidUser(string phoneNumber, string password)
        {
            var user = _context.Users.Include(x => x.Role).FirstOrDefault(x => x.PhoneNumber == phoneNumber);
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

        #region POST

        public string? Register(CreateUserDTO user)
        {
            if (PhoneNumberAlreadyExist(user.PhoneNumber))
            {
                throw new Exception("Пользователь с заданным номером телефона уже существует");
            }

            string salt = RegistrationTools.GetRandomKey(_random.Next(128, 256));
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
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Authorize(user.PhoneNumber, user.Password);
        }

        #endregion

        #region PUT
        public bool SetNewPassword(string phoneNumber, string password, int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user is not null)
            {
                if (userId != user.Id)
                {
                    throw new Exception("Id не совпадают");
                }
                string salt = RegistrationTools.GetRandomKey(_random.Next(128, 256));
                string pass = RegistrationTools.GetPasswordSha256(password, salt);
                user.Password = pass;
                user.PasswordSalt = salt;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion

        private bool PhoneNumberAlreadyExist(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user is null)
                return false;
            return true;
        }


    }
}
