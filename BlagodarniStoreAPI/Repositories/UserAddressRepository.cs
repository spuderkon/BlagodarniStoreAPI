using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;

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
            return LoadData(_context.UserAddresses.Where(x => x.UserId == id)).ToList();
        }

        private IQueryable<UserAddress> LoadData(IQueryable<UserAddress> userAddresses)
        {
            return userAddresses
                  .Select(x => new UserAddressDTO(x)
                  {

                  });
        }
        #endregion

        #region ADD

        public UserAddress Add(int id, string address)
        {
            if (UserAddressDoesntExist(id, address))
            { 
                var newAddress = new UserAddress
                {
                    UserId = id,
                    Address = address
                };
                _context.UserAddresses.Add(newAddress);
                _context.SaveChanges();
                return newAddress;
            }
            throw new Exception("Такой адрес уже существует");
        }

        #endregion

        #region UPDATE



        #endregion

        #region DELETE



        #endregion

        #region TOOLMETHODS

        public bool UserAddressDoesntExist(int id, string address)
        {
            if (_context.UserAddresses.FirstOrDefault(x => x.UserId == id && x.Address == address) == null)
                return true;
            return false;
        }

        #endregion
    }
}
