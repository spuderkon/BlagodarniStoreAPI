using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public int? OrderId { get; set; }

    public virtual User? Customer { get; set; } = null!;

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; } = null!;
}
