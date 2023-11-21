using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class UserAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Address { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
