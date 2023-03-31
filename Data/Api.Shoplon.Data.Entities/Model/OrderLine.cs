using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int PriceUnit { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
