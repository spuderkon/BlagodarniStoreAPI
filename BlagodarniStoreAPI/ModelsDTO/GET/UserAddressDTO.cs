using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlagodarniStoreAPI.ModelsDTO.GET
{
    public class UserAddressDTO : UserAddress
    {

        public UserAddressDTO(UserAddress userAddress)
        {
            Id = userAddress.Id;
            UserId = userAddress.UserId;
            Address = userAddress.Address;
        }

        new public int? Id { get; set; }
        new public int UserId { get; set; }
        new public string Address { get; set; }
    }
}
