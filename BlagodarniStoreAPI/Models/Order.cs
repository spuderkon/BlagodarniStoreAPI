using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public int StatusId { get; set; }

    public decimal TotalPrice { get; set; }

    public int PaymentMethodId { get; set; }

    public bool Paid { get; set; }

    public int AddressId { get; set; }

    public virtual UserAddress Address { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual OrderStatus Status { get; set; } = null!;
}
