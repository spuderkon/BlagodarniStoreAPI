using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int StatusId { get; set; }

    public decimal TotalPrice { get; set; }

    public int PaymentId { get; set; }

    public bool Paid { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
