namespace BlagodarniStoreAPI.ModelsDTO.POST
{
    public class CreateDeliveryDTO
    {
        public int OrderId { get; set; }
        public int CourierId { get; set; }
        public DateTime DateArrive { get; set; }
    }
}
