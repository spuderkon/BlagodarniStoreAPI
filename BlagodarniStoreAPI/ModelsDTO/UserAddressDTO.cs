using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class UserAddressDTO : UserAddress
    {

        public UserAddressDTO(UserAddress userAddress) 
        { 
            Id = userAddress.Id;
            UserId = userAddress.UserId;
            Address = userAddress.Address;
        }

        [Key]
        new public int Id { get; set; }
        new public int UserId { get; set; }
        [StringLength(50)]
        new public string Address { get; set; }
    }
}
