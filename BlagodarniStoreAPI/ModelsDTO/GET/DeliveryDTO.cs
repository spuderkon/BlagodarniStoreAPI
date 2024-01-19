using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.GET
{
    public class DeliveryDTO : Delivery
    {

        public DeliveryDTO(Delivery delivery)
        {
            Id = delivery.Id;
            OrderId = delivery.OrderId;
            CourierId = delivery.CourierId;
            DateArrive = delivery.DateArrive;
        }

        [Key]
        new public int Id { get; set; }
        new public int OrderId { get; set; }
        new public int CourierId { get; set; }
        new public DateTime DateArrive { get; set; }
    }
}
