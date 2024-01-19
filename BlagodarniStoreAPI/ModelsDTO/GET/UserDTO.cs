using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.GET
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
            Password = null;
            PasswordSalt = null;
            AddressId = user.AddressId;
        }
        new public int Id { get; set; }
        new public string Name { get; set; } = null!;
        new public string Surname { get; set; } = null!;
        new public string Lastname { get; set; } = null!;
        new public string Email { get; set; } = null!;
        new public string PhoneNumber { get; set; } = null!;
        new public int RoleId { get; set; }
        new public string? Password { get; set; }
        new public string? PasswordSalt { get; set; }
        new public int? AddressId { get; set; }
    }
}
