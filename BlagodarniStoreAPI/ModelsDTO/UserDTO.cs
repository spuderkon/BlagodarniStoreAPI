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
        new public int Id { get; set; }
        [StringLength(30)]
        new public string Name { get; set; } = null!;
        [StringLength(30)]
        new public string Surname { get; set; } = null!;
        [StringLength(30)]
        new public string Lastname { get; set; } = null!;
        [StringLength(60)]
        new public string Email { get; set; } = null!;
        [StringLength(11)]
        new public string PhoneNumber { get; set; } = null!;
        new public int RoleId { get; set; }
        [StringLength(50)]
        new public string Address { get; set; } = null!;
    }
}
