using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class UnitDTO : Unit
    {
        public UnitDTO(Unit unit) 
        {
            Id = unit.Id;
            Measure = unit.Measure;
            Name = unit.Name;
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public int Measure { get; set; } 
        [StringLength(30)]
        public string Name { get; set; } = null!;
    }
}
