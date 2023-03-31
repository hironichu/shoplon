using System;
using System.Collections.Generic;

namespace Api.Shoplon.Data.Entities.Model;

public partial class Contact
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
