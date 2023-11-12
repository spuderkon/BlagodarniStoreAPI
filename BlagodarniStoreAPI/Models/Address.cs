using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Addresses
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Address { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;
}
