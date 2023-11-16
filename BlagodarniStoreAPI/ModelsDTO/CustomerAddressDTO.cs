using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class CustomerAddressDTO : CustomerAddress
    {

        public CustomerAddressDTO(CustomerAddress customerAddress) 
        { 
            Id = customerAddress.Id;
            CustomerId = customerAddress.CustomerId;
            Address = customerAddress.Address;
        }

        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    }
}
