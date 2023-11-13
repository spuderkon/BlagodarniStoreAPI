using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class ProductDTO : Product
    {
        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            Description = product.Description;
            Image = product.Image;
            UnitId = product.UnitId;
            Price = product.Price;
        }
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        [StringLength(30)]
        public string Description { get; set; } = null!;
        [StringLength(300)]
        public string Image { get; set; } = null!;
        public int UnitId { get; set; }
        public decimal Price { get; set; }

    }
}
