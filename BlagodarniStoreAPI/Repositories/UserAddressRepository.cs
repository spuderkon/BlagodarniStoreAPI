using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        MeatStoreContext _context;

        public UserAddressRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET
        public List<UserAddress>? GetUserAddresses(int id)
        {
            var userAddresses = _context.UserAddresses.Where(x => x.UserId == id);
            if (userAddresses is not null)
            {
                return LoadData(userAddresses).ToList();
            }
            return null;
        }

        private IQueryable<UserAddress> LoadData(IQueryable<UserAddress> userAddresses)
        {
            return userAddresses
                  .Select(x => new UserAddressDTO(x)
                  {

                  });
        }
        #endregion

        #region POST

        public UserAddress Add(int userId, string address)
        {
            var newAddress = new UserAddress
            {
                UserId = userId,
                Address = address
            };
            _context.UserAddresses.Add(newAddress);
            _context.SaveChanges();
            return newAddress;
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
