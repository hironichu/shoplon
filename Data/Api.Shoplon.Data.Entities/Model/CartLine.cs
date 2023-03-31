using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class CartLine
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime Date { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
