using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlagodarniStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        MeatStoreContext _context;
        Random _random;

        public UserRepository(MeatStoreContext context)
        {
            _context = context;
            _random = new Random();
        }

        #region GET

        public User? Get(int id)
        {
            return LoadData(_context.Users.Where(x => x.Id == id)).FirstOrDefault(); ;
        }


        public User GetMy(int id)
        {
            return LoadData(_context.Users.Where(x => x.Id == id)).FirstOrDefault()!;
        }
        public List<User> GetCouriers()
        {
            return LoadData(_context.Users.Where(x => x.Role.Name == "courier")).ToList();
        }

        private IQueryable<User> LoadData(IQueryable<User> users)
        {
            return users
                  .Select(x => new UserDTO(x)
                  {
                      Role = new RoleDTO(x.Role!)
                  });
        }
        #endregion

        #region POST

        public User Add(User user)
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
                RoleId = user.RoleId,
                Password = pass,
                PasswordSalt = salt,
                Address = user.Address,
            };
            _context.Users.Add(creatingUser);
            _context.SaveChanges();
            var newUser = _context.Users.Include(x => x.Role).Where(x => x.Id == creatingUser.Id).FirstOrDefault();
            return newUser;
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion

        #region TOOLMETHODS

        private bool PhoneNumberAlreadyExist(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user is null)
                return false;
            return true;
        }

        public bool UserValid(User user)
        {
            if (user.Name is not String)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
