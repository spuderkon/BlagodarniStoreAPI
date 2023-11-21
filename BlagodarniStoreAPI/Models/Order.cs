using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? StatusId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int PaymentMethodId { get; set; }

    public bool Paid { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Delivery? Delivery { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; } = null!;

    public virtual OrderStatus? Status { get; set; }
}
