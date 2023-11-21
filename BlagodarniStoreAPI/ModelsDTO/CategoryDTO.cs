using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class CategoryDTO : Category
    {
        public CategoryDTO(Category category) 
        {
            Id = category.Id;
            Name = category.Name;
            ParentId = category.ParentId;
        }

        [Key]
        new public int Id { get; set; }
        [StringLength(30)]
        new public string Name { get; set; } = null!;
        new public int? ParentId { get; set; }
    }
}
