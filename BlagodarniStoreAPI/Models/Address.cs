using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Address
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Address1 { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;
}
