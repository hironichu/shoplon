using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Client
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int ContactId { get; set; }

    public DateOnly CreationDate { get; set; }

    public virtual ICollection<CartLine> CartLines { get; } = new List<CartLine>();

    public virtual Contact Contact { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
