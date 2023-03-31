using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Unitprice { get; set; }

    public int CategorieId { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<CartLine> CartLines { get; } = new List<CartLine>();

    public virtual Category Categorie { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();
}
