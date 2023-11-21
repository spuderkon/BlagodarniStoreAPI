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
        new public int Id { get; set; }
        [StringLength(30)]
        new public int Measure { get; set; } 
        [StringLength(30)]
        new public string Name { get; set; } = null!;
    }
}
