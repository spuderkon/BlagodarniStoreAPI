using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.GET
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
        new public int Id { get; set; }
        new public string Name { get; set; } = null!;
        new public int CategoryId { get; set; }
        new public string Description { get; set; } = null!;
        new public string Image { get; set; } = null!;
        new public int UnitId { get; set; }
        new public decimal Price { get; set; }

    }
}
