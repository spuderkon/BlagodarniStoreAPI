using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class RoleDTO : Role
    {
        public RoleDTO(Role role) 
        {
            Id = role.Id;
            Name = role.Name;
        }

        [Key]
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; } = null!;
    }
}
