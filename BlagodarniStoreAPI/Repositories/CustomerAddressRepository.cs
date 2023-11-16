using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Repositories
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        MeatStoreContext _context;

        public CustomerAddressRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET
        public List<CustomerAddress>? GetCustomerAddresses(int id)
        {
            var customerAddresses = _context.CustomerAddresses.Where(x => x.CustomerId == id);
            if (customerAddresses is not null)
            {
                return LoadData(customerAddresses).ToList();
            }
            return null;
        }

        private IQueryable<CustomerAddress> LoadData(IQueryable<CustomerAddress> customerAddresses)
        {
            return customerAddresses
                  .Select(x => new CustomerAddressDTO(x)
                  {

                  });
        }
        #endregion

        #region POST

        public CustomerAddress Add(int customerId, string address)
        {
            var newAddress = new CustomerAddress
            {
                CustomerId = customerId,
                Address = address
            };
            _context.CustomerAddresses.Add(newAddress);
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
