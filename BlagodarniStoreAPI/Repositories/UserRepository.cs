using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using System;

namespace BlagodarniStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        MeatStoreContext _context;

        public UserRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET

        public User? Get(int id)
        {
            return LoadData(_context.Users.Where(x => x.Id == id)).FirstOrDefault();
        }


        public User? GetMy(int id)
        {
            return LoadData(_context.Users.Where(x => x.Id == id)).FirstOrDefault();
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
                      Role = new RoleDTO(x.Role)
                  });
        }
        #endregion

        #region POST

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
