using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class CartDTO : Cart
    {
        public CartDTO(Cart cart)
        {
            Id = cart.Id;
            CustomerId = cart.CustomerId;
            ProductId = cart.ProductId;
            Amount = cart.Amount;
            OrderId = cart.OrderId;
        }

        [Key]
        new public int Id { get; set; }
        new public int CustomerId { get; set; }
        new public int ProductId { get; set; }
        new public int Amount { get; set; }
        new public int? OrderId { get; set; }
    }
}
