using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Context.Contract
{
    public interface IShoplonContext : IDbContext
    {

        DbSet<Client> Clients { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Contact> Contacts { get; set; }

        DbSet<Payment> Payments { get; set; }

        DbSet<OrderLine> OrderLines { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CartLine> CartLines { get; set; }

        DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
