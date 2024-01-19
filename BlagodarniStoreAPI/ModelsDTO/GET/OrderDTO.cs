using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.ModelsDTO.GET
{
    public class OrderDTO : Order
    {
        public OrderDTO(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            OrderDate = order.OrderDate;
            StatusId = order.StatusId;
            TotalPrice = order.TotalPrice;
            PaymentMethodId = order.PaymentMethodId;
            Paid = order.Paid;
            AddressId = order.AddressId;
        }

        new public int Id { get; set; }
        new public int? UserId { get; set; }
        new public DateTime? OrderDate { get; set; }
        new public int? StatusId { get; set; }
        new public decimal? TotalPrice { get; set; }
        new public int PaymentMethodId { get; set; }
        new public bool Paid { get; set; }
        new public int? AddressId { get; set; }
    }
}
