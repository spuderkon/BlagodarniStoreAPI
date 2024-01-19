using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.GET
{
    public class RoleDTO : Role
    {
        public RoleDTO(Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        [Key]
        new public int Id { get; set; }
        [StringLength(15)]
        new public string Name { get; set; } = null!;
    }
}
