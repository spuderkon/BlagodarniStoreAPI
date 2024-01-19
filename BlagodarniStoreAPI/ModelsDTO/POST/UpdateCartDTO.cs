namespace BlagodarniStoreAPI.ModelsDTO.POST
{
    public class UpdateCartDTO
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public int? OrderId { get; set; }
    }
}
