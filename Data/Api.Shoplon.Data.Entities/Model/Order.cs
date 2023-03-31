using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int Status { get; set; }

    public DateOnly Date { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual OrderStatus StatusNavigation { get; set; } = null!;
}
