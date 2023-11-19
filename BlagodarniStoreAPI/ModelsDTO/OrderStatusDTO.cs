using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class OrderStatusDTO : OrderStatus
    {
        public OrderStatusDTO(OrderStatus orderStatus) 
        { 
            Id = orderStatus.Id;
            Name = orderStatus.Name;
        }

        [Key]
        new public int Id { get; set; }
        [StringLength(30)]
        new public string Name { get; set; }
    }
}
