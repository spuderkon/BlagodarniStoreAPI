using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class UserAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
