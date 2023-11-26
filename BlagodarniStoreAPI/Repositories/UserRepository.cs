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
            var user = _context.Users.Where(x => x.Id == id);
            return LoadData(user).FirstOrDefault();
        }


        public User? GetMy(int id)
        {
            var user = _context.Users.Where(x => x.Id == id);
            return LoadData(user).FirstOrDefault();
        }
        public List<User> GetCouriers()
        {
            var users = _context.Users.Where(x => x.RoleId == 2);
            return LoadData(users).ToList();
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



        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
