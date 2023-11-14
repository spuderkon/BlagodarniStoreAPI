using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class UserDTO : User
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Lastname = user.Lastname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            RoleId = user.RoleId;
            Address = user.Address;
        }
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [StringLength(30)]
        public string Surname { get; set; } = null!;
        [StringLength(30)]
        public string Lastname { get; set; } = null!;
        [StringLength(60)]
        public string Email { get; set; } = null!;
        [StringLength(11)]
        public string PhoneNumber { get; set; } = null!;
        public int RoleId { get; set; }
        [StringLength(50)]
        public string Address { get; set; } = null!;
    }
}
