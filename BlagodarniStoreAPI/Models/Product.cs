using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int UnitId { get; set; }

    public decimal Price { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
