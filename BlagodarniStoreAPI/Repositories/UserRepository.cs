﻿using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;
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
                      Role = new RoleDTO(x.Role),
                      Address = x.Address == null ? null : new UserAddressDTO(x.Address)
                  });
        }
        #endregion

        #region ADD

        public User Add(CreateUserDTO user)
        {
            if (PhoneNumberAlreadyExist(user.PhoneNumber))
            {
                throw new Exception("Пользователь с заданным номер телефона уже существует");
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
                RoleId = user.RoleId,
                Password = pass,
                PasswordSalt = salt,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return LoadData(_context.Users.Where(x => x.Id == newUser.Id)).FirstOrDefault();
        }

        #endregion

        #region UPDATE

        public void UpdateUserAddress(int userId, int addressId)
        {
            User user = _context.Users.First(x => x.Id == userId);
            user.AddressId = addressId;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

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
