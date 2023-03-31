using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Payment
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int OrderId { get; set; }

    public string Total { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
