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
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
