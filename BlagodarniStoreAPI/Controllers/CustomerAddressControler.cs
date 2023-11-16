using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerAddressControler : ControllerBase
    {
        ICustomerAddressRepository _iCustomerAddressRepository;

        public CustomerAddressControler(ICustomerAddressRepository customerAddressRepository)
        {
            _iCustomerAddressRepository = customerAddressRepository;
        }

        #region GET

        [HttpGet("GetCustomerAddresses/{Id}")]
        public ActionResult<IEnumerable<CustomerAddress>> GetCustomerAddresses(int id) 
        {
            var customerAddresses = _iCustomerAddressRepository.GetCustomerAddresses(id);
            return customerAddresses == null ? NotFound() : customerAddresses;
        }


        #endregion
    }
}
