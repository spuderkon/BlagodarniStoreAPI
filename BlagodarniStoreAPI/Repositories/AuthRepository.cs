using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlagodarniStoreAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        MeatStoreContext _context;
        Random _random;
        IUserAddressRepository _userAddressRepository;

        public AuthRepository(MeatStoreContext context, IUserAddressRepository userAddressRepository)
        {
            _context = context;
            _random = new Random();
            _userAddressRepository = userAddressRepository;
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
        public User? Register(User user) 
        {
            if (PhoneNumberAlreadyExist(user.PhoneNumber)) 
            {
                throw new Exception("Пользователь с заданным номер телефона уже существует");
            }
            string salt = RegistrationTools.GetRandomKey(_random.Next(128, 256));
            string pass = RegistrationTools.GetPasswordSha256(user.Password, salt);
            var creatingUser = new User
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
            _context.Users.Add(creatingUser);
            _context.SaveChanges();
            _userAddressRepository.Add(creatingUser.Id, user.Address);
            var newUser = _context.Users.Include(x => x.Role).Where(x => x.Id == creatingUser.Id).FirstOrDefault();
            return newUser;
        }

        #endregion

        #region PUT
        public bool SetNewPassword(int userId, string phoneNumber, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user is not null)
            {
                if(userId != user.Id)
                {
                    throw new Exception("Id не совпадаю");
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
