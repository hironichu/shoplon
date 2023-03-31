using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string StatusText { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
