using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Hidden { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
