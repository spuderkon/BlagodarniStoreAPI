﻿using System;
using System.Collections.Generic;

namespace BlagodarniStoreAPI.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime DateArrive { get; set; }

    public bool Taken { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Order IdNavigation { get; set; } = null!;
}
