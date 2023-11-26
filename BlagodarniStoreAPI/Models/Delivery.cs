using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlagodarniStoreAPI.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime DateArrive {  get; set; }
    public virtual Order Order { get; set; } = null!;

    public virtual User? User { get; set; }
}
