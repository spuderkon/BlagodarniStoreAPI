namespace BlagodarniStoreAPI.ModelsDTO.POST
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int UnitId { get; set; }

        public decimal Price { get; set; }
    }
}
