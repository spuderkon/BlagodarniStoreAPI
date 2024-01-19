using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.POST
{
    public class CreateUserDTO
    {
        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Only Rus")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Only Rus")]
        public string Surname { get; set; } = null!;

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Only Rus")]
        public string Lastname { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Wrong email")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^[78]\d{10}$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; } = null!;

        [RegularExpression(@"^[1-3]$", ErrorMessage = "Wrong number")]
        public int? RoleId { get; set; }
        public string Password { get; set; } = null!;
    }
}
