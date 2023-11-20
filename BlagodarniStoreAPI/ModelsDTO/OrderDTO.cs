using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class OrderDTO : Order
    {
        public OrderDTO(Order order) 
        { 
            Id = order.Id;
            CustomerId = order.CustomerId;
            OrderDate = order.OrderDate;
            StatusId = order.StatusId;
            TotalPrice = order.TotalPrice;
            PaymentMethodId = order.PaymentMethodId;
            Paid = order.Paid;
        }

        new public int Id { get; set; }
        new public int CustomerId { get; set; }
        new public DateTime? OrderDate { get; set; }
        new public int? StatusId { get; set; }
        new public decimal? TotalPrice { get; set;}
        new public int PaymentMethodId { get; set; }
        new public bool Paid { get; set; }
    }
}
